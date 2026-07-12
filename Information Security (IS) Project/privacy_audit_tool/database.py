import sqlite3
import os
import hashlib
import secrets
import base64
import time
import logging
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives import padding
from cryptography.hazmat.backends import default_backend
from cryptography.hazmat.primitives.asymmetric import rsa, padding as asym_padding
from cryptography.hazmat.primitives import hashes, serialization

# Setup logging
logging.basicConfig(
    level=logging.DEBUG,
    format='%(asctime)s - %(levelname)s - %(message)s',
    handlers=[
        logging.FileHandler('db.log'),
        logging.StreamHandler()
    ]
)

class Database:
    def __init__(self, db_path='privacy_audit.db'):
        self.db_path = db_path
        self.init_db()
        # Generate or load RSA key pair for sensitive data
        self._generate_or_load_keys()
        logging.info("Database initialized")

    def _generate_or_load_keys(self):
        """Generate or load RSA keys for asymmetric encryption"""
        key_dir = 'keys'
        private_key_path = os.path.join(key_dir, 'private_key.pem')
        public_key_path = os.path.join(key_dir, 'public_key.pem')
        
        if not os.path.exists(key_dir):
            os.makedirs(key_dir)
            
        if os.path.exists(private_key_path) and os.path.exists(public_key_path):
            with open(private_key_path, 'rb') as key_file:
                self.private_key = serialization.load_pem_private_key(
                    key_file.read(),
                    password=None,
                    backend=default_backend()
                )
            with open(public_key_path, 'rb') as key_file:
                self.public_key = serialization.load_pem_public_key(
                    key_file.read(),
                    backend=default_backend()
                )
        else:
            self.private_key = rsa.generate_private_key(
                public_exponent=65537,
                key_size=2048,
                backend=default_backend()
            )
            self.public_key = self.private_key.public_key()
            
            with open(private_key_path, 'wb') as f:
                f.write(self.private_key.private_bytes(
                    encoding=serialization.Encoding.PEM,
                    format=serialization.PrivateFormat.PKCS8,
                    encryption_algorithm=serialization.NoEncryption()
                ))
            
            with open(public_key_path, 'wb') as f:
                f.write(self.public_key.public_bytes(
                    encoding=serialization.Encoding.PEM,
                    format=serialization.PublicFormat.SubjectPublicKeyInfo
                ))

    def init_db(self):
        """Initialize database with tables"""
        conn = sqlite3.connect(self.db_path)
        cursor = conn.cursor()
        
        # Create users table
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS users (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            username TEXT UNIQUE NOT NULL,
            email TEXT UNIQUE NOT NULL,
            password_hash TEXT NOT NULL,
            salt TEXT NOT NULL,
            audit_count INTEGER DEFAULT 0,
            is_premium INTEGER DEFAULT 0,
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
        )
        ''')
        
        # Create audits table
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS audits (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            url TEXT NOT NULL,
            report_id TEXT NOT NULL,
            scan_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
            FOREIGN KEY (user_id) REFERENCES users (id)
        )
        ''')
        
        # Create payment_info table without expiry_date
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS payment_info (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            name TEXT NOT NULL,
            card_number TEXT NOT NULL,
            cvv TEXT NOT NULL,
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
            FOREIGN KEY (user_id) REFERENCES users (id)
        )
        ''')
        
        # Create sensitive_data_tokens table
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS sensitive_data_tokens (
            user_id INTEGER PRIMARY KEY,
            token TEXT NOT NULL,
            expires_at INTEGER NOT NULL,
            FOREIGN KEY (user_id) REFERENCES users (id)
        )
        ''')
        
        # Create user_encryption_keys table
        cursor.execute('''
        CREATE TABLE IF NOT EXISTS user_encryption_keys (
            user_id INTEGER PRIMARY KEY,
            aes_key TEXT NOT NULL,
            aes_iv TEXT NOT NULL,
            created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
            FOREIGN KEY (user_id) REFERENCES users (id)
        )
        ''')
        
        conn.commit()
        conn.close()
        logging.info("Database tables initialized")

    def _get_connection(self):
        """Get SQLite connection with timeout and isolation level settings"""
        conn = sqlite3.connect(self.db_path, timeout=10)
        conn.row_factory = sqlite3.Row
        return conn

    def _sha256_hash_password(self, password, salt):
        """Hash a password using SHA-256 with a salt"""
        password_hash = hashlib.sha256((password + salt).encode()).hexdigest()
        return password_hash

    def _get_user_encryption_keys(self, user_id):
        """Retrieve and decrypt user-specific AES key and IV"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "SELECT aes_key, aes_iv FROM user_encryption_keys WHERE user_id = ?",
                (user_id,)
            )
            result = cursor.fetchone()
            
            if not result:
                logging.error(f"No encryption keys found for user {user_id}")
                return None, None
            
            try:
                aes_key = self._rsa_decrypt(result['aes_key'])
                aes_iv = self._rsa_decrypt(result['aes_iv'])
                return base64.b64decode(aes_key), base64.b64decode(aes_iv)
            except Exception as e:
                logging.error(f"Error decrypting AES key/IV for user {user_id}: {str(e)}")
                return None, None
        finally:
            conn.close()

    def _store_user_encryption_keys(self, user_id, aes_key, aes_iv):
        """Encrypt and store user-specific AES key and IV"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            encrypted_key = self._rsa_encrypt(base64.b64encode(aes_key).decode('utf-8'))
            encrypted_iv = self._rsa_encrypt(base64.b64encode(aes_iv).decode('utf-8'))
            
            cursor.execute(
                "INSERT OR REPLACE INTO user_encryption_keys (user_id, aes_key, aes_iv) VALUES (?, ?, ?)",
                (user_id, encrypted_key, encrypted_iv)
            )
            conn.commit()
            logging.info(f"Stored encryption keys for user {user_id}")
            return True
        except Exception as e:
            conn.rollback()
            logging.error(f"Error storing encryption keys for user {user_id}: {str(e)}")
            return False
        finally:
            conn.close()

    def _encrypt_credit_card(self, card_number, user_id):
        """Encrypt credit card using AES-CBC mode with user-specific key"""
        aes_key, aes_iv = self._get_user_encryption_keys(user_id)
        if not aes_key or not aes_iv:
            raise ValueError(f"No encryption keys available for user {user_id}")
        
        try:
            padder = padding.PKCS7(128).padder()
            padded_data = padder.update(card_number.encode()) + padder.finalize()
            
            cipher = Cipher(
                algorithms.AES(aes_key),
                modes.CBC(aes_iv),
                backend=default_backend()
            )
            encryptor = cipher.encryptor()
            ciphertext = encryptor.update(padded_data) + encryptor.finalize()
            
            encrypted_data = base64.b64encode(ciphertext).decode('utf-8')
            logging.info(f"Successfully encrypted card number ending in {card_number[-4:]} for user {user_id}")
            return encrypted_data
        except Exception as e:
            logging.error(f"Encryption error for card number for user {user_id}: {str(e)}")
            raise

    def _decrypt_credit_card(self, encrypted_card, user_id):
        """Decrypt credit card using AES-CBC mode with user-specific key"""
        aes_key, aes_iv = self._get_user_encryption_keys(user_id)
        if not aes_key or not aes_iv:
            raise ValueError(f"No encryption keys available for user {user_id}")
        
        try:
            ciphertext = base64.b64decode(encrypted_card)
            
            cipher = Cipher(
                algorithms.AES(aes_key),
                modes.CBC(aes_iv),
                backend=default_backend()
            )
            decryptor = cipher.decryptor()
            padded_data = decryptor.update(ciphertext) + decryptor.finalize()
            
            unpadder = padding.PKCS7(128).unpadder()
            data = unpadder.update(padded_data) + unpadder.finalize()
            
            decrypted_data = data.decode('utf-8')
            logging.info(f"Successfully decrypted card number ending in {decrypted_data[-4:]} for user {user_id}")
            return decrypted_data
        except Exception as e:
            logging.error(f"Decryption error for encrypted card for user {user_id}: {str(e)}")
            raise

    def _rsa_encrypt(self, data):
        """Encrypt data using RSA"""
        if isinstance(data, str):
            data = data.encode()
            
        ciphertext = self.public_key.encrypt(
            data,
            asym_padding.OAEP(
                mgf=asym_padding.MGF1(algorithm=hashes.SHA256()),
                algorithm=hashes.SHA256(),
                label=None
            )
        )
        return base64.b64encode(ciphertext).decode('utf-8')

    def _rsa_decrypt(self, encrypted_data):
        """Decrypt data using RSA"""
        ciphertext = base64.b64decode(encrypted_data)
        plaintext = self.private_key.decrypt(
            ciphertext,
            asym_padding.OAEP(
                mgf=asym_padding.MGF1(algorithm=hashes.SHA256()),
                algorithm=hashes.SHA256(),
                label=None
            )
        )
        return plaintext.decode('utf-8')

    def _validate_card_number(self, card_number):
        """Validate card number using Luhn algorithm"""
        if not card_number.isdigit() or len(card_number) != 16:
            return False
        sum = 0
        even = False
        for digit in reversed(card_number):
            n = int(digit)
            if even:
                n *= 2
                if n > 9:
                    n -= 9
            sum += n
            even = not even
        return sum % 10 == 0

    def _validate_cvv(self, cvv):
        """Validate CVV (3 or 4 digits)"""
        return cvv.isdigit() and 3 <= len(cvv) <= 4

    def register_user(self, username, email, password):
        """Register a new user with secure password hashing"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute("SELECT id FROM users WHERE username = ? OR email = ?", (username, email))
            if cursor.fetchone():
                conn.close()
                return False, "Username or email already exists"
            
            salt = secrets.token_hex(16)
            password_hash = self._sha256_hash_password(password, salt)
            
            cursor.execute(
                "INSERT INTO users (username, email, password_hash, salt) VALUES (?, ?, ?, ?)",
                (username, email, password_hash, salt)
            )
            
            conn.commit()
            return True, "User registered successfully"
        except Exception as e:
            conn.rollback()
            return False, str(e)
        finally:
            conn.close()

    def verify_user(self, username, password):
        """Verify user credentials"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute("SELECT id, password_hash, salt FROM users WHERE username = ?", (username,))
            user = cursor.fetchone()
            
            if not user:
                return None, "User not found"
            
            password_hash = self._sha256_hash_password(password, user['salt'])
            
            if password_hash == user['password_hash']:
                return user['id'], "Login successful"
            else:
                return None, "Invalid password"
        finally:
            conn.close()

    def get_user_by_id(self, user_id):
        """Get user information by ID"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute("SELECT id, username, email, audit_count, is_premium FROM users WHERE id = ?", (user_id,))
            user = cursor.fetchone()
            
            if user:
                return dict(user)
            return None
        finally:
            conn.close()

    def add_audit(self, user_id, url, report_id):
        """Add a new audit record and increment user's audit count"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "INSERT INTO audits (user_id, url, report_id) VALUES (?, ?, ?)",
                (user_id, url, report_id)
            )
            
            cursor.execute(
                "UPDATE users SET audit_count = audit_count + 1 WHERE id = ?",
                (user_id,)
            )
            
            conn.commit()
            return True, "Audit added successfully"
        except Exception as e:
            conn.rollback()
            return False, str(e)
        finally:
            conn.close()

    def get_user_audit_count(self, user_id):
        """Get the number of audits performed by a user"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute("SELECT audit_count FROM users WHERE id = ?", (user_id,))
            result = cursor.fetchone()
            
            if result:
                return result['audit_count']
            return 0
        finally:
            conn.close()

    def get_user_audits(self, user_id):
        """Get all audits performed by a user"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "SELECT id, url, report_id, scan_date FROM audits WHERE user_id = ? ORDER BY scan_date DESC",
                (user_id,)
            )
            audits = cursor.fetchall()
            
            return [dict(audit) for audit in audits]
        finally:
            conn.close()

    def store_payment_info(self, user_id, name, card_number, cvv):
        """Store payment information with encryption"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            # Validate payment details
            if not name.strip() or len(name) < 2:
                return False, "Invalid name"
            if not self._validate_card_number(card_number):
                return False, "Invalid card number"
            if not self._validate_cvv(cvv):
                return False, "Invalid CVV"
            
            # Generate user-specific AES key and IV
            aes_key = secrets.token_bytes(32)
            aes_iv = secrets.token_bytes(16)
            
            # Store the encryption keys
            if not self._store_user_encryption_keys(user_id, aes_key, aes_iv):
                return False, "Failed to store encryption keys"
            
            # Encrypt sensitive payment information
            encrypted_card = self._encrypt_credit_card(card_number, user_id)
            encrypted_cvv = self._rsa_encrypt(cvv)
            
            # Store payment information
            cursor.execute(
                "INSERT INTO payment_info (user_id, name, card_number, cvv) VALUES (?, ?, ?, ?)",
                (user_id, name, encrypted_card, encrypted_cvv)
            )
            
            # Update user to premium status
            cursor.execute(
                "UPDATE users SET is_premium = 1 WHERE id = ?",
                (user_id,)
            )
            
            conn.commit()
            return True, "Payment information stored successfully"
        except Exception as e:
            conn.rollback()
            logging.error(f"Error storing payment info for user {user_id}: {str(e)}")
            return False, str(e)
        finally:
            conn.close()

    def is_premium_user(self, user_id):
        """Check if a user has premium status"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute("SELECT is_premium FROM users WHERE id = ?", (user_id,))
            result = cursor.fetchone()
            
            if result:
                return bool(result['is_premium'])
            return False
        finally:
            conn.close()

    def get_user_payment_info(self, user_id):
        """Get user payment information with secure decryption"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "SELECT id, name, card_number, cvv, created_at FROM payment_info WHERE user_id = ? ORDER BY created_at DESC",
                (user_id,)
            )
            payment_info = cursor.fetchone()
            
            if payment_info:
                payment_dict = dict(payment_info)
                
                try:
                    card_number = self._decrypt_credit_card(payment_dict['card_number'], user_id)
                    masked_card = "**** **** **** " + card_number[-4:]
                    payment_dict['card_number'] = masked_card
                    
                    cvv = self._rsa_decrypt(payment_dict['cvv'])
                    payment_dict['cvv'] = "***"
                    
                    payment_dict['transaction_date'] = payment_dict['created_at'].split('.')[0]
                    
                    return payment_dict
                except Exception as e:
                    logging.error(f"Error decrypting payment info for user {user_id}: {str(e)}")
                    payment_dict['card_number'] = "**** **** **** ****"
                    payment_dict['cvv'] = "***"
                    return payment_dict
            
            return None
        finally:
            conn.close()
            
    def verify_user_for_sensitive_data_access(self, user_id, password):
        """Verify user password for access to sensitive data"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        logging.info(f"Authenticating user {user_id} for sensitive data access")
        
        try:
            cursor.execute("SELECT password_hash, salt FROM users WHERE id = ?", (user_id,))
            user = cursor.fetchone()
            
            if not user:
                logging.error(f"User {user_id} not found")
                return False, "User not found"
            
            password_hash = self._sha256_hash_password(password, user['salt'])
            stored_hash = user['password_hash']
            logging.debug(f"Password verification: {password_hash == stored_hash}")
            
            if password_hash == stored_hash:
                timestamp = str(int(time.time()))
                token = hashlib.sha256((str(user_id) + timestamp).encode()).hexdigest()
                logging.info(f"Generated token: {token[:10]}...")
                
                try:
                    cursor.execute("DELETE FROM sensitive_data_tokens WHERE user_id = ?", (user_id,))
                    expires_at = int(time.time()) + 300
                    cursor.execute(
                        "INSERT INTO sensitive_data_tokens (user_id, token, expires_at) VALUES (?, ?, ?)",
                        (user_id, token, expires_at)
                    )
                    conn.commit()
                    logging.info(f"Token inserted for user {user_id}")
                    
                    cursor.execute("SELECT token FROM sensitive_data_tokens WHERE user_id = ?", (user_id,))
                    stored_token = cursor.fetchone()
                    
                    if stored_token and stored_token['token'] == token:
                        logging.info("Token verification successful")
                        return True, token
                    else:
                        logging.error(f"Token verification failed. Stored token: {stored_token}")
                        return False, "Failed to store authentication token"
                except Exception as e:
                    conn.rollback()
                    logging.error(f"Token storage error: {str(e)}")
                    return False, f"Token storage error: {str(e)}"
            else:
                logging.error("Password verification failed")
                return False, "Invalid password"
        except Exception as e:
            conn.rollback()
            logging.error(f"Authentication error: {str(e)}")
            return False, str(e)
        finally:
            conn.close()
            
    def verify_sensitive_data_token(self, user_id, token):
        """Verify the token for accessing sensitive data"""
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "SELECT expires_at FROM sensitive_data_tokens WHERE user_id = ? AND token = ? AND expires_at > ?",
                (user_id, token, int(time.time()))
            )
            result = cursor.fetchone()
            
            if result:
                return True
            return False
        finally:
            conn.close()
            
    def get_unmasked_payment_info(self, user_id, token):
        """Get unmasked payment information with token verification"""
        if not self.verify_sensitive_data_token(user_id, token):
            logging.error(f"Token verification failed for user {user_id}, token {token[:10]}...")
            return {"error": "Invalid or expired token"}
        
        conn = self._get_connection()
        cursor = conn.cursor()
        
        try:
            cursor.execute(
                "SELECT id, name, card_number, cvv, created_at FROM payment_info WHERE user_id = ? ORDER BY created_at DESC",
                (user_id,)
            )
            payment_info = cursor.fetchone()
            
            if not payment_info:
                logging.error(f"No payment information found for user {user_id}")
                return {"error": "No payment information found for this user"}
            
            logging.info(f"Payment info found for user {user_id}: {dict(payment_info)}")
            payment_dict = dict(payment_info)
            
            try:
                card_number = self._decrypt_credit_card(payment_dict['card_number'], user_id)
                formatted_card = ' '.join([card_number[i:i+4] for i in range(0, len(card_number), 4)])
                payment_dict['card_number'] = formatted_card
                
                cvv = self._rsa_decrypt(payment_dict['cvv'])
                payment_dict['cvv'] = cvv
                
                payment_dict['transaction_date'] = payment_dict['created_at'].split('.')[0]
                
                data_string = f"{payment_dict['name']}|{formatted_card}|{cvv}"
                payment_dict['digital_signature'] = hashlib.sha256(data_string.encode()).hexdigest()[:16]
                
                logging.info(f"Returning unmasked payment info for user {user_id}")
                return payment_dict
            except Exception as e:
                logging.error(f"Decryption error for user {user_id}: {str(e)}")
                return {"error": f"Decryption failed: {str(e)}"}
        except Exception as e:
            logging.error(f"Database error in get_unmasked_payment_info for user {user_id}: {str(e)}")
            return {"error": f"Database error: {str(e)}"}
        finally:
            conn.close()
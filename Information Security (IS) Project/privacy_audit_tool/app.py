from flask import Flask, render_template, request, redirect, url_for, send_file, jsonify, session, flash
from flask_login import LoginManager, login_user, logout_user, login_required, current_user
import os
import time
import threading
import datetime
import logging
import secrets
from modules.website_scanner import WebsiteScanner
from modules.report_generator import generate_pdf_report
from database import Database
from user_manager import User

# Setup logging
logging.basicConfig(
    level=logging.DEBUG,
    format='%(asctime)s - %(levelname)s - %(message)s',
    handlers=[
        logging.FileHandler('app.log'),
        logging.StreamHandler()
    ]
)

app = Flask(__name__)
app.config['UPLOAD_FOLDER'] = 'static/reports'
app.config['SECRET_KEY'] = os.environ.get('SECRET_KEY', secrets.token_hex(16))
app.config['SESSION_TYPE'] = 'filesystem'
os.makedirs(app.config['UPLOAD_FOLDER'], exist_ok=True)

active_scanners = {}
# Lock for thread-safe access to active_scanners
scanner_lock = threading.Lock()

# Initialize Flask-Login
login_manager = LoginManager()
login_manager.init_app(app)
login_manager.login_view = 'login'

@login_manager.user_loader
def load_user(user_id):
    return User.get(user_id)

# Create database instance
db = Database()

def validate_results(results):
    """Ensure all required keys exist in the results dictionary"""
    if 'error' in results:
        return results

    required_keys = [
        'url', 'overall_score', 'rating', 'overall_score_class',
        'privacy_policy', 'gdpr', 'ccpa', 'data_collection',
        'form_security', 'sql_injection', 'ssl_security'
    ]

    for key in required_keys:
        if key not in results:
            results[key] = {}

    if 'ssl_security' in results:
        ssl = results['ssl_security']
        if 'insecure_content' not in ssl:
            ssl['insecure_content'] = {
                'mixed_content_found': False,
                'insecure_scripts': [],
                'insecure_stylesheets': [],
                'insecure_images': [],
                'insecure_iframes': [],
                'insecure_forms': [],
                'other_insecure_content': []
            }

    return results

@app.route('/')
def index():
    return render_template('index.html')

@app.route('/register', methods=['GET', 'POST'])
def register():
    if request.method == 'POST':
        username = request.form['username']
        email = request.form['email']
        password = request.form['password']
        confirm_password = request.form['confirm_password']

        if len(password) < 8:
            return render_template('register.html', error="Password must be at least 8 characters long")
        
        if password != confirm_password:
            return render_template('register.html', error="Passwords do not match")
        
        success, message = db.register_user(username, email, password)
        
        if success:
            user_id, _ = db.verify_user(username, password)
            user = User.get(user_id)
            login_user(user)
            return redirect(url_for('profile'))
        else:
            return render_template('register.html', error=message)

    return render_template('register.html')

@app.route('/login', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        username = request.form['username']
        password = request.form['password']

        user_id, message = db.verify_user(username, password)
        
        if user_id:
            user = User.get(user_id)
            login_user(user)
            return redirect(url_for('profile'))
        else:
            return render_template('login.html', error=message)

    return render_template('login.html')

@app.route('/logout')
@login_required
def logout():
    logout_user()
    return redirect(url_for('index'))

@app.route('/profile')
@login_required
def profile():
    audits = db.get_user_audits(current_user.id)
    payment_info = None
    if current_user.is_premium:
        payment_info = db.get_user_payment_info(current_user.id)
        
    return render_template('profile.html', audits=audits, payment_info=payment_info)

@app.route('/upgrade', methods=['GET', 'POST'])
@login_required
def upgrade():
    if request.method == 'POST':
        name = request.form['name']
        card_number = request.form['card_number'].replace(' ', '')
        cvv = request.form['cvv']

        # Basic server-side validation
        if not name.strip() or len(name) < 2:
            return render_template('upgrade.html', error="Invalid name")
        if not card_number.isdigit() or len(card_number) != 16:
            return render_template('upgrade.html', error="Invalid card number")
        if not cvv.isdigit() or not (3 <= len(cvv) <= 4):
            return render_template('upgrade.html', error="Invalid CVV")
        
        success, message = db.store_payment_info(
            current_user.id, 
            name, 
            card_number, 
            cvv
        )
        
        if success:
            return render_template('upgrade.html', success="Your payment was successful! You now have unlimited website audits.")
        else:
            return render_template('upgrade.html', error=f"Payment error: {message}")

    return render_template('upgrade.html')

@app.route('/scan', methods=['POST'])
@login_required
def scan():
    url = request.form['url']

    if not current_user.can_perform_audit():
        return redirect(url_for('upgrade'))

    if not url.startswith(('http://', 'https://')):
        url = 'https://' + url

    report_id = str(int(time.time()))

    try:
        logging.info(f"Starting scan for {url}")
        scanner = WebsiteScanner(url)
        # Store the scanner instance in active_scanners
        scanner_key = f"{current_user.id}:{report_id}"
        with scanner_lock:
            active_scanners[scanner_key] = scanner
        
        max_scan_time = 300
        results = None
        scan_error = None
        
        def run_scan():
            nonlocal results, scan_error
            try:
                results = scanner.scan_website()
            except Exception as e:
                scan_error = str(e)
                logging.error(f"Scan error: {e}")
            finally:
                # Remove scanner instance after scan completes
                with scanner_lock:
                    active_scanners.pop(scanner_key, None)
        
        scan_thread = threading.Thread(target=run_scan)
        scan_thread.daemon = True
        scan_thread.start()
        scan_thread.join(timeout=max_scan_time)
        
        if scan_thread.is_alive():
            scanner.close_browser()
            with scanner_lock:
                active_scanners.pop(scanner_key, None)
            logging.warning("Scan timed out")
            return render_template('error.html', 
                error="The scan timed out. Try a simpler website or check your network connection.")
        
        if not results or scan_error:
            logging.error(f"Scan failed: {scan_error or 'Unknown error'}")
            return render_template('error.html',
                error=f"Error scanning website: {scan_error or 'Unknown error'}")
        
        results = validate_results(results)
        
        report_path = os.path.join(app.config['UPLOAD_FOLDER'], f"report_{report_id}")
        pdf_available = False
        try:
            pdf_success = generate_pdf_report(results, report_path + ".pdf")
            pdf_available = pdf_success
            if not pdf_success:
                logging.error("PDF generation failed")
        except Exception as e:
            logging.error(f"Error generating PDF report: {str(e)}")
            pdf_available = False
        
        db.add_audit(current_user.id, url, report_id)
        
        logging.info(f"Scan completed for {url}")
        return render_template('results.html', 
                            results=results, 
                            url=url,
                            report_id=report_id,
                            pdf_available=pdf_available,
                            scan_date=datetime.datetime.now().strftime("%B %d, %Y"))

    except Exception as e:
        error_message = str(e)
        logging.error(f"Error scanning website: {error_message}")
        # Clean up scanner instance on error
        with scanner_lock:
            active_scanners.pop(scanner_key, None)
        return render_template('error.html', error=error_message)
@app.route('/download/<report_id>')
@login_required
def download_report(report_id):
    pdf_path = os.path.join(app.config['UPLOAD_FOLDER'], f"report_{report_id}.pdf")

    user = db.get_user_by_id(current_user.id)

    if os.path.exists(pdf_path) and user['is_premium']:
        return send_file(pdf_path, as_attachment=True)
    else:
        return render_template('error.html', error="PDF reports are only available for premium users")

@app.route('/scan_status')
def get_scan_status():
    """Get the current scan status for the user's active scan"""
    # Find the latest scanner instance for the current user
    scanner_key = None
    with scanner_lock:
        for key in active_scanners:
            if key.startswith(f"{current_user.id}:"):
                scanner_key = key
                break
    
    if scanner_key:
        scanner = active_scanners.get(scanner_key)
        if scanner:
            return jsonify(scanner.get_scan_status())
    
    # Return default status if no active scan is found
    return jsonify({
        "current_component": "No active scan",
        "progress": 0
    })
@app.route('/view_payment_details', methods=['POST'])
@login_required
def view_payment_details():
    password = request.form.get('password', '')
    success, token_or_message = db.verify_user_for_sensitive_data_access(current_user.id, password)

    if success:
        return jsonify({"success": True, "token": token_or_message})
    else:
        return jsonify({"success": False, "message": token_or_message})

@app.route('/get_unmasked_payment_info/<token>')
@login_required
def get_unmasked_payment_info(token):
    try:
        payment_info = db.get_unmasked_payment_info(current_user.id, token)

        if payment_info:
            return jsonify({
                "success": True, 
                "data": payment_info,
                "expires": int(time.time()) + 300
            })
        else:
            conn = db._get_connection()
            cursor = conn.cursor()
            
            try:
                cursor.execute(
                    "SELECT user_id, token, expires_at FROM sensitive_data_tokens WHERE user_id = ?",
                    (current_user.id,)
                )
                token_record = cursor.fetchone()
                
                if not token_record:
                    return jsonify({"success": False, "message": "No token found for this user"})
                
                if token_record['token'] != token:
                    return jsonify({
                        "success": False, 
                        "message": "Token mismatch",
                        "details": "Tokens don't match. Please try authenticating again." 
                    })
                
                if token_record['expires_at'] <= int(time.time()):
                    return jsonify({
                        "success": False, 
                        "message": "Token has expired",
                        "details": "Your authentication session has expired. Please try again."
                    })
                
                return jsonify({
                    "success": False, 
                    "message": "Failed to retrieve payment details",
                    "details": "Token is valid but payment info couldn't be retrieved."
                })
            finally:
                conn.close()
    except Exception as e:
        app.logger.error(f"Error in get_unmasked_payment_info: {str(e)}")
        return jsonify({
            "success": False, 
            "message": "An error occurred", 
            "details": str(e)
        })

@app.route('/verify_token', methods=['POST'])
@login_required
def verify_token():
    token = request.form.get('token', '')
    if not token:
        return jsonify({"success": False, "message": "No token provided"})
    
    try:
        is_valid = db.verify_sensitive_data_token(current_user.id, token)
        if is_valid:
            conn = db._get_connection()
            cursor = conn.cursor()
            try:
                cursor.execute(
                    "SELECT expires_at FROM sensitive_data_tokens WHERE user_id = ? AND token = ?",
                    (current_user.id, token)
                )
                token_record = cursor.fetchone()
                if token_record:
                    return jsonify({
                        "success": True,
                        "expires": token_record['expires_at']
                    })
                else:
                    return jsonify({"success": False, "message": "Token not found"})
            finally:
                conn.close()
        else:
            return jsonify({"success": False, "message": "Token is invalid or expired"})
    except Exception as e:
        app.logger.error(f"Error in verify_token: {str(e)}")
        return jsonify({"success": False, "message": "An error occurred", "details": str(e)})

if __name__ == '__main__':
    app.run(debug=True)
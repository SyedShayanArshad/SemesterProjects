import 'package:encrypt/encrypt.dart' as encrypt;

class EncryptionService {
  // A 32-byte key for AES encryption (must be 32 characters for AES-256)
  static final _key = encrypt.Key.fromUtf8('my32lengthsupersecretnooneknows1'); 
  static final _iv = encrypt.IV.fromLength(16);
  static final _encrypter = encrypt.Encrypter(encrypt.AES(_key));

  /// Encrypts plain text
  static String encryptText(String plainText) {
    if (plainText.isEmpty) return plainText;
    try {
      final encrypted = _encrypter.encrypt(plainText, iv: _iv);
      return encrypted.base64;
    } catch (e) {
      return plainText; // Fallback
    }
  }

  /// Decrypts base64 encrypted text
  static String decryptText(String encryptedText) {
    if (encryptedText.isEmpty) return encryptedText;
    try {
      final encrypted = encrypt.Encrypted.fromBase64(encryptedText);
      final decrypted = _encrypter.decrypt(encrypted, iv: _iv);
      return decrypted;
    } catch (e) {
      return encryptedText; // Fallback in case of failure or plain text
    }
  }
}

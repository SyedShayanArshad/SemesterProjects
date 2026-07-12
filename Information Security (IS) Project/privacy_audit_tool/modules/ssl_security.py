import ssl
import socket
import requests
import logging
from datetime import datetime
from urllib.parse import urlparse
from bs4 import BeautifulSoup
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class SSLSecurityChecker:
    def __init__(self, url, soup, browser=None):
        self.url = url
        # Force HTTPS to ensure accurate SSL checks
        if not url.startswith('https://'):
            self.url = url.replace('http://', 'https://')
        self.soup = soup
        self.browser = browser
        self.parsed_url = urlparse(self.url)
        self.hostname = self.parsed_url.hostname
        
    def check_ssl_security(self):
        """Analyze SSL/TLS and network security"""
        logging.debug(f"Starting SSL security check for {self.url}")
        results = {
            'https_enabled': False,
            'certificate': {
                'valid': False,
                'issuer': 'Unknown',
                'expiry': 'Unknown',
                'days_to_expiry': 0,
                'signature_algorithm': 'Unknown',
                'subject': 'Unknown',
                'version': 'Unknown'
            },
            'security_headers': {
                'hsts': False,
                'content_security_policy': False,
                'x_content_type_options': False,
                'x_frame_options': False,
                'x_xss_protection': False,
                'referrer_policy': False
            },
            'secure_cookies': {
                'total_cookies': 0,
                'secure_cookies': 0,
                'httponly_cookies': 0,
                'samesite_cookies': 0,
                'insecure_cookies': []
            },
            'insecure_content': {
                'mixed_content_found': False,
                'insecure_scripts': [],
                'insecure_stylesheets': [],
                'insecure_images': [],
                'insecure_iframes': [],
                'insecure_forms': [],
                'other_insecure_content': []
            },
            'score': 0,
            'score_class': 'danger',
            'recommendations': []
        }
        
        # Check HTTPS
        results['https_enabled'] = self.url.startswith('https://')
        logging.debug(f"HTTPS enabled: {results['https_enabled']}")
        
        # Check SSL certificate
        cert_info = self._get_certificate_info()
        results['certificate'] = cert_info
        logging.debug(f"Certificate valid: {cert_info['valid']}")
        
        # Check security headers
        headers_info = self._check_security_headers()
        results['security_headers'] = headers_info
        logging.debug(f"Security headers: {headers_info}")
        
        # Check cookies
        if self.browser:
            cookie_info = self._check_cookies()
            results['secure_cookies'] = cookie_info
            logging.debug(f"Secure cookies: {cookie_info}")
        
        # Check for mixed content
        if self.soup:
            mixed_content = self._check_mixed_content()
            results['insecure_content'] = mixed_content
            logging.debug(f"Mixed content found: {mixed_content['mixed_content_found']}")
        
        # Generate recommendations and calculate score
        self._generate_recommendations(results)
        self._calculate_score(results)
        
        logging.debug(f"SSL security score: {results['score']}")
        return results
    
    def _get_certificate_info(self):
        """Retrieve and analyze SSL certificate"""
        logging.debug(f"Retrieving SSL certificate for {self.hostname}")
        cert_info = {
            'valid': False,
            'issuer': 'Unknown',
            'expiry': 'Unknown',
            'days_to_expiry': 0,
            'signature_algorithm': 'Unknown',
            'subject': 'Unknown',
            'version': 'Unknown'
        }
        
        max_retries = 3
        for attempt in range(max_retries):
            try:
                context = ssl.create_default_context()
                with socket.create_connection((self.hostname, 443), timeout=15) as sock:
                    with context.wrap_socket(sock, server_hostname=self.hostname) as ssock:
                        cert = ssock.getpeercert()
                        
                        cert_info['valid'] = True
                        cert_info['issuer'] = cert.get('issuer', [['', 'Unknown']])[-1][-1]
                        expiry_date = datetime.strptime(cert['notAfter'], '%b %d %H:%M:%S %Y %Z')
                        cert_info['expiry'] = expiry_date.strftime('%Y-%m-%d')
                        cert_info['days_to_expiry'] = (expiry_date - datetime.now()).days
                        cert_info['signature_algorithm'] = cert.get('signatureAlgorithm', 'Unknown')
                        cert_info['subject'] = cert.get('subject', [['', 'Unknown']])[-1][-1]
                        cert_info['version'] = str(cert.get('version', 'Unknown'))
                        logging.info("Successfully retrieved SSL certificate")
                        return cert_info
            except (socket.gaierror, socket.timeout, ssl.SSLError, ConnectionError) as e:
                logging.warning(f"Failed to retrieve certificate (attempt {attempt + 1}): {e}")
                time.sleep(2)
            except Exception as e:
                logging.error(f"Unexpected error retrieving certificate: {e}")
                break
        
        logging.error("Failed to retrieve SSL certificate after retries")
        return cert_info
    
    def _check_security_headers(self):
        """Check for security-related HTTP headers"""
        logging.debug("Checking security headers")
        headers_info = {
            'hsts': False,
            'content_security_policy': False,
            'x_content_type_options': False,
            'x_frame_options': False,
            'x_xss_protection': False,
            'referrer_policy': False
        }
        
        try:
            response = requests.get(self.url, timeout=15)
            headers = {k.lower(): v for k, v in response.headers.items()}
            
            headers_info['hsts'] = 'strict-transport-security' in headers
            headers_info['content_security_policy'] = 'content-security-policy' in headers
            headers_info['x_content_type_options'] = headers.get('x-content-type-options', '').lower() == 'nosniff'
            headers_info['x_frame_options'] = headers.get('x-frame-options', '').lower() in ['deny', 'sameorigin']
            headers_info['x_xss_protection'] = headers.get('x-xss-protection', '').lower().startswith('1')
            headers_info['referrer_policy'] = 'referrer-policy' in headers
            
            logging.info("Security headers checked")
        except Exception as e:
            logging.error(f"Error checking security headers: {e}")
        
        return headers_info
    
    def _check_cookies(self):
        """Check cookie security attributes"""
        logging.debug("Checking cookie security")
        cookie_info = {
            'total_cookies': 0,
            'secure_cookies': 0,
            'httponly_cookies': 0,
            'samesite_cookies': 0,
            'insecure_cookies': []
        }
        
        try:
            WebDriverWait(self.browser, 10).until(
                EC.presence_of_element_located((By.TAG_NAME, 'body'))
            )
            cookies = self.browser.get_cookies()
            cookie_info['total_cookies'] = len(cookies)
            
            for cookie in cookies:
                cookie_name = cookie.get('name', 'unknown')
                is_secure = cookie.get('secure', False)
                is_httponly = cookie.get('httpOnly', False)
                samesite = cookie.get('sameSite', 'None').lower()
                
                if is_secure:
                    cookie_info['secure_cookies'] += 1
                if is_httponly:
                    cookie_info['httponly_cookies'] += 1
                if samesite in ['strict', 'lax']:
                    cookie_info['samesite_cookies'] += 1
                    
                if not is_secure or not is_httponly:
                    cookie_info['insecure_cookies'].append({
                        'name': cookie_name,
                        'secure': is_secure,
                        'httponly': is_httponly,
                        'samesite': samesite
                    })
            
            logging.info(f"Found {cookie_info['total_cookies']} cookies")
        except Exception as e:
            logging.error(f"Error checking cookies: {e}")
        
        return cookie_info
    
    def _check_mixed_content(self):
        """Check for mixed content (HTTP resources on HTTPS page)"""
        logging.debug("Checking for mixed content")
        mixed_content = {
            'mixed_content_found': False,
            'insecure_scripts': [],
            'insecure_stylesheets': [],
            'insecure_images': [],
            'insecure_iframes': [],
            'insecure_forms': [],
            'other_insecure_content': []
        }
        
        if not self.soup or not self.url.startswith('https://'):
            logging.warning("Skipping mixed content check (no HTTPS or no soup)")
            return mixed_content
        
        if self.browser:
            try:
                WebDriverWait(self.browser, 10).until(
                    EC.presence_of_element_located((By.TAG_NAME, 'body'))
                )
                page_source = self.browser.page_source
                self.soup = BeautifulSoup(page_source, 'html.parser')
                logging.info("Updated soup with dynamic content for mixed content check")
            except:
                logging.warning("Failed to update soup with dynamic content")
        
        for script in self.soup.find_all('script', src=True):
            src = script.get('src')
            if src.startswith('http://'):
                mixed_content['insecure_scripts'].append(src)
                mixed_content['mixed_content_found'] = True
        
        for link in self.soup.find_all('link', href=True):
            if 'stylesheet' in link.get('rel', []) and link.get('href', '').startswith('http://'):
                mixed_content['insecure_stylesheets'].append(link.get('href'))
                mixed_content['mixed_content_found'] = True
        
        for img in self.soup.find_all('img', src=True):
            if img.get('src', '').startswith('http://'):
                mixed_content['insecure_images'].append(img.get('src'))
                mixed_content['mixed_content_found'] = True
        
        for iframe in self.soup.find_all('iframe', src=True):
            if iframe.get('src', '').startswith('http://'):
                mixed_content['insecure_iframes'].append(iframe.get('src'))
                mixed_content['mixed_content_found'] = True
        
        for form in self.soup.find_all('form', action=True):
            action = form.get('action')
            if action and action.startswith('http://'):
                mixed_content['insecure_forms'].append(action)
                mixed_content['mixed_content_found'] = True
        
        logging.debug(f"Mixed content found: {mixed_content['mixed_content_found']}")
        return mixed_content
    
    def _generate_recommendations(self, results):
        """Generate recommendations based on SSL findings"""
        recommendations = []
        
        if not results['https_enabled']:
            recommendations.append("Implement HTTPS for secure communication")
        
        if not results['certificate']['valid']:
            recommendations.append("Obtain a valid SSL/TLS certificate from a trusted CA")
        elif results['certificate']['days_to_expiry'] < 30:
            recommendations.append("Renew your SSL certificate before it expires")
        
        if not results['security_headers']['hsts']:
            recommendations.append("Implement Strict-Transport-Security (HSTS) header")
        if not results['security_headers']['content_security_policy']:
            recommendations.append("Add Content-Security-Policy (CSP) header")
        if not results['security_headers']['x_content_type_options']:
            recommendations.append("Set X-Content-Type-Options to 'nosniff'")
        if not results['security_headers']['x_frame_options']:
            recommendations.append("Set X-Frame-Options to 'DENY' or 'SAMEORIGIN'")
        if not results['security_headers']['x_xss_protection']:
            recommendations.append("Enable X-XSS-Protection header")
        if not results['security_headers']['referrer_policy']:
            recommendations.append("Implement Referrer-Policy header")
        
        if results['secure_cookies']['total_cookies'] > 0:
            if results['secure_cookies']['secure_cookies'] < results['secure_cookies']['total_cookies']:
                recommendations.append("Ensure all cookies are marked as Secure")
            if results['secure_cookies']['httponly_cookies'] < results['secure_cookies']['total_cookies']:
                recommendations.append("Set HttpOnly attribute for all cookies")
            if results['secure_cookies']['samesite_cookies'] < results['secure_cookies']['total_cookies']:
                recommendations.append("Use SameSite=Strict or SameSite=Lax for cookies")
        
        if results['insecure_content']['mixed_content_found']:
            recommendations.append("Eliminate mixed content by using HTTPS for all resources")
        
        if not recommendations:
            recommendations.append("Maintain current SSL/TLS configuration and monitor regularly")
        
        results['recommendations'] = recommendations
    
    def _calculate_score(self, results):
        """Calculate SSL security score"""
        score = 0
        
        if results['https_enabled']:
            score += 30
        
        if results['certificate']['valid']:
            score += 30
            if results['certificate']['days_to_expiry'] >= 30:
                score += 10
        
        security_headers = results['security_headers']
        header_count = sum(1 for header in security_headers.values() if header)
        score += (header_count / len(security_headers)) * 20
        
        cookies = results['secure_cookies']
        if cookies['total_cookies'] > 0:
            secure_percent = (cookies['secure_cookies'] / cookies['total_cookies']) * 5
            httponly_percent = (cookies['httponly_cookies'] / cookies['total_cookies']) * 3
            samesite_percent = (cookies['samesite_cookies'] / cookies['total_cookies']) * 2
            score += secure_percent + httponly_percent + samesite_percent
        else:
            score += 10
        
        if not results['insecure_content']['mixed_content_found']:
            score += 10
        
        results['score'] = int(min(score, 100))
        results['score_class'] = 'good' if score >= 80 else 'warning' if score >= 50 else 'danger'
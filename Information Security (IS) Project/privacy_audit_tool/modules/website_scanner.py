import requests
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.chrome.options import Options
from selenium.webdriver.chrome.service import Service
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
import time
import logging
from urllib.parse import urljoin
from requests.exceptions import RequestException, Timeout, HTTPError
from selenium.common.exceptions import TimeoutException, WebDriverException
import threading

from .privacy_policy import PrivacyPolicyChecker
from .cookie_scanner import CookieScanner
from .data_collection import DataCollectionChecker
from .compliance import GDPRChecker, CCPAChecker
from .form_security import FormSecurityChecker
from .sql_injection import SQLInjectionDetector
from .ssl_security import SSLSecurityChecker

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

# Global scan status tracking
# scan_status = {
#     "current_component": "Initializing...",
#     "progress": 0
# }

# def get_scan_status():
#     """Return the current scan status"""
#     return scan_status.copy()

# def update_scan_status(component, progress):
#     """Update the current scan status"""
#     scan_status["current_component"] = component
#     scan_status["progress"] = progress
#     logging.debug(f"Scan status updated: {component} - {progress}%")

class WebsiteScanner:
    def __init__(self, url):
        self.url = url
        self.soup = None
        self.browser = None
        self.privacy_checker = None
        self.cookie_scanner = None
        self.data_checker = None
        self.gdpr_checker = None
        self.ccpa_checker = None
        self.form_security_checker = None
        self.sql_injection_detector = None
        self.ssl_security_checker = None
        self.scan_status = {
            "current_component": "Initializing...",
            "progress": 0
        }
    def get_scan_status(self):
        """Return the current scan status"""
        return self.scan_status.copy()

    def update_scan_status(self, component, progress):
        """Update the current scan status"""
        self.scan_status["current_component"] = component
        self.scan_status["progress"] = progress
        logging.debug(f"Scan status updated: {component} - {progress}%")
    def fetch_page(self):
        """Fetch the target website and create a BeautifulSoup object"""
        headers = {
            'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36'
        }
        
        max_retries = 3
        for attempt in range(max_retries):
            try:
                logging.debug(f"Fetching page: {self.url} (Attempt {attempt + 1})")
                response = requests.get(self.url, headers=headers, timeout=30)
                response.raise_for_status()
                self.soup = BeautifulSoup(response.content, 'html.parser')
                logging.info(f"Successfully fetched page: {self.url}")
                return True
            except Timeout:
                logging.warning(f"Request timed out while fetching page: {self.url}")
            except HTTPError as e:
                logging.error(f"HTTP error fetching page: {e}")
            except RequestException as e:
                logging.error(f"Error fetching page: {e}")
            time.sleep(2)  # Wait before retrying
        self.soup = BeautifulSoup("<html><body></body></html>", 'html.parser')
        logging.error(f"Failed to fetch page after {max_retries} attempts")
        return False

    def setup_browser(self):
        """Setup Selenium browser for dynamic content scanning"""
        try:
            options = Options()
            options.add_argument("--headless")
            options.add_argument("--disable-gpu")
            options.add_argument("--window-size=1920x1080")
            options.add_argument("--disable-extensions")
            options.add_argument("--no-sandbox")
            options.add_argument("--disable-dev-shm-usage")
            options.add_argument("--blink-settings=imagesEnabled=false")
            options.page_load_strategy = 'eager'
            # Removed --disable-javascript to allow dynamic content
            
            service = Service(ChromeDriverManager().install())
            self.browser = webdriver.Chrome(service=service, options=options)
            self.browser.set_page_load_timeout(30)  # Increased timeout
            logging.info("Browser initialized successfully")
            return self.browser
        except WebDriverException as e:
            logging.error(f"Could not initialize Chrome browser: {e}")
            self.browser = None
            return None
        except Exception as e:
            logging.error(f"Unexpected error initializing browser: {e}")
            self.browser = None
            return None
        
    def close_browser(self):
        """Close the Selenium browser instance"""
        if self.browser:
            try:
                self.browser.quit()
                logging.info("Browser closed successfully")
            except Exception as e:
                logging.error(f"Error closing browser: {e}")
            finally:
                self.browser = None
    
    def scan_website(self):
        """Main method that orchestrates the scanning process"""
        logging.debug(f"Starting website scan for {self.url}")
        self.update_scan_status("Initializing scanner...", 0)
        
        results = {
            'url': self.url,
            'overall_score': 0,
            'rating': 'Poor',
            'overall_score_class': 'danger',
            'privacy_policy': {
                'found': False,
                'score': 0,
                'score_class': 'danger',
                'recommendations': ['Could not analyze privacy policy']
            },
            'gdpr': {
                'score': 0,
                'score_class': 'danger',
                'findings': ['Could not analyze GDPR compliance'],
                'recommendations': ['Have your site reviewed manually for GDPR compliance']
            },
            'ccpa': {
                'score': 0,
                'score_class': 'danger',
                'findings': ['Could not analyze CCPA compliance'],
                'recommendations': ['Have your site reviewed manually for CCPA compliance']
            },
            'data_collection': {
                'score': 0,
                'score_class': 'danger',
                'trackers': [],
                'tracker_count': 0,
                'cookies': {
                    'total': 0,
                    'necessary': 0,
                    'functional': 0,
                    'analytics': 0,
                    'advertising': 0,
                    'unclassified': 0,
                    'necessary_percent': 0,
                    'functional_percent': 0,
                    'analytics_percent': 0,
                    'advertising_percent': 0,
                    'unclassified_percent': 0,
                    'consent': {'compliant': False, 'details': 'Consent check not performed'}
                },
                'forms': [],
                'recommendations': ['Could not analyze data collection practices']
            },
            'form_security': {
                'score': 0,
                'score_class': 'danger',
                'forms_found': 0,
                'forms_with_sensitive_data': 0,
                'secure_forms': 0,
                'insecure_forms': 0,
                'forms': [],
                'recommendations': ['Could not analyze form security']
            },
            'sql_injection': {
                'score': 100,
                'score_class': 'good',
                'forms_tested': 0,
                'vulnerable_forms': 0,
                'vulnerabilities': [],
                'recommendations': ['Could not test for SQL injection vulnerabilities']
            },
            'ssl_security': {
                'score': 0,
                'score_class': 'danger',
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
                'recommendations': ['Could not analyze SSL/TLS security']
            }
        }
        
        try:
            self.update_scan_status("Fetching website content...", 5)
            fetch_success = self.fetch_page()
            if not fetch_success:
                logging.warning(f"Failed to fetch {self.url} with requests")
                
            self.update_scan_status("Setting up browser environment...", 10)
            browser_setup_success = False
            try:
                browser = self.setup_browser()
                if browser:
                    browser_setup_success = True
                    try:
                        logging.debug(f"Loading page in browser: {self.url}")
                        self.update_scan_status("Loading website in browser...", 15)
                        self.browser.get(self.url)
                        WebDriverWait(self.browser, 10).until(
                            EC.presence_of_element_located((By.TAG_NAME, 'body'))
                        )
                        time.sleep(2)  # Allow dynamic content to load
                        logging.info(f"Page loaded in browser: {self.url}")
                    except TimeoutException:
                        logging.warning(f"Timeout loading page in browser: {self.url}")
                    except Exception as e:
                        logging.error(f"Error loading page in browser: {e}")
            except Exception as e:
                logging.error(f"Browser setup error: {e}")
            
            if self.soup:
                try:
                    self.update_scan_status("Scanning privacy policy...", 20)
                    logging.debug("Scanning privacy policy")
                    self.privacy_checker = PrivacyPolicyChecker(self.url, self.soup, self.browser)
                    results['privacy_policy'] = self.privacy_checker.scan_privacy_policy()
                except Exception as e:
                    logging.error(f"Error in privacy policy scanner: {e}")
                
                try:
                    self.update_scan_status("Scanning for data collection and cookies...", 35)
                    logging.debug("Scanning data collection and cookies")
                    self.data_checker = DataCollectionChecker(self.url, self.soup, self.browser)
                    cookie_results = results['data_collection']['cookies']
                    if browser_setup_success:
                        self.cookie_scanner = CookieScanner(self.url, self.browser)
                        cookie_results = self.cookie_scanner.scan_cookies()
                    results['data_collection'] = self.data_checker.scan_data_collection(cookie_results)
                except Exception as e:
                    logging.error(f"Error in data collection or cookie scanner: {e}")
                
                try:
                    self.update_scan_status("Checking GDPR compliance...", 50)
                    logging.debug("Checking GDPR compliance")
                    self.gdpr_checker = GDPRChecker(self.url, self.soup, self.browser)
                    results['gdpr'] = self.gdpr_checker.check_gdpr_compliance(
                        results['privacy_policy'], results['data_collection'])
                except Exception as e:
                    logging.error(f"Error in GDPR checker: {e}")
                
                try:
                    self.update_scan_status("Checking CCPA compliance...", 60)
                    logging.debug("Checking CCPA compliance")
                    self.ccpa_checker = CCPAChecker(self.url, self.soup, self.browser)
                    results['ccpa'] = self.ccpa_checker.check_ccpa_compliance(
                        results['privacy_policy'], results['data_collection'])
                except Exception as e:
                    logging.error(f"Error in CCPA checker: {e}")
                
                try:
                    self.update_scan_status("Checking form security...", 70)
                    logging.debug("Checking form security")
                    self.form_security_checker = FormSecurityChecker(self.url, self.soup, self.browser)
                    results['form_security'] = self.form_security_checker.check_forms_security()
                except Exception as e:
                    logging.error(f"Error in form security checker: {e}")
                
                try:
                    self.update_scan_status("Testing for SQL injection vulnerabilities...", 80)
                    logging.debug("Testing for SQL injection")
                    self.sql_injection_detector = SQLInjectionDetector(self.url, self.soup, self.browser)
                    results['sql_injection'] = self.sql_injection_detector.test_for_vulnerabilities()
                except Exception as e:
                    logging.error(f"Error in SQL injection detector: {e}")
                
                try:
                    self.update_scan_status("Checking SSL/TLS security...", 90)
                    logging.debug("Checking SSL security")
                    self.ssl_security_checker = SSLSecurityChecker(self.url, self.soup, self.browser)
                    results['ssl_security'] = self.ssl_security_checker.check_ssl_security()
                except Exception as e:
                    logging.error(f"Error in SSL security checker: {e}")
            
            try:
                self.update_scan_status("Calculating final score...", 95)
                policy_score = results['privacy_policy'].get('score', 0)
                gdpr_score = results['gdpr'].get('score', 0)
                ccpa_score = results['ccpa'].get('score', 0)
                data_score = results['data_collection'].get('score', 0)
                form_security_score = results['form_security'].get('score', 0)
                sql_injection_score = results['sql_injection'].get('score', 0)
                ssl_security_score = results['ssl_security'].get('score', 0)
                
                results['overall_score'] = int((
                    policy_score * 0.25 +
                    max(gdpr_score, ccpa_score) * 0.15 +
                    data_score * 0.15 + 
                    form_security_score * 0.15 + 
                    sql_injection_score * 0.15 +
                    ssl_security_score * 0.15
                ))
                
                if results['overall_score'] >= 75:
                    results['rating'] = "Excellent"
                    results['overall_score_class'] = "good"
                elif results['overall_score'] >= 55:
                    results['rating'] = "Good"
                    results['overall_score_class'] = "warning"
                elif results['overall_score'] >= 35:
                    results['rating'] = "Fair"
                    results['overall_score_class'] = "warning"
                else:
                    results['rating'] = "Poor"
                    results['overall_score_class'] = "danger"
                logging.info(f"Overall score calculated: {results['overall_score']}")
                self.update_scan_status("Scan completed!", 100)
            except Exception as e:
                logging.error(f"Error in score calculation: {e}")
                
        except Exception as e:
            logging.error(f"Critical error during scanning: {str(e)}")
        finally:
            self.close_browser()
            
        logging.debug(f"Scan completed for {self.url}")
        return results
import json
import time
import re
import requests
import logging
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class CookieScanner:
    def __init__(self, url, browser):
        self.url = url
        self.browser = browser
        self.cookie_db = {
            '_ga': 'analytics',
            '_gid': 'analytics',
            '_fbp': 'advertising',
            'session_id': 'necessary',
            'csrf_token': 'necessary',
            'NID': 'advertising',
            'IDE': 'advertising'
        }
        
    def scan_cookies(self):
        """Scan website for cookies and categorize them"""
        logging.debug(f"Starting cookie scan for {self.url}")
        results = {
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
            'consent': {
                'compliant': False,
                'details': 'No cookie consent detected'
            },
            'cookies': []
        }
        
        if not self.browser:
            logging.warning("No browser available for cookie scan")
            return results
            
        try:
            # Wait for dynamic content
            WebDriverWait(self.browser, 10).until(
                EC.presence_of_element_located((By.TAG_NAME, 'body'))
            )
            time.sleep(2)  # Allow cookies to set
            
            # Step 1: Get cookies directly from browser
            cookies = self.browser.get_cookies()
            logging.debug(f"Found {len(cookies)} browser cookies")
            
            # Step 2: Get cookies via HTTP headers
            session = requests.Session()
            response = session.get(self.url, timeout=15)
            http_cookies = [{'name': c.name, 'value': c.value, 'domain': c.domain} 
                            for c in session.cookies]
            logging.debug(f"Found {len(http_cookies)} HTTP cookies")
            
            # Combine cookies (avoid duplicates)
            seen_cookie_names = set()
            all_cookies = []
            
            for cookie in cookies:
                cookie_name = cookie.get('name')
                if cookie_name and cookie_name not in seen_cookie_names:
                    all_cookies.append(cookie)
                    seen_cookie_names.add(cookie_name)
            
            for cookie in http_cookies:
                cookie_name = cookie.get('name')
                if cookie_name and cookie_name not in seen_cookie_names:
                    all_cookies.append(cookie)
                    seen_cookie_names.add(cookie_name)
                    
            results['total'] = len(all_cookies)
            logging.info(f"Total cookies detected: {results['total']}")
            
            for cookie in all_cookies:
                cookie_info = {
                    'name': cookie.get('name', 'unknown'),
                    'domain': cookie.get('domain', 'unknown'),
                    'category': 'unclassified',
                }
                
                cookie_name = cookie_info['name'].lower()
                
                if any(x in cookie_name for x in ['sess', 'auth', 'token', 'logged', 'csrf', 'xsrf', 'security', 'cookie-law']):
                    cookie_info['category'] = 'necessary'
                    results['necessary'] += 1
                elif any(x in cookie_name for x in ['pref', 'func', 'setting', 'config', 'theme', 'display', 'lang', 'timezone']):
                    cookie_info['category'] = 'functional'
                    results['functional'] += 1
                elif any(x in cookie_name for x in ['ga', 'gtm', 'utm', 'analytics', 'stat', 'pixel', '_ym', 'metrics', 'plausible', 'track']):
                    cookie_info['category'] = 'analytics'
                    results['analytics'] += 1
                elif any(x in cookie_name for x in ['ad', 'ads', 'adsense', 'advert', 'doubleclick', 'facebook', 'twitter', 'linkedin', 'social']):
                    cookie_info['category'] = 'advertising'
                    results['advertising'] += 1
                else:
                    results['unclassified'] += 1
                    
                results['cookies'].append(cookie_info)
        
            if results['total'] > 0:
                results['necessary_percent'] = int((results['necessary'] / results['total']) * 100)
                results['functional_percent'] = int((results['functional'] / results['total']) * 100)
                results['analytics_percent'] = int((results['analytics'] / results['total']) * 100)
                results['advertising_percent'] = int((results['advertising'] / results['total']) * 100)
                results['unclassified_percent'] = int((results['unclassified'] / results['total']) * 100)
            
            self.check_cookie_consent(results)
            logging.info("Cookie scan completed")
        
        except Exception as e:
            logging.error(f"Error during cookie scanning: {e}")
            
        return results

    def check_cookie_consent(self, results):
        """Check if the website has a proper cookie consent banner"""
        logging.debug("Checking for cookie consent banner")
        try:
            page_source = self.browser.page_source.lower()
            
            has_cookie_content = 'cookie' in page_source
            
            consent_keywords = [
                'accept cookies', 'accept all cookies', 'cookie consent', 'cookie settings',
                'cookie preferences', 'privacy settings', 'agree to cookies',
                'cookie policy', 'use of cookies', 'we use cookies', 'site uses cookies',
                'privacy choices', 'gdpr', 'ccpa', 'manage cookies', 'cookie notice'
            ]
            
            has_consent_text = any(keyword in page_source for keyword in consent_keywords)
            
            consent_buttons = self.browser.find_elements(By.XPATH,
                "//button[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'accept') or " +
                "contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'cookie') or " +
                "contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'consent') or " + 
                "contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'agree')]"
            )
            
            consent_divs = self.browser.find_elements(By.XPATH,
                "//div[contains(@class, 'cookie') or contains(@id, 'cookie') or " +
                "contains(@class, 'consent') or contains(@id, 'consent') or " +
                "contains(@class, 'gdpr') or contains(@id, 'gdpr')]"
            )
            
            known_consent_elements = [
                "div#onetrust-consent-sdk",
                "div.cookieconsent",
                "div#cookieConsentBanner",
                "div#CookieConsent",
                "div#cookie-law-info-bar",
                "div#cookie-notice",
                ".eupopup-container",
                "#gdpr-banner",
                ".cc-window",
                ".cookie-dialog"
            ]
            
            consent_tools = []
            for selector in known_consent_elements:
                try:
                    elements = self.browser.find_elements(By.CSS_SELECTOR, selector)
                    if elements:
                        consent_tools.extend(elements)
                except:
                    pass
            
            has_consent_mechanism = (len(consent_buttons) > 0 or len(consent_divs) > 0 or 
                                    len(consent_tools) > 0 or has_consent_text)
            
            has_granular_controls = False
            try:
                cookie_checkboxes = self.browser.find_elements(By.XPATH,
                    "//input[@type='checkbox'][ancestor::div[contains(@class, 'cookie') or contains(@class, 'consent') or contains(@class, 'gdpr')]]"
                )
                cookie_radios = self.browser.find_elements(By.XPATH,
                    "//input[@type='radio'][ancestor::div[contains(@class, 'cookie') or contains(@class, 'consent') or contains(@class, 'gdpr')]]"
                )
                
                has_granular_controls = len(cookie_checkboxes) >= 2 or len(cookie_radios) >= 4
            except:
                pass
            
            if has_consent_mechanism:
                if (has_granular_controls or 
                    "necessary" in page_source and "preferences" in page_source and "statistics" in page_source):
                    results['consent']['compliant'] = True
                    results['consent']['details'] = "GDPR-compliant cookie consent with granular controls"
                    logging.info("GDPR-compliant cookie consent detected")
                else:
                    results['consent']['compliant'] = False
                    results['consent']['details'] = "Cookie consent present but may not be fully compliant"
                    logging.info("Non-compliant cookie consent detected")
            else:
                if results['total'] > 0:
                    results['consent']['compliant'] = False
                    results['consent']['details'] = "No cookie consent detected despite using cookies"
                    logging.warning("No cookie consent detected with cookies present")
                else:
                    results['consent']['compliant'] = True
                    results['consent']['details'] = "No cookies detected, consent not required"
                    logging.info("No cookies detected, consent not required")
                    
        except Exception as e:
            logging.error(f"Error checking cookie consent: {e}")
            results['consent']['details'] = "Could not determine cookie consent compliance"
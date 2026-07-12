import re
import logging
import requests
from bs4 import BeautifulSoup
from selenium import webdriver
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By
from datetime import datetime
from dateutil import parser as date_parser
from selenium.common.exceptions import TimeoutException, WebDriverException
from urllib.parse import urljoin  # Added import for urljoin
import time
# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class PrivacyPolicyChecker:
    def __init__(self, base_url, soup, browser):
        self.base_url = base_url
        self.soup = soup
        self.browser = browser
        self.privacy_urls = {
            'facebook.com': 'https://www.facebook.com/privacy/policy',
            'google.com': 'https://policies.google.com/privacy',
            'amazon.com': 'https://www.amazon.com/gp/help/customer/display.html?nodeId=468496'
        }
        self.driver = None
        if self.browser is None:
            try:
                chromedriver_path = 'C:/Users/Shayan/OneDrive/Desktop/New folder/privacy_audit_tool/chromedriver.exe'
                options = webdriver.ChromeOptions()
                options.add_argument('--disable-gpu')
                options.add_argument('--no-sandbox')
                self.driver = webdriver.Chrome(executable_path=chromedriver_path, options=options)
                self.browser = self.driver
                logging.info("Initialized fallback WebDriver")
            except Exception as e:
                logging.error(f"Failed to initialize fallback WebDriver: {e}")
                self.browser = None

    def __del__(self):
        """Clean up WebDriver"""
        if self.driver:
            try:
                self.driver.quit()
            except:
                pass
    def find_privacy_policy_link(self):
        """Find privacy policy URL by checking known URLs or scraping the page"""
        logging.debug(f"Checking privacy policy for {self.base_url}")
        
        # Check hardcoded URLs first
        for domain, url in self.privacy_urls.items():
            if domain in self.base_url.lower():
                logging.info(f"Using direct privacy policy URL: {url}")
                return url
        
        # Scrape the page for privacy policy links
        try:
            privacy_keywords = ['privacy', 'policy', 'data protection', 'legal', 'terms']
            for link in self.soup.find_all('a', href=True):
                href = link['href'].lower()
                text = link.get_text(strip=True).lower()
                if any(keyword in href or keyword in text for keyword in privacy_keywords):
                    # Convert relative URLs to absolute
                    full_url = urljoin(self.base_url, href)
                    logging.info(f"Found potential privacy policy link: {full_url}")
                    return full_url
        except Exception as e:
            logging.error(f"Error scraping for privacy policy link: {e}")
        
        logging.warning("No privacy policy URL found")
        return None
    def extract_last_updated_date(self, privacy_content):
        """Extract the last updated date from privacy policy content"""
        date_patterns = [
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*([A-Za-z]+\s+\d{1,2},?\s+\d{4})',
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*(\d{1,2}/\d{1,2}/\d{2,4})',
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*(\d{1,2}-\d{1,2}-\d{2,4})',
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*(\d{4}-\d{1,2}-\d{1,2})',
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*([A-Za-z]+,?\s+\d{4})',
            r'(?:last )?(?:updated|modified|revised|effective)(?:\s+on)?(?:\s+date)?:?\s*(\d{1,2}\s+[A-Za-z]+\s+\d{4})'
        ]

        for pattern in date_patterns:
            match = re.search(pattern, privacy_content, re.IGNORECASE)
            if match:
                try:
                    date_str = match.group(1)
                    date = date_parser.parse(date_str, fuzzy=True)
                    outdated = (datetime.now() - date).days > 365
                    logging.info(f"Found last updated date: {date_str}")
                    return {'date': date.strftime('%B %d, %Y'), 'outdated': outdated}
                except:
                    continue
        logging.warning("No last updated date found")
        return None
    def analyze_privacy_policy(self, policy_url):
        """Analyze the content of the privacy policy"""
        logging.debug(f"Analyzing privacy policy at {policy_url}")
        policy_text = ""

        # Try Selenium first
        if self.browser:
            try:
                self.browser.get(policy_url)
                WebDriverWait(self.browser, 10).until(EC.presence_of_element_located((By.TAG_NAME, 'body')))
                
                # Handle consent dialogs more robustly
                try:
                    consent_button = WebDriverWait(self.browser, 5).until(
                        EC.element_to_be_clickable((By.XPATH, "//button[contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'accept') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'agree') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'ok') or contains(translate(text(), 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'continue')]"))
                    )
                    consent_button.click()
                    logging.debug("Clicked consent dialog")
                except:
                    logging.debug("No consent dialog found or could not click")

                # Scroll to load dynamic content
                for _ in range(3):
                    self.browser.execute_script("window.scrollTo(0, document.body.scrollHeight);")
                    time.sleep(1)

                policy_content = self.browser.page_source
                policy_soup = BeautifulSoup(policy_content, 'html.parser')
                policy_text = policy_soup.get_text(separator=' ', strip=True)

                # Fallback to body text if insufficient
                if len(policy_text.strip()) < 1000:
                    logging.warning("BeautifulSoup extracted insufficient text, using Selenium body text")
                    policy_text = self.browser.find_element(By.TAG_NAME, 'body').text

                logging.debug(f"Extracted policy text length (Selenium): {len(policy_text)} characters")
            except (TimeoutException, WebDriverException) as e:
                logging.error(f"Selenium error: {e}")
                policy_text = ""

        # Fallback to requests
        if len(policy_text.strip()) < 1000:
            try:
                headers = {
                    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/135.0.0.0 Safari/537.36'
                }
                response = requests.get(policy_url, headers=headers, timeout=20, allow_redirects=True)
                response.raise_for_status()
                policy_soup = BeautifulSoup(response.text, 'html.parser')
                policy_text = policy_soup.get_text(separator=' ', strip=True)
                logging.debug(f"Extracted policy text length (requests): {len(policy_text)} characters")
            except Exception as e:
                logging.error(f"Requests error: {e}")
                policy_text = ""

        if len(policy_text.strip()) < 1000:
            logging.error("Failed to extract sufficient policy text")
            return {
                'url': policy_url,
                'found': True,
                'error': "Insufficient policy text extracted",
                'score': 20,
                'score_class': "danger",
                'recommendations': ["Ensure the privacy policy page loads correctly"]
            }

        last_updated = self.extract_last_updated_date(policy_text)
        elements = self._find_privacy_elements(policy_text)
        missing_elements = [k for k, v in elements.items() if not v]
        score = self._calculate_policy_score(elements, last_updated)

        recommendations = []
        if not elements['data_collection']:
            recommendations.append("Add information about what data you collect from users")
        # ... (other recommendations remain the same)
        if not last_updated:
            recommendations.append("Add a 'Last Updated' date to the privacy policy")
        elif last_updated.get('outdated', False):
            recommendations.append("Update your privacy policy as it is over a year old")
        if not recommendations:
            recommendations.append("Regularly review and update your privacy policy")

        logging.info(f"Privacy policy score: {score}, Elements: {elements}")
        return {
            'url': policy_url,
            'found': True,
            'last_updated': last_updated.get('date') if last_updated else None,
            'outdated': last_updated.get('outdated', False) if last_updated else True,
            'elements': elements,
            'missing_elements': missing_elements,
            'score': score,
            'score_class': "good" if score >= 80 else "warning" if score >= 60 else "danger",
            'recommendations': recommendations
        }
    def _find_privacy_elements(self, text):
        """Identify key privacy policy elements in the text"""
        elements = {
            'data_collection': False,
            'data_use': False,
            'data_sharing': False,
            'user_rights': False,
            'retention': False,
            'data_security': False,
            'contact': False,
            'cookies': False,
            'children': False,
            'updates': False
        }

        text = text.lower()
        patterns = {
            'data_collection': [r'collect', r'information', r'data', r'receive', r'gather', r'personal'],
            'data_use': [r'use', r'purpose', r'process', r'service', r'utilize', r'provide'],
            'data_sharing': [r'share', r'third', r'disclos', r'provide', r'partner', r'transfer'],
            'user_rights': [r'right', r'access', r'delete', r'control', r'choice', r'opt', r'correct'],
            'retention': [r'retain', r'store', r'keep', r'duration', r'long', r'hold'],
            'data_security': [r'secur', r'protect', r'safe', r'encrypt', r'measure', r'safeguard'],
            'contact': [r'contact', r'email', r'inquir', r'reach', r'support', r'address'],
            'cookies': [r'cooki', r'track', r'analytic', r'technolog', r'beacon', r'pixel'],
            'children': [r'child', r'minor', r'kid', r'under', r'youth', r'parent'],
            'updates': [r'update', r'revis', r'change', r'notify', r'amend', r'modify']
        }

        for element, pattern_list in patterns.items():
            for pattern in pattern_list:
                if re.search(pattern, text, re.IGNORECASE):
                    elements[element] = True
                    break

        logging.debug(f"Privacy elements detected: {elements}")
        return elements
    def _calculate_policy_score(self, elements, last_updated):
        """Calculate a score based on privacy policy elements"""
        required = ['data_collection', 'data_use', 'data_sharing', 'user_rights']
        recommended = ['retention', 'data_security', 'contact', 'cookies', 'children', 'updates']

        required_score = (sum(1 for e in required if elements.get(e, False)) / len(required)) * 50
        recommended_score = (sum(1 for e in recommended if elements.get(e, False)) / len(recommended)) * 40
        date_bonus = 10 if last_updated else 0  # Simpler date bonus

        score = min(100, int(required_score + recommended_score + date_bonus))
        logging.debug(f"Calculated privacy policy score: {score}")
        return score
    def scan_privacy_policy(self):
        """Main method to scan for privacy policy"""
        logging.debug("Starting privacy policy scan")
        try:
            policy_url = self.find_privacy_policy_link()
            if policy_url:
                return self.analyze_privacy_policy(policy_url)
            else:
                logging.warning("No privacy policy found")
                return {
                    'found': False,
                    'url': None,
                    'score': 0,
                    'score_class': "danger",
                    'recommendations': [
                        "Create a comprehensive privacy policy page",
                        "Make sure the privacy policy link is easily accessible from your homepage",
                        "Include the privacy policy link in your website footer"
                    ]
                }

        except Exception as e:
            logging.error(f"Error in privacy policy scan: {e}")
            return {
                'found': False,
                'error': str(e),
                'score': 0,
                'score_class': "danger",
                'recommendations': ["An error occurred. Please check your website configuration."]
            }
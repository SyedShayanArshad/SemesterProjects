import re
import requests
import logging
from urllib.parse import urljoin, urlparse
from bs4 import BeautifulSoup
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class FormSecurityChecker:
    def __init__(self, url, soup, browser=None):
        self.url = url
        self.soup = soup
        self.browser = browser
        self.base_url = urlparse(url).scheme + "://" + urlparse(url).netloc
        self.sensitive_fields = [
            'password', 'pass', 'pwd', 'secret', 'token',
            'creditcard', 'credit-card', 'card', 'cardnumber', 'ccnum', 'cc-number',
            'cvv', 'cvc', 'csc', 'cvv2', 'cid',
            'ssn', 'social', 'sin', 'tax', 'tin',
            'bank', 'account', 'routing',
            'username', 'user', 'email', 'mail',
            'phone', 'mobile', 'tel', 'cell',
            'dob', 'birth', 'bday'
        ]
        
    def check_forms_security(self):
        """Analyze security of forms on the website"""
        logging.debug(f"Starting form security check for {self.url}")
        results = {
            'forms_found': 0,
            'forms_with_sensitive_data': 0,
            'secure_forms': 0,
            'insecure_forms': 0,
            'forms': [],
            'score': 0,
            'score_class': 'danger',
            'recommendations': []
        }
        
        if not self.soup:
            results['recommendations'].append("Could not analyze forms - page content unavailable")
            logging.warning("No soup available for form security check")
            return results
        
        if self.browser:
            try:
                WebDriverWait(self.browser, 10).until(
                    EC.presence_of_all_elements_located((By.TAG_NAME, 'form'))
                )
                page_source = self.browser.page_source
                self.soup = BeautifulSoup(page_source, 'html.parser')
                logging.info("Updated soup with dynamic form content")
            except:
                logging.warning("Failed to detect dynamic forms")
        
        forms = self.soup.find_all('form')
        results['forms_found'] = len(forms)
        logging.info(f"Found {results['forms_found']} forms")
        
        for idx, form in enumerate(forms):
            form_info = self._analyze_form(form, idx + 1)
            results['forms'].append(form_info)
            
            if form_info['has_sensitive_data']:
                results['forms_with_sensitive_data'] += 1
                if form_info['is_secure']:
                    results['secure_forms'] += 1
                else:
                    results['insecure_forms'] += 1
                    results['recommendations'].append(
                        f"Secure form {idx + 1} by ensuring it submits via HTTPS"
                    )
        
        if results['forms_found'] > 0 and results['forms_with_sensitive_data'] == 0:
            results['recommendations'].append(
                "No forms with sensitive data detected - keep monitoring if you add new forms"
            )
        
        if results['insecure_forms'] > 0:
            results['recommendations'].append(
                "Implement TLS/HTTPS for all forms collecting user data"
            )
            
        if not results['forms_found']:
            results['recommendations'].append("No forms detected on the current page")
        
        if results['forms_with_sensitive_data'] > 0:
            secure_percentage = (results['secure_forms'] / results['forms_with_sensitive_data']) * 100
            results['score'] = int(secure_percentage)
            
            if results['score'] >= 80:
                results['score_class'] = 'good'
            elif results['score'] >= 50:
                results['score_class'] = 'warning'
            else:
                results['score_class'] = 'danger'
        else:
            results['score'] = 100
            results['score_class'] = 'good'
        
        logging.debug(f"Form security score: {results['score']}")
        return results
    
    def _analyze_form(self, form, form_id):
        """Analyze a single form's security posture"""
        logging.debug(f"Analyzing form {form_id}")
        form_info = {
            'id': form_id,
            'action': form.get('action', ''),
            'method': form.get('method', 'get').upper(),
            'inputs': [],
            'has_sensitive_data': False,
            'is_secure': False,
            'issues': []
        }
        
        action_url = form.get('action')
        if action_url:
            action_url = urljoin(self.url, action_url)
            form_info['is_secure'] = action_url.startswith('https://')
        else:
            form_info['is_secure'] = self.url.startswith('https://')
        
        inputs = form.find_all(['input', 'textarea', 'select'])
        
        for input_tag in inputs:
            input_type = input_tag.get('type', '').lower() if input_tag.name == 'input' else input_tag.name
            input_name = input_tag.get('name', '').lower()
            input_id = input_tag.get('id', '').lower()
            input_placeholder = input_tag.get('placeholder', '').lower()
            
            input_info = {
                'type': input_type,
                'name': input_name,
                'is_sensitive': False
            }
            
            all_attributes = f"{input_name} {input_id} {input_placeholder}"
            for sensitive in self.sensitive_fields:
                if sensitive in all_attributes or input_type in ['password', 'tel', 'email']:
                    input_info['is_sensitive'] = True
                    form_info['has_sensitive_data'] = True
                    break
            
            if input_info['is_sensitive'] and input_tag.get('autocomplete') != 'off':
                issue = f"Input '{input_name or input_id or input_type}' should have autocomplete='off'"
                if issue not in form_info['issues']:
                    form_info['issues'].append(issue)
            
            form_info['inputs'].append(input_info)
        
        csrf_token = form.find('input', attrs={'name': re.compile('csrf|token', re.IGNORECASE)})
        if not csrf_token and form_info['method'] == 'POST':
            form_info['issues'].append("Form lacks CSRF protection token")
        
        if form_info['has_sensitive_data'] and not form_info['is_secure']:
            form_info['issues'].append("Form with sensitive data doesn't use HTTPS")
            
        return form_info
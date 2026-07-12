import requests
import re
import time
import random
import logging
from urllib.parse import urljoin, urlparse
from bs4 import BeautifulSoup
from selenium.common.exceptions import TimeoutException
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class SQLInjectionDetector:
    def __init__(self, url, soup, browser=None):
        self.url = url
        self.soup = soup
        self.browser = browser
        self.base_url = urlparse(url).scheme + "://" + urlparse(url).netloc
        
        self.payloads = [
            "' OR '1'='1", 
            "\" OR \"1\"=\"1",
            "' --",
            "' OR '1'='1' --",
            "' OR 1=1 --",
            "admin' --",
            "1' OR '1' = '1",
            "1 OR 1=1",
            "' UNION SELECT 1, 1, 1 --",
            "' AND 1=2 --"
        ]
        
        self.error_patterns = [
            r"SQL syntax.*MySQL",
            r"Warning.*mysql_",
            r"PostgreSQL.*ERROR",
            r"Driver.*SQLServer",
            r"ORA-[0-9]{5}",
            r"Microsoft SQL Native Client error",
            r"SQLite3::query",
            r"SQLSTATE\[",
            r"Microsoft JET Database Engine error",
            r"Oracle error",
            r"invalid query"
        ]
    
    def test_for_vulnerabilities(self):
        """Test website forms for SQL injection vulnerabilities"""
        logging.debug(f"Starting SQL injection test for {self.url}")
        results = {
            'forms_tested': 0,
            'vulnerable_forms': 0,
            'vulnerabilities': [],
            'score': 100,
            'score_class': 'good',
            'recommendations': []
        }
        
        if not self.soup:
            results['recommendations'].append("Could not analyze for SQL injection - page content unavailable")
            logging.warning("No soup available for SQL injection test")
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
        
        if not forms:
            results['recommendations'].append("No forms detected to test for SQL injection vulnerabilities")
            logging.info("No forms detected")
            return results
        
        for form_idx, form in enumerate(forms):
            form_id = form_idx + 1
            form_action = form.get('action', '')
            form_method = form.get('method', 'get').lower()
            
            if form_action:
                form_url = urljoin(self.url, form_action)
                if urlparse(form_url).netloc != urlparse(self.url).netloc:
                    logging.debug(f"Skipping external form: {form_url}")
                    continue
            else:
                form_url = self.url
            
            inputs = {}
            input_tags = form.find_all(['input', 'textarea'])
            for input_tag in input_tags:
                input_name = input_tag.get('name')
                if not input_name:
                    continue
                    
                input_type = input_tag.get('type', 'text').lower() if input_tag.name == 'input' else 'textarea'
                if input_type in ['checkbox', 'radio', 'file', 'submit', 'button', 'image', 'reset']:
                    continue
                    
                input_value = input_tag.get('value', '')
                if not input_value:
                    placeholder = input_tag.get('placeholder', '')
                    if 'email' in input_name.lower() or input_type == 'email':
                        input_value = 'test@example.com'
                    elif 'password' in input_name.lower() or input_type == 'password':
                        input_value = 'Password123!'
                    else:
                        input_value = placeholder or 'test'
                        
                inputs[input_name] = input_value
            
            if not inputs:
                logging.debug(f"No testable inputs in form {form_id}")
                continue
                
            results['forms_tested'] += 1
            logging.info(f"Testing form {form_id}")
            
            vulnerable = False
            for input_name in inputs:
                original_value = inputs[input_name]
                
                for payload in self.payloads:
                    inputs[input_name] = payload
                    
                    try:
                        is_vulnerable = self._test_injection(form_url, form_method, inputs)
                        if is_vulnerable:
                            vulnerable = True
                            vulnerability = {
                                'form_id': form_id,
                                'form_url': form_url,
                                'input_field': input_name,
                                'payload': payload,
                                'type': 'SQL Injection'
                            }
                            results['vulnerabilities'].append(vulnerability)
                            logging.warning(f"Potential SQL injection vulnerability in form {form_id}")
                            break
                    except Exception as e:
                        logging.error(f"Error testing injection: {e}")
                    finally:
                        inputs[input_name] = original_value
                        time.sleep(0.3)
                        
            if vulnerable:
                results['vulnerable_forms'] += 1
        
        if results['forms_tested'] > 0:
            safe_forms = results['forms_tested'] - results['vulnerable_forms']
            results['score'] = int((safe_forms / results['forms_tested']) * 100)
            
            if results['vulnerable_forms'] > 0:
                results['score_class'] = 'danger'
                results['recommendations'].append("Fix SQL injection vulnerabilities by using parameterized queries")
                results['recommendations'].append("Implement proper input validation and sanitization")
                if results['vulnerable_forms'] > 1:
                    results['recommendations'].append("Consider using an ORM (Object-Relational Mapping) system")
            else:
                results['score_class'] = 'good'
                results['recommendations'].append("No SQL injection vulnerabilities detected in tested forms")
        
        logging.debug(f"SQL injection score: {results['score']}")
        return results
    
    def _test_injection(self, form_url, form_method, inputs):
        """Test a SQL injection payload on a form"""
        logging.debug(f"Testing injection on {form_url}")
        try:
            if self.browser and form_method == 'post':
                current_url = self.browser.current_url
                
                try:
                    self.browser.get(form_url)
                    for name, value in inputs.items():
                        try:
                            field = self.browser.find_element(By.NAME, name)
                            field_type = field.get_attribute('type')
                            if field_type not in ['checkbox', 'radio', 'file', 'submit']:
                                field.clear()
                                field.send_keys(value)
                        except:
                            logging.debug(f"Failed to fill input {name}")
                    
                    try:
                        submit = self.browser.find_element(By.CSS_SELECTOR, 'input[type="submit"]')
                        submit.click()
                    except:
                        try:
                            button = self.browser.find_element(By.TAG_NAME, 'button')
                            button.click()
                        except:
                            form = self.browser.find_element(By.TAG_NAME, 'form')
                            form.submit()
                    
                    WebDriverWait(self.browser, 10).until(
                        EC.presence_of_element_located((By.TAG_NAME, 'body'))
                    )
                    page_source = self.browser.page_source
                    if self._check_sql_errors(page_source):
                        logging.warning("SQL error detected in response")
                        return True
                        
                    self.browser.get(current_url)
                    
                except Exception as e:
                    logging.error(f"Error in Selenium form submission: {e}")
                    self.browser.get(current_url)
                    
                return False
            else:
                if form_method == 'post':
                    response = requests.post(form_url, data=inputs, allow_redirects=True, timeout=15)
                else:
                    response = requests.get(form_url, params=inputs, allow_redirects=True, timeout=15)
                
                return self._check_sql_errors(response.text)
                
        except Exception as e:
            logging.error(f"Exception in injection test: {e}")
            return False
    
    def _check_sql_errors(self, content):
        """Check response content for SQL error messages"""
        if not content:
            return False
            
        for pattern in self.error_patterns:
            if re.search(pattern, content, re.IGNORECASE):
                return True
                
        return False
import re
import logging
from bs4 import BeautifulSoup
from urllib.parse import urljoin
import requests
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class GDPRChecker:
    def __init__(self, url, soup, browser):
        self.url = url
        self.soup = soup
        self.browser = browser
        
    def check_gdpr_compliance(self, privacy_policy_results, data_collection_results):
        """Check website for GDPR compliance"""
        logging.debug(f"Starting GDPR compliance check for {self.url}")
        compliance_checks = {
            'privacy_policy': {
                'check': privacy_policy_results.get('found', False),
                'description': 'Website has a privacy policy',
                'requirement': 'mandatory'
            },
            'data_purpose': {
                'check': self._check_policy_element(privacy_policy_results, 'data_use'),
                'description': 'Clear explanation of how personal data is used',
                'requirement': 'mandatory'
            },
            'data_collection': {
                'check': self._check_policy_element(privacy_policy_results, 'data_collection'),
                'description': 'Clear explanation of what personal data is collected',
                'requirement': 'mandatory'
            },
            'cookie_consent': {
                'check': data_collection_results.get('cookies', {}).get('consent', {}).get('compliant', False),
                'description': 'Compliant cookie consent mechanism',
                'requirement': 'mandatory'
            },
            'data_sharing': {
                'check': self._check_policy_element(privacy_policy_results, 'data_sharing'),
                'description': 'Information about third-party data sharing',
                'requirement': 'mandatory'
            },
            'data_retention': {
                'check': self._check_policy_element(privacy_policy_results, 'retention'),
                'description': 'Clear data retention policy',
                'requirement': 'mandatory'
            },
            'user_rights': {
                'check': self._check_policy_element(privacy_policy_results, 'user_rights'),
                'description': 'Information about user rights (access, delete, etc.)',
                'requirement': 'mandatory'
            },
            'data_security': {
                'check': self._check_data_security(privacy_policy_results),
                'description': 'Information about data security measures and HTTPS',
                'requirement': 'recommended'
            }
        }
        
        # Check forms for consent
        forms_with_issues = 0
        for form in data_collection_results.get('forms', []):
            if form.get('sensitive_fields', 0) > 0 and not self._check_form_consent(form):
                forms_with_issues += 1
                
        compliance_checks['form_consent'] = {
            'check': forms_with_issues == 0,
            'description': 'Forms collecting personal data have consent checkboxes with explanatory text',
            'requirement': 'mandatory'
        }
        
        # Fallback: Check for GDPR page if privacy policy is missing
        if not privacy_policy_results.get('found', False):
            gdpr_page_found = self._check_for_gdpr_page()
            if gdpr_page_found:
                compliance_checks['privacy_policy']['check'] = True
                logging.info("Found GDPR compliance page as fallback")
        
        mandatory_checks = [check for check in compliance_checks.values() if check['requirement'] == 'mandatory']
        passed_mandatory = sum(1 for check in mandatory_checks if check['check'])
        recommended_checks = [check for check in compliance_checks.values() if check['requirement'] == 'recommended']
        passed_recommended = sum(1 for check in recommended_checks if check['check'])
        
        mandatory_score = (passed_mandatory / len(mandatory_checks)) * 80 if mandatory_checks else 0
        recommended_score = (passed_recommended / len(recommended_checks)) * 20 if recommended_checks else 0
        total_score = int(mandatory_score + recommended_score)
        
        findings = [check['description'] for check in compliance_checks.values() if check['check']]
        recommendations = []
        
        if not compliance_checks['privacy_policy']['check']:
            recommendations.append("Create a comprehensive privacy policy accessible from the homepage")
        if not compliance_checks['data_purpose']['check']:
            recommendations.append("Clearly explain how personal data is used in your privacy policy")
        if not compliance_checks['data_collection']['check']:
            recommendations.append("Specify what personal data is collected in your privacy policy")
        if not compliance_checks['cookie_consent']['check']:
            recommendations.append("Implement a GDPR-compliant cookie consent mechanism")
        if not compliance_checks['data_sharing']['check']:
            recommendations.append("Include information about third-party data sharing")
        if not compliance_checks['data_retention']['check']:
            recommendations.append("Add a data retention policy to your privacy policy")
        if not compliance_checks['user_rights']['check']:
            recommendations.append("Inform users about their data rights (access, deletion, etc.)")
        if not compliance_checks['data_security']['check']:
            recommendations.append("Describe data security measures in your privacy policy")
        if forms_with_issues > 0:
            recommendations.append("Add consent checkboxes with explanations to forms collecting personal data")
        
        if not recommendations:
            recommendations.append("Maintain and regularly update your GDPR compliance measures")
        
        logging.debug(f"GDPR compliance score: {total_score}")
        return {
            'score': total_score,
            'score_class': 'good' if total_score >= 80 else 'warning' if total_score >= 50 else 'danger',
            'findings': findings,
            'recommendations': recommendations
        }
    
    def _check_policy_element(self, privacy_policy_results, element):
        """Check if a specific element is present in the privacy policy"""
        try:
            return privacy_policy_results.get('elements', {}).get(element, False)
        except:
            logging.warning(f"Failed to check policy element: {element}")
            return False
    
    def _check_data_security(self, privacy_policy_results):
        """Check if data security measures are mentioned"""
        try:
            return privacy_policy_results.get('elements', {}).get('data_security', False)
        except:
            logging.warning("Failed to check data security")
            return False
    
    def _check_form_consent(self, form):
        """Check if a form has a consent checkbox with explanatory text"""
        try:
            has_checkbox = form.get('has_consent_checkbox', False)
            text = form.get('text', '').lower()
            has_explanation = any(keyword in text for keyword in ['consent', 'agree', 'permission', 'opt-in'])
            return has_checkbox and has_explanation
        except:
            logging.warning("Failed to check form consent")
            return False
    
    def _check_for_gdpr_page(self):
        """Fallback: Check for a GDPR-specific page"""
        logging.debug("Checking for GDPR-specific page")
        common_paths = ['/gdpr', '/privacy', '/data-protection', '/compliance']
        for path in common_paths:
            full_url = urljoin(self.url, path)
            try:
                response = requests.head(full_url, timeout=15)
                if response.status_code == 200:
                    logging.info(f"Found GDPR page at {full_url}")
                    return True
            except Exception as e:
                logging.debug(f"Failed to check GDPR path {full_url}: {e}")
        return False

class CCPAChecker:
    def __init__(self, url, soup, browser):
        self.url = url
        self.soup = soup
        self.browser = browser
        
    def check_ccpa_compliance(self, privacy_policy_results, data_collection_results):
        """Check website for CCPA compliance"""
        logging.debug(f"Starting CCPA compliance check for {self.url}")
        compliance_checks = {
            'privacy_policy': {
                'check': privacy_policy_results.get('found', False),
                'description': 'Website has a privacy policy',
                'requirement': 'mandatory'
            },
            'personal_info': {
                'check': self._check_policy_element(privacy_policy_results, 'data_collection'),
                'description': 'Clear explanation of personal information collected',
                'requirement': 'mandatory'
            },
            'consumer_rights': {
                'check': self._check_policy_element(privacy_policy_results, 'user_rights'),
                'description': 'Information about consumer rights (access, delete, opt-out)',
                'requirement': 'mandatory'
            },
            'opt_out': {
                'check': self._check_opt_out_mechanism(),
                'description': 'Clear opt-out mechanism for data selling/sharing',
                'requirement': 'mandatory'
            },
            'data_security': {
                'check': self._check_data_security(privacy_policy_results),
                'description': 'Information about data security measures',
                'requirement': 'recommended'
            }
        }
        
        # Fallback: Check for CCPA page if privacy policy is missing
        if not privacy_policy_results.get('found', False):
            ccpa_page_found = self._check_for_ccpa_page()
            if ccpa_page_found:
                compliance_checks['privacy_policy']['check'] = True
                logging.info("Found CCPA compliance page as fallback")
        
        mandatory_checks = [check for check in compliance_checks.values() if check['requirement'] == 'mandatory']
        passed_mandatory = sum(1 for check in mandatory_checks if check['check'])
        recommended_checks = [check for check in compliance_checks.values() if check['requirement'] == 'recommended']
        passed_recommended = sum(1 for check in recommended_checks if check['check'])
        
        mandatory_score = (passed_mandatory / len(mandatory_checks)) * 80 if mandatory_checks else 0
        recommended_score = (passed_recommended / len(recommended_checks)) * 20 if recommended_checks else 0
        total_score = int(mandatory_score + recommended_score)
        
        findings = [check['description'] for check in compliance_checks.values() if check['check']]
        recommendations = []
        
        if not compliance_checks['privacy_policy']['check']:
            recommendations.append("Create a comprehensive privacy policy accessible from the homepage")
        if not compliance_checks['personal_info']['check']:
            recommendations.append("Specify what personal information is collected in your privacy policy")
        if not compliance_checks['consumer_rights']['check']:
            recommendations.append("Inform users about their CCPA rights (access, deletion, opt-out)")
        if not compliance_checks['opt_out']['check']:
            recommendations.append("Provide a clear opt-out mechanism for data selling/sharing")
        if not compliance_checks['data_security']['check']:
            recommendations.append("Describe data security measures in your privacy policy")
        
        if not recommendations:
            recommendations.append("Maintain and regularly update your CCPA compliance measures")
        
        logging.debug(f"CCPA compliance score: {total_score}")
        return {
            'score': total_score,
            'score_class': 'good' if total_score >= 80 else 'warning' if total_score >= 50 else 'danger',
            'findings': findings,
            'recommendations': recommendations
        }
    
    def _check_policy_element(self, privacy_policy_results, element):
        """Check if a specific element is present in the privacy policy"""
        try:
            return privacy_policy_results.get('elements', {}).get(element, False)
        except:
            logging.warning(f"Failed to check policy element: {element}")
            return False
    
    def _check_data_security(self, privacy_policy_results):
        """Check if data security measures are mentioned"""
        try:
            return privacy_policy_results.get('elements', {}).get('data_security', False)
        except:
            logging.warning("Failed to check data security")
            return False
    
    def _check_opt_out_mechanism(self):
        """Check for a visible opt-out mechanism"""
        logging.debug("Checking for CCPA opt-out mechanism")
        try:
            if self.browser:
                WebDriverWait(self.browser, 10).until(
                    EC.presence_of_element_located((By.TAG_NAME, 'body'))
                )
                page_source = self.browser.page_source.lower()
                opt_out_keywords = ['do not sell', 'opt-out', 'opt out', 'ccpa', 'privacy rights']
                has_opt_out = any(keyword in page_source for keyword in opt_out_keywords)
                
                opt_out_links = self.browser.find_elements(By.XPATH,
                    "//a[contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'do not sell') or " +
                    "contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'opt-out') or " +
                    "contains(translate(., 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), 'privacy rights')]"
                )
                
                return has_opt_out or len(opt_out_links) > 0
            return False
        except:
            logging.warning("Failed to check opt-out mechanism")
            return False
    
    def _check_for_ccpa_page(self):
        """Fallback: Check for a CCPA-specific page"""
        logging.debug("Checking for CCPA-specific page")
        common_paths = ['/ccpa', '/privacy', '/privacy-rights', '/do-not-sell']
        for path in common_paths:
            full_url = urljoin(self.url, path)
            try:
                response = requests.head(full_url, timeout=15)
                if response.status_code == 200:
                    logging.info(f"Found CCPA page at {full_url}")
                    return True
            except Exception as e:
                logging.debug(f"Failed to check CCPA path {full_url}: {e}")
        return False
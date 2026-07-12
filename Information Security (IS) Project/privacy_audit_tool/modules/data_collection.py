import re
import json
import logging
from bs4 import BeautifulSoup
from urllib.parse import urlparse, urljoin
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.common.by import By

# Setup logging
logging.basicConfig(level=logging.DEBUG, format='%(asctime)s - %(levelname)s - %(message)s')

class DataCollectionChecker:
    def __init__(self, url, soup, browser=None):
        self.url = url
        self.soup = soup
        self.browser = browser
        self.domain = urlparse(url).netloc
        
    def scan_data_collection(self, cookie_data):
        """Analyze data collection practices"""
        logging.debug(f"Starting data collection scan for {self.url}")
        results = {
            'score': 0,
            'score_class': 'danger',
            'trackers': [],
            'tracker_count': 0,
            'cookies': cookie_data,
            'forms': [],
            'recommendations': []
        }
        
        try:
            tracker_info = self._detect_trackers()
            results['trackers'] = tracker_info['trackers']
            results['tracker_count'] = tracker_info['count']
            logging.info(f"Detected {results['tracker_count']} trackers")
        except Exception as e:
            logging.error(f"Error detecting trackers: {e}")
        
        try:
            results['forms'] = self.detect_forms()
            logging.info(f"Detected {len(results['forms'])} forms")
        except Exception as e:
            logging.error(f"Error detecting forms: {e}")
        
        self.generate_recommendations(results)
        self.calculate_score(results)
        
        logging.debug("Data collection scan completed")
        return results
        
    def _detect_trackers(self):
        """Detect third-party trackers on the site"""
        logging.debug("Detecting trackers")
        results = {
            'count': 0,
            'categories': {
                'advertising': 0,
                'analytics': 0, 
                'social': 0,
                'essential': 0,
                'other': 0
            },
            'trackers': []
        }
        
        if not self.soup:
            logging.warning("No soup available for tracker detection")
            return results
        
        if self.browser:
            try:
                WebDriverWait(self.browser, 10).until(
                    EC.presence_of_element_located((By.TAG_NAME, 'body'))
                )
                page_source = self.browser.page_source
                self.soup = BeautifulSoup(page_source, 'html.parser')
            except:
                logging.warning("Failed to update soup with browser content")
        
        base_domain = self._get_base_domain(self.url)
        
        tracker_domains = {
            'doubleclick.net': 'advertising',
            'googlesyndication.com': 'advertising',
            'adnxs.com': 'advertising',
            'rubiconproject.com': 'advertising',
            'ads': 'advertising',
            'adservice': 'advertising',
            'amazon-adsystem.com': 'advertising',
            'criteo': 'advertising',
            'adroll': 'advertising',
            'taboola': 'advertising',
            'outbrain': 'advertising',
            'pubmatic': 'advertising',
            'openx': 'advertising',
            'casalemedia': 'advertising',
            'google-analytics': 'analytics',
            'googletagmanager': 'analytics',
            'analytics': 'analytics',
            'segment.io': 'analytics',
            'amplitude': 'analytics',
            'hotjar': 'analytics',
            'mouseflow': 'analytics',
            'mixpanel': 'analytics',
            'crazyegg': 'analytics',
            'clarity.ms': 'analytics',
            'fullstory': 'analytics',
            'newrelic': 'analytics',
            'inspectlet': 'analytics',
            'heap': 'analytics',
            'statcounter': 'analytics',
            'matomo': 'analytics',
            'piwik': 'analytics',
            'plausible': 'analytics',
            'partytown': 'analytics',
            'facebook.com': 'social',
            'facebook.net': 'social',
            'fbcdn.net': 'social',
            'instagram.com': 'social',
            'twitter.com': 'social',
            'linkedin.com': 'social',
            'pinterest.com': 'social',
            'reddit.com': 'social',
            'tiktok.com': 'social',
            'snapchat.com': 'social',
            'sharethis': 'social',
            'addthis': 'social',
            'cloudflare': 'essential',
            'cloudfront.net': 'essential',
            'jsdelivr': 'essential',
            'unpkg': 'essential',
            'jquery': 'essential',
            'googleapis.com': 'essential',
        }
        
        external_resources = set()
        
        for script in self.soup.find_all('script', src=True):
            src = script.get('src', '')
            if src and not src.startswith('data:'):
                external_resources.add(self._normalize_url(src))
        
        for link in self.soup.find_all('link', href=True):
            if 'stylesheet' in link.get('rel', []) or link.get('type') == 'text/css':
                href = link.get('href', '')
                if href and not href.startswith('data:'):
                    external_resources.add(self._normalize_url(href))
        
        for img in self.soup.find_all('img', src=True):
            src = img.get('src', '')
            if src and not src.startswith('data:'):
                external_resources.add(self._normalize_url(src))
        
        for iframe in self.soup.find_all('iframe', src=True):
            src = iframe.get('src', '')
            if src and not src.startswith('data:'):
                external_resources.add(self._normalize_url(src))
                
        if self.browser:
            try:
                logs = self.browser.get_log('performance')
                for log in logs:
                    try:
                        log_json = json.loads(log.get('message', '{}'))
                        if 'message' in log_json and 'params' in log_json['message']:
                            params = log_json['message']['params']
                            if 'request' in params and 'url' in params['request']:
                                url = params['request']['url']
                                external_resources.add(self._normalize_url(url))
                    except:
                        pass
            except:
                logging.warning("Browser does not support performance logs")
        
        found_trackers = {}
        
        for url in external_resources:
            resource_domain = self._get_base_domain(url)
            
            if resource_domain == base_domain:
                continue
            
            matched = False
            for tracker_domain, category in tracker_domains.items():
                if tracker_domain in resource_domain:
                    tracker_id = resource_domain
                    
                    if tracker_id not in found_trackers:
                        found_trackers[tracker_id] = {
                            'name': resource_domain,
                            'category': category,
                            'url': url
                        }
                        results['categories'][category] += 1
                        matched = True
                    break
            
            if not matched:
                if any(pattern in resource_domain for pattern in ['track', 'pixel', 'tag', 'stat', 'metric', 'collect', 'beacon']):
                    tracker_id = resource_domain
                    if tracker_id not in found_trackers:
                        found_trackers[tracker_id] = {
                            'name': resource_domain,
                            'category': 'other',
                            'url': url
                        }
                        results['categories']['other'] += 1
        
        results['trackers'] = list(found_trackers.values())
        results['count'] = len(results['trackers'])
        
        return results

    def _normalize_url(self, url):
        """Normalize URL for comparison"""
        if not url:
            return ""
            
        if url.startswith('//'):
            url = 'https:' + url
        elif not url.startswith(('http://', 'https://')):
            url = urljoin(self.url, url)
            
        url = url.split('#')[0].split('?')[0]
        
        return url

    def _get_base_domain(self, url):
        """Extract base domain from URL"""
        try:
            parsed = urlparse(url)
            domain = parsed.netloc or ""
            
            if domain.startswith('www.'):
                domain = domain[4:]
                
            parts = domain.split('.')
            
            if len(parts) > 2:
                if parts[-2] in ['co', 'com', 'org', 'net', 'ac', 'gov', 'edu'] and len(parts[-1]) == 2:
                    return '.'.join(parts[-3:])
                else:
                    return '.'.join(parts[-2:])
            else:
                return domain
        except:
            return ""

    def detect_forms(self):
        """Detect forms and check for consent checkboxes"""
        logging.debug("Detecting forms")
        if self.browser:
            try:
                WebDriverWait(self.browser, 5).until(
                    EC.presence_of_all_elements_located((By.TAG_NAME, 'form'))
                )
                page_source = self.browser.page_source
                self.soup = BeautifulSoup(page_source, 'html.parser')
            except:
                logging.warning("Failed to detect dynamic forms")
        
        forms = []
        if not self.soup:
            logging.warning("No soup available for form detection")
            return forms
        
        form_elements = self.soup.find_all('form')
        sensitive_fields = ['email', 'name', 'phone', 'address', 'password']
        
        for form in form_elements:
            inputs = form.find_all('input')
            sensitive_count = 0
            for input_elem in inputs:
                input_type = input_elem.get('type', '').lower()
                input_name = input_elem.get('name', '').lower()
                if input_type in ['text', 'email', 'tel', 'password'] or any(field in input_name for field in sensitive_fields):
                    sensitive_count += 1
            
            has_consent_checkbox = bool(form.find('input', type='checkbox'))
            form_text = form.get_text().lower()
            
            forms.append({
                'sensitive_fields': sensitive_count,
                'has_consent_checkbox': has_consent_checkbox,
                'text': form_text
            })
        
        return forms
    
    def generate_recommendations(self, results):
        """Generate privacy recommendations based on findings"""
        recommendations = []
        
        if results['tracker_count'] > 10:
            recommendations.append(
                "The website uses a high number of trackers. Consider reducing third-party trackers."
            )
        elif results['tracker_count'] > 5:
            recommendations.append(
                "The website uses a moderate number of trackers. Review which trackers are essential."
            )
            
        ad_trackers = [t for t in results['trackers'] if t['category'] == 'advertising']
        if len(ad_trackers) > 3:
            recommendations.append(
                "Multiple advertising trackers detected. Ensure proper consent mechanisms."
            )
        
        cookies = results['cookies']
        if cookies['total'] > 0:
            if cookies['advertising'] > 0 and cookies['advertising_percent'] > 30:
                recommendations.append(
                    f"A high percentage ({cookies['advertising_percent']}%) of cookies are for advertising. "
                    "Implement a cookie consent management system."
                )
            if cookies['unclassified'] > 0 and cookies['unclassified_percent'] > 20:
                recommendations.append(
                    f"Many cookies ({cookies['unclassified_percent']}%) are unclassified. Audit your cookies."
                )
        
        for form in results['forms']:
            if form['sensitive_fields'] > 0 and not form['has_consent_checkbox']:
                recommendations.append(
                    "Forms collecting personal data lack consent checkboxes. Add them with clear explanations."
                )
        
        if not recommendations:
            recommendations.append(
                "Review your privacy policy to reflect current data collection practices."
            )
            recommendations.append(
                "Consider a cookie consent solution to give users more control."
            )
            
        results['recommendations'] = recommendations
    
    def calculate_score(self, results):
        """Calculate privacy score based on trackers, cookies, and forms"""
        base_score = 100
        deductions = 0
        
        if results['tracker_count'] > 15:
            deductions += 40
        elif results['tracker_count'] > 10:
            deductions += 30
        elif results['tracker_count'] > 5:
            deductions += 20
        elif results['tracker_count'] > 2:
            deductions += 10
            
        ad_trackers = [t for t in results['trackers'] if t['category'] == 'advertising']
        if len(ad_trackers) > 5:
            deductions += 25
        elif len(ad_trackers) > 3:
            deductions += 15
        elif len(ad_trackers) > 1:
            deductions += 5
            
        cookies = results['cookies']
        if cookies['total'] > 0:
            if cookies['advertising'] > 15:
                deductions += 20
            elif cookies['advertising'] > 10:
                deductions += 15
            elif cookies['advertising'] > 5:
                deductions += 10
            elif cookies['advertising'] > 0:
                deductions += 5
            if cookies['unclassified'] > 10:
                deductions += 15
            elif cookies['unclassified'] > 5:
                deductions += 10
            elif cookies['unclassified'] > 0:
                deductions += 5
            if not cookies['consent']['compliant']:
                deductions += 10
        
        for form in results['forms']:
            if form['sensitive_fields'] > 0 and not form['has_consent_checkbox']:
                deductions += 10
                
        final_score = max(0, base_score - deductions)
        results['score'] = final_score
        
        if final_score >= 80:
            results['score_class'] = 'good'
        elif final_score >= 60:
            results['score_class'] = 'warning' 
        else:
            results['score_class'] = 'danger'
        logging.debug(f"Data collection score: {final_score}")
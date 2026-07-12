import os
import datetime
import logging
from reportlab.lib import colors
from reportlab.lib.pagesizes import letter
from reportlab.platypus import SimpleDocTemplate, Paragraph, Spacer, Table, TableStyle
from reportlab.lib.styles import getSampleStyleSheet, ParagraphStyle
from reportlab.lib.units import inch

# Setup logging
logging.basicConfig(
    level=logging.DEBUG,
    format='%(asctime)s - %(levelname)s - %(message)s',
    handlers=[
        logging.FileHandler('report_generator.log'),
        logging.StreamHandler()
    ]
)

def validate_results_for_pdf(results):
    """Validate and sanitize results dictionary for PDF generation"""
    try:
        required_fields = {
            'url': str,
            'overall_score': int,
            'rating': str,
            'overall_score_class': str,
            'privacy_policy': dict,
            'gdpr': dict,
            'ccpa': dict,
            'data_collection': dict,
            'form_security': dict,
            'sql_injection': dict,
            'ssl_security': dict
        }
        
        for field, field_type in required_fields.items():
            if field not in results:
                logging.warning(f"Missing field {field} in results, initializing with default")
                results[field] = {} if field_type == dict else ""
            elif not isinstance(results[field], field_type):
                logging.warning(f"Invalid type for {field}, converting to {field_type}")
                results[field] = {} if field_type == dict else str(results[field])
        
        # Ensure nested fields exist
        for category in ['privacy_policy', 'gdpr', 'ccpa', 'data_collection', 'form_security', 'sql_injection', 'ssl_security']:
            if not results[category]:
                results[category] = {
                    'score': 0,
                    'score_class': 'danger',
                    'recommendations': [],
                    'checks': {} if category in ['gdpr', 'ccpa'] else None,
                    'cookies': {'total': 0, 'necessary': 0, 'functional': 0, 'analytics': 0, 'advertising': 0, 'unclassified': 0} if category == 'data_collection' else None,
                    'trackers': [] if category == 'data_collection' else None,
                    'certificate': {'valid': False, 'issuer': 'Unknown', 'expiry': 'Unknown', 'days_to_expiry': 0} if category == 'ssl_security' else None,
                    'security_headers': {} if category == 'ssl_security' else None,
                    'secure_cookies': {'total_cookies': 0, 'secure_cookies': 0, 'httponly_cookies': 0} if category == 'ssl_security' else None,
                    'insecure_content': {'mixed_content_found': False} if category == 'ssl_security' else None
                }
        
        return results
    except Exception as e:
        logging.error(f"Error validating results for PDF: {str(e)}")
        return results

def generate_pdf_report(results, output_path):
    """Generate PDF report using ReportLab"""
    try:
        # Validate and sanitize results
        results = validate_results_for_pdf(results)
        
        doc = SimpleDocTemplate(
            output_path,
            pagesize=letter,
            rightMargin=0.75*inch,
            leftMargin=0.75*inch,
            topMargin=0.75*inch,
            bottomMargin=0.75*inch
        )
        
        styles = getSampleStyleSheet()
        story = []

        # Custom styles
        title_style = ParagraphStyle(
            'TitleStyle',
            parent=styles['Heading1'],
            fontSize=18,
            spaceAfter=12,
            textColor=colors.HexColor('#4267b2')
        )
        
        heading_style = ParagraphStyle(
            'HeadingStyle',
            parent=styles['Heading2'],
            fontSize=14,
            spaceBefore=12,
            spaceAfter=8,
            textColor=colors.HexColor('#2c3e50')
        )
        
        subheading_style = ParagraphStyle(
            'SubHeadingStyle',
            parent=styles['Heading3'],
            fontSize=12,
            spaceBefore=10,
            spaceAfter=6
        )
        
        body_style = ParagraphStyle(
            'BodyStyle',
            parent=styles['BodyText'],
            fontSize=10,
            spaceAfter=6
        )

        # Title
        current_date = datetime.datetime.now().strftime("%B %d, %Y")
        story.append(Paragraph("Website Privacy Audit Report", title_style))
        story.append(Spacer(1, 0.2*inch))
        story.append(Paragraph(f"Generated: {current_date}", body_style))
        story.append(Paragraph(f"Website: {results['url']}", body_style))
        story.append(Spacer(1, 0.3*inch))

        # Executive Summary
        story.append(Paragraph("Executive Summary", heading_style))
        story.append(Paragraph(f"Overall Privacy Rating: {results['rating']} ({results['overall_score']}/100)", body_style))
        story.append(Paragraph(
            "This report assesses the privacy practices of the website, including privacy policy, GDPR/CCPA compliance, and data collection practices.",
            body_style
        ))
        
        # Key Findings
        story.append(Paragraph("Key Findings", subheading_style))
        findings = [
            f"Privacy Policy Score: {results['privacy_policy']['score']}/100 ({results['privacy_policy']['score_class']})",
            f"GDPR Compliance Score: {results['gdpr']['score']}/100 ({results['gdpr']['score_class']})",
            f"CCPA Compliance Score: {results['ccpa']['score']}/100 ({results['ccpa']['score_class']})",
            f"Data Collection Score: {results['data_collection']['score']}/100 ({results['data_collection']['score_class']})"
        ]
        for finding in findings:
            story.append(Paragraph(f"• {finding}", body_style))

        # Privacy Policy Analysis
        story.append(Paragraph("Privacy Policy Analysis", heading_style))
        story.append(Paragraph(f"Found: {'Yes' if results['privacy_policy'].get('found', False) else 'No'}", body_style))
        story.append(Paragraph(f"Last Updated: {results['privacy_policy'].get('last_updated', 'Not found')}", body_style))
        story.append(Paragraph("Recommendations:", subheading_style))
        for rec in results['privacy_policy'].get('recommendations', []):
            story.append(Paragraph(f"• {rec}", body_style))

        # GDPR Compliance
        story.append(Paragraph("GDPR Compliance", heading_style))
        gdpr_data = [[check['description'], '✓' if check['check'] else '✗'] for check in results['gdpr'].get('checks', {}).values()]
        gdpr_table = Table([['Check', 'Status']] + gdpr_data)
        gdpr_table.setStyle(TableStyle([
            ('BACKGROUND', (0, 0), (-1, 0), colors.HexColor('#f2f2f2')),
            ('GRID', (0, 0), (-1, -1), 1, colors.black),
            ('FONTSIZE', (0, 0), (-1, -1), 10),
            ('VALIGN', (0, 0), (-1, -1), 'MIDDLE'),
            ('ALIGN', (1, 1), (1, -1), 'CENTER')
        ]))
        story.append(gdpr_table)
        story.append(Paragraph("Recommendations:", subheading_style))
        for rec in results['gdpr'].get('recommendations', []):
            story.append(Paragraph(f"• {rec}", body_style))

        # CCPA Compliance
        story.append(Paragraph("CCPA Compliance", heading_style))
        ccpa_data = [[check['description'], '✓' if check['check'] else '✗'] for check in results['ccpa'].get('checks', {}).values()]
        ccpa_table = Table([['Check', 'Status']] + ccpa_data)
        ccpa_table.setStyle(TableStyle([
            ('BACKGROUND', (0, 0), (-1, 0), colors.HexColor('#f2f2f2')),
            ('GRID', (0, 0), (-1, -1), 1, colors.black),
            ('FONTSIZE', (0, 0), (-1, -1), 10),
            ('VALIGN', (0, 0), (-1, -1), 'MIDDLE'),
            ('ALIGN', (1, 1), (1, -1), 'CENTER')
        ]))
        story.append(ccpa_table)
        story.append(Paragraph("Recommendations:", subheading_style))
        for rec in results['ccpa'].get('recommendations', []):
            story.append(Paragraph(f"• {rec}", body_style))

        # Data Collection
        story.append(Paragraph("Data Collection", heading_style))
        story.append(Paragraph(f"Trackers Detected: {results['data_collection'].get('tracker_count', 0)}", body_style))
        story.append(Paragraph(f"Cookies Detected: {results['data_collection']['cookies'].get('total', 0)}", body_style))
        cookies = [
            f"Necessary: {results['data_collection']['cookies'].get('necessary', 0)} ({results['data_collection']['cookies'].get('necessary_percent', 0)}%)",
            f"Functional: {results['data_collection']['cookies'].get('functional', 0)} ({results['data_collection']['cookies'].get('functional_percent', 0)}%)",
            f"Analytics: {results['data_collection']['cookies'].get('analytics', 0)} ({results['data_collection']['cookies'].get('analytics_percent', 0)}%)",
            f"Advertising: {results['data_collection']['cookies'].get('advertising', 0)} ({results['data_collection']['cookies'].get('advertising_percent', 0)}%)",
            f"Unclassified: {results['data_collection']['cookies'].get('unclassified', 0)} ({results['data_collection']['cookies'].get('unclassified_percent', 0)}%)"
        ]
        for cookie in cookies:
            story.append(Paragraph(f"• {cookie}", body_style))
        story.append(Paragraph(f"Cookie Consent: {results['data_collection']['cookies'].get('consent', {}).get('details', 'Not available')}", body_style))
        story.append(Paragraph("Recommendations:", subheading_style))
        for rec in results['data_collection'].get('recommendations', []):
            story.append(Paragraph(f"• {rec}", body_style))

        # SSL/TLS & Network Security
        story.append(Paragraph("SSL/TLS & Network Security", heading_style))
        story.append(Paragraph(f"HTTPS Enabled: {'✓ Yes' if results['ssl_security'].get('https_enabled', False) else '✗ No'}", body_style))
        story.append(Paragraph(f"SSL Certificate Valid: {'✓ Yes' if results['ssl_security']['certificate'].get('valid', False) else '✗ No'}", body_style))
        story.append(Paragraph(f"Certificate Issuer: {results['ssl_security']['certificate'].get('issuer', 'Unknown')}", body_style))
        story.append(Paragraph(f"Certificate Expiry: {results['ssl_security']['certificate'].get('expiry', 'Unknown')} "
                             f"({results['ssl_security']['certificate'].get('days_to_expiry', 0)} days remaining)", body_style))

        # Security Headers
        story.append(Paragraph("Security Headers", subheading_style))
        headers_data = [
            ['HTTP Strict Transport Security (HSTS)', '✓ Enabled' if results['ssl_security']['security_headers'].get('hsts', False) else '✗ Not Enabled'],
            ['Content Security Policy', '✓ Enabled' if results['ssl_security']['security_headers'].get('content_security_policy', False) else '✗ Not Enabled'],
            ['X-Content-Type-Options', '✓ Enabled' if results['ssl_security']['security_headers'].get('x_content_type_options', False) else '✗ Not Enabled'],
            ['X-Frame-Options', '✓ Enabled' if results['ssl_security']['security_headers'].get('x_frame_options', False) else '✗ Not Enabled'],
            ['X-XSS-Protection', '✓ Enabled' if results['ssl_security']['security_headers'].get('x_xss_protection', False) else '✗ Not Enabled'],
            ['Referrer-Policy', '✓ Enabled' if results['ssl_security']['security_headers'].get('referrer_policy', False) else '✗ Not Enabled']
        ]
        headers_table = Table([['Header', 'Status']] + headers_data)
        headers_table.setStyle(TableStyle([
            ('BACKGROUND', (0, 0), (-1, 0), colors.HexColor('#f2f2f2')),
            ('GRID', (0, 0), (-1, -1), 1, colors.black),
            ('FONTSIZE', (0, 0), (-1, -1), 10)
        ]))
        story.append(headers_table)

        # Cookie Security
        story.append(Paragraph("Cookie Security", subheading_style))
        story.append(Paragraph(f"Total Cookies: {results['ssl_security']['secure_cookies'].get('total_cookies', 0)}", body_style))
        story.append(Paragraph(f"Secure Cookies: {results['ssl_security']['secure_cookies'].get('secure_cookies', 0)}", body_style))
        story.append(Paragraph(f"HttpOnly Cookies: {results['ssl_security']['secure_cookies'].get('httponly_cookies', 0)}", body_style))

        # Mixed Content
        mixed_content_text = "✓ No mixed content detected" if not results['ssl_security']['insecure_content'].get('mixed_content_found', False) else "✗ Mixed content detected"
        story.append(Paragraph("Mixed Content", subheading_style))
        story.append(Paragraph(mixed_content_text, body_style))

        # Recommendations
        story.append(Paragraph("Recommendations:", subheading_style))
        for rec in results['ssl_security'].get('recommendations', []):
            story.append(Paragraph(f"• {rec}", body_style))

        # Footer
        story.append(Spacer(1, 0.5*inch))
        story.append(Paragraph("Generated by Website Privacy Audit Tool", body_style))
        story.append(Paragraph("Information Security Semester Project", body_style))

        doc.build(story)
        logging.info(f"PDF report successfully generated at {output_path}")
        return True
    except Exception as e:
        logging.error(f"Failed to generate PDF report: {str(e)}")
        return False

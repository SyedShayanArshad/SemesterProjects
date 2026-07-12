from flask import Flask, render_template, request, redirect, url_for, make_response
from buffer import Buffer
import pyodbc
import random
import json
import datetime
import io
from reportlab.lib.pagesizes import letter
from reportlab.platypus import SimpleDocTemplate, Table, TableStyle, Paragraph, Spacer
from reportlab.lib import colors
from reportlab.lib.styles import getSampleStyleSheet, ParagraphStyle
from reportlab.lib.units import inch

app = Flask(__name__)

# Add a custom date filter for Jinja2 templates
@app.template_filter('date')
def date_filter(value, format="%H:%M:%S"):
    if isinstance(value, str) and value.lower() == "now":
        return datetime.datetime.now().strftime(format)
    return datetime.datetime.now().strftime(format)

SERVER = "USER-O0RKKSSBLQ\\SQLEXPRESS"
DATABASE = "BufferDB"
conn_str = f"DRIVER={{SQL Server}};SERVER={SERVER};DATABASE={DATABASE};Trusted_Connection=yes;"

# Define helper functions before initialization
def policy_to_number(policy):
    if policy == "LRU":
        return 0
    elif policy == "MRU":
        return 1
    elif policy == "LFU":
        return 2
    return 0

def workload_to_number(workload_type):
    workload_map = {
        "unknown": 0,
        "read-heavy-repetitive": 1,
        "read-heavy-diverse": 2,
        "write-heavy": 3,
        "mixed-diverse": 4,
        "mixed-repetitive": 5
    }
    return workload_map.get(workload_type, 0)

# Initialize global variables
def initialize_app():
    global buffer, policy_history, workload_history
    buffer = Buffer(size=0)  # Default size set to 0
    policy_history = [policy_to_number(buffer.policy)]
    workload_history = [workload_to_number(buffer.workload_type)]
    buffer.log("🆕 Application initialized with fresh state")

# Call initialization after defining all functions
initialize_app()

def get_db_connection():
    try:
        return pyodbc.connect(conn_str)
    except pyodbc.Error as e:
        print(f"Database connection error: {e}")
        return None

def get_pages_from_db():
    try:
        conn = get_db_connection()
        if conn:
            cursor = conn.cursor()
            cursor.execute("SELECT PageID FROM Pages")
            pages = [row.PageID for row in cursor.fetchall()]
            cursor.close()
            conn.close()
            return pages
        return list(range(1, 21))
    except:
        return list(range(1, 21))

@app.route('/', methods=['GET', 'POST'])
def index():
    global buffer, policy_history, workload_history
    result = []
    stats = {}
    current_run_stats = None
    
    # If buffer is not initialized or invalid, reset it
    if not buffer or not hasattr(buffer, 'size'):
        buffer = Buffer(size=0)  # Default size set to 0
        policy_history = [policy_to_number(buffer.policy)]
        workload_history = [workload_to_number(buffer.workload_type)]
        buffer.log("🆕 Buffer initialized on first load")
    
    if request.method == 'POST':
        run_count = int(request.form.get('run_count', 10))
        cache_size = int(request.form.get('cache_size', 5))
        
        # Ensure cache size is at least 1 for operations
        if cache_size < 1 and run_count > 0:
            cache_size = 5  # Default if invalid and we need to run operations
            
        # If cache size changed, reset the buffer completely
        if buffer.size != cache_size:
            buffer = Buffer(size=cache_size)
            policy_history = [policy_to_number(buffer.policy)]
            workload_history = [workload_to_number(buffer.workload_type)]
            buffer.log(f"🔧 Buffer resized to {cache_size}")
            
        # Store hit/miss counts BEFORE running the simulation
        previous_hits = buffer.hit_count
        previous_misses = buffer.miss_count
        
        if run_count > 0:
            all_pages = get_pages_from_db()
            # Make sure we have enough unique pages for larger cache sizes
            if len(all_pages) < cache_size * 2:
                # Generate more pages if needed
                additional_pages = list(range(max(all_pages) + 1, max(all_pages) + 1 + cache_size * 2))
                all_pages.extend(additional_pages)
                
            test_pattern = [random.choice(all_pages) for _ in range(run_count)]
            
            # Track hits/misses specifically for this run
            run_hits = 0
            run_misses = 0
            
            for i, page_id in enumerate(test_pattern):
                # Track if this access was a hit or miss
                operation = "read" if random.random() > 0.3 else "write"
                is_hit = buffer.access_page(page_id, operation)
                
                # Update local hit/miss counters for this run only
                if is_hit:
                    run_hits += 1
                else:
                    run_misses += 1
                    
                if (i+1) % 5 == 0:
                    buffer.switch_policy()
                    buffer.analyze_workload()
                    policy_history.append(policy_to_number(buffer.policy))
                    workload_history.append(workload_to_number(buffer.workload_type))
            
            # Calculate hit rate for this run
            run_hit_rate = (run_hits / run_count * 100) if run_count > 0 else 0
            
            # Create current run stats
            current_run_stats = {
                'operations': run_count,
                'hits': run_hits,
                'misses': run_misses,
                'hit_rate': run_hit_rate,
                'verified_hits': buffer.hit_count - previous_hits,
                'verified_misses': buffer.miss_count - previous_misses
            }
            
            # Log the results with actual counts from the buffer
            buffer.log(f"📊 This run: {run_count} operations")
            buffer.log(f"  - Hits: {run_hits} (direct count) / {buffer.hit_count - previous_hits} (from buffer)")
            buffer.log(f"  - Misses: {run_misses} (direct count) / {buffer.miss_count - previous_misses} (from buffer)")
            buffer.log(f"  - Hit rate: {run_hit_rate:.1f}%")
            buffer.log(f"  - Cache size: {cache_size}, Current buffer length: {len(buffer.buffer)}")
            
            result = test_pattern
    
    # Get overall stats from buffer
    stats = buffer.stats()
    
    # Add current run info if available
    if current_run_stats:
        stats['current_run'] = current_run_stats
    
    if not policy_history:
        policy_history = [policy_to_number(buffer.policy)]
    if not workload_history:
        workload_history = [workload_to_number(buffer.workload_type)]
    
    return render_template(
        "index.html",
        result=result,
        stats=stats,
        policy_data=policy_history,
        workload_data=workload_history,
        current_run=bool(current_run_stats)  # Flag to indicate if we have current run data
    )

@app.route('/reset', methods=['GET', 'POST'])
def reset_cache():
    global buffer, policy_history, workload_history
    
    cache_size = int(request.form.get('cache_size', 0)) if request.method == 'POST' else 0  # Default to 0
    buffer = Buffer(size=cache_size)
    policy_history = [policy_to_number(buffer.policy)]
    workload_history = [workload_to_number(buffer.workload_type)]
    
    buffer.log(f"🔄 Buffer reset with size {cache_size}")
    return redirect(url_for('index'))

@app.route('/workload', methods=['POST'])
def run_workload():
    global buffer, policy_history, workload_history
    workload_type = request.form.get('type', 'random')
    run_count = int(request.form.get('run_count', 20))
    
    # Store previous hit/miss counts to track changes from this run
    previous_hits = buffer.hit_count
    previous_misses = buffer.miss_count
    
    all_pages = get_pages_from_db()
    
    # Track hits/misses for current run
    current_run_hits = 0
    current_run_misses = 0
    test_pattern = []
    operations = []
    
    # Create the workload pattern based on type
    if workload_type == 'read-heavy':
        repeated_pages = all_pages[:3] if len(all_pages) >= 3 else all_pages
        for _ in range(run_count):
            if random.random() < 0.8:
                test_pattern.append(random.choice(repeated_pages))
            else:
                test_pattern.append(random.choice(all_pages))
        
        operations = ["read"] * int(run_count * 0.9) + ["write"] * int(run_count * 0.1)
        random.shuffle(operations)
        buffer.log(f"📊 Starting Read-Heavy Workload Simulation ({run_count} accesses)")
        
    elif workload_type == 'write-heavy':
        for _ in range(run_count):
            if random.random() < 0.7:
                test_pattern.append(max(all_pages) + random.randint(1, 10))
            else:
                test_pattern.append(random.choice(all_pages))
                
        operations = ["read"] * int(run_count * 0.2) + ["write"] * int(run_count * 0.8)
        random.shuffle(operations)
        buffer.log(f"📊 Starting Write-Heavy Workload Simulation ({run_count} accesses)")
        
    elif workload_type == 'repeated':
        repeated_pages = random.sample(all_pages, min(3, len(all_pages)))
        for _ in range(run_count):
            if random.random() < 0.9:
                if random.random() < 0.6:
                    test_pattern.append(repeated_pages[0])
                else:
                    test_pattern.append(random.choice(repeated_pages[1:]))
            else:
                test_pattern.append(random.choice(all_pages))
                
        operations = ["read"] * int(run_count * 0.7) + ["write"] * int(run_count * 0.3)
        random.shuffle(operations)
        buffer.log(f"📊 Starting Repeated Access Workload Simulation ({run_count} accesses)")
        
    else:
        test_pattern = [random.choice(all_pages) for _ in range(run_count)]
        operations = ["read"] * int(run_count * 0.5) + ["write"] * int(run_count * 0.5)
        random.shuffle(operations)
        buffer.log(f"📊 Starting Random Workload Simulation ({run_count} accesses)")
    
    # Execute the operations and track hits and misses
    for i, page_id in enumerate(test_pattern):
        operation = operations[i % len(operations)]
        # Track if this access was a hit or miss
        is_hit = buffer.access_page(page_id, operation)
        if is_hit:
            current_run_hits += 1
        else:
            current_run_misses += 1
            
        policy_history.append(policy_to_number(buffer.policy))
        workload_history.append(workload_to_number(buffer.workload_type))
    
    # Verify the hits/misses by checking the buffer directly
    actual_hits = buffer.hit_count - previous_hits
    actual_misses = buffer.miss_count - previous_misses
    
    # Log the results with both count methods for verification
    run_hit_rate = (current_run_hits/run_count*100) if run_count > 0 else 0
    buffer.log(f"📊 {workload_type} workload: {run_count} operations")
    buffer.log(f"  - Hits: {current_run_hits} (direct count) / {actual_hits} (from buffer)")
    buffer.log(f"  - Misses: {current_run_misses} (direct count) / {actual_misses} (from buffer)")
    buffer.log(f"  - Hit rate: {run_hit_rate:.1f}%")
    
    return redirect(url_for('index'))

@app.route('/test_lfu', methods=['GET'])
def test_lfu():
    """Special route to directly test LFU eviction"""
    global buffer
    
    # Reset and setup a buffer with small size
    buffer = Buffer(size=3)
    buffer.set_policy("LFU")
    
    # Create a pattern where page 1 is accessed 3 times, pages 2 and 3 once each
    buffer.access_page(1, "read")
    buffer.access_page(1, "read")
    buffer.access_page(1, "read")
    buffer.access_page(2, "read")
    buffer.access_page(3, "read")
    
    # Now page 4 should evict either page 2 or 3 (both have count 1)
    buffer.access_page(4, "read")
    
    # Now page 5 should evict the remaining page with count 1
    buffer.access_page(5, "read")
    
    # Pages 1, 4, 5 should be in buffer
    buffer.log(f"After LFU test: buffer contains {buffer.buffer}")
    return redirect(url_for('index'))

@app.route('/force_policy/<policy>', methods=['GET'])
def force_policy(policy):
    """Force a specific replacement policy"""
    global buffer
    if buffer.set_policy(policy):
        return f"Policy changed to {policy}", 200
    return "Invalid policy", 400

@app.route('/verify_counts', methods=['GET'])
def verify_counts():
    """Verify that access counts are being tracked correctly"""
    global buffer
    
    # Log current buffer state for debugging
    buffer.log(f"🔍 Verifying access counts for all pages")
    
    # Create a test page access pattern
    test_page = 999  # Use a unique page number
    
    # Access the test page multiple times and verify count increases
    buffer.log(f"Testing access count tracking with page {test_page}")
    buffer.log(f"Initial count: {buffer.access_count.get(test_page, 0)}")
    
    # First access should be a miss and set count to 1
    is_hit = buffer.access_page(test_page, "read")
    buffer.log(f"1st access: Hit={is_hit}, Count={buffer.access_count.get(test_page, 0)}")
    
    # Second access should be a hit and increase count to 2
    is_hit = buffer.access_page(test_page, "read")
    buffer.log(f"2nd access: Hit={is_hit}, Count={buffer.access_count.get(test_page, 0)}")
    
    # Third access should be a hit and increase count to 3
    is_hit = buffer.access_page(test_page, "read")
    buffer.log(f"3rd access: Hit={is_hit}, Count={buffer.access_count.get(test_page, 0)}")
    
    # Verify current buffer content
    buffer_access_counts = [(p, buffer.access_count.get(p, 0)) for p in buffer.buffer]
    buffer.log(f"Current buffer content with access counts: {buffer_access_counts}")
    
    return redirect(url_for('index'))

@app.route('/logs')
def logs():
    # Get the same stats you're using for the index page
    stats = buffer.stats()  # Retrieve statistics from the buffer object
    return render_template('logs.html', stats=stats)

@app.route('/download_eviction_history')
def download_eviction_history():
    """Generate and download eviction history as PDF"""
    global buffer
    
    # Create a file-like buffer to receive PDF data
    buffer_bytes = io.BytesIO()
    
    # Create the PDF document
    pdf = SimpleDocTemplate(
        buffer_bytes,
        pagesize=letter,
        rightMargin=72,
        leftMargin=72,
        topMargin=72,
        bottomMargin=18
    )
    
    # Container for the elements to add to the PDF
    elements = []
    
    # Define styles
    styles = getSampleStyleSheet()
    title_style = styles["Heading1"]
    subtitle_style = styles["Heading2"]
    normal_style = styles["Normal"]
    
    # Add title
    elements.append(Paragraph("Adaptive Buffer Management System", title_style))
    elements.append(Paragraph("Eviction History Report", subtitle_style))
    elements.append(Spacer(1, 0.25*inch))
    
    # Add generation date/time
    current_time = datetime.datetime.now().strftime("%Y-%m-%d %H:%M:%S")
    elements.append(Paragraph(f"Generated: {current_time}", normal_style))
    elements.append(Spacer(1, 0.25*inch))
    
    # Buffer stats summary
    stats = buffer.stats()
    elements.append(Paragraph("Buffer Statistics Summary", styles["Heading3"]))
    
    stats_data = [
        ["Buffer Size", f"{stats['size']}"],
        ["Current Policy", f"{stats['policy']}"],
        ["Hit Rate", f"{(stats['hit_rate']):.2f}%"],
        ["Workload Type", f"{stats['workload_type']}"],
        ["Total Evictions", f"{stats['eviction_counts']['LRU'] + stats['eviction_counts']['MRU'] + stats['eviction_counts']['LFU']}"],
    ]
    
    stats_table = Table(stats_data, colWidths=[2*inch, 3*inch])
    stats_table.setStyle(TableStyle([
        ('BACKGROUND', (0, 0), (0, -1), colors.lightgrey),
        ('TEXTCOLOR', (0, 0), (0, -1), colors.black),
        ('ALIGN', (0, 0), (0, -1), 'LEFT'),
        ('FONTNAME', (0, 0), (0, -1), 'Helvetica-Bold'),
        ('FONTSIZE', (0, 0), (0, -1), 10),
        ('BOTTOMPADDING', (0, 0), (-1, -1), 6),
        ('GRID', (0, 0), (-1, -1), 1, colors.black)
    ]))
    elements.append(stats_table)
    elements.append(Spacer(1, 0.25*inch))
    
    # Eviction counts by policy
    elements.append(Paragraph("Evictions by Policy", styles["Heading3"]))
    
    eviction_data = [
        ["Policy", "Count", "Percentage"],
        ["LRU", f"{stats['eviction_counts']['LRU']}", ""],
        ["MRU", f"{stats['eviction_counts']['MRU']}", ""],
        ["LFU", f"{stats['eviction_counts']['LFU']}", ""]
    ]
    
    # Calculate percentages - Fix the format specifier issue here
    total_evictions = stats['eviction_counts']['LRU'] + stats['eviction_counts']['MRU'] + stats['eviction_counts']['LFU']
    if total_evictions > 0:
        # Remove the extra colon in the format specifier
        eviction_data[1][2] = f"{(stats['eviction_counts']['LRU'] / total_evictions * 100):.1f}%"
        eviction_data[2][2] = f"{(stats['eviction_counts']['MRU'] / total_evictions * 100):.1f}%"
        eviction_data[3][2] = f"{(stats['eviction_counts']['LFU'] / total_evictions * 100):.1f}%"
    
    eviction_table = Table(eviction_data, colWidths=[1.5*inch, 1.5*inch, 1.5*inch])
    eviction_table.setStyle(TableStyle([
        ('BACKGROUND', (0, 0), (-1, 0), colors.grey),
        ('TEXTCOLOR', (0, 0), (-1, 0), colors.whitesmoke),
        ('ALIGN', (0, 0), (-1, 0), 'CENTER'),
        ('FONTNAME', (0, 0), (-1, 0), 'Helvetica-Bold'),
        ('FONTSIZE', (0, 0), (-1, 0), 12),
        ('BOTTOMPADDING', (0, 0), (-1, 0), 12),
        ('BACKGROUND', (0, 1), (-1, -1), colors.beige),
        ('GRID', (0, 0), (-1, -1), 1, colors.black)
    ]))
    elements.append(eviction_table)
    elements.append(Spacer(1, 0.25*inch))
    
    # Eviction history table
    elements.append(Paragraph("Detailed Eviction History", styles["Heading3"]))
    
    if stats['eviction_history'] and len(stats['eviction_history']) > 0:
        # Create table headers
        eviction_history_data = [["#", "Page ID", "Policy", "Access Count", "Reason"]]
        
        # Add eviction history rows (limit to most recent 50 to keep PDF manageable)
        for i, eviction in enumerate(reversed(stats['eviction_history'][-50:])):
            eviction_history_data.append([
                str(i+1),
                str(eviction['page']),
                str(eviction['policy']),
                str(eviction['access_count']),
                str(eviction['reason'])
            ])
        
        # Create table
        history_table = Table(eviction_history_data, colWidths=[0.5*inch, 1*inch, 1*inch, 1*inch, 3*inch])
        history_table.setStyle(TableStyle([
            ('BACKGROUND', (0, 0), (-1, 0), colors.darkblue),
            ('TEXTCOLOR', (0, 0), (-1, 0), colors.whitesmoke),
            ('ALIGN', (0, 0), (-1, 0), 'CENTER'),
            ('FONTNAME', (0, 0), (-1, 0), 'Helvetica-Bold'),
            ('FONTSIZE', (0, 0), (-1, 0), 10),
            ('BOTTOMPADDING', (0, 0), (-1, 0), 12),
            ('BACKGROUND', (0, 1), (-1, -1), colors.white),
            ('GRID', (0, 0), (-1, -1), 1, colors.black),
            ('FONTNAME', (0, 1), (-1, -1), 'Helvetica'),
            ('FONTSIZE', (0, 1), (-1, -1), 8),
            ('ALIGN', (0, 0), (0, -1), 'CENTER'),
            ('VALIGN', (0, 0), (-1, -1), 'MIDDLE'),
        ]))
        elements.append(history_table)
    else:
        elements.append(Paragraph("No eviction history available.", normal_style))
    
    # Build the PDF document
    pdf.build(elements)
    
    # Get the value of the BytesIO buffer and write it to the response
    pdf_data = buffer_bytes.getvalue()
    buffer_bytes.close()
    
    # Create response
    response = make_response(pdf_data)
    response.headers['Content-Type'] = 'application/pdf'
    response.headers['Content-Disposition'] = 'attachment; filename=eviction_history.pdf'
    
    return response

@app.after_request
def add_header(response):
    response.headers["Cache-Control"] = "no-cache, no-store, must-revalidate"
    response.headers["Pragma"] = "no-cache"
    response.headers["Expires"] = "0"
    return response

if __name__ == "__main__":
    print("Starting Buffer Management System...")
    print("Open your browser and navigate to http://127.0.0.1:5000")
    initialize_app()
    app.run(debug=True, port=5000)


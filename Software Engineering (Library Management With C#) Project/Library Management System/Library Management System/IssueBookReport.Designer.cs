namespace Library_Management_System
{
    partial class IssueBookReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnIssueBook = new Button();
            label2 = new Label();
            panel1 = new Panel();
            btnResetFilter = new Button();
            btnBookTitle = new Button();
            btnSelectRollNo = new Button();
            cbBookTitle = new ComboBox();
            label4 = new Label();
            cbRollNo = new ComboBox();
            label8 = new Label();
            label1 = new Label();
            dgvIssuedBooks = new DataGridView();
            RollNo = new DataGridViewTextBoxColumn();
            BookTitle = new DataGridViewTextBoxColumn();
            IssuedDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            btnAddStudent = new Button();
            btnHome = new Button();
            btnReturnBook = new Button();
            btnStudentReport = new Button();
            btnLogout = new Button();
            btnBookReport = new Button();
            btnAddBook = new Button();
            btnAddDepartment = new Button();
            btnIssueReport = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssuedBooks).BeginInit();
            SuspendLayout();
            // 
            // btnIssueBook
            // 
            btnIssueBook.BackColor = Color.DarkGreen;
            btnIssueBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.Location = new Point(13, 461);
            btnIssueBook.Margin = new Padding(3, 4, 3, 4);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(225, 45);
            btnIssueBook.TabIndex = 57;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(82, 11);
            label2.Name = "label2";
            label2.Padding = new Padding(80, 10, 80, 10);
            label2.Size = new Size(916, 57);
            label2.TabIndex = 62;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnResetFilter);
            panel1.Controls.Add(btnBookTitle);
            panel1.Controls.Add(btnSelectRollNo);
            panel1.Controls.Add(cbBookTitle);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbRollNo);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dgvIssuedBooks);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 60;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.Green;
            btnResetFilter.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetFilter.Location = new Point(15, 161);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(110, 37);
            btnResetFilter.TabIndex = 59;
            btnResetFilter.Text = "Reset Filter";
            btnResetFilter.UseVisualStyleBackColor = false;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnBookTitle
            // 
            btnBookTitle.BackColor = Color.Green;
            btnBookTitle.Location = new Point(610, 150);
            btnBookTitle.Name = "btnBookTitle";
            btnBookTitle.Size = new Size(97, 37);
            btnBookTitle.TabIndex = 55;
            btnBookTitle.Text = "View";
            btnBookTitle.UseVisualStyleBackColor = false;
            btnBookTitle.Click += btnBookTitle_Click_1;
            // 
            // btnSelectRollNo
            // 
            btnSelectRollNo.BackColor = Color.Green;
            btnSelectRollNo.Location = new Point(255, 150);
            btnSelectRollNo.Name = "btnSelectRollNo";
            btnSelectRollNo.Size = new Size(97, 37);
            btnSelectRollNo.TabIndex = 54;
            btnSelectRollNo.Text = "View";
            btnSelectRollNo.UseVisualStyleBackColor = false;
            btnSelectRollNo.Click += btnSelectRollNo_Click_1;
            // 
            // cbBookTitle
            // 
            cbBookTitle.Font = new Font("Arial Rounded MT Bold", 10F);
            cbBookTitle.FormattingEnabled = true;
            cbBookTitle.Location = new Point(566, 97);
            cbBookTitle.Name = "cbBookTitle";
            cbBookTitle.Size = new Size(207, 31);
            cbBookTitle.TabIndex = 53;
            cbBookTitle.SelectedIndexChanged += cbBookTitle_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 11F);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(426, 102);
            label4.Name = "label4";
            label4.Size = new Size(133, 26);
            label4.TabIndex = 52;
            label4.Text = "Book Title :";
            // 
            // cbRollNo
            // 
            cbRollNo.Font = new Font("Arial Rounded MT Bold", 10F);
            cbRollNo.FormattingEnabled = true;
            cbRollNo.Location = new Point(213, 97);
            cbRollNo.Name = "cbRollNo";
            cbRollNo.Size = new Size(207, 31);
            cbRollNo.TabIndex = 51;
            cbRollNo.SelectedIndexChanged += cbRollNo_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 11F);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(15, 102);
            label8.Name = "label8";
            label8.Size = new Size(192, 26);
            label8.TabIndex = 50;
            label8.Text = "Student Roll No :";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(758, 51);
            label1.TabIndex = 29;
            label1.Text = "Issued Books Report";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvIssuedBooks
            // 
            dgvIssuedBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssuedBooks.BackgroundColor = Color.Green;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvIssuedBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvIssuedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIssuedBooks.Columns.AddRange(new DataGridViewColumn[] { RollNo, BookTitle, IssuedDate, DueDate });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvIssuedBooks.DefaultCellStyle = dataGridViewCellStyle4;
            dgvIssuedBooks.Location = new Point(15, 204);
            dgvIssuedBooks.Name = "dgvIssuedBooks";
            dgvIssuedBooks.ReadOnly = true;
            dgvIssuedBooks.RowHeadersVisible = false;
            dgvIssuedBooks.RowHeadersWidth = 62;
            dgvIssuedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIssuedBooks.Size = new Size(758, 400);
            dgvIssuedBooks.TabIndex = 28;
            // 
            // RollNo
            // 
            RollNo.HeaderText = "Roll No";
            RollNo.MinimumWidth = 8;
            RollNo.Name = "RollNo";
            RollNo.ReadOnly = true;
            // 
            // BookTitle
            // 
            BookTitle.HeaderText = "Book Title";
            BookTitle.MinimumWidth = 8;
            BookTitle.Name = "BookTitle";
            BookTitle.ReadOnly = true;
            // 
            // IssuedDate
            // 
            IssuedDate.HeaderText = "Issued Date";
            IssuedDate.MinimumWidth = 8;
            IssuedDate.Name = "IssuedDate";
            IssuedDate.ReadOnly = true;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.MinimumWidth = 8;
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.DarkGreen;
            btnAddStudent.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(13, 331);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(225, 45);
            btnAddStudent.TabIndex = 55;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.DarkGreen;
            btnHome.Font = new Font("Arial Rounded MT Bold", 12F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(13, 81);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(225, 45);
            btnHome.TabIndex = 63;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.DarkGreen;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(13, 591);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(225, 45);
            btnReturnBook.TabIndex = 59;
            btnReturnBook.Text = "Return Book";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnStudentReport
            // 
            btnStudentReport.BackColor = Color.DarkGreen;
            btnStudentReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnStudentReport.ForeColor = Color.White;
            btnStudentReport.Location = new Point(13, 396);
            btnStudentReport.Margin = new Padding(3, 4, 3, 4);
            btnStudentReport.Name = "btnStudentReport";
            btnStudentReport.Size = new Size(225, 45);
            btnStudentReport.TabIndex = 56;
            btnStudentReport.Text = "Student  Report";
            btnStudentReport.UseVisualStyleBackColor = false;
            btnStudentReport.Click += btnStudentReport_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGreen;
            btnLogout.Font = new Font("Arial Rounded MT Bold", 12F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(13, 656);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(225, 45);
            btnLogout.TabIndex = 61;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnBookReport
            // 
            btnBookReport.BackColor = Color.DarkGreen;
            btnBookReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBookReport.ForeColor = Color.White;
            btnBookReport.Location = new Point(13, 201);
            btnBookReport.Margin = new Padding(3, 4, 3, 4);
            btnBookReport.Name = "btnBookReport";
            btnBookReport.Size = new Size(225, 45);
            btnBookReport.TabIndex = 54;
            btnBookReport.Text = "Book Report";
            btnBookReport.UseVisualStyleBackColor = false;
            btnBookReport.Click += btnBookReport_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.DarkGreen;
            btnAddBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(13, 141);
            btnAddBook.Margin = new Padding(3, 4, 3, 4);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(225, 45);
            btnAddBook.TabIndex = 53;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnAddDepartment
            // 
            btnAddDepartment.BackColor = Color.DarkGreen;
            btnAddDepartment.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddDepartment.ForeColor = Color.White;
            btnAddDepartment.Location = new Point(13, 266);
            btnAddDepartment.Margin = new Padding(3, 4, 3, 4);
            btnAddDepartment.Name = "btnAddDepartment";
            btnAddDepartment.Size = new Size(225, 45);
            btnAddDepartment.TabIndex = 52;
            btnAddDepartment.Text = "Add Department";
            btnAddDepartment.UseVisualStyleBackColor = false;
            btnAddDepartment.Click += btnAddDepartment_Click;
            // 
            // btnIssueReport
            // 
            btnIssueReport.BackColor = Color.DarkGreen;
            btnIssueReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnIssueReport.ForeColor = Color.White;
            btnIssueReport.Location = new Point(13, 526);
            btnIssueReport.Margin = new Padding(3, 4, 3, 4);
            btnIssueReport.Name = "btnIssueReport";
            btnIssueReport.Size = new Size(225, 45);
            btnIssueReport.TabIndex = 58;
            btnIssueReport.Text = "Issue Report";
            btnIssueReport.UseVisualStyleBackColor = false;
            btnIssueReport.Click += btnIssueReport_Click;
            // 
            // IssueBookReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnIssueBook);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnAddStudent);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnStudentReport);
            Controls.Add(btnLogout);
            Controls.Add(btnBookReport);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddDepartment);
            Controls.Add(btnIssueReport);
            Name = "IssueBookReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "IssueBookReport";
            Load += IssueBookReport_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvIssuedBooks).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIssueBook;
        private Label label2;
        private Panel panel1;
        private ComboBox cbBookTitle;
        private Label label4;
        private ComboBox cbRollNo;
        private Label label8;
        private Label label1;
        private DataGridView dgvIssuedBooks;
        private Button btnAddStudent;
        private Button btnHome;
        private Button btnReturnBook;
        private Button btnStudentReport;
        private Button btnLogout;
        private Button btnBookReport;
        private Button btnAddBook;
        private Button btnAddDepartment;
        private Button btnIssueReport;
        private Button btnSelectRollNo;
        private Button btnBookTitle;
        private DataGridViewTextBoxColumn RollNo;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn IssuedDate;
        private DataGridViewTextBoxColumn DueDate;
        private Button btnResetFilter;
    }
}
namespace Library_Management_System
{
    partial class StudentReport
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnStudentReport = new Button();
            btnLogout = new Button();
            btnBookReport = new Button();
            btnAddBook = new Button();
            btnAddDepartment = new Button();
            btnAddStudent = new Button();
            btnHome = new Button();
            btnReturnBook = new Button();
            btnIssueReport = new Button();
            label2 = new Label();
            ReportPanel = new Panel();
            btnResetFilter = new Button();
            btnRollNoView = new Button();
            btnDepartView = new Button();
            cbRollNo = new ComboBox();
            label4 = new Label();
            cbDepartment = new ComboBox();
            label8 = new Label();
            label1 = new Label();
            DGVStudentReport = new DataGridView();
            RollNo = new DataGridViewTextBoxColumn();
            StuName = new DataGridViewTextBoxColumn();
            Department = new DataGridViewTextBoxColumn();
            Mobile = new DataGridViewTextBoxColumn();
            View = new DataGridViewLinkColumn();
            detailPanel = new Panel();
            btnBack = new Button();
            label14 = new Label();
            lblDepartment = new Label();
            lblPassword = new Label();
            lblRollNo = new Label();
            lblGender = new Label();
            lblAddress = new Label();
            lblUsername = new Label();
            lblMobile = new Label();
            lblName = new Label();
            btnIssueBook = new Button();
            ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVStudentReport).BeginInit();
            detailPanel.SuspendLayout();
            SuspendLayout();
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
            btnStudentReport.TabIndex = 44;
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
            btnLogout.TabIndex = 49;
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
            btnBookReport.TabIndex = 42;
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
            btnAddBook.TabIndex = 41;
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
            btnAddDepartment.TabIndex = 40;
            btnAddDepartment.Text = "Add Department";
            btnAddDepartment.UseVisualStyleBackColor = false;
            btnAddDepartment.Click += btnAddDepartment_Click;
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
            btnAddStudent.TabIndex = 43;
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
            btnHome.TabIndex = 51;
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
            btnReturnBook.TabIndex = 47;
            btnReturnBook.Text = "Return Book";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
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
            btnIssueReport.TabIndex = 46;
            btnIssueReport.Text = "Issue Report";
            btnIssueReport.UseVisualStyleBackColor = false;
            btnIssueReport.Click += btnIssueReport_Click;
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
            label2.TabIndex = 50;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReportPanel
            // 
            ReportPanel.BackColor = Color.PaleGreen;
            ReportPanel.BorderStyle = BorderStyle.FixedSingle;
            ReportPanel.Controls.Add(btnResetFilter);
            ReportPanel.Controls.Add(btnRollNoView);
            ReportPanel.Controls.Add(btnDepartView);
            ReportPanel.Controls.Add(cbRollNo);
            ReportPanel.Controls.Add(label4);
            ReportPanel.Controls.Add(cbDepartment);
            ReportPanel.Controls.Add(label8);
            ReportPanel.Controls.Add(label1);
            ReportPanel.Controls.Add(DGVStudentReport);
            ReportPanel.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReportPanel.ForeColor = Color.White;
            ReportPanel.Location = new Point(244, 80);
            ReportPanel.Margin = new Padding(3, 4, 3, 4);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(788, 620);
            ReportPanel.TabIndex = 48;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.Green;
            btnResetFilter.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetFilter.Location = new Point(15, 154);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(110, 37);
            btnResetFilter.TabIndex = 58;
            btnResetFilter.Text = "Reset Filter";
            btnResetFilter.UseVisualStyleBackColor = false;
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnRollNoView
            // 
            btnRollNoView.BackColor = Color.Green;
            btnRollNoView.Location = new Point(600, 141);
            btnRollNoView.Name = "btnRollNoView";
            btnRollNoView.Size = new Size(97, 37);
            btnRollNoView.TabIndex = 56;
            btnRollNoView.Text = "View";
            btnRollNoView.UseVisualStyleBackColor = false;
            btnRollNoView.Click += btnRollNoView_Click;
            // 
            // btnDepartView
            // 
            btnDepartView.BackColor = Color.Green;
            btnDepartView.Location = new Point(234, 141);
            btnDepartView.Name = "btnDepartView";
            btnDepartView.Size = new Size(97, 37);
            btnDepartView.TabIndex = 55;
            btnDepartView.Text = "View";
            btnDepartView.UseVisualStyleBackColor = false;
            btnDepartView.Click += btnDepartView_Click;
            // 
            // cbRollNo
            // 
            cbRollNo.Font = new Font("Arial Rounded MT Bold", 9F);
            cbRollNo.FormattingEnabled = true;
            cbRollNo.Location = new Point(566, 99);
            cbRollNo.Name = "cbRollNo";
            cbRollNo.Size = new Size(207, 29);
            cbRollNo.TabIndex = 53;
            cbRollNo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Green;
            label4.Location = new Point(445, 102);
            label4.Name = "label4";
            label4.Size = new Size(103, 28);
            label4.TabIndex = 52;
            label4.Text = "Roll No:";
            label4.Click += label4_Click;
            // 
            // cbDepartment
            // 
            cbDepartment.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbDepartment.FormattingEnabled = true;
            cbDepartment.Location = new Point(193, 99);
            cbDepartment.Name = "cbDepartment";
            cbDepartment.Size = new Size(207, 29);
            cbDepartment.TabIndex = 51;
            cbDepartment.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.Green;
            label8.Location = new Point(15, 102);
            label8.Name = "label8";
            label8.Size = new Size(163, 28);
            label8.TabIndex = 50;
            label8.Text = "Department :";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 9);
            label1.Name = "label1";
            label1.Size = new Size(758, 51);
            label1.TabIndex = 29;
            label1.Text = "View Students Report";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGVStudentReport
            // 
            DGVStudentReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVStudentReport.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVStudentReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVStudentReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVStudentReport.Columns.AddRange(new DataGridViewColumn[] { RollNo, StuName, Department, Mobile, View });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGVStudentReport.DefaultCellStyle = dataGridViewCellStyle2;
            DGVStudentReport.Location = new Point(15, 197);
            DGVStudentReport.MultiSelect = false;
            DGVStudentReport.Name = "DGVStudentReport";
            DGVStudentReport.RowHeadersVisible = false;
            DGVStudentReport.RowHeadersWidth = 62;
            DGVStudentReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVStudentReport.Size = new Size(758, 407);
            DGVStudentReport.TabIndex = 28;
            DGVStudentReport.CellContentClick += DGVStudentReport_CellContentClick;
            // 
            // RollNo
            // 
            RollNo.HeaderText = "Roll No";
            RollNo.MinimumWidth = 8;
            RollNo.Name = "RollNo";
            RollNo.ReadOnly = true;
            // 
            // StuName
            // 
            StuName.HeaderText = "Name";
            StuName.MinimumWidth = 8;
            StuName.Name = "StuName";
            StuName.ReadOnly = true;
            // 
            // Department
            // 
            Department.HeaderText = "Department";
            Department.MinimumWidth = 8;
            Department.Name = "Department";
            Department.ReadOnly = true;
            // 
            // Mobile
            // 
            Mobile.HeaderText = "Mobile";
            Mobile.MinimumWidth = 8;
            Mobile.Name = "Mobile";
            Mobile.ReadOnly = true;
            // 
            // View
            // 
            View.HeaderText = "View";
            View.MinimumWidth = 8;
            View.Name = "View";
            View.ReadOnly = true;
            View.Text = "View";
            View.UseColumnTextForLinkValue = true;
            // 
            // detailPanel
            // 
            detailPanel.Controls.Add(btnBack);
            detailPanel.Controls.Add(label14);
            detailPanel.Controls.Add(lblDepartment);
            detailPanel.Controls.Add(lblPassword);
            detailPanel.Controls.Add(lblRollNo);
            detailPanel.Controls.Add(lblGender);
            detailPanel.Controls.Add(lblAddress);
            detailPanel.Controls.Add(lblUsername);
            detailPanel.Controls.Add(lblMobile);
            detailPanel.Controls.Add(lblName);
            detailPanel.Location = new Point(244, 82);
            detailPanel.Name = "detailPanel";
            detailPanel.Size = new Size(788, 619);
            detailPanel.TabIndex = 57;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Green;
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(290, 346);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(95, 41);
            btnBack.TabIndex = 67;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.None;
            label14.BackColor = Color.Green;
            label14.Font = new Font("Arial Rounded MT Bold", 14F);
            label14.ForeColor = Color.White;
            label14.Location = new Point(12, 9);
            label14.Name = "label14";
            label14.Size = new Size(758, 51);
            label14.TabIndex = 57;
            label14.Text = "StudentDetail";
            label14.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.BackColor = Color.Transparent;
            lblDepartment.Font = new Font("Arial Rounded MT Bold", 10F);
            lblDepartment.ForeColor = Color.Green;
            lblDepartment.Location = new Point(176, 158);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(138, 23);
            lblDepartment.TabIndex = 65;
            lblDepartment.Text = "Department :";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Arial Rounded MT Bold", 10F);
            lblPassword.ForeColor = Color.Green;
            lblPassword.Location = new Point(178, 291);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(118, 23);
            lblPassword.TabIndex = 63;
            lblPassword.Text = "Password :";
            // 
            // lblRollNo
            // 
            lblRollNo.AutoSize = true;
            lblRollNo.BackColor = Color.Transparent;
            lblRollNo.Font = new Font("Arial Rounded MT Bold", 10F);
            lblRollNo.ForeColor = Color.Green;
            lblRollNo.Location = new Point(176, 97);
            lblRollNo.Name = "lblRollNo";
            lblRollNo.Size = new Size(89, 23);
            lblRollNo.TabIndex = 59;
            lblRollNo.Text = "Roll No :";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Arial Rounded MT Bold", 10F);
            lblGender.ForeColor = Color.Green;
            lblGender.Location = new Point(176, 129);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(84, 23);
            lblGender.TabIndex = 58;
            lblGender.Text = "Gender";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Arial Rounded MT Bold", 10F);
            lblAddress.ForeColor = Color.Green;
            lblAddress.Location = new Point(178, 225);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(104, 23);
            lblAddress.TabIndex = 56;
            lblAddress.Text = "Address :";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Arial Rounded MT Bold", 10F);
            lblUsername.ForeColor = Color.Green;
            lblUsername.Location = new Point(176, 259);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(122, 23);
            lblUsername.TabIndex = 54;
            lblUsername.Text = "Username :";
            // 
            // lblMobile
            // 
            lblMobile.AutoSize = true;
            lblMobile.BackColor = Color.Transparent;
            lblMobile.Font = new Font("Arial Rounded MT Bold", 10F);
            lblMobile.ForeColor = Color.Green;
            lblMobile.Location = new Point(176, 194);
            lblMobile.Name = "lblMobile";
            lblMobile.Size = new Size(117, 23);
            lblMobile.TabIndex = 53;
            lblMobile.Text = "Mobile No :";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Arial Rounded MT Bold", 10F);
            lblName.ForeColor = Color.Green;
            lblName.Location = new Point(178, 64);
            lblName.Name = "lblName";
            lblName.Size = new Size(78, 23);
            lblName.TabIndex = 51;
            lblName.Text = "Name :";
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
            btnIssueBook.TabIndex = 45;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // StudentReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(detailPanel);
            Controls.Add(ReportPanel);
            Controls.Add(btnStudentReport);
            Controls.Add(btnLogout);
            Controls.Add(btnBookReport);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddDepartment);
            Controls.Add(btnAddStudent);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnIssueReport);
            Controls.Add(label2);
            Controls.Add(btnIssueBook);
            Name = "StudentReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentReport";
            Load += StudentReport_Load;
            ReportPanel.ResumeLayout(false);
            ReportPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVStudentReport).EndInit();
            detailPanel.ResumeLayout(false);
            detailPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStudentReport;
        private Button btnLogout;
        private Button btnBookReport;
        private Button btnAddBook;
        private Button btnAddDepartment;
        private Button btnAddStudent;
        private Button btnHome;
        private Button btnReturnBook;
        private Button btnIssueReport;
        private Label label2;
        private Panel ReportPanel;
        private DataGridView DGVStudentReport;
        private Button btnIssueBook;
        private Label label1;
        private ComboBox cbRollNo;
        private Label label4;
        private ComboBox cbDepartment;
        private Label label8;
        private Button btnDepartView;
        private Button btnRollNoView;
        private Panel detailPanel;
        private Label lblDepartment;
        private Label lblPassword;
        private Label lblRollNo;
        private Label lblGender;
        private Label lblAddress;
        private Label lblUsername;
        private Label lblMobile;
        private Label lblName;
        private Button btnBack;
        private Label label14;
        private Button btnResetFilter;
        private DataGridViewTextBoxColumn RollNo;
        private DataGridViewTextBoxColumn StuName;
        private DataGridViewTextBoxColumn Department;
        private DataGridViewTextBoxColumn Mobile;
        private DataGridViewLinkColumn View;
    }
}
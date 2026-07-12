namespace Library_Management_System
{
    partial class BookReport
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            btnStudentReport = new Button();
            btnLogout = new Button();
            btnBookReport = new Button();
            btnAddBook = new Button();
            btnAddDepartment = new Button();
            btnAddStudent = new Button();
            btnHome = new Button();
            label3 = new Label();
            btnReturnBook = new Button();
            btnIssueReport = new Button();
            label2 = new Label();
            ReportPanel = new Panel();
            DGVBookReport = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Available = new DataGridViewTextBoxColumn();
            Issued = new DataGridViewTextBoxColumn();
            View = new DataGridViewButtonColumn();
            DetailPanel = new Panel();
            label4 = new Label();
            btnBack = new Button();
            dAvailable = new Label();
            dIssued = new Label();
            dName = new Label();
            dPicture = new PictureBox();
            dEdition = new Label();
            dDetail = new Label();
            dQuantity = new Label();
            dAuthor = new Label();
            dPrice = new Label();
            btnIssueBook = new Button();
            ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVBookReport).BeginInit();
            DetailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dPicture).BeginInit();
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
            btnStudentReport.TabIndex = 32;
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
            btnLogout.TabIndex = 37;
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
            btnBookReport.TabIndex = 30;
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
            btnAddBook.TabIndex = 29;
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
            btnAddDepartment.TabIndex = 28;
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
            btnAddStudent.TabIndex = 31;
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
            btnHome.TabIndex = 39;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.BackColor = Color.Green;
            label3.Font = new Font("Arial Rounded MT Bold", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 8);
            label3.Name = "label3";
            label3.Size = new Size(758, 51);
            label3.TabIndex = 27;
            label3.Text = "View Books Report";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            btnReturnBook.TabIndex = 35;
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
            btnIssueReport.TabIndex = 34;
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
            label2.TabIndex = 38;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReportPanel
            // 
            ReportPanel.BackColor = Color.PaleGreen;
            ReportPanel.BorderStyle = BorderStyle.FixedSingle;
            ReportPanel.Controls.Add(DGVBookReport);
            ReportPanel.Controls.Add(label3);
            ReportPanel.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReportPanel.ForeColor = Color.White;
            ReportPanel.Location = new Point(258, 81);
            ReportPanel.Margin = new Padding(3, 4, 3, 4);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(788, 620);
            ReportPanel.TabIndex = 36;
            // 
            // DGVBookReport
            // 
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.Black;
            DGVBookReport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DGVBookReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVBookReport.BackgroundColor = Color.Green;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.Blue;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVBookReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVBookReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVBookReport.Columns.AddRange(new DataGridViewColumn[] { Title, Price, Quantity, Available, Issued, View });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DGVBookReport.DefaultCellStyle = dataGridViewCellStyle3;
            DGVBookReport.Location = new Point(3, 100);
            DGVBookReport.MultiSelect = false;
            DGVBookReport.Name = "DGVBookReport";
            DGVBookReport.ReadOnly = true;
            DGVBookReport.RowHeadersVisible = false;
            DGVBookReport.RowHeadersWidth = 62;
            DGVBookReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVBookReport.Size = new Size(780, 504);
            DGVBookReport.TabIndex = 28;
            DGVBookReport.CellContentClick += DGVBookReport_CellContentClick_1;
            // 
            // Title
            // 
            Title.HeaderText = "Title";
            Title.MinimumWidth = 180;
            Title.Name = "Title";
            Title.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 90;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 120;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Available
            // 
            Available.HeaderText = "Available";
            Available.MinimumWidth = 120;
            Available.Name = "Available";
            Available.ReadOnly = true;
            // 
            // Issued
            // 
            Issued.HeaderText = "Issued";
            Issued.MinimumWidth = 100;
            Issued.Name = "Issued";
            Issued.ReadOnly = true;
            // 
            // View
            // 
            View.HeaderText = "View";
            View.MinimumWidth = 100;
            View.Name = "View";
            View.ReadOnly = true;
            // 
            // DetailPanel
            // 
            DetailPanel.BorderStyle = BorderStyle.FixedSingle;
            DetailPanel.Controls.Add(label4);
            DetailPanel.Controls.Add(btnBack);
            DetailPanel.Controls.Add(dAvailable);
            DetailPanel.Controls.Add(dIssued);
            DetailPanel.Controls.Add(dName);
            DetailPanel.Controls.Add(dPicture);
            DetailPanel.Controls.Add(dEdition);
            DetailPanel.Controls.Add(dDetail);
            DetailPanel.Controls.Add(dQuantity);
            DetailPanel.Controls.Add(dAuthor);
            DetailPanel.Controls.Add(dPrice);
            DetailPanel.Location = new Point(258, 82);
            DetailPanel.Name = "DetailPanel";
            DetailPanel.Size = new Size(788, 619);
            DetailPanel.TabIndex = 29;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.BackColor = Color.Green;
            label4.Font = new Font("Arial Rounded MT Bold", 14F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 11);
            label4.Name = "label4";
            label4.Size = new Size(758, 53);
            label4.TabIndex = 30;
            label4.Text = "View Books Detail";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Green;
            btnBack.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(305, 491);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(99, 38);
            btnBack.TabIndex = 78;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // dAvailable
            // 
            dAvailable.AutoSize = true;
            dAvailable.BackColor = Color.Transparent;
            dAvailable.Font = new Font("Arial Rounded MT Bold", 11F);
            dAvailable.ForeColor = Color.Green;
            dAvailable.Location = new Point(243, 310);
            dAvailable.Name = "dAvailable";
            dAvailable.Size = new Size(124, 26);
            dAvailable.TabIndex = 77;
            dAvailable.Text = "Available :";
            // 
            // dIssued
            // 
            dIssued.AutoSize = true;
            dIssued.BackColor = Color.Transparent;
            dIssued.Font = new Font("Arial Rounded MT Bold", 11F);
            dIssued.ForeColor = Color.Green;
            dIssued.Location = new Point(243, 346);
            dIssued.Name = "dIssued";
            dIssued.Size = new Size(96, 26);
            dIssued.TabIndex = 76;
            dIssued.Text = "Issued :";
            // 
            // dName
            // 
            dName.AutoSize = true;
            dName.BackColor = Color.Transparent;
            dName.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dName.ForeColor = Color.Green;
            dName.Location = new Point(13, 101);
            dName.Name = "dName";
            dName.Size = new Size(158, 28);
            dName.TabIndex = 69;
            dName.Text = "Book Name :";
            // 
            // dPicture
            // 
            dPicture.Location = new Point(13, 153);
            dPicture.Name = "dPicture";
            dPicture.Size = new Size(199, 272);
            dPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            dPicture.TabIndex = 75;
            dPicture.TabStop = false;
            // 
            // dEdition
            // 
            dEdition.AutoSize = true;
            dEdition.BackColor = Color.Transparent;
            dEdition.Font = new Font("Arial Rounded MT Bold", 11F);
            dEdition.ForeColor = Color.Green;
            dEdition.Location = new Point(243, 192);
            dEdition.Name = "dEdition";
            dEdition.Size = new Size(100, 26);
            dEdition.TabIndex = 70;
            dEdition.Text = "Edition :";
            // 
            // dDetail
            // 
            dDetail.AutoSize = true;
            dDetail.BackColor = Color.Transparent;
            dDetail.Font = new Font("Arial Rounded MT Bold", 11F);
            dDetail.ForeColor = Color.Green;
            dDetail.Location = new Point(243, 387);
            dDetail.Name = "dDetail";
            dDetail.Size = new Size(87, 26);
            dDetail.TabIndex = 74;
            dDetail.Text = "Detail :";
            // 
            // dQuantity
            // 
            dQuantity.AutoSize = true;
            dQuantity.BackColor = Color.Transparent;
            dQuantity.Font = new Font("Arial Rounded MT Bold", 11F);
            dQuantity.ForeColor = Color.Green;
            dQuantity.Location = new Point(243, 272);
            dQuantity.Name = "dQuantity";
            dQuantity.Size = new Size(115, 26);
            dQuantity.TabIndex = 71;
            dQuantity.Text = "Quantity :";
            // 
            // dAuthor
            // 
            dAuthor.AutoSize = true;
            dAuthor.BackColor = Color.Transparent;
            dAuthor.Font = new Font("Arial Rounded MT Bold", 11F);
            dAuthor.ForeColor = Color.Green;
            dAuthor.Location = new Point(243, 153);
            dAuthor.Name = "dAuthor";
            dAuthor.Size = new Size(98, 26);
            dAuthor.TabIndex = 73;
            dAuthor.Text = "Author :";
            // 
            // dPrice
            // 
            dPrice.AutoSize = true;
            dPrice.BackColor = Color.Transparent;
            dPrice.Font = new Font("Arial Rounded MT Bold", 11F);
            dPrice.ForeColor = Color.Green;
            dPrice.Location = new Point(243, 233);
            dPrice.Name = "dPrice";
            dPrice.Size = new Size(82, 26);
            dPrice.TabIndex = 72;
            dPrice.Text = "Price :";
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
            btnIssueBook.TabIndex = 33;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // BookReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(DetailPanel);
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
            Name = "BookReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookReport";
            Load += BookReport_Load;
            ReportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVBookReport).EndInit();
            DetailPanel.ResumeLayout(false);
            DetailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dPicture).EndInit();
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
        private Label label3;
        private Button btnReturnBook;
        private Button btnIssueReport;
        private Label label2;
        private Panel ReportPanel;
        private Button btnIssueBook;
        private DataGridView DGVBookReport;
        private Panel DetailPanel;
        private Button btnBack;
        private Label dAvailable;
        private Label dIssued;
        private Label dName;
        private PictureBox dPicture;
        private Label dEdition;
        private Label dDetail;
        private Label dQuantity;
        private Label dAuthor;
        private Label dPrice;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Available;
        private DataGridViewTextBoxColumn Issued;
        private DataGridViewButtonColumn View;
        private Label label4;
    }
}
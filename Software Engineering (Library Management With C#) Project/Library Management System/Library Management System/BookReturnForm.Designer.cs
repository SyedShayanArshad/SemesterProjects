namespace Library_Management_System
{
    partial class BookReturnForm
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
            btnIssueReport = new Button();
            btnIssueBook = new Button();
            btnAddDepartment = new Button();
            btnReturnBook = new Button();
            label2 = new Label();
            panel1 = new Panel();
            PenaltyReport = new Label();
            ReturnList = new Label();
            lblReturnDate = new Label();
            ReturnDatePicker = new DateTimePicker();
            lblIssuedDate = new Label();
            btnReturn = new Button();
            lblStudentName = new Label();
            cbSelectBook = new ComboBox();
            label16 = new Label();
            lblDueDate = new Label();
            pbBookPicture = new PictureBox();
            lblAuthor = new Label();
            lblPrice = new Label();
            lblEdition = new Label();
            lblBookName = new Label();
            btnViewBook = new Button();
            label1 = new Label();
            cbSelectStudent = new ComboBox();
            label8 = new Label();
            label3 = new Label();
            btnStudentReport = new Button();
            btnLogout = new Button();
            btnAddBook = new Button();
            btnAddStudent = new Button();
            btnHome = new Button();
            btnBookReport = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBookPicture).BeginInit();
            SuspendLayout();
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
            panel1.Controls.Add(PenaltyReport);
            panel1.Controls.Add(ReturnList);
            panel1.Controls.Add(lblReturnDate);
            panel1.Controls.Add(ReturnDatePicker);
            panel1.Controls.Add(lblIssuedDate);
            panel1.Controls.Add(btnReturn);
            panel1.Controls.Add(lblStudentName);
            panel1.Controls.Add(cbSelectBook);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(lblDueDate);
            panel1.Controls.Add(pbBookPicture);
            panel1.Controls.Add(lblAuthor);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblEdition);
            panel1.Controls.Add(lblBookName);
            panel1.Controls.Add(btnViewBook);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbSelectStudent);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label3);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 60;
            // 
            // PenaltyReport
            // 
            PenaltyReport.AutoSize = true;
            PenaltyReport.BackColor = Color.Transparent;
            PenaltyReport.Cursor = Cursors.Hand;
            PenaltyReport.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            PenaltyReport.ForeColor = Color.Red;
            PenaltyReport.Location = new Point(629, 165);
            PenaltyReport.Name = "PenaltyReport";
            PenaltyReport.Size = new Size(141, 21);
            PenaltyReport.TabIndex = 82;
            PenaltyReport.Text = "Penalty Report";
            PenaltyReport.Click += PenaltyReport_Click;
            // 
            // ReturnList
            // 
            ReturnList.AutoSize = true;
            ReturnList.BackColor = Color.Transparent;
            ReturnList.Cursor = Cursors.Hand;
            ReturnList.Font = new Font("Arial Rounded MT Bold", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            ReturnList.ForeColor = Color.Blue;
            ReturnList.Location = new Point(12, 165);
            ReturnList.Name = "ReturnList";
            ReturnList.Size = new Size(195, 21);
            ReturnList.TabIndex = 81;
            ReturnList.Text = "Return Books Report";
            ReturnList.Click += ReturnList_Click;
            // 
            // lblReturnDate
            // 
            lblReturnDate.AutoSize = true;
            lblReturnDate.BackColor = Color.Transparent;
            lblReturnDate.Font = new Font("Arial Rounded MT Bold", 11F);
            lblReturnDate.ForeColor = Color.Green;
            lblReturnDate.Location = new Point(222, 507);
            lblReturnDate.Name = "lblReturnDate";
            lblReturnDate.Size = new Size(154, 26);
            lblReturnDate.TabIndex = 80;
            lblReturnDate.Text = "Return Date :";
            // 
            // ReturnDatePicker
            // 
            ReturnDatePicker.CalendarFont = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReturnDatePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            ReturnDatePicker.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReturnDatePicker.Format = DateTimePickerFormat.Custom;
            ReturnDatePicker.Location = new Point(382, 503);
            ReturnDatePicker.Name = "ReturnDatePicker";
            ReturnDatePicker.Size = new Size(230, 31);
            ReturnDatePicker.TabIndex = 79;
            ReturnDatePicker.ValueChanged += ReturnDatePicker_ValueChanged;
            // 
            // lblIssuedDate
            // 
            lblIssuedDate.AutoSize = true;
            lblIssuedDate.BackColor = Color.Transparent;
            lblIssuedDate.Font = new Font("Arial Rounded MT Bold", 11F);
            lblIssuedDate.ForeColor = Color.Green;
            lblIssuedDate.Location = new Point(222, 472);
            lblIssuedDate.Name = "lblIssuedDate";
            lblIssuedDate.Size = new Size(152, 26);
            lblIssuedDate.TabIndex = 78;
            lblIssuedDate.Text = "Issued Date :";
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.DarkGreen;
            btnReturn.Font = new Font("Arial Rounded MT Bold", 10F);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(333, 553);
            btnReturn.Margin = new Padding(3, 4, 3, 4);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(141, 42);
            btnReturn.TabIndex = 77;
            btnReturn.Text = "Return Book";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // lblStudentName
            // 
            lblStudentName.AutoSize = true;
            lblStudentName.BackColor = Color.Transparent;
            lblStudentName.Font = new Font("Arial Rounded MT Bold", 11F);
            lblStudentName.ForeColor = Color.Green;
            lblStudentName.Location = new Point(222, 402);
            lblStudentName.Name = "lblStudentName";
            lblStudentName.Size = new Size(177, 26);
            lblStudentName.TabIndex = 76;
            lblStudentName.Text = "Student Name :";
            // 
            // cbSelectBook
            // 
            cbSelectBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectBook.Enabled = false;
            cbSelectBook.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSelectBook.FormattingEnabled = true;
            cbSelectBook.Location = new Point(565, 85);
            cbSelectBook.Name = "cbSelectBook";
            cbSelectBook.Size = new Size(205, 31);
            cbSelectBook.TabIndex = 75;
            cbSelectBook.SelectedIndexChanged += cbSelectBook_SelectedIndexChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Arial Rounded MT Bold", 11F);
            label16.ForeColor = Color.Green;
            label16.Location = new Point(412, 90);
            label16.Name = "label16";
            label16.Size = new Size(154, 26);
            label16.TabIndex = 74;
            label16.Text = "Select Book :";
            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.BackColor = Color.Transparent;
            lblDueDate.Font = new Font("Arial Rounded MT Bold", 11F);
            lblDueDate.ForeColor = Color.Green;
            lblDueDate.Location = new Point(222, 437);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(123, 26);
            lblDueDate.TabIndex = 66;
            lblDueDate.Text = "Due Date :";
            // 
            // pbBookPicture
            // 
            pbBookPicture.Location = new Point(12, 297);
            pbBookPicture.Name = "pbBookPicture";
            pbBookPicture.Size = new Size(175, 230);
            pbBookPicture.TabIndex = 65;
            pbBookPicture.TabStop = false;
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAuthor.ForeColor = Color.Green;
            lblAuthor.Location = new Point(222, 297);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(98, 26);
            lblAuthor.TabIndex = 62;
            lblAuthor.Text = "Author :";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Arial Rounded MT Bold", 11F);
            lblPrice.ForeColor = Color.Green;
            lblPrice.Location = new Point(222, 367);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(82, 26);
            lblPrice.TabIndex = 59;
            lblPrice.Text = "Price :";
            // 
            // lblEdition
            // 
            lblEdition.AutoSize = true;
            lblEdition.BackColor = Color.Transparent;
            lblEdition.Font = new Font("Arial Rounded MT Bold", 11F);
            lblEdition.ForeColor = Color.Green;
            lblEdition.Location = new Point(222, 332);
            lblEdition.Name = "lblEdition";
            lblEdition.Size = new Size(100, 26);
            lblEdition.TabIndex = 56;
            lblEdition.Text = "Edition :";
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.BackColor = Color.Transparent;
            lblBookName.ForeColor = Color.Green;
            lblBookName.Location = new Point(12, 256);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(158, 28);
            lblBookName.TabIndex = 53;
            lblBookName.Text = "Book Name :";
            // 
            // btnViewBook
            // 
            btnViewBook.BackColor = Color.DarkGreen;
            btnViewBook.Font = new Font("Arial Rounded MT Bold", 10F);
            btnViewBook.ForeColor = Color.White;
            btnViewBook.Location = new Point(352, 138);
            btnViewBook.Margin = new Padding(3, 4, 3, 4);
            btnViewBook.Name = "btnViewBook";
            btnViewBook.Size = new Size(122, 39);
            btnViewBook.TabIndex = 52;
            btnViewBook.Text = "View Book";
            btnViewBook.UseVisualStyleBackColor = false;
            btnViewBook.Click += btnViewBook_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 197);
            label1.Name = "label1";
            label1.Size = new Size(765, 44);
            label1.TabIndex = 51;
            label1.Text = "View Book Detail";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // cbSelectStudent
            // 
            cbSelectStudent.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectStudent.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cbSelectStudent.FormattingEnabled = true;
            cbSelectStudent.Location = new Point(201, 85);
            cbSelectStudent.Name = "cbSelectStudent";
            cbSelectStudent.Size = new Size(205, 31);
            cbSelectStudent.TabIndex = 49;
            cbSelectStudent.SelectedIndexChanged += cbSelectStudent_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 11F);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(12, 90);
            label8.Name = "label8";
            label8.Size = new Size(183, 26);
            label8.TabIndex = 48;
            label8.Text = "Select Student :";
            // 
            // label3
            // 
            label3.BackColor = Color.Green;
            label3.Font = new Font("Arial Rounded MT Bold", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 8);
            label3.Name = "label3";
            label3.Size = new Size(765, 52);
            label3.TabIndex = 27;
            label3.Text = "Book Return Form";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            // BookReturnForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnIssueReport);
            Controls.Add(btnIssueBook);
            Controls.Add(btnAddDepartment);
            Controls.Add(btnReturnBook);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnStudentReport);
            Controls.Add(btnLogout);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddStudent);
            Controls.Add(btnHome);
            Controls.Add(btnBookReport);
            Name = "BookReturnForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookReturnForm";
            Load += BookReturnForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBookPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnIssueReport;
        private Button btnIssueBook;
        private Button btnAddDepartment;
        private Button btnReturnBook;
        private Label label2;
        private Panel panel1;
        private Label lblDueDate;
        private PictureBox pbBookPicture;
        private Label lblAuthor;
        private Label lblPrice;
        private Label lblEdition;
        private Label lblBookName;
        private Button btnViewBook;
        private Label label1;
        private ComboBox cbSelectStudent;
        private Label label8;
        private Label label3;
        private Button btnStudentReport;
        private Button btnLogout;
        private Button btnAddBook;
        private Button btnAddStudent;
        private Button btnHome;
        private Button btnBookReport;
        private ComboBox cbSelectBook;
        private Label label16;
        private Label lblStudentName;
        private Button btnReturn;
        private Label lblIssuedDate;
        private DateTimePicker ReturnDatePicker;
        private Label lblReturnDate;
        private Label ReturnList;
        private Label PenaltyReport;
    }
}
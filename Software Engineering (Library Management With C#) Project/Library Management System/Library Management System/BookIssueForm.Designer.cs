namespace Library_Management_System
{
    partial class BookIssueForm
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
            cbSelectBook = new ComboBox();
            label8 = new Label();
            btnStudentReport = new Button();
            btnLogout = new Button();
            btnAddBook = new Button();
            btnAddStudent = new Button();
            btnHome = new Button();
            btnBookReport = new Button();
            btnAddDepartment = new Button();
            btnReturnBook = new Button();
            label3 = new Label();
            label2 = new Label();
            panel1 = new Panel();
            txtDays = new TextBox();
            label15 = new Label();
            btnIssue = new Button();
            cbSelectRollNo = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            lblAvailable = new Label();
            lblIssued = new Label();
            pbPicture = new PictureBox();
            lblDetail = new Label();
            lblAuthor = new Label();
            lblPrice = new Label();
            lblQuantity = new Label();
            lblEdition = new Label();
            lblBookName = new Label();
            btnSelectBook = new Button();
            label1 = new Label();
            btnIssueReport = new Button();
            btnIssueBook = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // cbSelectBook
            // 
            cbSelectBook.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectBook.Font = new Font("Arial Rounded MT Bold", 10F);
            cbSelectBook.FormattingEnabled = true;
            cbSelectBook.Location = new Point(245, 87);
            cbSelectBook.Name = "cbSelectBook";
            cbSelectBook.Size = new Size(380, 31);
            cbSelectBook.TabIndex = 49;
            cbSelectBook.SelectedIndexChanged += cbDepartment_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.ForeColor = Color.Green;
            label8.Location = new Point(65, 90);
            label8.Name = "label8";
            label8.Size = new Size(164, 28);
            label8.TabIndex = 48;
            label8.Text = "Select Book :";
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
            // label3
            // 
            label3.BackColor = Color.Green;
            label3.Font = new Font("Arial Rounded MT Bold", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 8);
            label3.Name = "label3";
            label3.Size = new Size(765, 52);
            label3.TabIndex = 27;
            label3.Text = "Book Issue Form";
            label3.TextAlign = ContentAlignment.MiddleCenter;
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
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtDays);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(btnIssue);
            panel1.Controls.Add(cbSelectRollNo);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(lblAvailable);
            panel1.Controls.Add(lblIssued);
            panel1.Controls.Add(pbPicture);
            panel1.Controls.Add(lblDetail);
            panel1.Controls.Add(lblAuthor);
            panel1.Controls.Add(lblPrice);
            panel1.Controls.Add(lblQuantity);
            panel1.Controls.Add(lblEdition);
            panel1.Controls.Add(lblBookName);
            panel1.Controls.Add(btnSelectBook);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(cbSelectBook);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label3);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 48;
            panel1.Paint += panel1_Paint;
            // 
            // txtDays
            // 
            txtDays.Font = new Font("Arial Rounded MT Bold", 10F);
            txtDays.Location = new Point(519, 563);
            txtDays.Margin = new Padding(3, 4, 3, 4);
            txtDays.Name = "txtDays";
            txtDays.Size = new Size(114, 31);
            txtDays.TabIndex = 73;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Arial Rounded MT Bold", 11F);
            label15.ForeColor = Color.Green;
            label15.Location = new Point(435, 568);
            label15.Name = "label15";
            label15.Size = new Size(78, 26);
            label15.TabIndex = 72;
            label15.Text = "Days :";
            // 
            // btnIssue
            // 
            btnIssue.BackColor = Color.DarkGreen;
            btnIssue.Font = new Font("Arial Rounded MT Bold", 10F);
            btnIssue.ForeColor = Color.White;
            btnIssue.Location = new Point(645, 560);
            btnIssue.Margin = new Padding(3, 4, 3, 4);
            btnIssue.Name = "btnIssue";
            btnIssue.Size = new Size(132, 39);
            btnIssue.TabIndex = 71;
            btnIssue.Text = "Issue Book";
            btnIssue.UseVisualStyleBackColor = false;
            btnIssue.Click += btnIssue_Click;
            // 
            // cbSelectRollNo
            // 
            cbSelectRollNo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelectRollNo.Font = new Font("Arial Rounded MT Bold", 10F);
            cbSelectRollNo.FormattingEnabled = true;
            cbSelectRollNo.Location = new Point(193, 563);
            cbSelectRollNo.Name = "cbSelectRollNo";
            cbSelectRollNo.Size = new Size(236, 31);
            cbSelectRollNo.TabIndex = 70;
            cbSelectRollNo.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Arial Rounded MT Bold", 11F);
            label14.ForeColor = Color.Green;
            label14.Location = new Point(11, 568);
            label14.Name = "label14";
            label14.Size = new Size(176, 26);
            label14.TabIndex = 69;
            label14.Text = "Select Roll No :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Arial Rounded MT Bold", 10F);
            label13.ForeColor = Color.Blue;
            label13.Location = new Point(3, 521);
            label13.Name = "label13";
            label13.Size = new Size(368, 23);
            label13.TabIndex = 68;
            label13.Text = "Select Student Detail for Issue Book :";
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.BackColor = Color.Transparent;
            lblAvailable.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAvailable.ForeColor = Color.Green;
            lblAvailable.Location = new Point(222, 399);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(124, 26);
            lblAvailable.TabIndex = 67;
            lblAvailable.Text = "Available :";
            // 
            // lblIssued
            // 
            lblIssued.AutoSize = true;
            lblIssued.BackColor = Color.Transparent;
            lblIssued.Font = new Font("Arial Rounded MT Bold", 11F);
            lblIssued.ForeColor = Color.Green;
            lblIssued.Location = new Point(222, 435);
            lblIssued.Name = "lblIssued";
            lblIssued.Size = new Size(96, 26);
            lblIssued.TabIndex = 66;
            lblIssued.Text = "Issued :";
            // 
            // pbPicture
            // 
            pbPicture.Location = new Point(12, 242);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(175, 230);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 65;
            pbPicture.TabStop = false;
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.BackColor = Color.Transparent;
            lblDetail.Font = new Font("Arial Rounded MT Bold", 11F);
            lblDetail.ForeColor = Color.Green;
            lblDetail.Location = new Point(222, 476);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(87, 26);
            lblDetail.TabIndex = 64;
            lblDetail.Text = "Detail :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAuthor.ForeColor = Color.Green;
            lblAuthor.Location = new Point(222, 242);
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
            lblPrice.Location = new Point(222, 322);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(82, 26);
            lblPrice.TabIndex = 59;
            lblPrice.Text = "Price :";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Arial Rounded MT Bold", 11F);
            lblQuantity.ForeColor = Color.Green;
            lblQuantity.Location = new Point(222, 361);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(115, 26);
            lblQuantity.TabIndex = 57;
            lblQuantity.Text = "Quantity :";
            // 
            // lblEdition
            // 
            lblEdition.AutoSize = true;
            lblEdition.BackColor = Color.Transparent;
            lblEdition.Font = new Font("Arial Rounded MT Bold", 11F);
            lblEdition.ForeColor = Color.Green;
            lblEdition.Location = new Point(222, 281);
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
            lblBookName.Location = new Point(12, 201);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(158, 28);
            lblBookName.TabIndex = 53;
            lblBookName.Text = "Book Name :";
            // 
            // btnSelectBook
            // 
            btnSelectBook.BackColor = Color.DarkGreen;
            btnSelectBook.Font = new Font("Arial Rounded MT Bold", 10F);
            btnSelectBook.ForeColor = Color.White;
            btnSelectBook.Location = new Point(641, 84);
            btnSelectBook.Margin = new Padding(3, 4, 3, 4);
            btnSelectBook.Name = "btnSelectBook";
            btnSelectBook.Size = new Size(122, 39);
            btnSelectBook.TabIndex = 52;
            btnSelectBook.Text = "Select";
            btnSelectBook.UseVisualStyleBackColor = false;
            btnSelectBook.Click += btnSelectBook_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 142);
            label1.Name = "label1";
            label1.Size = new Size(765, 44);
            label1.TabIndex = 51;
            label1.Text = "View Book Detail";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            // BookIssueForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnStudentReport);
            Controls.Add(btnLogout);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddStudent);
            Controls.Add(btnHome);
            Controls.Add(btnBookReport);
            Controls.Add(btnAddDepartment);
            Controls.Add(btnReturnBook);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnIssueReport);
            Controls.Add(btnIssueBook);
            Name = "BookIssueForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BookIssueForm";
            Load += BookIssueForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbSelectBook;
        private Label label8;
        private Button btnStudentReport;
        private Button btnLogout;
        private Button btnAddBook;
        private Button btnAddStudent;
        private Button btnHome;
        private Button btnBookReport;
        private Button btnAddDepartment;
        private Button btnReturnBook;
        private Label label3;
        private Label label2;
        private Panel panel1;
        private Button btnIssueReport;
        private Button btnIssueBook;
        private Label label1;
        private Button btnSelectBook;
        private Label lblDetail;
        private Label lblAuthor;
        private Label lblPrice;
        private Label lblQuantity;
        private Label lblEdition;
        private Label lblBookName;
        private PictureBox pbPicture;
        private Label lblAvailable;
        private Label lblIssued;
        private Label label13;
        private Button btnIssue;
        private ComboBox cbSelectRollNo;
        private Label label14;
        private Label label15;
        private TextBox txtDays;
    }
}
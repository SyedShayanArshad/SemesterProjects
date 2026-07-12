namespace Library_Management_System
{
    partial class AddBookPage
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
            panel1 = new Panel();
            btnUploadImage = new Button();
            txtDescription = new TextBox();
            label10 = new Label();
            txtAuthor = new TextBox();
            label9 = new Label();
            txtPrice = new TextBox();
            txtQuantity = new TextBox();
            label7 = new Label();
            txtEdition = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnBookAdd = new Button();
            txtBookTitle = new TextBox();
            label1 = new Label();
            btnReturnBook = new Button();
            btnIssueReport = new Button();
            btnIssueBook = new Button();
            btnStudentReport = new Button();
            btnAddStudent = new Button();
            btnBookReport = new Button();
            btnAddBook = new Button();
            btnAddDepartment = new Button();
            btnLogout = new Button();
            label2 = new Label();
            btnHome = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnUploadImage);
            panel1.Controls.Add(txtDescription);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(txtAuthor);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtPrice);
            panel1.Controls.Add(txtQuantity);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtEdition);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnBookAdd);
            panel1.Controls.Add(txtBookTitle);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(257, 80);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 24;
            // 
            // btnUploadImage
            // 
            btnUploadImage.BackColor = Color.White;
            btnUploadImage.Font = new Font("Arial Rounded MT Bold", 10F);
            btnUploadImage.ForeColor = Color.Black;
            btnUploadImage.Location = new Point(353, 393);
            btnUploadImage.Margin = new Padding(3, 4, 3, 4);
            btnUploadImage.Name = "btnUploadImage";
            btnUploadImage.Size = new Size(207, 37);
            btnUploadImage.TabIndex = 7;
            btnUploadImage.TabStop = false;
            btnUploadImage.Text = "Upload Image";
            btnUploadImage.UseVisualStyleBackColor = false;
            btnUploadImage.Click += button1_Click;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(353, 142);
            txtDescription.Margin = new Padding(3, 4, 3, 4);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(207, 35);
            txtDescription.TabIndex = 2;
            txtDescription.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.ForeColor = Color.Green;
            label10.Location = new Point(162, 145);
            label10.Name = "label10";
            label10.Size = new Size(161, 28);
            label10.TabIndex = 40;
            label10.Text = "Description :";
            // 
            // txtAuthor
            // 
            txtAuthor.Location = new Point(353, 192);
            txtAuthor.Margin = new Padding(3, 4, 3, 4);
            txtAuthor.Name = "txtAuthor";
            txtAuthor.Size = new Size(207, 35);
            txtAuthor.TabIndex = 3;
            txtAuthor.TabStop = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.ForeColor = Color.Green;
            label9.Location = new Point(162, 195);
            label9.Name = "label9";
            label9.Size = new Size(104, 28);
            label9.TabIndex = 38;
            label9.Text = "Author :";
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(353, 295);
            txtPrice.Margin = new Padding(3, 4, 3, 4);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(207, 35);
            txtPrice.TabIndex = 5;
            txtPrice.TabStop = false;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(353, 343);
            txtQuantity.Margin = new Padding(3, 4, 3, 4);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(207, 35);
            txtQuantity.TabIndex = 6;
            txtQuantity.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.Green;
            label7.Location = new Point(162, 298);
            label7.Name = "label7";
            label7.Size = new Size(88, 28);
            label7.TabIndex = 34;
            label7.Text = "Price :";
            // 
            // txtEdition
            // 
            txtEdition.Location = new Point(353, 243);
            txtEdition.Margin = new Padding(3, 4, 3, 4);
            txtEdition.Name = "txtEdition";
            txtEdition.Size = new Size(207, 35);
            txtEdition.TabIndex = 4;
            txtEdition.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.Green;
            label6.Location = new Point(162, 346);
            label6.Name = "label6";
            label6.Size = new Size(123, 28);
            label6.TabIndex = 32;
            label6.Text = "Quantity :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.Green;
            label5.Location = new Point(162, 246);
            label5.Name = "label5";
            label5.Size = new Size(107, 28);
            label5.TabIndex = 30;
            label5.Text = "Edition :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Green;
            label4.Location = new Point(162, 396);
            label4.Name = "label4";
            label4.Size = new Size(163, 28);
            label4.TabIndex = 28;
            label4.Text = "Book Image :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Green;
            label3.Font = new Font("Arial Rounded MT Bold", 14F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 8);
            label3.Name = "label3";
            label3.Padding = new Padding(275, 10, 275, 10);
            label3.Size = new Size(765, 52);
            label3.TabIndex = 27;
            label3.Text = "Add New Book";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnBookAdd
            // 
            btnBookAdd.BackColor = Color.DarkGreen;
            btnBookAdd.Font = new Font("Arial Rounded MT Bold", 10F);
            btnBookAdd.ForeColor = Color.White;
            btnBookAdd.Location = new Point(281, 462);
            btnBookAdd.Margin = new Padding(3, 4, 3, 4);
            btnBookAdd.Name = "btnBookAdd";
            btnBookAdd.Size = new Size(180, 54);
            btnBookAdd.TabIndex = 8;
            btnBookAdd.TabStop = false;
            btnBookAdd.Text = "Add Book";
            btnBookAdd.UseVisualStyleBackColor = false;
            btnBookAdd.Click += btnBookAdd_Click;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(353, 90);
            txtBookTitle.Margin = new Padding(3, 4, 3, 4);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.Size = new Size(207, 35);
            txtBookTitle.TabIndex = 1;
            txtBookTitle.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Green;
            label1.Location = new Point(162, 94);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 1;
            label1.Text = "Book Title :";
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.DarkGreen;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(12, 590);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(225, 45);
            btnReturnBook.TabIndex = 23;
            btnReturnBook.Text = "Return Book";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnIssueReport
            // 
            btnIssueReport.BackColor = Color.DarkGreen;
            btnIssueReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnIssueReport.ForeColor = Color.White;
            btnIssueReport.Location = new Point(12, 525);
            btnIssueReport.Margin = new Padding(3, 4, 3, 4);
            btnIssueReport.Name = "btnIssueReport";
            btnIssueReport.Size = new Size(225, 45);
            btnIssueReport.TabIndex = 22;
            btnIssueReport.Text = "Issue Report";
            btnIssueReport.UseVisualStyleBackColor = false;
            btnIssueReport.Click += btnIssueReport_Click;
            // 
            // btnIssueBook
            // 
            btnIssueBook.BackColor = Color.DarkGreen;
            btnIssueBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnIssueBook.ForeColor = Color.White;
            btnIssueBook.Location = new Point(12, 460);
            btnIssueBook.Margin = new Padding(3, 4, 3, 4);
            btnIssueBook.Name = "btnIssueBook";
            btnIssueBook.Size = new Size(225, 45);
            btnIssueBook.TabIndex = 21;
            btnIssueBook.Text = "Issue Book";
            btnIssueBook.UseVisualStyleBackColor = false;
            btnIssueBook.Click += btnIssueBook_Click;
            // 
            // btnStudentReport
            // 
            btnStudentReport.BackColor = Color.DarkGreen;
            btnStudentReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnStudentReport.ForeColor = Color.White;
            btnStudentReport.Location = new Point(12, 395);
            btnStudentReport.Margin = new Padding(3, 4, 3, 4);
            btnStudentReport.Name = "btnStudentReport";
            btnStudentReport.Size = new Size(225, 45);
            btnStudentReport.TabIndex = 20;
            btnStudentReport.Text = "Student  Report";
            btnStudentReport.UseVisualStyleBackColor = false;
            btnStudentReport.Click += btnStudentReport_Click;
            // 
            // btnAddStudent
            // 
            btnAddStudent.BackColor = Color.DarkGreen;
            btnAddStudent.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddStudent.ForeColor = Color.White;
            btnAddStudent.Location = new Point(12, 330);
            btnAddStudent.Margin = new Padding(3, 4, 3, 4);
            btnAddStudent.Name = "btnAddStudent";
            btnAddStudent.Size = new Size(225, 45);
            btnAddStudent.TabIndex = 19;
            btnAddStudent.Text = "Add Student";
            btnAddStudent.UseVisualStyleBackColor = false;
            btnAddStudent.Click += btnAddStudent_Click;
            // 
            // btnBookReport
            // 
            btnBookReport.BackColor = Color.DarkGreen;
            btnBookReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBookReport.ForeColor = Color.White;
            btnBookReport.Location = new Point(12, 200);
            btnBookReport.Margin = new Padding(3, 4, 3, 4);
            btnBookReport.Name = "btnBookReport";
            btnBookReport.Size = new Size(225, 45);
            btnBookReport.TabIndex = 18;
            btnBookReport.Text = "Book Report";
            btnBookReport.UseVisualStyleBackColor = false;
            btnBookReport.Click += btnBookReport_Click;
            // 
            // btnAddBook
            // 
            btnAddBook.BackColor = Color.DarkGreen;
            btnAddBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddBook.ForeColor = Color.White;
            btnAddBook.Location = new Point(12, 140);
            btnAddBook.Margin = new Padding(3, 4, 3, 4);
            btnAddBook.Name = "btnAddBook";
            btnAddBook.Size = new Size(225, 45);
            btnAddBook.TabIndex = 17;
            btnAddBook.Text = "Add Book";
            btnAddBook.UseVisualStyleBackColor = false;
            btnAddBook.Click += btnAddBook_Click;
            // 
            // btnAddDepartment
            // 
            btnAddDepartment.BackColor = Color.DarkGreen;
            btnAddDepartment.Font = new Font("Arial Rounded MT Bold", 12F);
            btnAddDepartment.ForeColor = Color.White;
            btnAddDepartment.Location = new Point(12, 265);
            btnAddDepartment.Margin = new Padding(3, 4, 3, 4);
            btnAddDepartment.Name = "btnAddDepartment";
            btnAddDepartment.Size = new Size(225, 45);
            btnAddDepartment.TabIndex = 16;
            btnAddDepartment.Text = "Add Department";
            btnAddDepartment.UseVisualStyleBackColor = false;
            btnAddDepartment.Click += btnAddDepartment_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGreen;
            btnLogout.Font = new Font("Arial Rounded MT Bold", 12F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(12, 655);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(225, 45);
            btnLogout.TabIndex = 25;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(81, 10);
            label2.Name = "label2";
            label2.Padding = new Padding(80, 10, 80, 10);
            label2.Size = new Size(916, 57);
            label2.TabIndex = 26;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.DarkGreen;
            btnHome.Font = new Font("Arial Rounded MT Bold", 12F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(12, 80);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(225, 45);
            btnHome.TabIndex = 27;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // AddBookPage
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnHome);
            Controls.Add(label2);
            Controls.Add(btnLogout);
            Controls.Add(panel1);
            Controls.Add(btnReturnBook);
            Controls.Add(btnIssueReport);
            Controls.Add(btnIssueBook);
            Controls.Add(btnStudentReport);
            Controls.Add(btnAddStudent);
            Controls.Add(btnBookReport);
            Controls.Add(btnAddBook);
            Controls.Add(btnAddDepartment);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddBookPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddBookPage";
            Load += AddBookPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnBookAdd;
        private TextBox txtBookTitle;
        private Label label1;
        private Button btnReturnBook;
        private Button btnIssueReport;
        private Button btnIssueBook;
        private Button btnStudentReport;
        private Button btnAddStudent;
        private Button btnBookReport;
        private Button btnAddBook;
        private Button btnAddDepartment;
        private Button btnLogout;
        private Label label2;
        private Label label3;
        private TextBox txtDescription;
        private Label label10;
        private TextBox txtAuthor;
        private Label label9;
        private TextBox txtPrice;
        private TextBox txtQuantity;
        private Label label7;
        private TextBox txtEdition;
        private Label label6;
        private Label label5;
        private Label label4;
        private OpenFileDialog openFileDialog1;
        private Button btnUploadImage;
        private Button btnHome;
    }
}
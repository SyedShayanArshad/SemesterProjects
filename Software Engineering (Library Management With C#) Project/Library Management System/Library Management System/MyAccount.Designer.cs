namespace Library_Management_System
{
    partial class MyAccount
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
            btnLogout = new Button();
            btnMyAccount = new Button();
            btnBorrowBooks = new Button();
            btnHome = new Button();
            btnReturnBook = new Button();
            btnViewBooks = new Button();
            label2 = new Label();
            panel1 = new Panel();
            panelEditAccount = new Panel();
            btnUpdate = new Button();
            txtUsername = new TextBox();
            txtMobileNo = new TextBox();
            txtAddress = new TextBox();
            txtDepartment = new TextBox();
            txtPassword = new TextBox();
            txtGender = new TextBox();
            txtRollNo = new TextBox();
            txtName = new TextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            panelAccountDetail = new Panel();
            lblPassword = new Label();
            lblUsername = new Label();
            lblAddress = new Label();
            lblMobileNo = new Label();
            lblDepartment = new Label();
            label3 = new Label();
            lblName = new Label();
            lblRollNo = new Label();
            lblGender = new Label();
            panelChangePassword = new Panel();
            btnChangePass = new Button();
            label15 = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtOldPassword = new TextBox();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            btnChangePassword = new Button();
            btnEditDetail = new Button();
            btnViewAccount = new Button();
            label1 = new Label();
            btnPenalty = new Button();
            panel1.SuspendLayout();
            panelEditAccount.SuspendLayout();
            panelAccountDetail.SuspendLayout();
            panelChangePassword.SuspendLayout();
            SuspendLayout();
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
            btnLogout.TabIndex = 57;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMyAccount
            // 
            btnMyAccount.BackColor = Color.DarkGreen;
            btnMyAccount.Font = new Font("Arial Rounded MT Bold", 12F);
            btnMyAccount.ForeColor = Color.White;
            btnMyAccount.Location = new Point(13, 141);
            btnMyAccount.Margin = new Padding(3, 4, 3, 4);
            btnMyAccount.Name = "btnMyAccount";
            btnMyAccount.Size = new Size(225, 45);
            btnMyAccount.TabIndex = 52;
            btnMyAccount.Text = "My Account";
            btnMyAccount.UseVisualStyleBackColor = false;
            // 
            // btnBorrowBooks
            // 
            btnBorrowBooks.BackColor = Color.DarkGreen;
            btnBorrowBooks.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBorrowBooks.ForeColor = Color.White;
            btnBorrowBooks.Location = new Point(13, 206);
            btnBorrowBooks.Margin = new Padding(3, 4, 3, 4);
            btnBorrowBooks.Name = "btnBorrowBooks";
            btnBorrowBooks.Size = new Size(225, 45);
            btnBorrowBooks.TabIndex = 53;
            btnBorrowBooks.Text = "Books Borrowed";
            btnBorrowBooks.UseVisualStyleBackColor = false;
            btnBorrowBooks.Click += btnBorrowBooks_Click;
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
            btnHome.TabIndex = 59;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.DarkGreen;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(13, 268);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(225, 45);
            btnReturnBook.TabIndex = 55;
            btnReturnBook.Text = "Books Returned";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnViewBooks
            // 
            btnViewBooks.BackColor = Color.DarkGreen;
            btnViewBooks.Font = new Font("Arial Rounded MT Bold", 12F);
            btnViewBooks.ForeColor = Color.White;
            btnViewBooks.Location = new Point(13, 333);
            btnViewBooks.Margin = new Padding(3, 4, 3, 4);
            btnViewBooks.Name = "btnViewBooks";
            btnViewBooks.Size = new Size(225, 45);
            btnViewBooks.TabIndex = 54;
            btnViewBooks.Text = "View Books";
            btnViewBooks.UseVisualStyleBackColor = false;
            btnViewBooks.Click += btnViewBooks_Click;
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
            label2.TabIndex = 58;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panelEditAccount);
            panel1.Controls.Add(panelAccountDetail);
            panel1.Controls.Add(panelChangePassword);
            panel1.Controls.Add(btnChangePassword);
            panel1.Controls.Add(btnEditDetail);
            panel1.Controls.Add(btnViewAccount);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 56;
            // 
            // panelEditAccount
            // 
            panelEditAccount.Controls.Add(btnUpdate);
            panelEditAccount.Controls.Add(txtUsername);
            panelEditAccount.Controls.Add(txtMobileNo);
            panelEditAccount.Controls.Add(txtAddress);
            panelEditAccount.Controls.Add(txtDepartment);
            panelEditAccount.Controls.Add(txtPassword);
            panelEditAccount.Controls.Add(txtGender);
            panelEditAccount.Controls.Add(txtRollNo);
            panelEditAccount.Controls.Add(txtName);
            panelEditAccount.Controls.Add(label4);
            panelEditAccount.Controls.Add(label5);
            panelEditAccount.Controls.Add(label6);
            panelEditAccount.Controls.Add(label7);
            panelEditAccount.Controls.Add(label8);
            panelEditAccount.Controls.Add(label9);
            panelEditAccount.Controls.Add(label10);
            panelEditAccount.Controls.Add(label11);
            panelEditAccount.Controls.Add(label12);
            panelEditAccount.Location = new Point(149, 157);
            panelEditAccount.Name = "panelEditAccount";
            panelEditAccount.Size = new Size(480, 458);
            panelEditAccount.TabIndex = 66;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.DarkOrange;
            btnUpdate.Location = new Point(233, 414);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(104, 44);
            btnUpdate.TabIndex = 67;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(200, 330);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(232, 35);
            txtUsername.TabIndex = 70;
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(200, 285);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(232, 35);
            txtMobileNo.TabIndex = 69;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(200, 240);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(232, 35);
            txtAddress.TabIndex = 68;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(200, 195);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(232, 35);
            txtDepartment.TabIndex = 67;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(200, 375);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(232, 35);
            txtPassword.TabIndex = 66;
            // 
            // txtGender
            // 
            txtGender.Location = new Point(200, 150);
            txtGender.Name = "txtGender";
            txtGender.Size = new Size(232, 35);
            txtGender.TabIndex = 65;
            // 
            // txtRollNo
            // 
            txtRollNo.Location = new Point(200, 105);
            txtRollNo.Name = "txtRollNo";
            txtRollNo.Size = new Size(232, 35);
            txtRollNo.TabIndex = 64;
            // 
            // txtName
            // 
            txtName.Location = new Point(200, 60);
            txtName.Name = "txtName";
            txtName.Size = new Size(232, 35);
            txtName.TabIndex = 63;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 11F);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(30, 380);
            label4.Name = "label4";
            label4.Size = new Size(132, 26);
            label4.TabIndex = 62;
            label4.Text = "Password :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Arial Rounded MT Bold", 11F);
            label5.ForeColor = Color.Green;
            label5.Location = new Point(30, 335);
            label5.Name = "label5";
            label5.Size = new Size(135, 26);
            label5.TabIndex = 61;
            label5.Text = "Username :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Arial Rounded MT Bold", 11F);
            label6.ForeColor = Color.Green;
            label6.Location = new Point(30, 245);
            label6.Name = "label6";
            label6.Size = new Size(116, 26);
            label6.TabIndex = 60;
            label6.Text = "Address :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Arial Rounded MT Bold", 11F);
            label7.ForeColor = Color.Green;
            label7.Location = new Point(30, 290);
            label7.Name = "label7";
            label7.Size = new Size(131, 26);
            label7.TabIndex = 59;
            label7.Text = "Mobile No :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 11F);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(30, 200);
            label8.Name = "label8";
            label8.Size = new Size(152, 26);
            label8.TabIndex = 58;
            label8.Text = "Department :";
            // 
            // label9
            // 
            label9.BackColor = Color.Green;
            label9.Location = new Point(0, 0);
            label9.Name = "label9";
            label9.Size = new Size(480, 46);
            label9.TabIndex = 57;
            label9.Text = "Edit Account Detail";
            label9.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial Rounded MT Bold", 11F);
            label10.ForeColor = Color.Green;
            label10.Location = new Point(30, 65);
            label10.Name = "label10";
            label10.Size = new Size(87, 26);
            label10.TabIndex = 6;
            label10.Text = "Name :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Arial Rounded MT Bold", 11F);
            label11.ForeColor = Color.Green;
            label11.Location = new Point(30, 110);
            label11.Name = "label11";
            label11.Size = new Size(102, 26);
            label11.TabIndex = 54;
            label11.Text = "Roll No :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Arial Rounded MT Bold", 11F);
            label12.ForeColor = Color.Green;
            label12.Location = new Point(30, 155);
            label12.Name = "label12";
            label12.Size = new Size(105, 26);
            label12.TabIndex = 53;
            label12.Text = "Gender :";
            // 
            // panelAccountDetail
            // 
            panelAccountDetail.Controls.Add(lblPassword);
            panelAccountDetail.Controls.Add(lblUsername);
            panelAccountDetail.Controls.Add(lblAddress);
            panelAccountDetail.Controls.Add(lblMobileNo);
            panelAccountDetail.Controls.Add(lblDepartment);
            panelAccountDetail.Controls.Add(label3);
            panelAccountDetail.Controls.Add(lblName);
            panelAccountDetail.Controls.Add(lblRollNo);
            panelAccountDetail.Controls.Add(lblGender);
            panelAccountDetail.Location = new Point(149, 157);
            panelAccountDetail.Name = "panelAccountDetail";
            panelAccountDetail.Size = new Size(480, 399);
            panelAccountDetail.TabIndex = 65;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Arial Rounded MT Bold", 11F);
            lblPassword.ForeColor = Color.Green;
            lblPassword.Location = new Point(30, 350);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(132, 26);
            lblPassword.TabIndex = 62;
            lblPassword.Text = "Password :";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.Transparent;
            lblUsername.Font = new Font("Arial Rounded MT Bold", 11F);
            lblUsername.ForeColor = Color.Green;
            lblUsername.Location = new Point(30, 310);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(135, 26);
            lblUsername.TabIndex = 61;
            lblUsername.Text = "Username :";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.BackColor = Color.Transparent;
            lblAddress.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAddress.ForeColor = Color.Green;
            lblAddress.Location = new Point(30, 230);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(116, 26);
            lblAddress.TabIndex = 60;
            lblAddress.Text = "Address :";
            // 
            // lblMobileNo
            // 
            lblMobileNo.AutoSize = true;
            lblMobileNo.BackColor = Color.Transparent;
            lblMobileNo.Font = new Font("Arial Rounded MT Bold", 11F);
            lblMobileNo.ForeColor = Color.Green;
            lblMobileNo.Location = new Point(30, 270);
            lblMobileNo.Name = "lblMobileNo";
            lblMobileNo.Size = new Size(131, 26);
            lblMobileNo.TabIndex = 59;
            lblMobileNo.Text = "Mobile No :";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.BackColor = Color.Transparent;
            lblDepartment.Font = new Font("Arial Rounded MT Bold", 11F);
            lblDepartment.ForeColor = Color.Green;
            lblDepartment.Location = new Point(30, 190);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(152, 26);
            lblDepartment.TabIndex = 58;
            lblDepartment.Text = "Department :";
            // 
            // label3
            // 
            label3.BackColor = Color.Green;
            label3.Location = new Point(0, 0);
            label3.Name = "label3";
            label3.Size = new Size(480, 46);
            label3.TabIndex = 57;
            label3.Text = "My Account Detail";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Arial Rounded MT Bold", 11F);
            lblName.ForeColor = Color.Green;
            lblName.Location = new Point(30, 70);
            lblName.Name = "lblName";
            lblName.Size = new Size(87, 26);
            lblName.TabIndex = 6;
            lblName.Text = "Name :";
            // 
            // lblRollNo
            // 
            lblRollNo.AutoSize = true;
            lblRollNo.BackColor = Color.Transparent;
            lblRollNo.Font = new Font("Arial Rounded MT Bold", 11F);
            lblRollNo.ForeColor = Color.Green;
            lblRollNo.Location = new Point(30, 110);
            lblRollNo.Name = "lblRollNo";
            lblRollNo.Size = new Size(102, 26);
            lblRollNo.TabIndex = 54;
            lblRollNo.Text = "Roll No :";
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.BackColor = Color.Transparent;
            lblGender.Font = new Font("Arial Rounded MT Bold", 11F);
            lblGender.ForeColor = Color.Green;
            lblGender.Location = new Point(30, 150);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(105, 26);
            lblGender.TabIndex = 53;
            lblGender.Text = "Gender :";
            // 
            // panelChangePassword
            // 
            panelChangePassword.Controls.Add(btnChangePass);
            panelChangePassword.Controls.Add(label15);
            panelChangePassword.Controls.Add(txtNewPassword);
            panelChangePassword.Controls.Add(txtConfirmPassword);
            panelChangePassword.Controls.Add(txtOldPassword);
            panelChangePassword.Controls.Add(label22);
            panelChangePassword.Controls.Add(label23);
            panelChangePassword.Controls.Add(label24);
            panelChangePassword.Location = new Point(149, 157);
            panelChangePassword.Name = "panelChangePassword";
            panelChangePassword.Size = new Size(480, 261);
            panelChangePassword.TabIndex = 64;
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = Color.DarkOrange;
            btnChangePass.Location = new Point(116, 200);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(241, 44);
            btnChangePass.TabIndex = 58;
            btnChangePass.Text = "Change Password";
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += btnChangePass_Click_1;
            // 
            // label15
            // 
            label15.BackColor = Color.Green;
            label15.Location = new Point(0, 0);
            label15.Name = "label15";
            label15.Size = new Size(480, 46);
            label15.TabIndex = 57;
            label15.Text = "Change Password";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(243, 105);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(219, 35);
            txtNewPassword.TabIndex = 61;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(243, 150);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(219, 35);
            txtConfirmPassword.TabIndex = 58;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(243, 60);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(219, 35);
            txtOldPassword.TabIndex = 57;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial Rounded MT Bold", 11F);
            label22.ForeColor = Color.Green;
            label22.Location = new Point(29, 65);
            label22.Name = "label22";
            label22.Size = new Size(175, 26);
            label22.TabIndex = 6;
            label22.Text = "Old Password :";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.Transparent;
            label23.Font = new Font("Arial Rounded MT Bold", 11F);
            label23.ForeColor = Color.Green;
            label23.Location = new Point(29, 110);
            label23.Name = "label23";
            label23.Size = new Size(186, 26);
            label23.TabIndex = 54;
            label23.Text = "New Password :";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.Transparent;
            label24.Font = new Font("Arial Rounded MT Bold", 11F);
            label24.ForeColor = Color.Green;
            label24.Location = new Point(15, 155);
            label24.Name = "label24";
            label24.Size = new Size(222, 26);
            label24.TabIndex = 53;
            label24.Text = "Confirm Password :";
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.DarkOrange;
            btnChangePassword.Location = new Point(502, 80);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(237, 44);
            btnChangePassword.TabIndex = 3;
            btnChangePassword.Text = "Change Password";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // btnEditDetail
            // 
            btnEditDetail.BackColor = Color.DarkOrange;
            btnEditDetail.Location = new Point(298, 80);
            btnEditDetail.Name = "btnEditDetail";
            btnEditDetail.Size = new Size(188, 44);
            btnEditDetail.TabIndex = 2;
            btnEditDetail.Text = "Edit Account";
            btnEditDetail.UseVisualStyleBackColor = false;
            btnEditDetail.Click += btnEditDetail_Click;
            // 
            // btnViewAccount
            // 
            btnViewAccount.BackColor = Color.DarkOrange;
            btnViewAccount.Location = new Point(94, 80);
            btnViewAccount.Name = "btnViewAccount";
            btnViewAccount.Size = new Size(188, 44);
            btnViewAccount.TabIndex = 1;
            btnViewAccount.Text = "View Account";
            btnViewAccount.UseVisualStyleBackColor = false;
            btnViewAccount.Click += btnViewAccount_Click;
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.Location = new Point(3, 13);
            label1.Name = "label1";
            label1.Size = new Size(780, 45);
            label1.TabIndex = 0;
            label1.Text = "My Account";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Click += label1_Click;
            // 
            // btnPenalty
            // 
            btnPenalty.BackColor = Color.DarkGreen;
            btnPenalty.Font = new Font("Arial Rounded MT Bold", 12F);
            btnPenalty.ForeColor = Color.White;
            btnPenalty.Location = new Point(13, 398);
            btnPenalty.Margin = new Padding(3, 4, 3, 4);
            btnPenalty.Name = "btnPenalty";
            btnPenalty.Size = new Size(225, 45);
            btnPenalty.TabIndex = 60;
            btnPenalty.Text = "Penalty Report";
            btnPenalty.UseVisualStyleBackColor = false;
            btnPenalty.Click += btnPenalty_Click;
            // 
            // MyAccount
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnPenalty);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnBorrowBooks);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewBooks);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "MyAccount";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MyAccount";
            Load += MyAccount_Load;
            panel1.ResumeLayout(false);
            panelEditAccount.ResumeLayout(false);
            panelEditAccount.PerformLayout();
            panelAccountDetail.ResumeLayout(false);
            panelAccountDetail.PerformLayout();
            panelChangePassword.ResumeLayout(false);
            panelChangePassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnMyAccount;
        private Button btnBorrowBooks;
        private Button btnHome;
        private Button btnReturnBook;
        private Button btnViewBooks;
        private Label label2;
        private Panel panel1;
        private Label label1;
        private Button btnChangePassword;
        private Button btnEditDetail;
        private Button btnViewAccount;
        private Panel panelChangePassword;
        private Button btnChangePass;
        private Label label15;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtOldPassword;
        private Label label22;
        private Label label23;
        private Label label24;
        private Panel panelAccountDetail;
        private Label lblPassword;
        private Label lblUsername;
        private Label lblAddress;
        private Label lblMobileNo;
        private Label lblDepartment;
        private Label label3;
        private Label lblName;
        private Label lblRollNo;
        private Label lblGender;
        private Panel panelEditAccount;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtUsername;
        private TextBox txtMobileNo;
        private TextBox txtAddress;
        private TextBox txtDepartment;
        private TextBox txtGender;
        private TextBox txtRollNo;
        private TextBox txtName;
        private TextBox txtPassword;
        private Button btnUpdate;
        private Button btnPenalty;
    }
}
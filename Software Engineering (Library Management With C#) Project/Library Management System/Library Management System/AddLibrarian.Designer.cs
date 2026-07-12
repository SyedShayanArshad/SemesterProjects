namespace Library_Management_System
{
    partial class AddLibrarian
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
            btnLibrarianReport = new Button();
            label2 = new Label();
            panel1 = new Panel();
            txtLibrarianID = new TextBox();
            LibrarianId = new Label();
            txtMobile = new TextBox();
            txtAddress = new TextBox();
            txtPassword = new TextBox();
            label4 = new Label();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label9 = new Label();
            txtUsername = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            btnLibrarianAdd = new Button();
            txtName = new TextBox();
            label1 = new Label();
            btnReturnBook = new Button();
            panel1.SuspendLayout();
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
            btnLogout.TabIndex = 58;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMyAccount
            // 
            btnMyAccount.BackColor = Color.DarkGreen;
            btnMyAccount.Font = new Font("Arial Rounded MT Bold", 12F);
            btnMyAccount.ForeColor = Color.White;
            btnMyAccount.Location = new Point(12, 80);
            btnMyAccount.Margin = new Padding(3, 4, 3, 4);
            btnMyAccount.Name = "btnMyAccount";
            btnMyAccount.Size = new Size(225, 45);
            btnMyAccount.TabIndex = 53;
            btnMyAccount.Text = "Add Librarian";
            btnMyAccount.UseVisualStyleBackColor = false;
            btnMyAccount.Click += btnMyAccount_Click;
            // 
            // btnLibrarianReport
            // 
            btnLibrarianReport.BackColor = Color.DarkGreen;
            btnLibrarianReport.Font = new Font("Arial Rounded MT Bold", 12F);
            btnLibrarianReport.ForeColor = Color.White;
            btnLibrarianReport.Location = new Point(12, 150);
            btnLibrarianReport.Margin = new Padding(3, 4, 3, 4);
            btnLibrarianReport.Name = "btnLibrarianReport";
            btnLibrarianReport.Size = new Size(225, 45);
            btnLibrarianReport.TabIndex = 54;
            btnLibrarianReport.Text = "Librarian Report";
            btnLibrarianReport.UseVisualStyleBackColor = false;
            btnLibrarianReport.Click += btnLibrarianReport_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(380, 10);
            label2.Name = "label2";
            label2.Padding = new Padding(80, 10, 80, 10);
            label2.Size = new Size(560, 57);
            label2.TabIndex = 59;
            label2.Text = "Welcome to Admin Panel";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(txtLibrarianID);
            panel1.Controls.Add(LibrarianId);
            panel1.Controls.Add(txtMobile);
            panel1.Controls.Add(txtAddress);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(radioButton2);
            panel1.Controls.Add(radioButton1);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(txtUsername);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnLibrarianAdd);
            panel1.Controls.Add(txtName);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 62;
            // 
            // txtLibrarianID
            // 
            txtLibrarianID.Location = new Point(352, 91);
            txtLibrarianID.Margin = new Padding(3, 4, 3, 4);
            txtLibrarianID.Name = "txtLibrarianID";
            txtLibrarianID.Size = new Size(207, 35);
            txtLibrarianID.TabIndex = 53;
            // 
            // LibrarianId
            // 
            LibrarianId.AutoSize = true;
            LibrarianId.BackColor = Color.Transparent;
            LibrarianId.ForeColor = Color.Green;
            LibrarianId.Location = new Point(161, 95);
            LibrarianId.Name = "LibrarianId";
            LibrarianId.Size = new Size(165, 28);
            LibrarianId.TabIndex = 52;
            LibrarianId.Text = "Librarian ID :";
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(351, 236);
            txtMobile.Margin = new Padding(3, 4, 3, 4);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(207, 35);
            txtMobile.TabIndex = 51;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(351, 286);
            txtAddress.Margin = new Padding(3, 4, 3, 4);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(207, 35);
            txtAddress.TabIndex = 50;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(351, 386);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(207, 35);
            txtPassword.TabIndex = 47;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.ForeColor = Color.Green;
            label4.Location = new Point(160, 389);
            label4.Name = "label4";
            label4.Size = new Size(142, 28);
            label4.TabIndex = 46;
            label4.Text = "Password :";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.ForeColor = Color.Green;
            radioButton2.Location = new Point(455, 189);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(121, 32);
            radioButton2.TabIndex = 45;
            radioButton2.TabStop = true;
            radioButton2.Text = "Female";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.ForeColor = Color.Green;
            radioButton1.Location = new Point(357, 189);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(92, 32);
            radioButton1.TabIndex = 44;
            radioButton1.TabStop = true;
            radioButton1.Text = "Male";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.ForeColor = Color.Green;
            label9.Location = new Point(161, 191);
            label9.Name = "label9";
            label9.Size = new Size(99, 28);
            label9.TabIndex = 38;
            label9.Text = "Gender";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(351, 336);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(207, 35);
            txtUsername.TabIndex = 35;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.ForeColor = Color.Green;
            label7.Location = new Point(160, 289);
            label7.Name = "label7";
            label7.Size = new Size(124, 28);
            label7.TabIndex = 34;
            label7.Text = "Address :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.ForeColor = Color.Green;
            label6.Location = new Point(160, 339);
            label6.Name = "label6";
            label6.Size = new Size(145, 28);
            label6.TabIndex = 32;
            label6.Text = "Username :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.ForeColor = Color.Green;
            label5.Location = new Point(161, 239);
            label5.Name = "label5";
            label5.Size = new Size(141, 28);
            label5.TabIndex = 30;
            label5.Text = "Mobile No :";
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
            label3.Text = "Add New Librarian";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnLibrarianAdd
            // 
            btnLibrarianAdd.BackColor = Color.DarkGreen;
            btnLibrarianAdd.Font = new Font("Arial Rounded MT Bold", 10F);
            btnLibrarianAdd.ForeColor = Color.White;
            btnLibrarianAdd.Location = new Point(269, 452);
            btnLibrarianAdd.Margin = new Padding(3, 4, 3, 4);
            btnLibrarianAdd.Name = "btnLibrarianAdd";
            btnLibrarianAdd.Size = new Size(180, 54);
            btnLibrarianAdd.TabIndex = 15;
            btnLibrarianAdd.Text = "Add Librarian";
            btnLibrarianAdd.UseVisualStyleBackColor = false;
            btnLibrarianAdd.Click += btnLibrarianAdd_Click;
            // 
            // txtName
            // 
            txtName.Location = new Point(352, 139);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(207, 35);
            txtName.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.ForeColor = Color.Green;
            label1.Location = new Point(161, 143);
            label1.Name = "label1";
            label1.Size = new Size(93, 28);
            label1.TabIndex = 1;
            label1.Text = "Name :";
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.DarkGreen;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(12, 220);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(225, 45);
            btnReturnBook.TabIndex = 69;
            btnReturnBook.Text = "Edit Account";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // AddLibrarian
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnReturnBook);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnLibrarianReport);
            Controls.Add(label2);
            Name = "AddLibrarian";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminSide";
            Load += AddLibrarian_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnMyAccount;
        private Button btnLibrarianReport;
        private Label label2;
        private Panel panel1;
        private TextBox txtAddress;
        private TextBox txtPassword;
        private Label label4;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Label label9;
        private TextBox txtUsername;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Button btnLibrarianAdd;
        private TextBox txtName;
        private Label label1;
        private TextBox txtMobile;
        private TextBox txtLibrarianID;
        private Label LibrarianId;
        private Button btnReturnBook;
    }
}
namespace Library_Management_System
{
    partial class AdminChange
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
            btnChangePass = new Button();
            label15 = new Label();
            txtNewPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            txtOldPassword = new TextBox();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            panel1 = new Panel();
            panel4 = new Panel();
            txtUsername = new TextBox();
            label1 = new Label();
            btnLogout = new Button();
            btnMyAccount = new Button();
            btnLibrarianReport = new Button();
            label2 = new Label();
            btnReturnBook = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // btnChangePass
            // 
            btnChangePass.BackColor = Color.DarkOrange;
            btnChangePass.Location = new Point(122, 286);
            btnChangePass.Name = "btnChangePass";
            btnChangePass.Size = new Size(241, 44);
            btnChangePass.TabIndex = 58;
            btnChangePass.Text = "Change Password";
            btnChangePass.UseVisualStyleBackColor = false;
            btnChangePass.Click += btnChangePass_Click;
            // 
            // label15
            // 
            label15.BackColor = Color.Green;
            label15.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.White;
            label15.Location = new Point(0, 0);
            label15.Name = "label15";
            label15.Size = new Size(480, 46);
            label15.TabIndex = 57;
            label15.Text = "Change Admin Information";
            label15.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtNewPassword
            // 
            txtNewPassword.Location = new Point(250, 180);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(219, 35);
            txtNewPassword.TabIndex = 61;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(250, 235);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(219, 35);
            txtConfirmPassword.TabIndex = 58;
            // 
            // txtOldPassword
            // 
            txtOldPassword.Location = new Point(250, 125);
            txtOldPassword.Name = "txtOldPassword";
            txtOldPassword.Size = new Size(219, 35);
            txtOldPassword.TabIndex = 57;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial Rounded MT Bold", 11F);
            label22.ForeColor = Color.Green;
            label22.Location = new Point(20, 130);
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
            label23.Location = new Point(20, 185);
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
            label24.Location = new Point(20, 240);
            label24.Name = "label24";
            label24.Size = new Size(222, 26);
            label24.TabIndex = 53;
            label24.Text = "Confirm Password :";
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(panel4);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 82);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 74;
            // 
            // panel4
            // 
            panel4.Controls.Add(txtUsername);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(btnChangePass);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(txtNewPassword);
            panel4.Controls.Add(txtConfirmPassword);
            panel4.Controls.Add(txtOldPassword);
            panel4.Controls.Add(label22);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(label24);
            panel4.Location = new Point(140, 137);
            panel4.Name = "panel4";
            panel4.Size = new Size(480, 401);
            panel4.TabIndex = 66;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(250, 70);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(219, 35);
            txtUsername.TabIndex = 63;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 11F);
            label1.ForeColor = Color.Green;
            label1.Location = new Point(20, 75);
            label1.Name = "label1";
            label1.Size = new Size(135, 26);
            label1.TabIndex = 62;
            label1.Text = "Username :";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkGreen;
            btnLogout.Font = new Font("Arial Rounded MT Bold", 12F);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(13, 657);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(225, 45);
            btnLogout.TabIndex = 71;
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
            btnMyAccount.TabIndex = 67;
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
            btnLibrarianReport.TabIndex = 68;
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
            label2.TabIndex = 72;
            label2.Text = "Welcome to Admin Panel";
            label2.TextAlign = ContentAlignment.TopCenter;
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
            btnReturnBook.TabIndex = 77;
            btnReturnBook.Text = "Edit Account";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // AdminChange
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
            Name = "AdminChange";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AdminChange";
            Load += AdminChange_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnChangePass;
        private Label label15;
        private TextBox txtNewPassword;
        private TextBox txtConfirmPassword;
        private TextBox txtOldPassword;
        private Label label22;
        private Label label23;
        private Label label24;
        private Panel panel1;
        private Button btnLogout;
        private Button btnMyAccount;
        private Button btnLibrarianReport;
        private Label label2;
        private Panel panel4;
        private Button btnReturnBook;
        private TextBox txtUsername;
        private Label label1;
    }
}
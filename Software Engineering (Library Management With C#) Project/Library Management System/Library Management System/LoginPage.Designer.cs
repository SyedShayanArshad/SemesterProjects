namespace Library_Management_System
{
    partial class LoginPage
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
            textBox2 = new TextBox();
            loginArea = new Panel();
            txtPassword = new TextBox();
            txtUsername = new TextBox();
            btnLogin = new Button();
            radioLibrarian = new RadioButton();
            radioStudent = new RadioButton();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            radioAdmin = new RadioButton();
            panel1.SuspendLayout();
            loginArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(textBox2);
            panel1.ForeColor = Color.Black;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 150);
            panel1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.DarkGreen;
            textBox2.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(224, 41);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(675, 54);
            textBox2.TabIndex = 10;
            textBox2.Text = "Library Management System";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // loginArea
            // 
            loginArea.BackColor = Color.Aquamarine;
            loginArea.BorderStyle = BorderStyle.FixedSingle;
            loginArea.Controls.Add(radioAdmin);
            loginArea.Controls.Add(txtPassword);
            loginArea.Controls.Add(txtUsername);
            loginArea.Controls.Add(btnLogin);
            loginArea.Controls.Add(radioLibrarian);
            loginArea.Controls.Add(radioStudent);
            loginArea.Controls.Add(label2);
            loginArea.Controls.Add(label1);
            loginArea.Controls.Add(textBox1);
            loginArea.Location = new Point(303, 371);
            loginArea.Name = "loginArea";
            loginArea.Size = new Size(474, 255);
            loginArea.TabIndex = 1;
            loginArea.Paint += loginArea_Paint;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(156, 129);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(221, 31);
            txtPassword.TabIndex = 9;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(156, 80);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(221, 31);
            txtUsername.TabIndex = 8;
            txtUsername.TextChanged += txtUsername_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(169, 200);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // radioLibrarian
            // 
            radioLibrarian.AutoSize = true;
            radioLibrarian.Location = new Point(273, 167);
            radioLibrarian.Name = "radioLibrarian";
            radioLibrarian.Size = new Size(124, 27);
            radioLibrarian.TabIndex = 6;
            radioLibrarian.TabStop = true;
            radioLibrarian.Text = "Librarian";
            radioLibrarian.UseVisualStyleBackColor = true;
            // 
            // radioStudent
            // 
            radioStudent.AutoSize = true;
            radioStudent.Location = new Point(156, 167);
            radioStudent.Name = "radioStudent";
            radioStudent.Size = new Size(111, 27);
            radioStudent.TabIndex = 5;
            radioStudent.TabStop = true;
            radioStudent.Text = "Student";
            radioStudent.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Green;
            label2.Location = new Point(20, 132);
            label2.Name = "label2";
            label2.Size = new Size(123, 23);
            label2.TabIndex = 4;
            label2.Text = "Password : ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Green;
            label1.Location = new Point(16, 83);
            label1.Name = "label1";
            label1.Size = new Size(127, 23);
            label1.TabIndex = 3;
            label1.Text = "Username : ";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.DarkGreen;
            textBox1.Font = new Font("Arial Rounded MT Bold", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(-1, -1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(474, 54);
            textBox1.TabIndex = 2;
            textBox1.Text = "Login Area";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.library;
            pictureBox1.Location = new Point(12, 168);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1034, 185);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // radioAdmin
            // 
            radioAdmin.AutoSize = true;
            radioAdmin.Font = new Font("Arial Rounded MT Bold", 9F);
            radioAdmin.Location = new Point(3, 227);
            radioAdmin.Name = "radioAdmin";
            radioAdmin.Size = new Size(91, 25);
            radioAdmin.TabIndex = 10;
            radioAdmin.TabStop = true;
            radioAdmin.Text = "Admin";
            radioAdmin.UseVisualStyleBackColor = true;
            // 
            // LoginPage
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MediumSpringGreen;
            ClientSize = new Size(1058, 712);
            Controls.Add(pictureBox1);
            Controls.Add(loginArea);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "LoginPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginPage";
            Load += LoginPage_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            loginArea.ResumeLayout(false);
            loginArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel loginArea;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private RadioButton radioLibrarian;
        private RadioButton radioStudent;
        private TextBox txtPassword;
        private TextBox txtUsername;
        private Button btnLogin;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private RadioButton radioAdmin;
    }
}
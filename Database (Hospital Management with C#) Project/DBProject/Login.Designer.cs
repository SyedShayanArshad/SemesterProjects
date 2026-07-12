namespace DBProject
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtUserName = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(484, 663);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold);
            label1.ForeColor = Color.SeaGreen;
            label1.Location = new Point(533, 45);
            label1.Name = "label1";
            label1.Size = new Size(369, 43);
            label1.TabIndex = 1;
            label1.Text = "AL-SHIFA HOSPITAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Arial", 18F, FontStyle.Bold);
            label2.ForeColor = Color.SeaGreen;
            label2.Location = new Point(501, 88);
            label2.Name = "label2";
            label2.Size = new Size(435, 43);
            label2.TabIndex = 2;
            label2.Text = "MANAGEMENT SYSTEM";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 12F, FontStyle.Bold);
            label3.Location = new Point(533, 254);
            label3.Name = "label3";
            label3.Size = new Size(141, 29);
            label3.TabIndex = 3;
            label3.Text = "Username :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold);
            label4.Location = new Point(527, 303);
            label4.Name = "label4";
            label4.Size = new Size(147, 29);
            label4.TabIndex = 4;
            label4.Text = "Password  :";
            // 
            // txtUserName
            // 
            txtUserName.Location = new Point(712, 254);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(190, 31);
            txtUserName.TabIndex = 5;
            txtUserName.TextChanged += txtPassword_TextChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(712, 303);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(190, 31);
            txtPassword.TabIndex = 6;
            txtPassword.TextChanged += txtUserName_TextChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.SeaGreen;
            btnLogin.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(624, 378);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(146, 51);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Control;
            label5.Font = new Font("Arial", 14F, FontStyle.Bold);
            label5.ForeColor = Color.SeaGreen;
            label5.Location = new Point(624, 180);
            label5.Name = "label5";
            label5.Size = new Size(178, 33);
            label5.TabIndex = 8;
            label5.Text = "Login Portal";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 664);
            Controls.Add(label5);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUserName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtUserName;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label5;
    }
}
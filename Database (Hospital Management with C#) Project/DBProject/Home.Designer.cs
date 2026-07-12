namespace DBProject
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnHomeClick = new Button();
            btnAdminClick = new Button();
            btnPaymentClick = new Button();
            btnBillClick = new Button();
            btnPatientClick = new Button();
            btnDoctorClick = new Button();
            btnRoomClick = new Button();
            btnLogoutClick = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            textBox9 = new TextBox();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            textBox12 = new TextBox();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnHomeClick
            // 
            btnHomeClick.BackColor = Color.MediumSeaGreen;
            btnHomeClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHomeClick.ForeColor = Color.White;
            btnHomeClick.Location = new Point(24, 95);
            btnHomeClick.Name = "btnHomeClick";
            btnHomeClick.Size = new Size(194, 40);
            btnHomeClick.TabIndex = 0;
            btnHomeClick.Text = "HOME";
            btnHomeClick.UseVisualStyleBackColor = false;
            btnHomeClick.Click += btnHomeClick_Click;
            // 
            // btnAdminClick
            // 
            btnAdminClick.BackColor = Color.MediumSeaGreen;
            btnAdminClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdminClick.ForeColor = Color.White;
            btnAdminClick.Location = new Point(24, 465);
            btnAdminClick.Name = "btnAdminClick";
            btnAdminClick.Size = new Size(194, 40);
            btnAdminClick.TabIndex = 1;
            btnAdminClick.Text = "Admin/Reports";
            btnAdminClick.UseVisualStyleBackColor = false;
            btnAdminClick.Click += btnAdminClick_Click;
            // 
            // btnPaymentClick
            // 
            btnPaymentClick.BackColor = Color.MediumSeaGreen;
            btnPaymentClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPaymentClick.ForeColor = Color.White;
            btnPaymentClick.Location = new Point(24, 404);
            btnPaymentClick.Name = "btnPaymentClick";
            btnPaymentClick.Size = new Size(194, 40);
            btnPaymentClick.TabIndex = 2;
            btnPaymentClick.Text = "Payment";
            btnPaymentClick.UseVisualStyleBackColor = false;
            btnPaymentClick.Click += btnPaymentClick_Click;
            // 
            // btnBillClick
            // 
            btnBillClick.BackColor = Color.MediumSeaGreen;
            btnBillClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBillClick.ForeColor = Color.White;
            btnBillClick.Location = new Point(24, 343);
            btnBillClick.Name = "btnBillClick";
            btnBillClick.Size = new Size(194, 40);
            btnBillClick.TabIndex = 3;
            btnBillClick.Text = "Bill";
            btnBillClick.UseVisualStyleBackColor = false;
            btnBillClick.Click += btnBillClick_Click;
            // 
            // btnPatientClick
            // 
            btnPatientClick.BackColor = Color.MediumSeaGreen;
            btnPatientClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPatientClick.ForeColor = Color.White;
            btnPatientClick.Location = new Point(24, 280);
            btnPatientClick.Name = "btnPatientClick";
            btnPatientClick.Size = new Size(194, 40);
            btnPatientClick.TabIndex = 4;
            btnPatientClick.Text = "ADD PATIENT";
            btnPatientClick.UseVisualStyleBackColor = false;
            btnPatientClick.Click += btnPatientClick_Click;
            // 
            // btnDoctorClick
            // 
            btnDoctorClick.BackColor = Color.MediumSeaGreen;
            btnDoctorClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDoctorClick.ForeColor = Color.White;
            btnDoctorClick.Location = new Point(24, 217);
            btnDoctorClick.Name = "btnDoctorClick";
            btnDoctorClick.Size = new Size(194, 40);
            btnDoctorClick.TabIndex = 5;
            btnDoctorClick.Text = "ADD DOCTOR";
            btnDoctorClick.UseVisualStyleBackColor = false;
            btnDoctorClick.Click += button5_Click;
            // 
            // btnRoomClick
            // 
            btnRoomClick.BackColor = Color.MediumSeaGreen;
            btnRoomClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRoomClick.ForeColor = Color.White;
            btnRoomClick.Location = new Point(24, 154);
            btnRoomClick.Name = "btnRoomClick";
            btnRoomClick.Size = new Size(194, 40);
            btnRoomClick.TabIndex = 6;
            btnRoomClick.Text = "ADD ROOM";
            btnRoomClick.UseVisualStyleBackColor = false;
            btnRoomClick.Click += btnRoomClick_Click;
            // 
            // btnLogoutClick
            // 
            btnLogoutClick.BackColor = Color.MediumSeaGreen;
            btnLogoutClick.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogoutClick.ForeColor = Color.White;
            btnLogoutClick.Location = new Point(24, 521);
            btnLogoutClick.Name = "btnLogoutClick";
            btnLogoutClick.Size = new Size(194, 40);
            btnLogoutClick.TabIndex = 7;
            btnLogoutClick.Text = "Logout";
            btnLogoutClick.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnHomeClick);
            panel1.Controls.Add(btnLogoutClick);
            panel1.Controls.Add(btnAdminClick);
            panel1.Controls.Add(btnRoomClick);
            panel1.Controls.Add(btnPaymentClick);
            panel1.Controls.Add(btnDoctorClick);
            panel1.Controls.Add(btnBillClick);
            panel1.Controls.Add(btnPatientClick);
            panel1.ForeColor = Color.MediumSeaGreen;
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(247, 688);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(265, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(981, 60);
            panel2.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Control;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox1.ForeColor = Color.MediumSeaGreen;
            textBox1.Location = new Point(207, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(592, 42);
            textBox1.TabIndex = 10;
            textBox1.Text = "Home";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 22F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(265, 125);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(981, 51);
            textBox2.TabIndex = 11;
            textBox2.Text = "WELCOME TO Al-SHIFA";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.BackColor = SystemColors.Control;
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.Font = new Font("Arial", 22F, FontStyle.Bold);
            textBox3.ForeColor = Color.MediumSeaGreen;
            textBox3.Location = new Point(391, 177);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(723, 51);
            textBox3.TabIndex = 12;
            textBox3.Text = "HOSPITAL MANAGEMENT SYSTEM";
            textBox3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.BackColor = SystemColors.Control;
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox4.ForeColor = Color.MediumSeaGreen;
            textBox4.Location = new Point(278, 296);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(273, 37);
            textBox4.TabIndex = 11;
            textBox4.Text = "Developed By: ";
            textBox4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox5.BackColor = SystemColors.Control;
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox5.ForeColor = Color.MediumSeaGreen;
            textBox5.Location = new Point(791, 389);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(201, 37);
            textBox5.TabIndex = 13;
            textBox5.Text = "2023-CS-625";
            textBox5.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            textBox9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox9.BackColor = SystemColors.Control;
            textBox9.BorderStyle = BorderStyle.None;
            textBox9.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox9.ForeColor = Color.MediumSeaGreen;
            textBox9.Location = new Point(391, 389);
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(319, 37);
            textBox9.TabIndex = 17;
            textBox9.Text = "Syed Shayan Arshad";
            textBox9.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            textBox10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox10.BackColor = SystemColors.Control;
            textBox10.BorderStyle = BorderStyle.None;
            textBox10.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox10.ForeColor = Color.MediumSeaGreen;
            textBox10.Location = new Point(391, 442);
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(319, 37);
            textBox10.TabIndex = 18;
            textBox10.Text = "Adeel-Ur-Rehman";
            textBox10.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox11
            // 
            textBox11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox11.BackColor = SystemColors.Control;
            textBox11.BorderStyle = BorderStyle.None;
            textBox11.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox11.ForeColor = Color.MediumSeaGreen;
            textBox11.Location = new Point(391, 494);
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(319, 37);
            textBox11.TabIndex = 19;
            textBox11.Text = "M. Hammad Khalid";
            textBox11.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox12
            // 
            textBox12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox12.BackColor = SystemColors.Control;
            textBox12.BorderStyle = BorderStyle.None;
            textBox12.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox12.ForeColor = Color.MediumSeaGreen;
            textBox12.Location = new Point(391, 550);
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(319, 37);
            textBox12.TabIndex = 20;
            textBox12.Text = "Waqar Haider";
            textBox12.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            textBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox6.BackColor = SystemColors.Control;
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox6.ForeColor = Color.MediumSeaGreen;
            textBox6.Location = new Point(791, 442);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(201, 37);
            textBox6.TabIndex = 21;
            textBox6.Text = "2023-CS-626";
            textBox6.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            textBox7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox7.BackColor = SystemColors.Control;
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox7.ForeColor = Color.MediumSeaGreen;
            textBox7.Location = new Point(791, 550);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(201, 37);
            textBox7.TabIndex = 22;
            textBox7.Text = "2023-CS-640";
            textBox7.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            textBox8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox8.BackColor = SystemColors.Control;
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.Font = new Font("Arial", 16F, FontStyle.Bold);
            textBox8.ForeColor = Color.MediumSeaGreen;
            textBox8.Location = new Point(791, 494);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(201, 37);
            textBox8.TabIndex = 23;
            textBox8.Text = "2023-CS-637";
            textBox8.TextAlign = HorizontalAlignment.Center;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 712);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            Controls.Add(textBox6);
            Controls.Add(textBox12);
            Controls.Add(textBox11);
            Controls.Add(textBox10);
            Controls.Add(textBox9);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "Home";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Home_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHomeClick;
        private Button btnAdminClick;
        private Button btnPaymentClick;
        private Button btnBillClick;
        private Button btnPatientClick;
        private Button btnDoctorClick;
        private Button btnRoomClick;
        private Button btnLogoutClick;
        private Panel panel1;
        private Panel panel2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private TextBox textBox9;
        private TextBox textBox10;
        private TextBox textBox11;
        private TextBox textBox12;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
    }
}

namespace DBProject
{
    partial class AddRoom
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
            btnHomeClick = new Button();
            btnLogoutClick = new Button();
            btnAdminClick = new Button();
            btnRoomClick = new Button();
            btnPaymentClick = new Button();
            btnDoctorClick = new Button();
            btnBillClick = new Button();
            btnPatientClick = new Button();
            panel2 = new Panel();
            textBox1 = new TextBox();
            panel3 = new Panel();
            userControl11 = new UserControl1();
            uC_Edit_Room_Detail1 = new UC_Edit_Room_Detail();
            btnEditRoomDetails = new Button();
            btnRoomReports = new Button();
            btnAddRoom = new Button();
            DGVRooms = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            panel4 = new Panel();
            textBox2 = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVRooms).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
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
            panel1.TabIndex = 9;
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
            btnLogoutClick.Click += btnLogoutClick_Click;
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
            btnDoctorClick.Click += btnDoctorClick_Click;
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
            // panel2
            // 
            panel2.Controls.Add(textBox1);
            panel2.Location = new Point(265, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(981, 60);
            panel2.TabIndex = 10;
            panel2.Paint += panel2_Paint;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.BackColor = SystemColors.Window;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox1.ForeColor = Color.MediumSeaGreen;
            textBox1.Location = new Point(331, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(360, 42);
            textBox1.TabIndex = 10;
            textBox1.Text = "Add Room";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel3
            // 
            panel3.Controls.Add(userControl11);
            panel3.Controls.Add(uC_Edit_Room_Detail1);
            panel3.Controls.Add(btnEditRoomDetails);
            panel3.Controls.Add(btnRoomReports);
            panel3.Controls.Add(btnAddRoom);
            panel3.Controls.Add(DGVRooms);
            panel3.Location = new Point(265, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(981, 622);
            panel3.TabIndex = 11;
            panel3.Paint += panel3_Paint_1;
            // 
            // userControl11
            // 
            userControl11.Location = new Point(49, 113);
            userControl11.Name = "userControl11";
            userControl11.Size = new Size(720, 447);
            userControl11.TabIndex = 17;
            userControl11.Load += userControl11_Load;
            // 
            // uC_Edit_Room_Detail1
            // 
            uC_Edit_Room_Detail1.Location = new Point(49, 113);
            uC_Edit_Room_Detail1.Name = "uC_Edit_Room_Detail1";
            uC_Edit_Room_Detail1.Size = new Size(720, 463);
            uC_Edit_Room_Detail1.TabIndex = 15;
            // 
            // btnEditRoomDetails
            // 
            btnEditRoomDetails.Location = new Point(286, 36);
            btnEditRoomDetails.Name = "btnEditRoomDetails";
            btnEditRoomDetails.Size = new Size(162, 34);
            btnEditRoomDetails.TabIndex = 14;
            btnEditRoomDetails.Text = "Edit Room Details";
            btnEditRoomDetails.UseVisualStyleBackColor = true;
            btnEditRoomDetails.Click += btnEditRoomDetails_Click;
            // 
            // btnRoomReports
            // 
            btnRoomReports.Location = new Point(155, 36);
            btnRoomReports.Name = "btnRoomReports";
            btnRoomReports.Size = new Size(134, 34);
            btnRoomReports.TabIndex = 13;
            btnRoomReports.Text = "Room Reports";
            btnRoomReports.UseVisualStyleBackColor = true;
            btnRoomReports.Click += btnRoomReports_Click;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(49, 36);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(112, 34);
            btnAddRoom.TabIndex = 12;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += button2_Click;
            // 
            // DGVRooms
            // 
            DGVRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVRooms.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            DGVRooms.Location = new Point(49, 121);
            DGVRooms.Name = "DGVRooms";
            DGVRooms.RowHeadersWidth = 62;
            DGVRooms.Size = new Size(715, 439);
            DGVRooms.TabIndex = 18;
            // 
            // Column1
            // 
            Column1.HeaderText = "Room ID";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Room Type";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 200;
            // 
            // Column3
            // 
            Column3.HeaderText = "Total Roms";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.HeaderText = "Rate / Day";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(265, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(981, 60);
            panel4.TabIndex = 10;
            panel4.Paint += panel2_Paint;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(331, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(360, 42);
            textBox2.TabIndex = 10;
            textBox2.Text = "Add Room";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += textBox1_TextChanged;
            // 
            // AddRoom
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 712);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "AddRoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddRoom";
            Load += AddRoom_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVRooms).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnHomeClick;
        private Button btnLogoutClick;
        private Button btnAdminClick;
        private Button btnRoomClick;
        private Button btnPaymentClick;
        private Button btnDoctorClick;
        private Button btnBillClick;
        private Button btnPatientClick;
        private Panel panel2;
        private TextBox textBox1;
        private Panel panel3;
        private Button button3;
        private Button btnAddRoom;
        private Button btnEditRoomDetails;
        private Button btnRoomReports;
        private UC_Edit_Room_Detail uC_Edit_Room_Detail1;
        private UserControl1 userControl11;
        private DataGridView DGVRooms;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private Panel panel4;
        private TextBox textBox2;
    }
}
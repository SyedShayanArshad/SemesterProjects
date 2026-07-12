namespace DBProject
{
    partial class Doctor
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
            panel4 = new Panel();
            textBox2 = new TextBox();
            panel3 = new Panel();
            PancelAddDoctor = new Panel();
            btnAdd = new Button();
            txtMobileNo = new TextBox();
            CBSpeciality = new ComboBox();
            txtDoctorName = new TextBox();
            txtDoctorID = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDoctorReport = new Button();
            btnEditDoctorDetails = new Button();
            DGVDoctors = new DataGridView();
            btnAddDoctor = new Button();
            PanelEditDetails = new Panel();
            CBDSpeciality = new ComboBox();
            txtMobile = new TextBox();
            label5 = new Label();
            CBDoctorID = new ComboBox();
            btnUpdate = new Button();
            btnDelete = new Button();
            txtDName = new TextBox();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            PancelAddDoctor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDoctors).BeginInit();
            PanelEditDetails.SuspendLayout();
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
            panel1.TabIndex = 10;
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
            btnDoctorClick.Click += btnDoctorClick_Click_1;
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
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(265, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(981, 60);
            panel4.TabIndex = 11;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Window;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(327, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(402, 42);
            textBox2.TabIndex = 10;
            textBox2.Text = "Add Doctor Detail";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // panel3
            // 
            panel3.Controls.Add(PancelAddDoctor);
            panel3.Controls.Add(btnDoctorReport);
            panel3.Controls.Add(btnEditDoctorDetails);
            panel3.Controls.Add(DGVDoctors);
            panel3.Controls.Add(btnAddDoctor);
            panel3.Controls.Add(PanelEditDetails);
            panel3.Location = new Point(265, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(981, 622);
            panel3.TabIndex = 12;
            panel3.Paint += panel3_Paint;
            // 
            // PancelAddDoctor
            // 
            PancelAddDoctor.Controls.Add(btnAdd);
            PancelAddDoctor.Controls.Add(txtMobileNo);
            PancelAddDoctor.Controls.Add(CBSpeciality);
            PancelAddDoctor.Controls.Add(txtDoctorName);
            PancelAddDoctor.Controls.Add(txtDoctorID);
            PancelAddDoctor.Controls.Add(label4);
            PancelAddDoctor.Controls.Add(label3);
            PancelAddDoctor.Controls.Add(label2);
            PancelAddDoctor.Controls.Add(label1);
            PancelAddDoctor.Location = new Point(49, 108);
            PancelAddDoctor.Name = "PancelAddDoctor";
            PancelAddDoctor.Size = new Size(715, 471);
            PancelAddDoctor.TabIndex = 20;
            PancelAddDoctor.Paint += PancelAddDoctor_Paint_1;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(278, 279);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(106, 40);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(224, 218);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(222, 31);
            txtMobileNo.TabIndex = 28;
            // 
            // CBSpeciality
            // 
            CBSpeciality.FormattingEnabled = true;
            CBSpeciality.Items.AddRange(new object[] { "Cardiology", "ENT Specialist", "Gynaecology", "Neurology", "Paediatrics", "Psychiatrist", "Physician", "Surgeon", "Urologist" });
            CBSpeciality.Location = new Point(224, 164);
            CBSpeciality.Name = "CBSpeciality";
            CBSpeciality.Size = new Size(222, 33);
            CBSpeciality.TabIndex = 27;
            // 
            // txtDoctorName
            // 
            txtDoctorName.Location = new Point(224, 109);
            txtDoctorName.Name = "txtDoctorName";
            txtDoctorName.Size = new Size(222, 31);
            txtDoctorName.TabIndex = 26;
            // 
            // txtDoctorID
            // 
            txtDoctorID.Location = new Point(224, 59);
            txtDoctorID.Name = "txtDoctorID";
            txtDoctorID.Size = new Size(127, 31);
            txtDoctorID.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F, FontStyle.Bold);
            label4.Location = new Point(69, 218);
            label4.Name = "label4";
            label4.Size = new Size(109, 21);
            label4.TabIndex = 24;
            label4.Text = "Mobile No :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Bold);
            label3.Location = new Point(69, 164);
            label3.Name = "label3";
            label3.Size = new Size(108, 21);
            label3.TabIndex = 23;
            label3.Text = "Speciality :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Bold);
            label2.Location = new Point(69, 115);
            label2.Name = "label2";
            label2.Size = new Size(136, 21);
            label2.TabIndex = 22;
            label2.Text = "Doctor Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold);
            label1.Location = new Point(69, 65);
            label1.Name = "label1";
            label1.Size = new Size(103, 21);
            label1.TabIndex = 21;
            label1.Text = "Doctor ID :";
            // 
            // btnDoctorReport
            // 
            btnDoctorReport.Location = new Point(216, 36);
            btnDoctorReport.Name = "btnDoctorReport";
            btnDoctorReport.Size = new Size(136, 34);
            btnDoctorReport.TabIndex = 19;
            btnDoctorReport.Text = "Doctor Report";
            btnDoctorReport.UseVisualStyleBackColor = true;
            btnDoctorReport.Click += btnDoctorReport_Click;
            // 
            // btnEditDoctorDetails
            // 
            btnEditDoctorDetails.Location = new Point(348, 36);
            btnEditDoctorDetails.Name = "btnEditDoctorDetails";
            btnEditDoctorDetails.Size = new Size(173, 34);
            btnEditDoctorDetails.TabIndex = 14;
            btnEditDoctorDetails.Text = "Edit Doctor Details";
            btnEditDoctorDetails.UseVisualStyleBackColor = true;
            btnEditDoctorDetails.Click += btnEditDoctorDetails_Click;
            // 
            // DGVDoctors
            // 
            DGVDoctors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDoctors.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column4, Column3 });
            DGVDoctors.Location = new Point(49, 108);
            DGVDoctors.Name = "DGVDoctors";
            DGVDoctors.RowHeadersWidth = 62;
            DGVDoctors.Size = new Size(715, 439);
            DGVDoctors.TabIndex = 18;
            DGVDoctors.CellContentClick += DGVDoctors_CellContentClick_1;
            // 
            // btnAddDoctor
            // 
            btnAddDoctor.Location = new Point(49, 36);
            btnAddDoctor.Name = "btnAddDoctor";
            btnAddDoctor.Size = new Size(169, 34);
            btnAddDoctor.TabIndex = 12;
            btnAddDoctor.Text = "Add Doctor Detail";
            btnAddDoctor.UseVisualStyleBackColor = true;
            btnAddDoctor.Click += btnAddDoctor_Click;
            // 
            // PanelEditDetails
            // 
            PanelEditDetails.Controls.Add(CBDSpeciality);
            PanelEditDetails.Controls.Add(txtMobile);
            PanelEditDetails.Controls.Add(label5);
            PanelEditDetails.Controls.Add(CBDoctorID);
            PanelEditDetails.Controls.Add(btnUpdate);
            PanelEditDetails.Controls.Add(btnDelete);
            PanelEditDetails.Controls.Add(txtDName);
            PanelEditDetails.Controls.Add(label6);
            PanelEditDetails.Controls.Add(label7);
            PanelEditDetails.Controls.Add(label8);
            PanelEditDetails.Location = new Point(49, 108);
            PanelEditDetails.Name = "PanelEditDetails";
            PanelEditDetails.Size = new Size(715, 471);
            PanelEditDetails.TabIndex = 29;
            PanelEditDetails.Paint += PanelEditDetails_Paint;
            // 
            // CBDSpeciality
            // 
            CBDSpeciality.FormattingEnabled = true;
            CBDSpeciality.Items.AddRange(new object[] { "Cardiology", "ENT Specialist", "Gynaecology", "Neurology", "Paediatrics", "Psychiatrist", "Physician", "Surgeon", "Urologist" });
            CBDSpeciality.Location = new Point(220, 147);
            CBDSpeciality.Name = "CBDSpeciality";
            CBDSpeciality.Size = new Size(222, 33);
            CBDSpeciality.TabIndex = 28;
            CBDSpeciality.SelectedIndexChanged += CBDSpeciality_SelectedIndexChanged;
            // 
            // txtMobile
            // 
            txtMobile.Location = new Point(220, 193);
            txtMobile.Name = "txtMobile";
            txtMobile.Size = new Size(150, 31);
            txtMobile.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F, FontStyle.Bold);
            label5.Location = new Point(80, 108);
            label5.Name = "label5";
            label5.Size = new Size(136, 21);
            label5.TabIndex = 21;
            label5.Text = "Doctor Name :";
            // 
            // CBDoctorID
            // 
            CBDoctorID.FormattingEnabled = true;
            CBDoctorID.Location = new Point(220, 53);
            CBDoctorID.Name = "CBDoctorID";
            CBDoctorID.Size = new Size(150, 33);
            CBDoctorID.TabIndex = 20;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.MediumSeaGreen;
            btnUpdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(135, 269);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 40);
            btnUpdate.TabIndex = 19;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MediumSeaGreen;
            btnDelete.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(276, 269);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 40);
            btnDelete.TabIndex = 18;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // txtDName
            // 
            txtDName.Location = new Point(220, 102);
            txtDName.Name = "txtDName";
            txtDName.Size = new Size(188, 31);
            txtDName.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F, FontStyle.Bold);
            label6.Location = new Point(82, 199);
            label6.Name = "label6";
            label6.Size = new Size(109, 21);
            label6.TabIndex = 15;
            label6.Text = "Mobile No :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F, FontStyle.Bold);
            label7.Location = new Point(81, 152);
            label7.Name = "label7";
            label7.Size = new Size(108, 21);
            label7.TabIndex = 14;
            label7.Text = "Speciality :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F, FontStyle.Bold);
            label8.Location = new Point(81, 59);
            label8.Name = "label8";
            label8.Size = new Size(103, 21);
            label8.TabIndex = 13;
            label8.Text = "Doctor ID :";
            // 
            // Column1
            // 
            Column1.HeaderText = "Doctor ID";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.HeaderText = "Doctor Name";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 200;
            // 
            // Column4
            // 
            Column4.HeaderText = "Speciality";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 150;
            // 
            // Column3
            // 
            Column3.HeaderText = "Mobile No";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 150;
            // 
            // Doctor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 712);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Doctor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Doctor";
            Load += Doctor_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            PancelAddDoctor.ResumeLayout(false);
            PancelAddDoctor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDoctors).EndInit();
            PanelEditDetails.ResumeLayout(false);
            PanelEditDetails.PerformLayout();
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
        private Panel panel4;
        private TextBox textBox2;
        private Panel panel3;
        private Button btnEditDoctorDetails;
        private Button btnAddDoctor;
        private DataGridView DGVDoctors;
        private Button btnDoctorReport;
        private Panel PancelAddDoctor;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtMobileNo;
        private ComboBox CBSpeciality;
        private TextBox txtDoctorName;
        private TextBox txtDoctorID;
        private Button btnAdd;
        private Panel PanelEditDetails;
        private TextBox txtMobile;
        private Label label5;
        private ComboBox CBDoctorID;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox txtDName;
        private TextBox txtSpeciality;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox CBDSpeciality;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column3;
    }
}
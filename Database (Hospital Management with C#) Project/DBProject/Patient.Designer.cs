namespace DBProject
{
    partial class Patient
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
            PanelPatientReport = new Panel();
            panel2 = new Panel();
            panel5 = new Panel();
            txtgetPaidBill = new TextBox();
            txtgetRemainingBill = new TextBox();
            txtgetTotalBill = new TextBox();
            txtgetDoctorBill = new TextBox();
            txtgetMedicineBill = new TextBox();
            label30 = new Label();
            label29 = new Label();
            label28 = new Label();
            label27 = new Label();
            label26 = new Label();
            txtgetRoomBill = new TextBox();
            label21 = new Label();
            DGVPaymentDetail = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            txtGetAge = new TextBox();
            txtGetMobile = new TextBox();
            txtGetAddress = new TextBox();
            txtGetReferDr = new TextBox();
            txtGetDisease = new TextBox();
            txtGetHandleDr = new TextBox();
            txtGetRoomType = new TextBox();
            txtGetGender = new TextBox();
            txtgetName = new TextBox();
            label25 = new Label();
            label24 = new Label();
            label23 = new Label();
            label22 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            label17 = new Label();
            label16 = new Label();
            btnSelectDischarge = new Button();
            CBSelectDisPatient = new ComboBox();
            label15 = new Label();
            btnSelect = new Button();
            CBSelectAdmitPatient = new ComboBox();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            PanelDeleteRecord = new Panel();
            label31 = new Label();
            btnDeletePatient = new Button();
            button2 = new Button();
            CBDelPatientID = new ComboBox();
            label32 = new Label();
            DGVDeletePatient = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            PanelAddPatient = new Panel();
            btnPatientAdd = new Button();
            txtDisease = new TextBox();
            txtReferByDoctor = new TextBox();
            txtCity = new TextBox();
            txtAddress = new TextBox();
            txtMobileNo = new TextBox();
            txtAge = new TextBox();
            CBGender = new ComboBox();
            txtPatientName = new TextBox();
            txtPatientID = new TextBox();
            CBHandleDoctor = new ComboBox();
            label11 = new Label();
            label10 = new Label();
            CBRoomType = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel3 = new Panel();
            btnPatientReport = new Button();
            btnDeleteRecord = new Button();
            btnAddPatient = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            PanelPatientReport.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPaymentDetail).BeginInit();
            PanelDeleteRecord.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDeletePatient).BeginInit();
            PanelAddPatient.SuspendLayout();
            panel3.SuspendLayout();
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
            panel1.TabIndex = 11;
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
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(265, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(981, 60);
            panel4.TabIndex = 12;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(266, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(449, 42);
            textBox2.TabIndex = 10;
            textBox2.Text = "Add Patient Detail";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // PanelPatientReport
            // 
            PanelPatientReport.Controls.Add(panel2);
            PanelPatientReport.Controls.Add(btnSelectDischarge);
            PanelPatientReport.Controls.Add(CBSelectDisPatient);
            PanelPatientReport.Controls.Add(label15);
            PanelPatientReport.Controls.Add(btnSelect);
            PanelPatientReport.Controls.Add(CBSelectAdmitPatient);
            PanelPatientReport.Controls.Add(label14);
            PanelPatientReport.Controls.Add(label13);
            PanelPatientReport.Controls.Add(label12);
            PanelPatientReport.Location = new Point(29, 89);
            PanelPatientReport.Name = "PanelPatientReport";
            PanelPatientReport.Size = new Size(920, 521);
            PanelPatientReport.TabIndex = 21;
            PanelPatientReport.Paint += PanelPatientReport_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 255, 128);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(DGVPaymentDetail);
            panel2.Controls.Add(txtGetAge);
            panel2.Controls.Add(txtGetMobile);
            panel2.Controls.Add(txtGetAddress);
            panel2.Controls.Add(txtGetReferDr);
            panel2.Controls.Add(txtGetDisease);
            panel2.Controls.Add(txtGetHandleDr);
            panel2.Controls.Add(txtGetRoomType);
            panel2.Controls.Add(txtGetGender);
            panel2.Controls.Add(txtgetName);
            panel2.Controls.Add(label25);
            panel2.Controls.Add(label24);
            panel2.Controls.Add(label23);
            panel2.Controls.Add(label22);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label16);
            panel2.Location = new Point(14, 78);
            panel2.Name = "panel2";
            panel2.Size = new Size(893, 440);
            panel2.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(txtgetPaidBill);
            panel5.Controls.Add(txtgetRemainingBill);
            panel5.Controls.Add(txtgetTotalBill);
            panel5.Controls.Add(txtgetDoctorBill);
            panel5.Controls.Add(txtgetMedicineBill);
            panel5.Controls.Add(label30);
            panel5.Controls.Add(label29);
            panel5.Controls.Add(label28);
            panel5.Controls.Add(label27);
            panel5.Controls.Add(label26);
            panel5.Controls.Add(txtgetRoomBill);
            panel5.Controls.Add(label21);
            panel5.Location = new Point(-1, 187);
            panel5.Name = "panel5";
            panel5.Size = new Size(893, 74);
            panel5.TabIndex = 20;
            // 
            // txtgetPaidBill
            // 
            txtgetPaidBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetPaidBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetPaidBill.ForeColor = Color.SeaGreen;
            txtgetPaidBill.Location = new Point(602, 34);
            txtgetPaidBill.Name = "txtgetPaidBill";
            txtgetPaidBill.Size = new Size(128, 31);
            txtgetPaidBill.TabIndex = 36;
            // 
            // txtgetRemainingBill
            // 
            txtgetRemainingBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetRemainingBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetRemainingBill.ForeColor = Color.Red;
            txtgetRemainingBill.Location = new Point(747, 34);
            txtgetRemainingBill.Name = "txtgetRemainingBill";
            txtgetRemainingBill.Size = new Size(128, 31);
            txtgetRemainingBill.TabIndex = 35;
            // 
            // txtgetTotalBill
            // 
            txtgetTotalBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetTotalBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetTotalBill.ForeColor = SystemColors.MenuHighlight;
            txtgetTotalBill.Location = new Point(458, 34);
            txtgetTotalBill.Name = "txtgetTotalBill";
            txtgetTotalBill.Size = new Size(128, 31);
            txtgetTotalBill.TabIndex = 34;
            // 
            // txtgetDoctorBill
            // 
            txtgetDoctorBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetDoctorBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetDoctorBill.Location = new Point(170, 34);
            txtgetDoctorBill.Name = "txtgetDoctorBill";
            txtgetDoctorBill.Size = new Size(128, 31);
            txtgetDoctorBill.TabIndex = 33;
            // 
            // txtgetMedicineBill
            // 
            txtgetMedicineBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetMedicineBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetMedicineBill.Location = new Point(311, 34);
            txtgetMedicineBill.Name = "txtgetMedicineBill";
            txtgetMedicineBill.Size = new Size(128, 31);
            txtgetMedicineBill.TabIndex = 32;
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(170, 9);
            label30.Name = "label30";
            label30.Size = new Size(113, 21);
            label30.TabIndex = 27;
            label30.Text = "Doctor Bill :";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(311, 9);
            label29.Name = "label29";
            label29.Size = new Size(134, 21);
            label29.TabIndex = 26;
            label29.Text = "Medicine Bill :";
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = SystemColors.MenuHighlight;
            label28.Location = new Point(458, 9);
            label28.Name = "label28";
            label28.Size = new Size(97, 21);
            label28.TabIndex = 25;
            label28.Text = "Total Bill :";
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label27.ForeColor = Color.SeaGreen;
            label27.Location = new Point(602, 9);
            label27.Name = "label27";
            label27.Size = new Size(93, 21);
            label27.TabIndex = 24;
            label27.Text = "Paid Bill :";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = Color.Red;
            label26.Location = new Point(744, 10);
            label26.Name = "label26";
            label26.Size = new Size(144, 21);
            label26.TabIndex = 23;
            label26.Text = "Remaining Bal:";
            label26.Click += label26_Click;
            // 
            // txtgetRoomBill
            // 
            txtgetRoomBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetRoomBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetRoomBill.Location = new Point(22, 34);
            txtgetRoomBill.Name = "txtgetRoomBill";
            txtgetRoomBill.Size = new Size(128, 31);
            txtgetRoomBill.TabIndex = 22;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(22, 9);
            label21.Name = "label21";
            label21.Size = new Size(107, 21);
            label21.TabIndex = 21;
            label21.Text = "Room Bill :";
            // 
            // DGVPaymentDetail
            // 
            DGVPaymentDetail.BackgroundColor = Color.White;
            DGVPaymentDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVPaymentDetail.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5 });
            DGVPaymentDetail.Location = new Point(-1, 258);
            DGVPaymentDetail.Name = "DGVPaymentDetail";
            DGVPaymentDetail.RowHeadersWidth = 62;
            DGVPaymentDetail.Size = new Size(893, 181);
            DGVPaymentDetail.TabIndex = 19;
            DGVPaymentDetail.CellContentClick += DGVPaymentDetail_CellContentClick;
            // 
            // Column1
            // 
            Column1.HeaderText = "Payment ID";
            Column1.MinimumWidth = 8;
            Column1.Name = "Column1";
            Column1.Width = 140;
            // 
            // Column2
            // 
            Column2.HeaderText = "Paid Amount";
            Column2.MinimumWidth = 8;
            Column2.Name = "Column2";
            Column2.Width = 170;
            // 
            // Column3
            // 
            Column3.HeaderText = "Method";
            Column3.MinimumWidth = 8;
            Column3.Name = "Column3";
            Column3.Width = 120;
            // 
            // Column4
            // 
            Column4.HeaderText = "Bank Name";
            Column4.MinimumWidth = 8;
            Column4.Name = "Column4";
            Column4.Width = 198;
            // 
            // Column5
            // 
            Column5.HeaderText = "Cheque No";
            Column5.MinimumWidth = 8;
            Column5.Name = "Column5";
            Column5.Width = 195;
            // 
            // txtGetAge
            // 
            txtGetAge.BackColor = Color.FromArgb(255, 255, 128);
            txtGetAge.BorderStyle = BorderStyle.FixedSingle;
            txtGetAge.Location = new Point(182, 76);
            txtGetAge.Name = "txtGetAge";
            txtGetAge.Size = new Size(250, 31);
            txtGetAge.TabIndex = 18;
            // 
            // txtGetMobile
            // 
            txtGetMobile.BackColor = Color.FromArgb(255, 255, 128);
            txtGetMobile.BorderStyle = BorderStyle.FixedSingle;
            txtGetMobile.Location = new Point(182, 113);
            txtGetMobile.Name = "txtGetMobile";
            txtGetMobile.Size = new Size(250, 31);
            txtGetMobile.TabIndex = 17;
            // 
            // txtGetAddress
            // 
            txtGetAddress.BackColor = Color.FromArgb(255, 255, 128);
            txtGetAddress.BorderStyle = BorderStyle.FixedSingle;
            txtGetAddress.Location = new Point(182, 150);
            txtGetAddress.Name = "txtGetAddress";
            txtGetAddress.Size = new Size(250, 31);
            txtGetAddress.TabIndex = 16;
            // 
            // txtGetReferDr
            // 
            txtGetReferDr.BackColor = Color.FromArgb(255, 255, 128);
            txtGetReferDr.BorderStyle = BorderStyle.FixedSingle;
            txtGetReferDr.Location = new Point(623, 2);
            txtGetReferDr.Name = "txtGetReferDr";
            txtGetReferDr.Size = new Size(244, 31);
            txtGetReferDr.TabIndex = 15;
            // 
            // txtGetDisease
            // 
            txtGetDisease.BackColor = Color.FromArgb(255, 255, 128);
            txtGetDisease.BorderStyle = BorderStyle.FixedSingle;
            txtGetDisease.Location = new Point(623, 39);
            txtGetDisease.Name = "txtGetDisease";
            txtGetDisease.Size = new Size(244, 31);
            txtGetDisease.TabIndex = 14;
            // 
            // txtGetHandleDr
            // 
            txtGetHandleDr.BackColor = Color.FromArgb(255, 255, 128);
            txtGetHandleDr.BorderStyle = BorderStyle.FixedSingle;
            txtGetHandleDr.Location = new Point(623, 76);
            txtGetHandleDr.Name = "txtGetHandleDr";
            txtGetHandleDr.Size = new Size(244, 31);
            txtGetHandleDr.TabIndex = 13;
            // 
            // txtGetRoomType
            // 
            txtGetRoomType.BackColor = Color.FromArgb(255, 255, 128);
            txtGetRoomType.BorderStyle = BorderStyle.FixedSingle;
            txtGetRoomType.Location = new Point(623, 113);
            txtGetRoomType.Name = "txtGetRoomType";
            txtGetRoomType.Size = new Size(244, 31);
            txtGetRoomType.TabIndex = 12;
            // 
            // txtGetGender
            // 
            txtGetGender.BackColor = Color.FromArgb(255, 255, 128);
            txtGetGender.BorderStyle = BorderStyle.FixedSingle;
            txtGetGender.Location = new Point(182, 39);
            txtGetGender.Name = "txtGetGender";
            txtGetGender.Size = new Size(250, 31);
            txtGetGender.TabIndex = 11;
            // 
            // txtgetName
            // 
            txtgetName.BackColor = Color.FromArgb(255, 255, 128);
            txtgetName.BorderStyle = BorderStyle.FixedSingle;
            txtgetName.Location = new Point(182, 2);
            txtgetName.Name = "txtgetName";
            txtgetName.Size = new Size(250, 31);
            txtgetName.TabIndex = 10;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Arial", 9F, FontStyle.Bold);
            label25.Location = new Point(455, 9);
            label25.Name = "label25";
            label25.Size = new Size(162, 21);
            label25.TabIndex = 9;
            label25.Text = "Refer By Doctor :";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Arial", 9F, FontStyle.Bold);
            label24.Location = new Point(525, 45);
            label24.Name = "label24";
            label24.Size = new Size(92, 21);
            label24.TabIndex = 8;
            label24.Text = "Disease :";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Arial", 9F, FontStyle.Bold);
            label23.Location = new Point(442, 79);
            label23.Name = "label23";
            label23.Size = new Size(175, 21);
            label23.TabIndex = 7;
            label23.Text = "Handle By Doctor :";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Arial", 9F, FontStyle.Bold);
            label22.Location = new Point(495, 115);
            label22.Name = "label22";
            label22.Size = new Size(122, 21);
            label22.TabIndex = 6;
            label22.Text = "Room Type :";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Arial", 9F, FontStyle.Bold);
            label20.Location = new Point(76, 159);
            label20.Name = "label20";
            label20.Size = new Size(95, 21);
            label20.TabIndex = 4;
            label20.Text = "Address :";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Arial", 9F, FontStyle.Bold);
            label19.Location = new Point(62, 117);
            label19.Name = "label19";
            label19.Size = new Size(109, 21);
            label19.TabIndex = 3;
            label19.Text = "Mobile No :";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Arial", 9F, FontStyle.Bold);
            label18.Location = new Point(114, 82);
            label18.Name = "label18";
            label18.Size = new Size(57, 21);
            label18.TabIndex = 2;
            label18.Text = "Age :";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Arial", 9F, FontStyle.Bold);
            label17.Location = new Point(84, 49);
            label17.Name = "label17";
            label17.Size = new Size(87, 21);
            label17.TabIndex = 1;
            label17.Text = "Gender :";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Arial", 9F, FontStyle.Bold);
            label16.Location = new Point(32, 9);
            label16.Name = "label16";
            label16.Size = new Size(139, 21);
            label16.TabIndex = 0;
            label16.Text = "Patient Name :";
            // 
            // btnSelectDischarge
            // 
            btnSelectDischarge.BackColor = Color.MediumSeaGreen;
            btnSelectDischarge.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectDischarge.ForeColor = Color.White;
            btnSelectDischarge.Location = new Point(784, 38);
            btnSelectDischarge.Name = "btnSelectDischarge";
            btnSelectDischarge.Size = new Size(96, 34);
            btnSelectDischarge.TabIndex = 11;
            btnSelectDischarge.Text = "Select";
            btnSelectDischarge.UseVisualStyleBackColor = false;
            btnSelectDischarge.Click += btnSelectDischarge_Click;
            // 
            // CBSelectDisPatient
            // 
            CBSelectDisPatient.FormattingEnabled = true;
            CBSelectDisPatient.Location = new Point(589, 39);
            CBSelectDisPatient.Name = "CBSelectDisPatient";
            CBSelectDisPatient.Size = new Size(182, 33);
            CBSelectDisPatient.TabIndex = 10;
            CBSelectDisPatient.SelectedIndexChanged += CBSelectDisPatient_SelectedIndexChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 9F, FontStyle.Bold);
            label15.Location = new Point(477, 45);
            label15.Name = "label15";
            label15.Size = new Size(106, 21);
            label15.TabIndex = 9;
            label15.Text = "Patient ID :";
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.MediumSeaGreen;
            btnSelect.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(330, 39);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(95, 34);
            btnSelect.TabIndex = 8;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // CBSelectAdmitPatient
            // 
            CBSelectAdmitPatient.FormattingEnabled = true;
            CBSelectAdmitPatient.Location = new Point(135, 40);
            CBSelectAdmitPatient.Name = "CBSelectAdmitPatient";
            CBSelectAdmitPatient.Size = new Size(182, 33);
            CBSelectAdmitPatient.TabIndex = 3;
            CBSelectAdmitPatient.SelectedIndexChanged += CBSelectAdmitPatient_SelectedIndexChanged;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9F, FontStyle.Bold);
            label14.Location = new Point(589, 12);
            label14.Name = "label14";
            label14.Size = new Size(187, 21);
            label14.TabIndex = 2;
            label14.Text = "Discharged Patient :";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9F, FontStyle.Bold);
            label13.Location = new Point(135, 12);
            label13.Name = "label13";
            label13.Size = new Size(168, 21);
            label13.TabIndex = 1;
            label13.Text = "Admitted Patient :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9F, FontStyle.Bold);
            label12.Location = new Point(23, 46);
            label12.Name = "label12";
            label12.Size = new Size(106, 21);
            label12.TabIndex = 0;
            label12.Text = "Patient ID :";
            // 
            // PanelDeleteRecord
            // 
            PanelDeleteRecord.Controls.Add(label31);
            PanelDeleteRecord.Controls.Add(btnDeletePatient);
            PanelDeleteRecord.Controls.Add(button2);
            PanelDeleteRecord.Controls.Add(CBDelPatientID);
            PanelDeleteRecord.Controls.Add(label32);
            PanelDeleteRecord.Controls.Add(DGVDeletePatient);
            PanelDeleteRecord.Location = new Point(29, 89);
            PanelDeleteRecord.Name = "PanelDeleteRecord";
            PanelDeleteRecord.Size = new Size(920, 521);
            PanelDeleteRecord.TabIndex = 11;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.ForeColor = Color.Red;
            label31.Location = new Point(14, 462);
            label31.Name = "label31";
            label31.Size = new Size(856, 21);
            label31.TabIndex = 15;
            label31.Text = "Note: When you delete Patient Record, Its Bill and Payment Record will be deleted automatically.";
            // 
            // btnDeletePatient
            // 
            btnDeletePatient.BackColor = Color.Red;
            btnDeletePatient.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeletePatient.ForeColor = Color.White;
            btnDeletePatient.Location = new Point(660, 21);
            btnDeletePatient.Name = "btnDeletePatient";
            btnDeletePatient.Size = new Size(95, 34);
            btnDeletePatient.TabIndex = 14;
            btnDeletePatient.Text = "Delete";
            btnDeletePatient.UseVisualStyleBackColor = false;
            btnDeletePatient.Click += btnDeletePatient_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.MediumSeaGreen;
            button2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(542, 20);
            button2.Name = "button2";
            button2.Size = new Size(95, 34);
            button2.TabIndex = 12;
            button2.Text = "Select";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // CBDelPatientID
            // 
            CBDelPatientID.FormattingEnabled = true;
            CBDelPatientID.Location = new Point(327, 21);
            CBDelPatientID.Name = "CBDelPatientID";
            CBDelPatientID.Size = new Size(182, 33);
            CBDelPatientID.TabIndex = 11;
            CBDelPatientID.SelectedIndexChanged += CBDelPatientID_SelectedIndexChanged;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Arial", 9F, FontStyle.Bold);
            label32.Location = new Point(206, 25);
            label32.Name = "label32";
            label32.Size = new Size(106, 21);
            label32.TabIndex = 9;
            label32.Text = "Patient ID :";
            // 
            // DGVDeletePatient
            // 
            DGVDeletePatient.BackgroundColor = Color.White;
            DGVDeletePatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVDeletePatient.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7, Column8, Column9, Column11 });
            DGVDeletePatient.Location = new Point(14, 82);
            DGVDeletePatient.Name = "DGVDeletePatient";
            DGVDeletePatient.RowHeadersWidth = 62;
            DGVDeletePatient.Size = new Size(893, 353);
            DGVDeletePatient.TabIndex = 13;
            DGVDeletePatient.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column6
            // 
            Column6.HeaderText = "Patient Name";
            Column6.MinimumWidth = 8;
            Column6.Name = "Column6";
            Column6.Width = 200;
            // 
            // Column7
            // 
            Column7.HeaderText = "Gender";
            Column7.MinimumWidth = 8;
            Column7.Name = "Column7";
            Column7.Width = 150;
            // 
            // Column8
            // 
            Column8.HeaderText = "Age";
            Column8.MinimumWidth = 8;
            Column8.Name = "Column8";
            Column8.Width = 88;
            // 
            // Column9
            // 
            Column9.HeaderText = "Address";
            Column9.MinimumWidth = 8;
            Column9.Name = "Column9";
            Column9.Width = 190;
            // 
            // Column11
            // 
            Column11.HeaderText = "Handle By Doctor";
            Column11.MinimumWidth = 8;
            Column11.Name = "Column11";
            Column11.Width = 200;
            // 
            // PanelAddPatient
            // 
            PanelAddPatient.Controls.Add(btnPatientAdd);
            PanelAddPatient.Controls.Add(txtDisease);
            PanelAddPatient.Controls.Add(txtReferByDoctor);
            PanelAddPatient.Controls.Add(txtCity);
            PanelAddPatient.Controls.Add(txtAddress);
            PanelAddPatient.Controls.Add(txtMobileNo);
            PanelAddPatient.Controls.Add(txtAge);
            PanelAddPatient.Controls.Add(CBGender);
            PanelAddPatient.Controls.Add(txtPatientName);
            PanelAddPatient.Controls.Add(txtPatientID);
            PanelAddPatient.Controls.Add(CBHandleDoctor);
            PanelAddPatient.Controls.Add(label11);
            PanelAddPatient.Controls.Add(label10);
            PanelAddPatient.Controls.Add(CBRoomType);
            PanelAddPatient.Controls.Add(label9);
            PanelAddPatient.Controls.Add(label8);
            PanelAddPatient.Controls.Add(label7);
            PanelAddPatient.Controls.Add(label6);
            PanelAddPatient.Controls.Add(label5);
            PanelAddPatient.Controls.Add(label4);
            PanelAddPatient.Controls.Add(label3);
            PanelAddPatient.Controls.Add(label2);
            PanelAddPatient.Controls.Add(label1);
            PanelAddPatient.Location = new Point(29, 89);
            PanelAddPatient.Name = "PanelAddPatient";
            PanelAddPatient.Size = new Size(920, 521);
            PanelAddPatient.TabIndex = 20;
            // 
            // btnPatientAdd
            // 
            btnPatientAdd.BackColor = Color.MediumSeaGreen;
            btnPatientAdd.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPatientAdd.ForeColor = Color.White;
            btnPatientAdd.Location = new Point(643, 356);
            btnPatientAdd.Name = "btnPatientAdd";
            btnPatientAdd.Size = new Size(162, 40);
            btnPatientAdd.TabIndex = 8;
            btnPatientAdd.Text = "Add Patient";
            btnPatientAdd.UseVisualStyleBackColor = false;
            btnPatientAdd.Click += btnPatientAdd_Click;
            // 
            // txtDisease
            // 
            txtDisease.Location = new Point(643, 107);
            txtDisease.Name = "txtDisease";
            txtDisease.Size = new Size(244, 31);
            txtDisease.TabIndex = 21;
            // 
            // txtReferByDoctor
            // 
            txtReferByDoctor.Location = new Point(643, 63);
            txtReferByDoctor.Name = "txtReferByDoctor";
            txtReferByDoctor.Size = new Size(244, 31);
            txtReferByDoctor.TabIndex = 20;
            // 
            // txtCity
            // 
            txtCity.Location = new Point(208, 362);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(221, 31);
            txtCity.TabIndex = 19;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(208, 312);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(221, 31);
            txtAddress.TabIndex = 18;
            // 
            // txtMobileNo
            // 
            txtMobileNo.Location = new Point(208, 265);
            txtMobileNo.Name = "txtMobileNo";
            txtMobileNo.Size = new Size(221, 31);
            txtMobileNo.TabIndex = 17;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(208, 207);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(112, 31);
            txtAge.TabIndex = 16;
            // 
            // CBGender
            // 
            CBGender.FormattingEnabled = true;
            CBGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            CBGender.Location = new Point(208, 158);
            CBGender.Name = "CBGender";
            CBGender.Size = new Size(144, 33);
            CBGender.TabIndex = 15;
            // 
            // txtPatientName
            // 
            txtPatientName.Location = new Point(208, 114);
            txtPatientName.Name = "txtPatientName";
            txtPatientName.Size = new Size(221, 31);
            txtPatientName.TabIndex = 14;
            // 
            // txtPatientID
            // 
            txtPatientID.Location = new Point(208, 67);
            txtPatientID.Name = "txtPatientID";
            txtPatientID.Size = new Size(112, 31);
            txtPatientID.TabIndex = 13;
            // 
            // CBHandleDoctor
            // 
            CBHandleDoctor.FormattingEnabled = true;
            CBHandleDoctor.Location = new Point(643, 158);
            CBHandleDoctor.Name = "CBHandleDoctor";
            CBHandleDoctor.Size = new Size(244, 33);
            CBHandleDoctor.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9F, FontStyle.Bold);
            label11.Location = new Point(443, 207);
            label11.Name = "label11";
            label11.Size = new Size(122, 21);
            label11.TabIndex = 11;
            label11.Text = "Room Type :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Arial", 9F, FontStyle.Bold);
            label10.Location = new Point(443, 164);
            label10.Name = "label10";
            label10.RightToLeft = RightToLeft.No;
            label10.Size = new Size(175, 21);
            label10.TabIndex = 10;
            label10.Text = "Handle By Doctor :";
            // 
            // CBRoomType
            // 
            CBRoomType.FormattingEnabled = true;
            CBRoomType.Location = new Point(643, 201);
            CBRoomType.Name = "CBRoomType";
            CBRoomType.Size = new Size(244, 33);
            CBRoomType.TabIndex = 9;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Arial", 9F, FontStyle.Bold);
            label9.Location = new Point(443, 120);
            label9.Name = "label9";
            label9.Size = new Size(92, 21);
            label9.TabIndex = 8;
            label9.Text = "Disease :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial", 9F, FontStyle.Bold);
            label8.Location = new Point(443, 73);
            label8.Name = "label8";
            label8.RightToLeft = RightToLeft.No;
            label8.Size = new Size(162, 21);
            label8.TabIndex = 7;
            label8.Text = "Refer By Doctor :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial", 9F, FontStyle.Bold);
            label7.Location = new Point(52, 271);
            label7.Name = "label7";
            label7.RightToLeft = RightToLeft.No;
            label7.Size = new Size(80, 21);
            label7.TabIndex = 6;
            label7.Text = "Mobile :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F, FontStyle.Bold);
            label6.Location = new Point(52, 318);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.No;
            label6.Size = new Size(95, 21);
            label6.TabIndex = 5;
            label6.Text = "Address :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 9F, FontStyle.Bold);
            label5.Location = new Point(52, 368);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.No;
            label5.Size = new Size(57, 21);
            label5.TabIndex = 4;
            label5.Text = "City :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F, FontStyle.Bold);
            label4.Location = new Point(52, 213);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.No;
            label4.Size = new Size(57, 21);
            label4.TabIndex = 3;
            label4.Text = "Age :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Bold);
            label3.Location = new Point(52, 164);
            label3.Name = "label3";
            label3.Size = new Size(87, 21);
            label3.TabIndex = 2;
            label3.Text = "Gender :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Bold);
            label2.Location = new Point(52, 120);
            label2.Name = "label2";
            label2.Size = new Size(139, 21);
            label2.TabIndex = 1;
            label2.Text = "Patient Name :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold);
            label1.Location = new Point(52, 73);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 0;
            label1.Text = "Patient ID :";
            // 
            // panel3
            // 
            panel3.Controls.Add(PanelDeleteRecord);
            panel3.Controls.Add(PanelPatientReport);
            panel3.Controls.Add(PanelAddPatient);
            panel3.Controls.Add(btnPatientReport);
            panel3.Controls.Add(btnDeleteRecord);
            panel3.Controls.Add(btnAddPatient);
            panel3.Location = new Point(265, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(981, 622);
            panel3.TabIndex = 13;
            // 
            // btnPatientReport
            // 
            btnPatientReport.Location = new Point(216, 36);
            btnPatientReport.Name = "btnPatientReport";
            btnPatientReport.Size = new Size(136, 34);
            btnPatientReport.TabIndex = 19;
            btnPatientReport.Text = "Patient Report";
            btnPatientReport.UseVisualStyleBackColor = true;
            btnPatientReport.Click += btnPatientReport_Click;
            // 
            // btnDeleteRecord
            // 
            btnDeleteRecord.Location = new Point(348, 36);
            btnDeleteRecord.Name = "btnDeleteRecord";
            btnDeleteRecord.Size = new Size(130, 34);
            btnDeleteRecord.TabIndex = 14;
            btnDeleteRecord.Text = "Delete Record";
            btnDeleteRecord.UseVisualStyleBackColor = true;
            btnDeleteRecord.Click += btnDeleteRecord_Click;
            // 
            // btnAddPatient
            // 
            btnAddPatient.Location = new Point(49, 36);
            btnAddPatient.Name = "btnAddPatient";
            btnAddPatient.Size = new Size(169, 34);
            btnAddPatient.TabIndex = 12;
            btnAddPatient.Text = "Add Patient Detail";
            btnAddPatient.UseVisualStyleBackColor = true;
            btnAddPatient.Click += btnAddPatient_Click;
            // 
            // Patient
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 712);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Patient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Patient";
            Load += Patient_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            PanelPatientReport.ResumeLayout(false);
            PanelPatientReport.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVPaymentDetail).EndInit();
            PanelDeleteRecord.ResumeLayout(false);
            PanelDeleteRecord.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVDeletePatient).EndInit();
            PanelAddPatient.ResumeLayout(false);
            PanelAddPatient.PerformLayout();
            panel3.ResumeLayout(false);
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
        private Button btnPatientReport;
        private Button btnDeleteRecord;
        private Button btnAddPatient;
        private Panel PanelAddPatient;
        private Label label1;
        private Label label2;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label11;
        private Label label10;
        private ComboBox CBRoomType;
        private Label label9;
        private ComboBox CBHandleDoctor;
        private TextBox txtCity;
        private TextBox txtAddress;
        private TextBox txtMobileNo;
        private TextBox txtAge;
        private ComboBox CBGender;
        private TextBox txtPatientName;
        private TextBox txtPatientID;
        private TextBox txtReferByDoctor;
        private TextBox txtDisease;
        private Button btnPatientAdd;
        private Panel PanelPatientReport;
        private Label label13;
        private Label label12;
        private Label label14;
        private Button btnSelect;
        private ComboBox CBSelectAdmitPatient;
        private Button btnSelectDischarge;
        private ComboBox CBSelectDisPatient;
        private Label label15;
        private Panel panel2;
        private Label label18;
        private Label label17;
        private Label label16;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label20;
        private Label label19;
        private TextBox txtGetAge;
        private TextBox txtGetMobile;
        private TextBox txtGetAddress;
        private TextBox txtGetReferDr;
        private TextBox txtGetDisease;
        private TextBox txtGetHandleDr;
        private TextBox txtGetRoomType;
        private TextBox txtGetGender;
        private TextBox txtgetName;
        private DataGridView DGVPaymentDetail;
        private Panel panel5;
        private Label label30;
        private Label label29;
        private Label label28;
        private Label label27;
        private Label label26;
        private TextBox txtgetRoomBill;
        private Label label21;
        private TextBox txtgetDoctorBill;
        private TextBox txtgetMedicineBill;
        private TextBox txtgetPaidBill;
        private TextBox txtgetRemainingBill;
        private TextBox txtgetTotalBill;
        private Panel PanelDeleteRecord;
        private Button button2;
        private ComboBox CBDelPatientID;
        private Label label32;
        private DataGridView DGVDeletePatient;
        private Button btnDeletePatient;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column11;
        private Label label31;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
    }
}
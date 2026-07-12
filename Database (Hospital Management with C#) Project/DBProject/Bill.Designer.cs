namespace DBProject
{
    partial class Bill
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
            PanelBillReport = new Panel();
            PanelAddBillDetail = new Panel();
            panel2 = new Panel();
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
            panel5 = new Panel();
            txtgetPaidBill = new TextBox();
            txtgetRemainingBill = new TextBox();
            label27 = new Label();
            label26 = new Label();
            txtTotalBill = new TextBox();
            txtTotalDoctorBill = new TextBox();
            btnAddBill = new Button();
            txtTotalRoomBill = new TextBox();
            label1 = new Label();
            txtTotalMedicineBill = new TextBox();
            CBPatientIDBill = new ComboBox();
            label9 = new Label();
            btnSelectPatientID = new Button();
            label8 = new Label();
            txtgetRoomBill = new TextBox();
            label7 = new Label();
            label30 = new Label();
            label6 = new Label();
            label21 = new Label();
            label5 = new Label();
            label29 = new Label();
            label4 = new Label();
            txtgetMedicineBill = new TextBox();
            label3 = new Label();
            txtTotalDays = new TextBox();
            label2 = new Label();
            txtgetDoctorBill = new TextBox();
            label10 = new Label();
            label36 = new Label();
            btnSelectBillReport = new Button();
            panel7 = new Panel();
            txtRemainingBal = new TextBox();
            txtPaidBill = new TextBox();
            label11 = new Label();
            label12 = new Label();
            txtTBill = new TextBox();
            txtDoctorBill = new TextBox();
            txtPName = new TextBox();
            label13 = new Label();
            txtRefDoctor = new TextBox();
            txtRoomBill = new TextBox();
            txtMedicineBill = new TextBox();
            label35 = new Label();
            label40 = new Label();
            label41 = new Label();
            label42 = new Label();
            label44 = new Label();
            txtPAge = new TextBox();
            txtPMobile = new TextBox();
            txtPAddress = new TextBox();
            txtPGender = new TextBox();
            txtRoomType = new TextBox();
            label14 = new Label();
            label15 = new Label();
            txtDisease = new TextBox();
            label28 = new Label();
            label31 = new Label();
            txtHanDoctor = new TextBox();
            label32 = new Label();
            label33 = new Label();
            label34 = new Label();
            CBBillReport = new ComboBox();
            btnBillReport = new Button();
            btnAddBillDetail = new Button();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            PanelBillReport.SuspendLayout();
            PanelAddBillDetail.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel7.SuspendLayout();
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
            panel1.TabIndex = 12;
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
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(265, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(981, 60);
            panel4.TabIndex = 13;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(301, 15);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(365, 42);
            textBox2.TabIndex = 10;
            textBox2.Text = "Add Bill Detail";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // panel3
            // 
            panel3.Controls.Add(PanelAddBillDetail);
            panel3.Controls.Add(PanelBillReport);
            panel3.Controls.Add(btnBillReport);
            panel3.Controls.Add(btnAddBillDetail);
            panel3.Location = new Point(265, 78);
            panel3.Name = "panel3";
            panel3.Size = new Size(981, 622);
            panel3.TabIndex = 14;
            // 
            // PanelBillReport
            // 
            PanelBillReport.BackColor = SystemColors.Control;
            PanelBillReport.Controls.Add(label36);
            PanelBillReport.Controls.Add(btnSelectBillReport);
            PanelBillReport.Controls.Add(panel7);
            PanelBillReport.Controls.Add(CBBillReport);
            PanelBillReport.Location = new Point(17, 76);
            PanelBillReport.Name = "PanelBillReport";
            PanelBillReport.Size = new Size(945, 535);
            PanelBillReport.TabIndex = 70;
            PanelBillReport.Paint += PanelBillReport_Paint;
            // 
            // PanelAddBillDetail
            // 
            PanelAddBillDetail.Controls.Add(panel2);
            PanelAddBillDetail.Controls.Add(panel5);
            PanelAddBillDetail.Controls.Add(txtTotalBill);
            PanelAddBillDetail.Controls.Add(txtTotalDoctorBill);
            PanelAddBillDetail.Controls.Add(btnAddBill);
            PanelAddBillDetail.Controls.Add(txtTotalRoomBill);
            PanelAddBillDetail.Controls.Add(label1);
            PanelAddBillDetail.Controls.Add(txtTotalMedicineBill);
            PanelAddBillDetail.Controls.Add(CBPatientIDBill);
            PanelAddBillDetail.Controls.Add(label9);
            PanelAddBillDetail.Controls.Add(btnSelectPatientID);
            PanelAddBillDetail.Controls.Add(label8);
            PanelAddBillDetail.Controls.Add(txtgetRoomBill);
            PanelAddBillDetail.Controls.Add(label7);
            PanelAddBillDetail.Controls.Add(label30);
            PanelAddBillDetail.Controls.Add(label6);
            PanelAddBillDetail.Controls.Add(label21);
            PanelAddBillDetail.Controls.Add(label5);
            PanelAddBillDetail.Controls.Add(label29);
            PanelAddBillDetail.Controls.Add(label4);
            PanelAddBillDetail.Controls.Add(txtgetMedicineBill);
            PanelAddBillDetail.Controls.Add(label3);
            PanelAddBillDetail.Controls.Add(txtTotalDays);
            PanelAddBillDetail.Controls.Add(label2);
            PanelAddBillDetail.Controls.Add(txtgetDoctorBill);
            PanelAddBillDetail.Controls.Add(label10);
            PanelAddBillDetail.Location = new Point(17, 76);
            PanelAddBillDetail.Name = "PanelAddBillDetail";
            PanelAddBillDetail.Size = new Size(945, 535);
            PanelAddBillDetail.TabIndex = 22;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 255, 128);
            panel2.BorderStyle = BorderStyle.FixedSingle;
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
            panel2.Location = new Point(0, 52);
            panel2.Name = "panel2";
            panel2.Size = new Size(945, 193);
            panel2.TabIndex = 25;
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
            txtgetName.Location = new Point(182, 4);
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
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(txtgetPaidBill);
            panel5.Controls.Add(txtgetRemainingBill);
            panel5.Controls.Add(label27);
            panel5.Controls.Add(label26);
            panel5.Location = new Point(0, 478);
            panel5.Name = "panel5";
            panel5.Size = new Size(945, 57);
            panel5.TabIndex = 69;
            // 
            // txtgetPaidBill
            // 
            txtgetPaidBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetPaidBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetPaidBill.ForeColor = Color.SeaGreen;
            txtgetPaidBill.Location = new Point(478, 16);
            txtgetPaidBill.Name = "txtgetPaidBill";
            txtgetPaidBill.Size = new Size(128, 31);
            txtgetPaidBill.TabIndex = 36;
            // 
            // txtgetRemainingBill
            // 
            txtgetRemainingBill.BackColor = Color.FromArgb(255, 224, 192);
            txtgetRemainingBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetRemainingBill.ForeColor = Color.Red;
            txtgetRemainingBill.Location = new Point(762, 16);
            txtgetRemainingBill.Name = "txtgetRemainingBill";
            txtgetRemainingBill.Size = new Size(128, 31);
            txtgetRemainingBill.TabIndex = 35;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label27.ForeColor = Color.SeaGreen;
            label27.Location = new Point(379, 21);
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
            label26.Location = new Point(612, 21);
            label26.Name = "label26";
            label26.Size = new Size(144, 21);
            label26.TabIndex = 23;
            label26.Text = "Remaining Bal:";
            // 
            // txtTotalBill
            // 
            txtTotalBill.BackColor = SystemColors.ControlLightLight;
            txtTotalBill.BorderStyle = BorderStyle.FixedSingle;
            txtTotalBill.Location = new Point(526, 415);
            txtTotalBill.Name = "txtTotalBill";
            txtTotalBill.Size = new Size(128, 31);
            txtTotalBill.TabIndex = 68;
            // 
            // txtTotalDoctorBill
            // 
            txtTotalDoctorBill.BackColor = SystemColors.ControlLightLight;
            txtTotalDoctorBill.BorderStyle = BorderStyle.FixedSingle;
            txtTotalDoctorBill.Location = new Point(526, 306);
            txtTotalDoctorBill.Name = "txtTotalDoctorBill";
            txtTotalDoctorBill.Size = new Size(128, 31);
            txtTotalDoctorBill.TabIndex = 67;
            txtTotalDoctorBill.TextChanged += txtTotalDoctorBill_TextChanged;
            // 
            // btnAddBill
            // 
            btnAddBill.BackColor = Color.Green;
            btnAddBill.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddBill.ForeColor = Color.White;
            btnAddBill.Location = new Point(769, 419);
            btnAddBill.Name = "btnAddBill";
            btnAddBill.Size = new Size(146, 38);
            btnAddBill.TabIndex = 23;
            btnAddBill.Text = "Add Bill";
            btnAddBill.UseVisualStyleBackColor = false;
            btnAddBill.Click += btnAddBill_Click;
            // 
            // txtTotalRoomBill
            // 
            txtTotalRoomBill.BackColor = SystemColors.ControlLightLight;
            txtTotalRoomBill.BorderStyle = BorderStyle.FixedSingle;
            txtTotalRoomBill.Location = new Point(526, 263);
            txtTotalRoomBill.Name = "txtTotalRoomBill";
            txtTotalRoomBill.Size = new Size(128, 31);
            txtTotalRoomBill.TabIndex = 65;
            txtTotalRoomBill.TextChanged += txtTotalRoomBill_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(170, 19);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 20;
            label1.Text = "Patient ID :";
            // 
            // txtTotalMedicineBill
            // 
            txtTotalMedicineBill.BackColor = SystemColors.ControlLightLight;
            txtTotalMedicineBill.BorderStyle = BorderStyle.FixedSingle;
            txtTotalMedicineBill.Location = new Point(526, 352);
            txtTotalMedicineBill.Name = "txtTotalMedicineBill";
            txtTotalMedicineBill.Size = new Size(128, 31);
            txtTotalMedicineBill.TabIndex = 66;
            txtTotalMedicineBill.TextChanged += txtTotalMedicineBill_TextChanged;
            // 
            // CBPatientIDBill
            // 
            CBPatientIDBill.FormattingEnabled = true;
            CBPatientIDBill.Location = new Point(282, 13);
            CBPatientIDBill.Name = "CBPatientIDBill";
            CBPatientIDBill.Size = new Size(182, 33);
            CBPatientIDBill.TabIndex = 21;
            CBPatientIDBill.SelectedIndexChanged += CBPatientIDBill_SelectedIndexChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(478, 357);
            label9.Name = "label9";
            label9.Size = new Size(36, 25);
            label9.TabIndex = 64;
            label9.Text = "==";
            // 
            // btnSelectPatientID
            // 
            btnSelectPatientID.BackColor = Color.MediumSeaGreen;
            btnSelectPatientID.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectPatientID.ForeColor = Color.White;
            btnSelectPatientID.Location = new Point(481, 13);
            btnSelectPatientID.Name = "btnSelectPatientID";
            btnSelectPatientID.Size = new Size(106, 33);
            btnSelectPatientID.TabIndex = 8;
            btnSelectPatientID.Text = "Select";
            btnSelectPatientID.UseVisualStyleBackColor = false;
            btnSelectPatientID.Click += btnSelectPatientID_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(478, 312);
            label8.Name = "label8";
            label8.Size = new Size(36, 25);
            label8.TabIndex = 63;
            label8.Text = "==";
            // 
            // txtgetRoomBill
            // 
            txtgetRoomBill.BackColor = SystemColors.ControlLightLight;
            txtgetRoomBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetRoomBill.ForeColor = Color.Black;
            txtgetRoomBill.Location = new Point(178, 263);
            txtgetRoomBill.Name = "txtgetRoomBill";
            txtgetRoomBill.Size = new Size(128, 31);
            txtgetRoomBill.TabIndex = 55;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(478, 269);
            label7.Name = "label7";
            label7.Size = new Size(36, 25);
            label7.TabIndex = 62;
            label7.Text = "==";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(59, 312);
            label30.Name = "label30";
            label30.Size = new Size(113, 21);
            label30.TabIndex = 52;
            label30.Text = "Doctor Bill :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(417, 420);
            label6.Name = "label6";
            label6.Size = new Size(97, 21);
            label6.TabIndex = 61;
            label6.Text = "Total Bill :";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(65, 263);
            label21.Name = "label21";
            label21.Size = new Size(107, 21);
            label21.TabIndex = 49;
            label21.Text = "Room Bill :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(178, 354);
            label5.Name = "label5";
            label5.Size = new Size(22, 25);
            label5.TabIndex = 60;
            label5.Text = "0";
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(38, 357);
            label29.Name = "label29";
            label29.Size = new Size(134, 21);
            label29.TabIndex = 51;
            label29.Text = "Medicine Bill :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(178, 308);
            label4.Name = "label4";
            label4.Size = new Size(22, 25);
            label4.TabIndex = 59;
            label4.Text = "0";
            // 
            // txtgetMedicineBill
            // 
            txtgetMedicineBill.BackColor = SystemColors.ControlLightLight;
            txtgetMedicineBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetMedicineBill.Location = new Point(338, 352);
            txtgetMedicineBill.Name = "txtgetMedicineBill";
            txtgetMedicineBill.Size = new Size(128, 31);
            txtgetMedicineBill.TabIndex = 53;
            txtgetMedicineBill.TextChanged += txtgetMedicineBill_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(308, 309);
            label3.Name = "label3";
            label3.Size = new Size(24, 25);
            label3.TabIndex = 58;
            label3.Text = "+";
            // 
            // txtTotalDays
            // 
            txtTotalDays.BackColor = SystemColors.ControlLightLight;
            txtTotalDays.BorderStyle = BorderStyle.FixedSingle;
            txtTotalDays.Location = new Point(338, 263);
            txtTotalDays.Name = "txtTotalDays";
            txtTotalDays.Size = new Size(128, 31);
            txtTotalDays.TabIndex = 50;
            txtTotalDays.TextChanged += txtTotalDays_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(308, 354);
            label2.Name = "label2";
            label2.Size = new Size(24, 25);
            label2.TabIndex = 57;
            label2.Text = "+";
            // 
            // txtgetDoctorBill
            // 
            txtgetDoctorBill.BackColor = SystemColors.ControlLightLight;
            txtgetDoctorBill.BorderStyle = BorderStyle.FixedSingle;
            txtgetDoctorBill.Location = new Point(338, 306);
            txtgetDoctorBill.Name = "txtgetDoctorBill";
            txtgetDoctorBill.Size = new Size(128, 31);
            txtgetDoctorBill.TabIndex = 54;
            txtgetDoctorBill.TextChanged += txtgetDoctorBill_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(312, 269);
            label10.Name = "label10";
            label10.Size = new Size(20, 25);
            label10.TabIndex = 56;
            label10.Text = "*";
            // 
            // label36
            // 
            label36.AutoSize = true;
            label36.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label36.Location = new Point(211, 27);
            label36.Name = "label36";
            label36.Size = new Size(106, 21);
            label36.TabIndex = 20;
            label36.Text = "Patient ID :";
            // 
            // btnSelectBillReport
            // 
            btnSelectBillReport.BackColor = Color.MediumSeaGreen;
            btnSelectBillReport.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectBillReport.ForeColor = Color.White;
            btnSelectBillReport.Location = new Point(524, 21);
            btnSelectBillReport.Name = "btnSelectBillReport";
            btnSelectBillReport.Size = new Size(106, 33);
            btnSelectBillReport.TabIndex = 8;
            btnSelectBillReport.Text = "Select";
            btnSelectBillReport.UseVisualStyleBackColor = false;
            btnSelectBillReport.Click += button2_Click;
            // 
            // panel7
            // 
            panel7.BackColor = Color.DarkTurquoise;
            panel7.Controls.Add(txtRemainingBal);
            panel7.Controls.Add(txtPaidBill);
            panel7.Controls.Add(label11);
            panel7.Controls.Add(label12);
            panel7.Controls.Add(txtTBill);
            panel7.Controls.Add(txtDoctorBill);
            panel7.Controls.Add(txtPName);
            panel7.Controls.Add(label13);
            panel7.Controls.Add(txtRefDoctor);
            panel7.Controls.Add(txtRoomBill);
            panel7.Controls.Add(txtMedicineBill);
            panel7.Controls.Add(label35);
            panel7.Controls.Add(label40);
            panel7.Controls.Add(label41);
            panel7.Controls.Add(label42);
            panel7.Controls.Add(label44);
            panel7.Controls.Add(txtPAge);
            panel7.Controls.Add(txtPMobile);
            panel7.Controls.Add(txtPAddress);
            panel7.Controls.Add(txtPGender);
            panel7.Controls.Add(txtRoomType);
            panel7.Controls.Add(label14);
            panel7.Controls.Add(label15);
            panel7.Controls.Add(txtDisease);
            panel7.Controls.Add(label28);
            panel7.Controls.Add(label31);
            panel7.Controls.Add(txtHanDoctor);
            panel7.Controls.Add(label32);
            panel7.Controls.Add(label33);
            panel7.Controls.Add(label34);
            panel7.Location = new Point(3, 76);
            panel7.Name = "panel7";
            panel7.Size = new Size(939, 456);
            panel7.TabIndex = 70;
            panel7.Paint += panel7_Paint;
            // 
            // txtRemainingBal
            // 
            txtRemainingBal.BackColor = SystemColors.ControlLightLight;
            txtRemainingBal.BorderStyle = BorderStyle.FixedSingle;
            txtRemainingBal.ForeColor = Color.Red;
            txtRemainingBal.Location = new Point(634, 82);
            txtRemainingBal.Name = "txtRemainingBal";
            txtRemainingBal.Size = new Size(128, 31);
            txtRemainingBal.TabIndex = 76;
            // 
            // txtPaidBill
            // 
            txtPaidBill.BackColor = SystemColors.ControlLightLight;
            txtPaidBill.BorderStyle = BorderStyle.FixedSingle;
            txtPaidBill.ForeColor = Color.Green;
            txtPaidBill.Location = new Point(634, 38);
            txtPaidBill.Name = "txtPaidBill";
            txtPaidBill.Size = new Size(128, 31);
            txtPaidBill.TabIndex = 75;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Green;
            label11.Location = new Point(512, 43);
            label11.Name = "label11";
            label11.Size = new Size(97, 21);
            label11.TabIndex = 74;
            label11.Text = "Paid Bill =";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(456, 87);
            label12.Name = "label12";
            label12.Size = new Size(153, 21);
            label12.TabIndex = 73;
            label12.Text = "Remaining Bal =";
            // 
            // txtTBill
            // 
            txtTBill.BackColor = SystemColors.ControlLightLight;
            txtTBill.BorderStyle = BorderStyle.FixedSingle;
            txtTBill.Location = new Point(634, 125);
            txtTBill.Name = "txtTBill";
            txtTBill.Size = new Size(128, 31);
            txtTBill.TabIndex = 84;
            // 
            // txtDoctorBill
            // 
            txtDoctorBill.BackColor = SystemColors.ControlLightLight;
            txtDoctorBill.BorderStyle = BorderStyle.FixedSingle;
            txtDoctorBill.Location = new Point(265, 97);
            txtDoctorBill.Name = "txtDoctorBill";
            txtDoctorBill.Size = new Size(128, 31);
            txtDoctorBill.TabIndex = 83;
            // 
            // txtPName
            // 
            txtPName.BackColor = SystemColors.ControlLightLight;
            txtPName.BorderStyle = BorderStyle.FixedSingle;
            txtPName.Location = new Point(174, 216);
            txtPName.Name = "txtPName";
            txtPName.Size = new Size(250, 31);
            txtPName.TabIndex = 71;
            txtPName.TextChanged += txtPName_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Arial", 9F, FontStyle.Bold);
            label13.Location = new Point(478, 209);
            label13.Name = "label13";
            label13.Size = new Size(162, 21);
            label13.TabIndex = 70;
            label13.Text = "Refer By Doctor :";
            // 
            // txtRefDoctor
            // 
            txtRefDoctor.BackColor = SystemColors.ControlLightLight;
            txtRefDoctor.BorderStyle = BorderStyle.FixedSingle;
            txtRefDoctor.Location = new Point(668, 206);
            txtRefDoctor.Name = "txtRefDoctor";
            txtRefDoctor.Size = new Size(244, 31);
            txtRefDoctor.TabIndex = 72;
            // 
            // txtRoomBill
            // 
            txtRoomBill.BackColor = SystemColors.ControlLightLight;
            txtRoomBill.BorderStyle = BorderStyle.FixedSingle;
            txtRoomBill.Location = new Point(265, 54);
            txtRoomBill.Name = "txtRoomBill";
            txtRoomBill.Size = new Size(128, 31);
            txtRoomBill.TabIndex = 81;
            // 
            // txtMedicineBill
            // 
            txtMedicineBill.BackColor = SystemColors.ControlLightLight;
            txtMedicineBill.BorderStyle = BorderStyle.FixedSingle;
            txtMedicineBill.Location = new Point(265, 138);
            txtMedicineBill.Name = "txtMedicineBill";
            txtMedicineBill.Size = new Size(128, 31);
            txtMedicineBill.TabIndex = 82;
            // 
            // label35
            // 
            label35.AutoSize = true;
            label35.Font = new Font("Arial", 9F, FontStyle.Bold);
            label35.Location = new Point(25, 221);
            label35.Name = "label35";
            label35.Size = new Size(139, 21);
            label35.TabIndex = 69;
            label35.Text = "Patient Name :";
            // 
            // label40
            // 
            label40.AutoSize = true;
            label40.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label40.Location = new Point(146, 105);
            label40.Name = "label40";
            label40.Size = new Size(113, 21);
            label40.TabIndex = 79;
            label40.Text = "Doctor Bill :";
            // 
            // label41
            // 
            label41.AutoSize = true;
            label41.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label41.Location = new Point(508, 130);
            label41.Name = "label41";
            label41.Size = new Size(101, 21);
            label41.TabIndex = 80;
            label41.Text = "Total Bill =";
            // 
            // label42
            // 
            label42.AutoSize = true;
            label42.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label42.Location = new Point(152, 59);
            label42.Name = "label42";
            label42.Size = new Size(107, 21);
            label42.TabIndex = 77;
            label42.Text = "Room Bill :";
            // 
            // label44
            // 
            label44.AutoSize = true;
            label44.Font = new Font("Arial", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label44.Location = new Point(125, 140);
            label44.Name = "label44";
            label44.Size = new Size(134, 21);
            label44.TabIndex = 78;
            label44.Text = "Medicine Bill :";
            // 
            // txtPAge
            // 
            txtPAge.BackColor = SystemColors.ControlLightLight;
            txtPAge.BorderStyle = BorderStyle.FixedSingle;
            txtPAge.Location = new Point(170, 315);
            txtPAge.Name = "txtPAge";
            txtPAge.Size = new Size(250, 31);
            txtPAge.TabIndex = 32;
            // 
            // txtPMobile
            // 
            txtPMobile.BackColor = SystemColors.ControlLightLight;
            txtPMobile.BorderStyle = BorderStyle.FixedSingle;
            txtPMobile.Location = new Point(170, 361);
            txtPMobile.Name = "txtPMobile";
            txtPMobile.Size = new Size(250, 31);
            txtPMobile.TabIndex = 31;
            // 
            // txtPAddress
            // 
            txtPAddress.BackColor = SystemColors.ControlLightLight;
            txtPAddress.BorderStyle = BorderStyle.FixedSingle;
            txtPAddress.Location = new Point(170, 407);
            txtPAddress.Name = "txtPAddress";
            txtPAddress.Size = new Size(250, 31);
            txtPAddress.TabIndex = 30;
            // 
            // txtPGender
            // 
            txtPGender.BackColor = SystemColors.ControlLightLight;
            txtPGender.BorderStyle = BorderStyle.FixedSingle;
            txtPGender.Location = new Point(170, 267);
            txtPGender.Name = "txtPGender";
            txtPGender.Size = new Size(250, 31);
            txtPGender.TabIndex = 26;
            // 
            // txtRoomType
            // 
            txtRoomType.BackColor = SystemColors.ControlLightLight;
            txtRoomType.BorderStyle = BorderStyle.FixedSingle;
            txtRoomType.Location = new Point(664, 349);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(244, 31);
            txtRoomType.TabIndex = 29;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Arial", 9F, FontStyle.Bold);
            label14.Location = new Point(544, 261);
            label14.Name = "label14";
            label14.Size = new Size(92, 21);
            label14.TabIndex = 25;
            label14.Text = "Disease :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Arial", 9F, FontStyle.Bold);
            label15.Location = new Point(461, 307);
            label15.Name = "label15";
            label15.Size = new Size(175, 21);
            label15.TabIndex = 24;
            label15.Text = "Handle By Doctor :";
            // 
            // txtDisease
            // 
            txtDisease.BackColor = SystemColors.ControlLightLight;
            txtDisease.BorderStyle = BorderStyle.FixedSingle;
            txtDisease.Location = new Point(664, 256);
            txtDisease.Name = "txtDisease";
            txtDisease.Size = new Size(244, 31);
            txtDisease.TabIndex = 28;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.Font = new Font("Arial", 9F, FontStyle.Bold);
            label28.Location = new Point(514, 353);
            label28.Name = "label28";
            label28.Size = new Size(122, 21);
            label28.TabIndex = 23;
            label28.Text = "Room Type :";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Arial", 9F, FontStyle.Bold);
            label31.Location = new Point(64, 412);
            label31.Name = "label31";
            label31.Size = new Size(95, 21);
            label31.TabIndex = 22;
            label31.Text = "Address :";
            // 
            // txtHanDoctor
            // 
            txtHanDoctor.BackColor = SystemColors.ControlLightLight;
            txtHanDoctor.BorderStyle = BorderStyle.FixedSingle;
            txtHanDoctor.Location = new Point(664, 302);
            txtHanDoctor.Name = "txtHanDoctor";
            txtHanDoctor.Size = new Size(244, 31);
            txtHanDoctor.TabIndex = 27;
            // 
            // label32
            // 
            label32.AutoSize = true;
            label32.Font = new Font("Arial", 9F, FontStyle.Bold);
            label32.Location = new Point(50, 366);
            label32.Name = "label32";
            label32.Size = new Size(109, 21);
            label32.TabIndex = 21;
            label32.Text = "Mobile No :";
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Font = new Font("Arial", 9F, FontStyle.Bold);
            label33.Location = new Point(103, 313);
            label33.Name = "label33";
            label33.Size = new Size(57, 21);
            label33.TabIndex = 20;
            label33.Text = "Age :";
            // 
            // label34
            // 
            label34.AutoSize = true;
            label34.Font = new Font("Arial", 9F, FontStyle.Bold);
            label34.Location = new Point(73, 274);
            label34.Name = "label34";
            label34.Size = new Size(87, 21);
            label34.TabIndex = 19;
            label34.Text = "Gender :";
            // 
            // CBBillReport
            // 
            CBBillReport.FormattingEnabled = true;
            CBBillReport.Location = new Point(323, 21);
            CBBillReport.Name = "CBBillReport";
            CBBillReport.Size = new Size(182, 33);
            CBBillReport.TabIndex = 21;
            CBBillReport.SelectedIndexChanged += CBBillReport_SelectedIndexChanged;
            // 
            // btnBillReport
            // 
            btnBillReport.Location = new Point(184, 36);
            btnBillReport.Name = "btnBillReport";
            btnBillReport.Size = new Size(102, 34);
            btnBillReport.TabIndex = 19;
            btnBillReport.Text = "Bill Report";
            btnBillReport.UseVisualStyleBackColor = true;
            btnBillReport.Click += btnBillReport_Click;
            // 
            // btnAddBillDetail
            // 
            btnAddBillDetail.Location = new Point(49, 36);
            btnAddBillDetail.Name = "btnAddBillDetail";
            btnAddBillDetail.Size = new Size(138, 34);
            btnAddBillDetail.TabIndex = 12;
            btnAddBillDetail.Text = "Add Bill Detail";
            btnAddBillDetail.UseVisualStyleBackColor = true;
            btnAddBillDetail.Click += btnAddBillDetail_Click;
            // 
            // Bill
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 712);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel1);
            Name = "Bill";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bill";
            Load += Bill_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            PanelBillReport.ResumeLayout(false);
            PanelBillReport.PerformLayout();
            PanelAddBillDetail.ResumeLayout(false);
            PanelAddBillDetail.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
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
        private Panel panel3;
        private Button btnBillReport;
        private Button btnAddBillDetail;
        private TextBox textBox2;
        private Panel PanelAddBillDetail;
        private Panel panel5;
        private TextBox txtgetPaidBill;
        private TextBox txtgetRemainingBill;
        private Label label27;
        private Label label26;
        private TextBox txtTotalBill;
        private Panel panel2;
        private TextBox txtGetAge;
        private TextBox txtGetMobile;
        private TextBox txtGetAddress;
        private TextBox txtGetReferDr;
        private TextBox txtGetDisease;
        private TextBox txtGetHandleDr;
        private TextBox txtGetRoomType;
        private TextBox txtGetGender;
        private TextBox txtgetName;
        private Label label25;
        private Label label24;
        private Label label23;
        private Label label22;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private Label label16;
        private TextBox txtTotalDoctorBill;
        private Button btnAddBill;
        private TextBox txtTotalRoomBill;
        private Label label1;
        private TextBox txtTotalMedicineBill;
        private ComboBox CBPatientIDBill;
        private Label label9;
        private Button btnSelectPatientID;
        private Label label8;
        private TextBox txtgetRoomBill;
        private Label label7;
        private Label label30;
        private Label label6;
        private Label label21;
        private Label label5;
        private Label label29;
        private Label label4;
        private TextBox txtgetMedicineBill;
        private Label label3;
        private TextBox txtTotalDays;
        private Label label2;
        private TextBox txtgetDoctorBill;
        private Label label10;
        private Panel PanelBillReport;
        private Label label36;
        private ComboBox CBBillReport;
        private Button btnSelectBillReport;
        private Panel panel7;
        private TextBox txtRemainingBal;
        private TextBox txtPaidBill;
        private Label label11;
        private Label label12;
        private TextBox txtTBill;
        private TextBox txtDoctorBill;
        private TextBox txtPName;
        private Label label13;
        private TextBox txtRefDoctor;
        private TextBox txtRoomBill;
        private TextBox txtMedicineBill;
        private Label label35;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label44;
        private TextBox txtPAge;
        private TextBox txtPMobile;
        private TextBox txtPAddress;
        private TextBox txtPGender;
        private TextBox txtRoomType;
        private Label label14;
        private Label label15;
        private TextBox txtDisease;
        private Label label28;
        private Label label31;
        private TextBox txtHanDoctor;
        private Label label32;
        private Label label33;
        private Label label34;
    }
}
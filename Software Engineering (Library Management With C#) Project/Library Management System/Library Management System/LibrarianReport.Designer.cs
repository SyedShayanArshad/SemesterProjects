namespace Library_Management_System
{
    partial class LibrarianReport
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnLogout = new Button();
            btnMyAccount = new Button();
            btnLibrarianReport = new Button();
            btnReturnBook = new Button();
            label2 = new Label();
            ReportPanel = new Panel();
            btnUpdateLibrarian = new Button();
            btnRemoveLibrarian = new Button();
            label1 = new Label();
            DGVLibrarianReport = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            Username = new DataGridViewTextBoxColumn();
            Password = new DataGridViewTextBoxColumn();
            Mobile = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVLibrarianReport).BeginInit();
            SuspendLayout();
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
            btnLogout.TabIndex = 67;
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
            btnMyAccount.TabIndex = 63;
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
            btnLibrarianReport.TabIndex = 64;
            btnLibrarianReport.Text = "Librarian Report";
            btnLibrarianReport.UseVisualStyleBackColor = false;
            btnLibrarianReport.Click += btnLibrarianReport_Click;
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
            btnReturnBook.TabIndex = 66;
            btnReturnBook.Text = "Edit Account";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
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
            label2.TabIndex = 68;
            label2.Text = "Welcome to Admin Panel";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReportPanel
            // 
            ReportPanel.BackColor = Color.PaleGreen;
            ReportPanel.BorderStyle = BorderStyle.FixedSingle;
            ReportPanel.Controls.Add(btnUpdateLibrarian);
            ReportPanel.Controls.Add(btnRemoveLibrarian);
            ReportPanel.Controls.Add(label1);
            ReportPanel.Controls.Add(DGVLibrarianReport);
            ReportPanel.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReportPanel.ForeColor = Color.White;
            ReportPanel.Location = new Point(258, 82);
            ReportPanel.Margin = new Padding(3, 4, 3, 4);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(788, 620);
            ReportPanel.TabIndex = 70;
            // 
            // btnUpdateLibrarian
            // 
            btnUpdateLibrarian.BackColor = Color.Green;
            btnUpdateLibrarian.Location = new Point(563, 504);
            btnUpdateLibrarian.Name = "btnUpdateLibrarian";
            btnUpdateLibrarian.Size = new Size(220, 37);
            btnUpdateLibrarian.TabIndex = 72;
            btnUpdateLibrarian.Text = "Update Librarian";
            btnUpdateLibrarian.UseVisualStyleBackColor = false;
            btnUpdateLibrarian.Click += btnUpdateLibrarian_Click;
            // 
            // btnRemoveLibrarian
            // 
            btnRemoveLibrarian.BackColor = Color.Green;
            btnRemoveLibrarian.Location = new Point(3, 504);
            btnRemoveLibrarian.Name = "btnRemoveLibrarian";
            btnRemoveLibrarian.Size = new Size(226, 37);
            btnRemoveLibrarian.TabIndex = 71;
            btnRemoveLibrarian.Text = "Remove Librarian";
            btnRemoveLibrarian.UseVisualStyleBackColor = false;
            btnRemoveLibrarian.Click += btnRemoveLibrarian_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(15, 10);
            label1.Name = "label1";
            label1.Size = new Size(758, 51);
            label1.TabIndex = 29;
            label1.Text = "View Librarian Report";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DGVLibrarianReport
            // 
            DGVLibrarianReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVLibrarianReport.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVLibrarianReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVLibrarianReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVLibrarianReport.Columns.AddRange(new DataGridViewColumn[] { ID, Name, Username, Password, Mobile, Address, Gender });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            DGVLibrarianReport.DefaultCellStyle = dataGridViewCellStyle2;
            DGVLibrarianReport.Location = new Point(3, 79);
            DGVLibrarianReport.MultiSelect = false;
            DGVLibrarianReport.Name = "DGVLibrarianReport";
            DGVLibrarianReport.RowHeadersVisible = false;
            DGVLibrarianReport.RowHeadersWidth = 62;
            DGVLibrarianReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DGVLibrarianReport.Size = new Size(780, 407);
            DGVLibrarianReport.TabIndex = 28;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 8;
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.MinimumWidth = 8;
            Name.Name = "Name";
            Name.ReadOnly = true;
            // 
            // Username
            // 
            Username.HeaderText = "Username";
            Username.MinimumWidth = 8;
            Username.Name = "Username";
            Username.ReadOnly = true;
            // 
            // Password
            // 
            Password.HeaderText = "Password";
            Password.MinimumWidth = 8;
            Password.Name = "Password";
            Password.ReadOnly = true;
            // 
            // Mobile
            // 
            Mobile.HeaderText = "Mobile";
            Mobile.MinimumWidth = 8;
            Mobile.Name = "Mobile";
            Mobile.ReadOnly = true;
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 8;
            Address.Name = "Address";
            Address.ReadOnly = true;
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.MinimumWidth = 8;
            Gender.Name = "Gender";
            Gender.ReadOnly = true;
            // 
            // LibrarianReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(ReportPanel);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnLibrarianReport);
            Controls.Add(btnReturnBook);
            Controls.Add(label2);
            //Name = "LibrarianReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LibrarianReport";
            Load += LibrarianReport_Load;
            ReportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DGVLibrarianReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLogout;
        private Button btnMyAccount;
        private Button btnLibrarianReport;
        private Button btnReturnBook;
        private Label label2;
        private Panel ReportPanel;
        private Label label1;
        private DataGridView DGVLibrarianReport;
        private Button btnRemoveLibrarian;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn Username;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn Mobile;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Gender;
        private Button btnUpdateLibrarian;
    }
}
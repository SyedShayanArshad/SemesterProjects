namespace Library_Management_System
{
    partial class StudentViewBooks
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
            btnBorrowBooks = new Button();
            btnHome = new Button();
            btnReturnBook = new Button();
            btnViewBooks = new Button();
            label2 = new Label();
            ReportPanel = new Panel();
            label8 = new Label();
            dgvBookReport = new DataGridView();
            BookTitle = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Available = new DataGridViewTextBoxColumn();
            View = new DataGridViewLinkColumn();
            detailPanel = new Panel();
            btnBack = new Button();
            lblAvailable = new Label();
            label1 = new Label();
            lblIssued = new Label();
            lblBookName = new Label();
            pbBookPicture = new PictureBox();
            lblEdition = new Label();
            lblDetail = new Label();
            lblQuantity = new Label();
            lblAuthor = new Label();
            lblPrice = new Label();
            btnPenalty = new Button();
            ReportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookReport).BeginInit();
            detailPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbBookPicture).BeginInit();
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
            btnLogout.TabIndex = 73;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnMyAccount
            // 
            btnMyAccount.BackColor = Color.DarkGreen;
            btnMyAccount.Font = new Font("Arial Rounded MT Bold", 12F);
            btnMyAccount.ForeColor = Color.White;
            btnMyAccount.Location = new Point(13, 141);
            btnMyAccount.Margin = new Padding(3, 4, 3, 4);
            btnMyAccount.Name = "btnMyAccount";
            btnMyAccount.Size = new Size(225, 45);
            btnMyAccount.TabIndex = 68;
            btnMyAccount.Text = "My Account";
            btnMyAccount.UseVisualStyleBackColor = false;
            btnMyAccount.Click += btnMyAccount_Click;
            // 
            // btnBorrowBooks
            // 
            btnBorrowBooks.BackColor = Color.DarkGreen;
            btnBorrowBooks.Font = new Font("Arial Rounded MT Bold", 12F);
            btnBorrowBooks.ForeColor = Color.White;
            btnBorrowBooks.Location = new Point(13, 206);
            btnBorrowBooks.Margin = new Padding(3, 4, 3, 4);
            btnBorrowBooks.Name = "btnBorrowBooks";
            btnBorrowBooks.Size = new Size(225, 45);
            btnBorrowBooks.TabIndex = 69;
            btnBorrowBooks.Text = "Books Borrowed";
            btnBorrowBooks.UseVisualStyleBackColor = false;
            btnBorrowBooks.Click += btnBorrowBooks_Click;
            // 
            // btnHome
            // 
            btnHome.BackColor = Color.DarkGreen;
            btnHome.Font = new Font("Arial Rounded MT Bold", 12F);
            btnHome.ForeColor = Color.White;
            btnHome.Location = new Point(13, 81);
            btnHome.Margin = new Padding(3, 4, 3, 4);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(225, 45);
            btnHome.TabIndex = 75;
            btnHome.Text = "Home";
            btnHome.UseVisualStyleBackColor = false;
            btnHome.Click += btnHome_Click;
            // 
            // btnReturnBook
            // 
            btnReturnBook.BackColor = Color.DarkGreen;
            btnReturnBook.Font = new Font("Arial Rounded MT Bold", 12F);
            btnReturnBook.ForeColor = Color.White;
            btnReturnBook.Location = new Point(13, 268);
            btnReturnBook.Margin = new Padding(3, 4, 3, 4);
            btnReturnBook.Name = "btnReturnBook";
            btnReturnBook.Size = new Size(225, 45);
            btnReturnBook.TabIndex = 71;
            btnReturnBook.Text = "Books Returned";
            btnReturnBook.UseVisualStyleBackColor = false;
            btnReturnBook.Click += btnReturnBook_Click;
            // 
            // btnViewBooks
            // 
            btnViewBooks.BackColor = Color.DarkGreen;
            btnViewBooks.Font = new Font("Arial Rounded MT Bold", 12F);
            btnViewBooks.ForeColor = Color.White;
            btnViewBooks.Location = new Point(13, 333);
            btnViewBooks.Margin = new Padding(3, 4, 3, 4);
            btnViewBooks.Name = "btnViewBooks";
            btnViewBooks.Size = new Size(225, 45);
            btnViewBooks.TabIndex = 70;
            btnViewBooks.Text = "View Books";
            btnViewBooks.UseVisualStyleBackColor = false;
            btnViewBooks.Click += btnViewBooks_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(82, 11);
            label2.Name = "label2";
            label2.Padding = new Padding(80, 10, 80, 10);
            label2.Size = new Size(916, 57);
            label2.TabIndex = 74;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // ReportPanel
            // 
            ReportPanel.BackColor = Color.PaleGreen;
            ReportPanel.BorderStyle = BorderStyle.FixedSingle;
            ReportPanel.Controls.Add(label8);
            ReportPanel.Controls.Add(dgvBookReport);
            ReportPanel.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ReportPanel.ForeColor = Color.White;
            ReportPanel.Location = new Point(258, 81);
            ReportPanel.Margin = new Padding(3, 4, 3, 4);
            ReportPanel.Name = "ReportPanel";
            ReportPanel.Size = new Size(788, 620);
            ReportPanel.TabIndex = 76;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.None;
            label8.BackColor = Color.Green;
            label8.Font = new Font("Arial Rounded MT Bold", 14F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(10, 11);
            label8.Name = "label8";
            label8.Size = new Size(758, 51);
            label8.TabIndex = 30;
            label8.Text = "All Books";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvBookReport
            // 
            dgvBookReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookReport.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookReport.Columns.AddRange(new DataGridViewColumn[] { BookTitle, Price, Quantity, Available, View });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBookReport.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBookReport.Location = new Point(3, 107);
            dgvBookReport.Name = "dgvBookReport";
            dgvBookReport.ReadOnly = true;
            dgvBookReport.RowHeadersVisible = false;
            dgvBookReport.RowHeadersWidth = 62;
            dgvBookReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookReport.Size = new Size(780, 504);
            dgvBookReport.TabIndex = 28;
            dgvBookReport.CellContentClick += dgvBookReport_CellContentClick;
            // 
            // BookTitle
            // 
            BookTitle.HeaderText = "Title";
            BookTitle.MinimumWidth = 8;
            BookTitle.Name = "BookTitle";
            BookTitle.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 8;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 8;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Available
            // 
            Available.HeaderText = "Available";
            Available.MinimumWidth = 8;
            Available.Name = "Available";
            Available.ReadOnly = true;
            // 
            // View
            // 
            View.HeaderText = "View";
            View.MinimumWidth = 8;
            View.Name = "View";
            View.ReadOnly = true;
            View.Text = "View";
            View.UseColumnTextForLinkValue = true;
            // 
            // detailPanel
            // 
            detailPanel.Controls.Add(btnBack);
            detailPanel.Controls.Add(lblAvailable);
            detailPanel.Controls.Add(label1);
            detailPanel.Controls.Add(lblIssued);
            detailPanel.Controls.Add(lblBookName);
            detailPanel.Controls.Add(pbBookPicture);
            detailPanel.Controls.Add(lblEdition);
            detailPanel.Controls.Add(lblDetail);
            detailPanel.Controls.Add(lblQuantity);
            detailPanel.Controls.Add(lblAuthor);
            detailPanel.Controls.Add(lblPrice);
            detailPanel.Location = new Point(258, 80);
            detailPanel.Name = "detailPanel";
            detailPanel.Size = new Size(788, 620);
            detailPanel.TabIndex = 29;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.Green;
            btnBack.Font = new Font("Arial Rounded MT Bold", 11F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(291, 386);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(99, 38);
            btnBack.TabIndex = 78;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // lblAvailable
            // 
            lblAvailable.AutoSize = true;
            lblAvailable.BackColor = Color.Transparent;
            lblAvailable.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAvailable.ForeColor = Color.Green;
            lblAvailable.Location = new Point(213, 257);
            lblAvailable.Name = "lblAvailable";
            lblAvailable.Size = new Size(124, 26);
            lblAvailable.TabIndex = 77;
            lblAvailable.Text = "Available :";
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(774, 44);
            label1.TabIndex = 68;
            label1.Text = "View Book Detail";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblIssued
            // 
            lblIssued.AutoSize = true;
            lblIssued.BackColor = Color.Transparent;
            lblIssued.Font = new Font("Arial Rounded MT Bold", 11F);
            lblIssued.ForeColor = Color.Green;
            lblIssued.Location = new Point(213, 293);
            lblIssued.Name = "lblIssued";
            lblIssued.Size = new Size(96, 26);
            lblIssued.TabIndex = 76;
            lblIssued.Text = "Issued :";
            // 
            // lblBookName
            // 
            lblBookName.AutoSize = true;
            lblBookName.BackColor = Color.Transparent;
            lblBookName.Font = new Font("Arial Rounded MT Bold", 11F);
            lblBookName.ForeColor = Color.Green;
            lblBookName.Location = new Point(3, 59);
            lblBookName.Name = "lblBookName";
            lblBookName.Size = new Size(148, 26);
            lblBookName.TabIndex = 69;
            lblBookName.Text = "Book Name :";
            // 
            // pbBookPicture
            // 
            pbBookPicture.Location = new Point(3, 100);
            pbBookPicture.Name = "pbBookPicture";
            pbBookPicture.Size = new Size(175, 230);
            pbBookPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBookPicture.TabIndex = 75;
            pbBookPicture.TabStop = false;
            // 
            // lblEdition
            // 
            lblEdition.AutoSize = true;
            lblEdition.BackColor = Color.Transparent;
            lblEdition.Font = new Font("Arial Rounded MT Bold", 11F);
            lblEdition.ForeColor = Color.Green;
            lblEdition.Location = new Point(213, 139);
            lblEdition.Name = "lblEdition";
            lblEdition.Size = new Size(100, 26);
            lblEdition.TabIndex = 70;
            lblEdition.Text = "Edition :";
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.BackColor = Color.Transparent;
            lblDetail.Font = new Font("Arial Rounded MT Bold", 11F);
            lblDetail.ForeColor = Color.Green;
            lblDetail.Location = new Point(213, 334);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(87, 26);
            lblDetail.TabIndex = 74;
            lblDetail.Text = "Detail :";
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.BackColor = Color.Transparent;
            lblQuantity.Font = new Font("Arial Rounded MT Bold", 11F);
            lblQuantity.ForeColor = Color.Green;
            lblQuantity.Location = new Point(213, 219);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(115, 26);
            lblQuantity.TabIndex = 71;
            lblQuantity.Text = "Quantity :";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.Transparent;
            lblAuthor.Font = new Font("Arial Rounded MT Bold", 11F);
            lblAuthor.ForeColor = Color.Green;
            lblAuthor.Location = new Point(213, 100);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(98, 26);
            lblAuthor.TabIndex = 73;
            lblAuthor.Text = "Author :";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Arial Rounded MT Bold", 11F);
            lblPrice.ForeColor = Color.Green;
            lblPrice.Location = new Point(213, 180);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(82, 26);
            lblPrice.TabIndex = 72;
            lblPrice.Text = "Price :";
            // 
            // btnPenalty
            // 
            btnPenalty.BackColor = Color.DarkGreen;
            btnPenalty.Font = new Font("Arial Rounded MT Bold", 12F);
            btnPenalty.ForeColor = Color.White;
            btnPenalty.Location = new Point(13, 398);
            btnPenalty.Margin = new Padding(3, 4, 3, 4);
            btnPenalty.Name = "btnPenalty";
            btnPenalty.Size = new Size(225, 45);
            btnPenalty.TabIndex = 77;
            btnPenalty.Text = "Penalty Report";
            btnPenalty.UseVisualStyleBackColor = false;
            btnPenalty.Click += btnPenalty_Click;
            // 
            // StudentViewBooks
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnPenalty);
            Controls.Add(detailPanel);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnBorrowBooks);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewBooks);
            Controls.Add(label2);
            Controls.Add(ReportPanel);
            Name = "StudentViewBooks";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentViewBooks";
            Load += StudentViewBooks_Load;
            ReportPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBookReport).EndInit();
            detailPanel.ResumeLayout(false);
            detailPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbBookPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLogout;
        private Button btnMyAccount;
        private Button btnBorrowBooks;
        private Button btnHome;
        private Button btnReturnBook;
        private Button btnViewBooks;
        private Label label2;
        private Panel ReportPanel;
        private DataGridView dgvBookReport;
        private Label label8;
        private Panel detailPanel;
        private Button btnBack;
        private Label lblAvailable;
        private Label label1;
        private Label lblIssued;
        private Label lblBookName;
        private PictureBox pbBookPicture;
        private Label lblEdition;
        private Label lblDetail;
        private Label lblQuantity;
        private Label lblAuthor;
        private Label lblPrice;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Available;
        private DataGridViewLinkColumn View;
        private Button btnPenalty;
    }
}
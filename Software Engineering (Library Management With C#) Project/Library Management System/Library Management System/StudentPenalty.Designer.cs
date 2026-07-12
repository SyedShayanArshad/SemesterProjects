namespace Library_Management_System
{
    partial class StudentPenalty
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btnLogout = new Button();
            btnMyAccount = new Button();
            btnBorrowBooks = new Button();
            btnHome = new Button();
            btnReturnBook = new Button();
            btnViewBooks = new Button();
            label2 = new Label();
            panel1 = new Panel();
            dgvPenaltyList = new DataGridView();
            BookTitle = new DataGridViewTextBoxColumn();
            IssuedDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            ReturnDate = new DataGridViewTextBoxColumn();
            Fine = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnPenalty = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPenaltyList).BeginInit();
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
            btnLogout.TabIndex = 74;
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
            btnMyAccount.TabIndex = 69;
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
            btnBorrowBooks.TabIndex = 70;
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
            btnHome.TabIndex = 76;
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
            btnReturnBook.TabIndex = 72;
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
            btnViewBooks.TabIndex = 71;
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
            label2.TabIndex = 75;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(dgvPenaltyList);
            panel1.Controls.Add(label1);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 73;
            // 
            // dgvPenaltyList
            // 
            dgvPenaltyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPenaltyList.BackgroundColor = Color.Green;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvPenaltyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvPenaltyList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenaltyList.Columns.AddRange(new DataGridViewColumn[] { BookTitle, IssuedDate, DueDate, ReturnDate, Fine, Status });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Arial Rounded MT Bold", 10F);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvPenaltyList.DefaultCellStyle = dataGridViewCellStyle4;
            dgvPenaltyList.Location = new Point(3, 48);
            dgvPenaltyList.Name = "dgvPenaltyList";
            dgvPenaltyList.RowHeadersVisible = false;
            dgvPenaltyList.RowHeadersWidth = 62;
            dgvPenaltyList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPenaltyList.Size = new Size(780, 355);
            dgvPenaltyList.TabIndex = 61;
            dgvPenaltyList.CellContentClick += dgvPenaltyList_CellContentClick;
            // 
            // BookTitle
            // 
            BookTitle.HeaderText = "Book Title";
            BookTitle.MinimumWidth = 8;
            BookTitle.Name = "BookTitle";
            BookTitle.ReadOnly = true;
            // 
            // IssuedDate
            // 
            IssuedDate.HeaderText = "Issued Date";
            IssuedDate.MinimumWidth = 8;
            IssuedDate.Name = "IssuedDate";
            IssuedDate.ReadOnly = true;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.MinimumWidth = 8;
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
            // 
            // ReturnDate
            // 
            ReturnDate.HeaderText = "Return Date";
            ReturnDate.MinimumWidth = 8;
            ReturnDate.Name = "ReturnDate";
            ReturnDate.ReadOnly = true;
            // 
            // Fine
            // 
            Fine.HeaderText = "Fine";
            Fine.MinimumWidth = 8;
            Fine.Name = "Fine";
            Fine.ReadOnly = true;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 8;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // label1
            // 
            label1.BackColor = Color.Green;
            label1.Font = new Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(780, 45);
            label1.TabIndex = 60;
            label1.Text = "Student Penalty Report";
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
            // StudentPenalty
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnBorrowBooks);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewBooks);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(btnPenalty);
            Name = "StudentPenalty";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentPenalty";
            Load += StudentPenalty_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPenaltyList).EndInit();
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
        private Panel panel1;
        private Label label1;
        private Button btnPenalty;
        private DataGridView dgvPenaltyList;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn IssuedDate;
        private DataGridViewTextBoxColumn DueDate;
        private DataGridViewTextBoxColumn ReturnDate;
        private DataGridViewTextBoxColumn Fine;
        private DataGridViewTextBoxColumn Status;
    }
}
namespace Library_Management_System
{
    partial class StudentBorrowed
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
            panel1 = new Panel();
            label1 = new Label();
            dgvBorrowList = new DataGridView();
            BookTitle = new DataGridViewTextBoxColumn();
            BorrowedDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            btnPenalty = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowList).BeginInit();
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
            btnLogout.TabIndex = 57;
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
            btnMyAccount.TabIndex = 52;
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
            btnBorrowBooks.TabIndex = 53;
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
            btnHome.TabIndex = 59;
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
            btnReturnBook.TabIndex = 55;
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
            btnViewBooks.TabIndex = 54;
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
            label2.TabIndex = 58;
            label2.Text = "Welcome to Digital Library Management System";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dgvBorrowList);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(258, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(788, 620);
            panel1.TabIndex = 56;
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
            label1.Text = "Borrowed Books List";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvBorrowList
            // 
            dgvBorrowList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowList.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBorrowList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBorrowList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowList.Columns.AddRange(new DataGridViewColumn[] { BookTitle, BorrowedDate, DueDate });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 10F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBorrowList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBorrowList.Location = new Point(3, 71);
            dgvBorrowList.Name = "dgvBorrowList";
            dgvBorrowList.RowHeadersVisible = false;
            dgvBorrowList.RowHeadersWidth = 62;
            dgvBorrowList.Size = new Size(780, 225);
            dgvBorrowList.TabIndex = 0;
            dgvBorrowList.CellContentClick += dgvBorrowList_CellContentClick;
            // 
            // BookTitle
            // 
            BookTitle.HeaderText = "Book Title";
            BookTitle.MinimumWidth = 8;
            BookTitle.Name = "BookTitle";
            BookTitle.ReadOnly = true;
            // 
            // BorrowedDate
            // 
            BorrowedDate.HeaderText = "Borrowed Date";
            BorrowedDate.MinimumWidth = 8;
            BorrowedDate.Name = "BorrowedDate";
            BorrowedDate.ReadOnly = true;
            // 
            // DueDate
            // 
            DueDate.HeaderText = "Due Date";
            DueDate.MinimumWidth = 8;
            DueDate.Name = "DueDate";
            DueDate.ReadOnly = true;
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
            btnPenalty.TabIndex = 60;
            btnPenalty.Text = "Penalty Report";
            btnPenalty.UseVisualStyleBackColor = false;
            btnPenalty.Click += btnPenalty_Click;
            // 
            // StudentBorrowed
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1058, 712);
            Controls.Add(btnPenalty);
            Controls.Add(btnLogout);
            Controls.Add(btnMyAccount);
            Controls.Add(btnBorrowBooks);
            Controls.Add(btnHome);
            Controls.Add(btnReturnBook);
            Controls.Add(btnViewBooks);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "StudentBorrowed";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentBorrowed";
            Load += StudentBorrowed_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBorrowList).EndInit();
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
        private DataGridView dgvBorrowList;
        private Label label1;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn BorrowedDate;
        private DataGridViewTextBoxColumn DueDate;
        private Button btnPenalty;
    }
}
namespace Library_Management_System
{
    partial class ReturnBookReport
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
            dgvIssuedBooks = new DataGridView();
            RollNo = new DataGridViewTextBoxColumn();
            BookTitle = new DataGridViewTextBoxColumn();
            IssuedDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            ReturnDate = new DataGridViewTextBoxColumn();
            PenaltyStatus = new DataGridViewTextBoxColumn();
            label2 = new Label();
            label8 = new Label();
            cbRollNo = new ComboBox();
            label4 = new Label();
            cbBookTitle = new ComboBox();
            btnSelectRollNo = new Button();
            btnBookTitle = new Button();
            btnResetFilter = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvIssuedBooks).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dgvIssuedBooks
            // 
            dgvIssuedBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIssuedBooks.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvIssuedBooks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvIssuedBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvIssuedBooks.Columns.AddRange(new DataGridViewColumn[] { RollNo, BookTitle, IssuedDate, DueDate, ReturnDate, PenaltyStatus });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvIssuedBooks.DefaultCellStyle = dataGridViewCellStyle2;
            dgvIssuedBooks.Location = new Point(15, 204);
            dgvIssuedBooks.Name = "dgvIssuedBooks";
            dgvIssuedBooks.ReadOnly = true;
            dgvIssuedBooks.RowHeadersVisible = false;
            dgvIssuedBooks.RowHeadersWidth = 62;
            dgvIssuedBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIssuedBooks.Size = new Size(891, 400);
            dgvIssuedBooks.TabIndex = 28;
            // 
            // RollNo
            // 
            RollNo.HeaderText = "Roll No";
            RollNo.MinimumWidth = 8;
            RollNo.Name = "RollNo";
            RollNo.ReadOnly = true;
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
            // PenaltyStatus
            // 
            PenaltyStatus.HeaderText = "Penalty Status";
            PenaltyStatus.MinimumWidth = 8;
            PenaltyStatus.Name = "PenaltyStatus";
            PenaltyStatus.ReadOnly = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(76, 14);
            label2.Name = "label2";
            label2.Size = new Size(758, 51);
            label2.TabIndex = 29;
            label2.Text = "Return Books Report";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 11F);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(15, 102);
            label8.Name = "label8";
            label8.Size = new Size(192, 26);
            label8.TabIndex = 50;
            label8.Text = "Student Roll No :";
            // 
            // cbRollNo
            // 
            cbRollNo.Font = new Font("Arial Rounded MT Bold", 10F);
            cbRollNo.FormattingEnabled = true;
            cbRollNo.Location = new Point(213, 97);
            cbRollNo.Name = "cbRollNo";
            cbRollNo.Size = new Size(207, 31);
            cbRollNo.TabIndex = 51;
            cbRollNo.SelectedIndexChanged += cbRollNo_SelectedIndexChanged_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 11F);
            label4.ForeColor = Color.Green;
            label4.Location = new Point(426, 102);
            label4.Name = "label4";
            label4.Size = new Size(133, 26);
            label4.TabIndex = 52;
            label4.Text = "Book Title :";
            // 
            // cbBookTitle
            // 
            cbBookTitle.Font = new Font("Arial Rounded MT Bold", 10F);
            cbBookTitle.FormattingEnabled = true;
            cbBookTitle.Location = new Point(566, 97);
            cbBookTitle.Name = "cbBookTitle";
            cbBookTitle.Size = new Size(207, 31);
            cbBookTitle.TabIndex = 53;
            cbBookTitle.SelectedIndexChanged += cbBookTitle_SelectedIndexChanged_1;
            // 
            // btnSelectRollNo
            // 
            btnSelectRollNo.BackColor = Color.Green;
            btnSelectRollNo.Location = new Point(255, 150);
            btnSelectRollNo.Name = "btnSelectRollNo";
            btnSelectRollNo.Size = new Size(97, 37);
            btnSelectRollNo.TabIndex = 54;
            btnSelectRollNo.Text = "View";
            btnSelectRollNo.UseVisualStyleBackColor = false;
            btnSelectRollNo.Click += btnSelectRollNo_Click;
            // 
            // btnBookTitle
            // 
            btnBookTitle.BackColor = Color.Green;
            btnBookTitle.Location = new Point(610, 150);
            btnBookTitle.Name = "btnBookTitle";
            btnBookTitle.Size = new Size(97, 37);
            btnBookTitle.TabIndex = 55;
            btnBookTitle.Text = "View";
            btnBookTitle.UseVisualStyleBackColor = false;
            btnBookTitle.Click += btnBookTitle_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.BackColor = Color.Green;
            btnResetFilter.Font = new Font("Arial Rounded MT Bold", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnResetFilter.Location = new Point(15, 161);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(110, 37);
            btnResetFilter.TabIndex = 59;
            btnResetFilter.Text = "Reset Filter";
            btnResetFilter.UseVisualStyleBackColor = false;
            btnResetFilter.Click += btnResetFilter_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnResetFilter);
            panel1.Controls.Add(btnBookTitle);
            panel1.Controls.Add(btnSelectRollNo);
            panel1.Controls.Add(cbBookTitle);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(cbRollNo);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvIssuedBooks);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(12, 13);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 620);
            panel1.TabIndex = 61;
            // 
            // ReturnBookReport
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 646);
            Controls.Add(panel1);
            Name = "ReturnBookReport";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReturnBookReport";
            Load += ReturnBookReport_Load;
            ((System.ComponentModel.ISupportInitialize)dgvIssuedBooks).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvIssuedBooks;
        private DataGridViewTextBoxColumn RollNo;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn IssuedDate;
        private DataGridViewTextBoxColumn DueDate;
        private DataGridViewTextBoxColumn ReturnDate;
        private Label label2;
        private Label label8;
        private ComboBox cbRollNo;
        private Label label4;
        private ComboBox cbBookTitle;
        private Button btnSelectRollNo;
        private Button btnBookTitle;
        private Button btnResetFilter;
        private Panel panel1;
        private DataGridViewTextBoxColumn PenaltyStatus;
    }
}
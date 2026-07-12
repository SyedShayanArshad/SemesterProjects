namespace Library_Management_System
{
    partial class LibrarianPenalty
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
            panel1 = new Panel();
            btnPaidFine = new Button();
            btnWaiveFine = new Button();
            btnResetFilter = new Button();
            btnSelectRollNo = new Button();
            cbRollNo = new ComboBox();
            label8 = new Label();
            label2 = new Label();
            dgvPenaltyList = new DataGridView();
            RollNo = new DataGridViewTextBoxColumn();
            BookTitle = new DataGridViewTextBoxColumn();
            IssuedDate = new DataGridViewTextBoxColumn();
            DueDate = new DataGridViewTextBoxColumn();
            ReturnDate = new DataGridViewTextBoxColumn();
            Fine = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPenaltyList).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.PaleGreen;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnPaidFine);
            panel1.Controls.Add(btnWaiveFine);
            panel1.Controls.Add(btnResetFilter);
            panel1.Controls.Add(btnSelectRollNo);
            panel1.Controls.Add(cbRollNo);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dgvPenaltyList);
            panel1.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.White;
            panel1.Location = new Point(12, 13);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(911, 686);
            panel1.TabIndex = 62;
            // 
            // btnPaidFine
            // 
            btnPaidFine.BackColor = Color.Green;
            btnPaidFine.Location = new Point(467, 588);
            btnPaidFine.Name = "btnPaidFine";
            btnPaidFine.Size = new Size(128, 37);
            btnPaidFine.TabIndex = 61;
            btnPaidFine.Text = "Paid Fine";
            btnPaidFine.UseVisualStyleBackColor = false;
            btnPaidFine.Click += btnPaidFine_Click;
            // 
            // btnWaiveFine
            // 
            btnWaiveFine.BackColor = Color.Green;
            btnWaiveFine.Location = new Point(273, 588);
            btnWaiveFine.Name = "btnWaiveFine";
            btnWaiveFine.Size = new Size(146, 37);
            btnWaiveFine.TabIndex = 60;
            btnWaiveFine.Text = "Waive Fine";
            btnWaiveFine.UseVisualStyleBackColor = false;
            btnWaiveFine.Click += btnWaiveFine_Click;
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
            btnResetFilter.Click += btnResetFilter_Click;
            // 
            // btnSelectRollNo
            // 
            btnSelectRollNo.BackColor = Color.Green;
            btnSelectRollNo.Location = new Point(489, 148);
            btnSelectRollNo.Name = "btnSelectRollNo";
            btnSelectRollNo.Size = new Size(97, 37);
            btnSelectRollNo.TabIndex = 54;
            btnSelectRollNo.Text = "View";
            btnSelectRollNo.UseVisualStyleBackColor = false;
            btnSelectRollNo.Click += btnSelectRollNo_Click;
            // 
            // cbRollNo
            // 
            cbRollNo.Font = new Font("Arial Rounded MT Bold", 10F);
            cbRollNo.FormattingEnabled = true;
            cbRollNo.Location = new Point(453, 92);
            cbRollNo.Name = "cbRollNo";
            cbRollNo.Size = new Size(207, 31);
            cbRollNo.TabIndex = 51;
            cbRollNo.SelectedIndexChanged += cbRollNo_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Arial Rounded MT Bold", 11F);
            label8.ForeColor = Color.Green;
            label8.Location = new Point(255, 97);
            label8.Name = "label8";
            label8.Size = new Size(192, 26);
            label8.TabIndex = 50;
            label8.Text = "Student Roll No :";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.BackColor = Color.Green;
            label2.Font = new Font("Arial Rounded MT Bold", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(82, 14);
            label2.Name = "label2";
            label2.Size = new Size(758, 51);
            label2.TabIndex = 29;
            label2.Text = "Penalty Report";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // dgvPenaltyList
            // 
            dgvPenaltyList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPenaltyList.BackgroundColor = Color.Green;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 11F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPenaltyList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPenaltyList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPenaltyList.Columns.AddRange(new DataGridViewColumn[] { RollNo, BookTitle, IssuedDate, DueDate, ReturnDate, Fine });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial Rounded MT Bold", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPenaltyList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPenaltyList.Location = new Point(15, 204);
            dgvPenaltyList.MultiSelect = false;
            dgvPenaltyList.Name = "dgvPenaltyList";
            dgvPenaltyList.RowHeadersVisible = false;
            dgvPenaltyList.RowHeadersWidth = 62;
            dgvPenaltyList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPenaltyList.Size = new Size(891, 355);
            dgvPenaltyList.TabIndex = 28;
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
            // Fine
            // 
            Fine.HeaderText = "Fine";
            Fine.MinimumWidth = 8;
            Fine.Name = "Fine";
            Fine.ReadOnly = true;
            // 
            // LibrarianPenalty
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 712);
            Controls.Add(panel1);
            Name = "LibrarianPenalty";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LibrarianPenalty";
            Load += LibrarianPenalty_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPenaltyList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnResetFilter;
        private Button btnSelectRollNo;
        private ComboBox cbRollNo;
        private Label label8;
        private Label label2;
        private DataGridView dgvPenaltyList;
        private Button btnPaidFine;
        private Button btnWaiveFine;
        private DataGridViewTextBoxColumn RollNo;
        private DataGridViewTextBoxColumn BookTitle;
        private DataGridViewTextBoxColumn IssuedDate;
        private DataGridViewTextBoxColumn DueDate;
        private DataGridViewTextBoxColumn ReturnDate;
        private DataGridViewTextBoxColumn Fine;
    }
}
namespace DBProject
{
    partial class Audit
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
            panel4 = new Panel();
            textBox2 = new TextBox();
            CBSelectRecord = new ComboBox();
            btnSelect = new Button();
            label1 = new Label();
            DGVAudit = new DataGridView();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DGVAudit).BeginInit();
            SuspendLayout();
            // 
            // panel4
            // 
            panel4.Controls.Add(textBox2);
            panel4.Location = new Point(3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(944, 60);
            panel4.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.BackColor = SystemColors.Control;
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Arial", 18F, FontStyle.Bold);
            textBox2.ForeColor = Color.MediumSeaGreen;
            textBox2.Location = new Point(327, 10);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(297, 42);
            textBox2.TabIndex = 10;
            textBox2.Text = "Audit Record";
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // CBSelectRecord
            // 
            CBSelectRecord.FormattingEnabled = true;
            CBSelectRecord.Items.AddRange(new object[] { "Doctors", "Patients", "Rooms", "Bills", "Payments" });
            CBSelectRecord.Location = new Point(392, 96);
            CBSelectRecord.Name = "CBSelectRecord";
            CBSelectRecord.Size = new Size(182, 33);
            CBSelectRecord.TabIndex = 17;
            // 
            // btnSelect
            // 
            btnSelect.BackColor = Color.Green;
            btnSelect.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelect.ForeColor = Color.White;
            btnSelect.Location = new Point(615, 96);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(101, 33);
            btnSelect.TabIndex = 18;
            btnSelect.Text = "Select";
            btnSelect.UseVisualStyleBackColor = false;
            btnSelect.Click += btnSelect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(194, 96);
            label1.Name = "label1";
            label1.Size = new Size(172, 29);
            label1.TabIndex = 19;
            label1.Text = "Select Record";
            // 
            // DGVAudit
            // 
            DGVAudit.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            DGVAudit.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            DGVAudit.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGVAudit.Location = new Point(37, 188);
            DGVAudit.Name = "DGVAudit";
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.PaleGreen;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DGVAudit.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DGVAudit.RowHeadersWidth = 62;
            DGVAudit.Size = new Size(870, 353);
            DGVAudit.TabIndex = 20;
            // 
            // Audit
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(948, 664);
            Controls.Add(DGVAudit);
            Controls.Add(label1);
            Controls.Add(btnSelect);
            Controls.Add(CBSelectRecord);
            Controls.Add(panel4);
            Name = "Audit";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Audit";
            Load += Audit_Load;
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DGVAudit).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel4;
        private TextBox textBox2;
        private ComboBox CBSelectRecord;
        private Button btnSelect;
        private Label label1;
        private DataGridView DGVAudit;
    }
}
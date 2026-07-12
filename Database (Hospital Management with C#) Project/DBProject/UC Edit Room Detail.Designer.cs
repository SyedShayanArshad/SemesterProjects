namespace DBProject
{
    partial class UC_Edit_Room_Detail
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtTotalRoom = new TextBox();
            txtRoomType = new TextBox();
            btnDelete = new Button();
            btnUpdate = new Button();
            CBRoomID = new ComboBox();
            label4 = new Label();
            txtRate = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 9F, FontStyle.Bold);
            label1.Location = new Point(23, 37);
            label1.Name = "label1";
            label1.Size = new Size(97, 21);
            label1.TabIndex = 2;
            label1.Text = "Room ID :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9F, FontStyle.Bold);
            label2.Location = new Point(23, 130);
            label2.Name = "label2";
            label2.Size = new Size(121, 21);
            label2.TabIndex = 3;
            label2.Text = "Total Room :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9F, FontStyle.Bold);
            label3.Location = new Point(24, 177);
            label3.Name = "label3";
            label3.Size = new Size(111, 21);
            label3.TabIndex = 4;
            label3.Text = "Rate / Day :";
            // 
            // txtTotalRoom
            // 
            txtTotalRoom.Location = new Point(162, 124);
            txtTotalRoom.Name = "txtTotalRoom";
            txtTotalRoom.Size = new Size(150, 31);
            txtTotalRoom.TabIndex = 5;
            txtTotalRoom.TextChanged += txtRate_TextChanged;
            // 
            // txtRoomType
            // 
            txtRoomType.Location = new Point(162, 80);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(188, 31);
            txtRoomType.TabIndex = 6;
            txtRoomType.TextChanged += txtTotalRoom_TextChanged;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MediumSeaGreen;
            btnDelete.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(218, 247);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 40);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.MediumSeaGreen;
            btnUpdate.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(77, 247);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 40);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // CBRoomID
            // 
            CBRoomID.FormattingEnabled = true;
            CBRoomID.Location = new Point(162, 31);
            CBRoomID.Name = "CBRoomID";
            CBRoomID.Size = new Size(150, 33);
            CBRoomID.TabIndex = 10;
            CBRoomID.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 9F, FontStyle.Bold);
            label4.Location = new Point(22, 86);
            label4.Name = "label4";
            label4.Size = new Size(122, 21);
            label4.TabIndex = 11;
            label4.Text = "Room Type :";
            // 
            // txtRate
            // 
            txtRate.Location = new Point(162, 171);
            txtRate.Name = "txtRate";
            txtRate.Size = new Size(150, 31);
            txtRate.TabIndex = 12;
            // 
            // UC_Edit_Room_Detail
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtRate);
            Controls.Add(label4);
            Controls.Add(CBRoomID);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(txtRoomType);
            Controls.Add(txtTotalRoom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UC_Edit_Room_Detail";
            Size = new Size(452, 321);
            Load += UC_Edit_Room_Detail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtTotalRoom;
        private TextBox txtRoomType;
        private Button btnDelete;
        private Button btnUpdate;
        private ComboBox CBRoomID;
        private Label label4;
        private TextBox txtRate;
    }
}

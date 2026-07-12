namespace DBProject
{
    partial class UserControl1
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
            btnAdd = new Button();
            txtRoomRate = new TextBox();
            label2 = new Label();
            txtTotalRoom = new TextBox();
            label1 = new Label();
            label3 = new Label();
            txtRoomType = new TextBox();
            label4 = new Label();
            txtRoomID = new TextBox();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.MediumSeaGreen;
            btnAdd.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(203, 204);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += button1_Click;
            // 
            // txtRoomRate
            // 
            txtRoomRate.Location = new Point(169, 166);
            txtRoomRate.Name = "txtRoomRate";
            txtRoomRate.Size = new Size(200, 31);
            txtRoomRate.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 118);
            label2.Name = "label2";
            label2.Size = new Size(111, 25);
            label2.TabIndex = 2;
            label2.Text = "Total Room :";
            // 
            // txtTotalRoom
            // 
            txtTotalRoom.Location = new Point(169, 115);
            txtTotalRoom.Name = "txtTotalRoom";
            txtTotalRoom.Size = new Size(200, 31);
            txtTotalRoom.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 61);
            label1.Name = "label1";
            label1.Size = new Size(111, 25);
            label1.TabIndex = 0;
            label1.Text = "Room Type :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(38, 172);
            label3.Name = "label3";
            label3.Size = new Size(104, 25);
            label3.TabIndex = 3;
            label3.Text = "Rate / Day :";
            label3.Click += label3_Click;
            // 
            // txtRoomType
            // 
            txtRoomType.Location = new Point(169, 61);
            txtRoomType.Name = "txtRoomType";
            txtRoomType.Size = new Size(200, 31);
            txtRoomType.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(38, 18);
            label4.Name = "label4";
            label4.Size = new Size(92, 25);
            label4.TabIndex = 7;
            label4.Text = "Room ID :";
            // 
            // txtRoomID
            // 
            txtRoomID.Location = new Point(169, 18);
            txtRoomID.Name = "txtRoomID";
            txtRoomID.Size = new Size(200, 31);
            txtRoomID.TabIndex = 8;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(txtRoomID);
            Controls.Add(label4);
            Controls.Add(btnAdd);
            Controls.Add(txtRoomRate);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(txtRoomType);
            Controls.Add(txtTotalRoom);
            Controls.Add(label3);
            Name = "UserControl1";
            Size = new Size(415, 269);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private TextBox txtRoomRate;
        private Label label2;
        private TextBox txtTotalRoom;
        private Label label1;
        private Label label3;
        private TextBox txtRoomType;
        private Label label4;
        private TextBox txtRoomID;
    }
}

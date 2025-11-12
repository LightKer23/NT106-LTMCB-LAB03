namespace Exercise.Bai06
{
    partial class WhatEatTodayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WhatEatTodayForm));
            btnAdd = new Button();
            btnFind = new Button();
            btnDel = new Button();
            btnExit = new Button();
            groupBox1 = new GroupBox();
            lblUserContribute = new Label();
            pctDish = new PictureBox();
            lblNameDish = new Label();
            listView1 = new ListView();
            id = new ColumnHeader();
            dish = new ColumnHeader();
            contribute = new ColumnHeader();
            groupBox2 = new GroupBox();
            btnPickPic = new Button();
            txtDish = new TextBox();
            txtAccess = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtUser = new TextBox();
            txtServerIP = new TextBox();
            txtPort = new TextBox();
            label4 = new Label();
            label6 = new Label();
            btnConnect = new Button();
            lblConnStatus = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pctDish).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.ButtonHighlight;
            btnAdd.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.Location = new Point(526, 111);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 38);
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnFind
            // 
            btnFind.BackColor = SystemColors.ButtonHighlight;
            btnFind.FlatAppearance.BorderColor = Color.Blue;
            btnFind.FlatStyle = FlatStyle.Flat;
            btnFind.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFind.Location = new Point(526, 256);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(112, 38);
            btnFind.TabIndex = 4;
            btnFind.Text = "Tìm món ăn";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += btnFind_Click;
            // 
            // btnDel
            // 
            btnDel.BackColor = SystemColors.ButtonHighlight;
            btnDel.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnDel.FlatStyle = FlatStyle.Flat;
            btnDel.Font = new Font("Tahoma", 9F);
            btnDel.Location = new Point(526, 299);
            btnDel.Name = "btnDel";
            btnDel.Size = new Size(112, 38);
            btnDel.TabIndex = 5;
            btnDel.Text = "Xóa";
            btnDel.UseVisualStyleBackColor = false;
            btnDel.Click += btnDel_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = SystemColors.ButtonHighlight;
            btnExit.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Tahoma", 9F);
            btnExit.Location = new Point(526, 343);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(112, 38);
            btnExit.TabIndex = 6;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblUserContribute);
            groupBox1.Controls.Add(pctDish);
            groupBox1.Controls.Add(lblNameDish);
            groupBox1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(28, 439);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(611, 235);
            groupBox1.TabIndex = 7;
            groupBox1.TabStop = false;
            groupBox1.Text = "Kết quả";
            // 
            // lblUserContribute
            // 
            lblUserContribute.Location = new Point(360, 53);
            lblUserContribute.Name = "lblUserContribute";
            lblUserContribute.Size = new Size(233, 29);
            lblUserContribute.TabIndex = 2;
            // 
            // pctDish
            // 
            pctDish.Location = new Point(28, 24);
            pctDish.Name = "pctDish";
            pctDish.Size = new Size(288, 195);
            pctDish.TabIndex = 1;
            pctDish.TabStop = false;
            // 
            // lblNameDish
            // 
            lblNameDish.Location = new Point(360, 24);
            lblNameDish.Name = "lblNameDish";
            lblNameDish.Size = new Size(233, 29);
            lblNameDish.TabIndex = 0;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { id, dish, contribute });
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Location = new Point(28, 256);
            listView1.Name = "listView1";
            listView1.Size = new Size(491, 172);
            listView1.TabIndex = 18;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // id
            // 
            id.Text = "ID";
            id.Width = 50;
            // 
            // dish
            // 
            dish.Text = "Món ăn";
            dish.Width = 200;
            // 
            // contribute
            // 
            contribute.Text = "Người đóng góp";
            contribute.Width = 200;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnPickPic);
            groupBox2.Controls.Add(txtDish);
            groupBox2.Controls.Add(txtAccess);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtUser);
            groupBox2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(28, 102);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(492, 142);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nhập";
            // 
            // btnPickPic
            // 
            btnPickPic.BackColor = SystemColors.ControlLight;
            btnPickPic.FlatAppearance.BorderColor = SystemColors.ActiveCaptionText;
            btnPickPic.FlatStyle = FlatStyle.Flat;
            btnPickPic.Font = new Font("Tahoma", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnPickPic.Location = new Point(290, 105);
            btnPickPic.Name = "btnPickPic";
            btnPickPic.Size = new Size(82, 26);
            btnPickPic.TabIndex = 33;
            btnPickPic.Text = "Chọn ảnh";
            btnPickPic.UseVisualStyleBackColor = false;
            btnPickPic.Click += btnPickPic_Click;
            // 
            // txtDish
            // 
            txtDish.Location = new Point(194, 77);
            txtDish.Name = "txtDish";
            txtDish.Size = new Size(284, 26);
            txtDish.TabIndex = 32;
            // 
            // txtAccess
            // 
            txtAccess.Location = new Point(194, 48);
            txtAccess.Name = "txtAccess";
            txtAccess.Size = new Size(284, 26);
            txtAccess.TabIndex = 31;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(18, 48);
            label5.Name = "label5";
            label5.Size = new Size(85, 18);
            label5.TabIndex = 30;
            label5.Text = "Quyền hạn:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(18, 77);
            label3.Name = "label3";
            label3.Size = new Size(62, 18);
            label3.TabIndex = 29;
            label3.Text = "Món ăn:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 105);
            label2.Name = "label2";
            label2.Size = new Size(112, 18);
            label2.TabIndex = 28;
            label2.Text = "Thêm hình ảnh:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 20);
            label1.Name = "label1";
            label1.Size = new Size(116, 18);
            label1.TabIndex = 27;
            label1.Text = "Tên người dùng:";
            // 
            // txtUser
            // 
            txtUser.Location = new Point(194, 20);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(284, 26);
            txtUser.TabIndex = 26;
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(117, 15);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(140, 27);
            txtServerIP.TabIndex = 20;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(351, 15);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(140, 27);
            txtPort.TabIndex = 21;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 18);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 22;
            label4.Text = "Server IP: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(297, 18);
            label6.Name = "label6";
            label6.Size = new Size(48, 19);
            label6.TabIndex = 23;
            label6.Text = "Port: ";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(526, 9);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(112, 38);
            btnConnect.TabIndex = 24;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click_1;
            // 
            // lblConnStatus
            // 
            lblConnStatus.AutoSize = true;
            lblConnStatus.Location = new Point(28, 54);
            lblConnStatus.Name = "lblConnStatus";
            lblConnStatus.Size = new Size(99, 19);
            lblConnStatus.TabIndex = 25;
            lblConnStatus.Text = "Unconnected";
            // 
            // WhatEatTodayForm
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(672, 728);
            Controls.Add(lblConnStatus);
            Controls.Add(btnConnect);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(txtPort);
            Controls.Add(txtServerIP);
            Controls.Add(groupBox2);
            Controls.Add(listView1);
            Controls.Add(groupBox1);
            Controls.Add(btnExit);
            Controls.Add(btnDel);
            Controls.Add(btnFind);
            Controls.Add(btnAdd);
            Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "WhatEatTodayForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hôm nay ăn gì?";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pctDish).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private Button btnFind;
        private Button btnDel;
        private Button btnExit;
        private GroupBox groupBox1;
        private Label lblNameDish;
        private ListView listView1;
        private PictureBox pctDish;
        private Label lblUserContribute;
        private GroupBox groupBox2;
        private Button btnPickPic;
        private TextBox txtDish;
        private TextBox txtAccess;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtUser;
        private ColumnHeader id;
        private ColumnHeader dish;
        private ColumnHeader contribute;
        private TextBox txtServerIP;
        private TextBox txtPort;
        private Label label4;
        private Label label6;
        private Button btnConnect;
        private Label lblConnStatus;
    }
}
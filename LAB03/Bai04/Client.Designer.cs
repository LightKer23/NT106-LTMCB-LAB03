namespace Bai04
{
    partial class Client
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label5 = new Label();
            Total = new TextBox();
            BookButton = new Button();
            CustomerNameBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            RoomComboBox = new ComboBox();
            MovieComboBox = new ComboBox();
            groupBox3 = new GroupBox();
            label13 = new Label();
            label14 = new Label();
            label12 = new Label();
            label10 = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label6 = new Label();
            label7 = new Label();
            flowLayoutPanel6 = new FlowLayoutPanel();
            flowLayoutPanel5 = new FlowLayoutPanel();
            label8 = new Label();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label11 = new Label();
            label9 = new Label();
            label1 = new Label();
            groupBox1 = new GroupBox();
            C2 = new Button();
            C3 = new Button();
            C4 = new Button();
            C5 = new Button();
            C1 = new Button();
            B2 = new Button();
            B3 = new Button();
            B4 = new Button();
            B5 = new Button();
            B1 = new Button();
            A2 = new Button();
            A3 = new Button();
            A4 = new Button();
            A5 = new Button();
            A1 = new Button();
            ConnectButton = new Button();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(276, 498);
            label5.Name = "label5";
            label5.Size = new Size(121, 25);
            label5.TabIndex = 62;
            label5.Text = "Thành tiền";
            // 
            // Total
            // 
            Total.Location = new Point(432, 496);
            Total.Name = "Total";
            Total.ReadOnly = true;
            Total.Size = new Size(309, 27);
            Total.TabIndex = 61;
            // 
            // BookButton
            // 
            BookButton.BackgroundImageLayout = ImageLayout.Zoom;
            BookButton.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BookButton.Location = new Point(777, 466);
            BookButton.Name = "BookButton";
            BookButton.Size = new Size(188, 66);
            BookButton.TabIndex = 60;
            BookButton.Text = "Đặt vé";
            BookButton.UseVisualStyleBackColor = true;
            BookButton.Click += BookButton_Click;
            // 
            // CustomerNameBox
            // 
            CustomerNameBox.Location = new Point(777, 413);
            CustomerNameBox.Name = "CustomerNameBox";
            CustomerNameBox.Size = new Size(188, 27);
            CustomerNameBox.TabIndex = 59;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(777, 362);
            label4.Name = "label4";
            label4.Size = new Size(108, 25);
            label4.TabIndex = 58;
            label4.Text = "Họ và tên";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(775, 257);
            label3.Name = "label3";
            label3.Size = new Size(136, 25);
            label3.TabIndex = 57;
            label3.Text = "Chọn phòng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(777, 152);
            label2.Name = "label2";
            label2.Size = new Size(123, 25);
            label2.TabIndex = 56;
            label2.Text = "Chọn phim";
            // 
            // RoomComboBox
            // 
            RoomComboBox.FormattingEnabled = true;
            RoomComboBox.Location = new Point(775, 308);
            RoomComboBox.Name = "RoomComboBox";
            RoomComboBox.Size = new Size(190, 28);
            RoomComboBox.TabIndex = 55;
            RoomComboBox.SelectedIndexChanged += RoomComboBox_SelectedIndexChanged;
            // 
            // MovieComboBox
            // 
            MovieComboBox.FormattingEnabled = true;
            MovieComboBox.Location = new Point(777, 203);
            MovieComboBox.Name = "MovieComboBox";
            MovieComboBox.Size = new Size(190, 28);
            MovieComboBox.TabIndex = 38;
            MovieComboBox.SelectedIndexChanged += MovieComboBox_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.Transparent;
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label14);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(flowLayoutPanel2);
            groupBox3.Controls.Add(flowLayoutPanel1);
            groupBox3.Controls.Add(label6);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(flowLayoutPanel6);
            groupBox3.Controls.Add(flowLayoutPanel5);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(flowLayoutPanel4);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(label9);
            groupBox3.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(5, 24);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(188, 445);
            groupBox3.TabIndex = 54;
            groupBox3.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(61, 389);
            label13.Name = "label13";
            label13.Size = new Size(100, 19);
            label13.TabIndex = 22;
            label13.Text = "Đã được đặt ";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.BackColor = Color.Transparent;
            label14.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(62, 356);
            label14.Name = "label14";
            label14.Size = new Size(77, 19);
            label14.TabIndex = 21;
            label14.Text = "Bạn chọn";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(43, 311);
            label12.Name = "label12";
            label12.Size = new Size(72, 25);
            label12.TabIndex = 19;
            label12.Text = "Lưu ý";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(43, 19);
            label10.Name = "label10";
            label10.Size = new Size(89, 25);
            label10.TabIndex = 18;
            label10.Text = "Loại  vé";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = Color.Gray;
            flowLayoutPanel2.Location = new Point(28, 388);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(27, 20);
            flowLayoutPanel2.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.LightGreen;
            flowLayoutPanel1.Location = new Point(28, 355);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(27, 20);
            flowLayoutPanel1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(62, 117);
            label6.Name = "label6";
            label6.Size = new Size(65, 19);
            label6.TabIndex = 17;
            label6.Text = "Thường";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(62, 77);
            label7.Name = "label7";
            label7.Size = new Size(37, 19);
            label7.TabIndex = 16;
            label7.Text = "VIP";
            // 
            // flowLayoutPanel6
            // 
            flowLayoutPanel6.BackColor = Color.FromArgb(168, 195, 162);
            flowLayoutPanel6.Location = new Point(29, 151);
            flowLayoutPanel6.Name = "flowLayoutPanel6";
            flowLayoutPanel6.Size = new Size(27, 20);
            flowLayoutPanel6.TabIndex = 10;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.BackColor = Color.FromArgb(176, 212, 184);
            flowLayoutPanel5.Location = new Point(29, 115);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Size = new Size(27, 20);
            flowLayoutPanel5.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.WindowText;
            label8.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(254, 231, 21);
            label8.Location = new Point(62, 116);
            label8.Name = "label8";
            label8.Size = new Size(0, 19);
            label8.TabIndex = 15;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.BackColor = Color.FromArgb(93, 123, 111);
            flowLayoutPanel4.Location = new Point(29, 77);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(27, 20);
            flowLayoutPanel4.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.WindowText;
            label11.ForeColor = Color.White;
            label11.Location = new Point(99, 36);
            label11.Name = "label11";
            label11.Size = new Size(0, 25);
            label11.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(62, 152);
            label9.Name = "label9";
            label9.Size = new Size(84, 19);
            label9.TabIndex = 14;
            label9.Text = "Tiết kiệm ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(93, 123, 111);
            label1.Font = new Font("Times New Roman", 39F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(316, 24);
            label1.Name = "label1";
            label1.Size = new Size(305, 73);
            label1.TabIndex = 53;
            label1.Text = "Màn hình";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(C2);
            groupBox1.Controls.Add(C3);
            groupBox1.Controls.Add(C4);
            groupBox1.Controls.Add(C5);
            groupBox1.Controls.Add(C1);
            groupBox1.Controls.Add(B2);
            groupBox1.Controls.Add(B3);
            groupBox1.Controls.Add(B4);
            groupBox1.Controls.Add(B5);
            groupBox1.Controls.Add(B1);
            groupBox1.Controls.Add(A2);
            groupBox1.Controls.Add(A3);
            groupBox1.Controls.Add(A4);
            groupBox1.Controls.Add(A5);
            groupBox1.Controls.Add(A1);
            groupBox1.Location = new Point(199, 117);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(542, 356);
            groupBox1.TabIndex = 64;
            groupBox1.TabStop = false;
            // 
            // C2
            // 
            C2.BackColor = Color.FromArgb(176, 212, 184);
            C2.FlatAppearance.BorderSize = 0;
            C2.FlatStyle = FlatStyle.Flat;
            C2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            C2.ForeColor = Color.Black;
            C2.Location = new Point(121, 262);
            C2.Name = "C2";
            C2.Size = new Size(77, 67);
            C2.TabIndex = 67;
            C2.Text = "C2";
            C2.UseVisualStyleBackColor = false;
            C2.Click += SeatButton_Click;
            // 
            // C3
            // 
            C3.BackColor = Color.FromArgb(176, 212, 184);
            C3.FlatAppearance.BorderSize = 0;
            C3.FlatStyle = FlatStyle.Flat;
            C3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            C3.ForeColor = Color.Black;
            C3.Location = new Point(233, 262);
            C3.Name = "C3";
            C3.Size = new Size(77, 67);
            C3.TabIndex = 66;
            C3.Text = "C3";
            C3.UseVisualStyleBackColor = false;
            C3.Click += SeatButton_Click;
            // 
            // C4
            // 
            C4.BackColor = Color.FromArgb(176, 212, 184);
            C4.FlatAppearance.BorderSize = 0;
            C4.FlatStyle = FlatStyle.Flat;
            C4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            C4.ForeColor = Color.Black;
            C4.Location = new Point(345, 262);
            C4.Name = "C4";
            C4.Size = new Size(77, 67);
            C4.TabIndex = 65;
            C4.Text = "C4";
            C4.UseVisualStyleBackColor = false;
            C4.Click += SeatButton_Click;
            // 
            // C5
            // 
            C5.BackColor = Color.FromArgb(168, 195, 162);
            C5.FlatAppearance.BorderSize = 0;
            C5.FlatStyle = FlatStyle.Flat;
            C5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            C5.ForeColor = Color.Black;
            C5.Location = new Point(457, 262);
            C5.Name = "C5";
            C5.Size = new Size(77, 67);
            C5.TabIndex = 64;
            C5.Text = "C5";
            C5.UseVisualStyleBackColor = false;
            C5.Click += SeatButton_Click;
            // 
            // C1
            // 
            C1.BackColor = Color.FromArgb(168, 195, 162);
            C1.FlatAppearance.BorderSize = 0;
            C1.FlatStyle = FlatStyle.Flat;
            C1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            C1.ForeColor = Color.Black;
            C1.Location = new Point(9, 262);
            C1.Name = "C1";
            C1.Size = new Size(77, 67);
            C1.TabIndex = 63;
            C1.Text = "C1";
            C1.UseVisualStyleBackColor = false;
            C1.Click += SeatButton_Click;
            // 
            // B2
            // 
            B2.BackColor = Color.FromArgb(93, 123, 111);
            B2.FlatAppearance.BorderSize = 0;
            B2.FlatStyle = FlatStyle.Flat;
            B2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            B2.ForeColor = Color.Black;
            B2.Location = new Point(121, 145);
            B2.Name = "B2";
            B2.Size = new Size(77, 67);
            B2.TabIndex = 62;
            B2.Text = "B2";
            B2.UseVisualStyleBackColor = false;
            B2.Click += SeatButton_Click;
            // 
            // B3
            // 
            B3.BackColor = Color.FromArgb(93, 123, 111);
            B3.FlatAppearance.BorderSize = 0;
            B3.FlatStyle = FlatStyle.Flat;
            B3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            B3.ForeColor = Color.Black;
            B3.Location = new Point(233, 145);
            B3.Name = "B3";
            B3.Size = new Size(77, 67);
            B3.TabIndex = 61;
            B3.Text = "B3";
            B3.UseVisualStyleBackColor = false;
            B3.Click += SeatButton_Click;
            // 
            // B4
            // 
            B4.BackColor = Color.FromArgb(93, 123, 111);
            B4.FlatAppearance.BorderSize = 0;
            B4.FlatStyle = FlatStyle.Flat;
            B4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            B4.ForeColor = Color.Black;
            B4.Location = new Point(345, 145);
            B4.Name = "B4";
            B4.Size = new Size(77, 67);
            B4.TabIndex = 60;
            B4.Text = "B4";
            B4.UseVisualStyleBackColor = false;
            B4.Click += SeatButton_Click;
            // 
            // B5
            // 
            B5.BackColor = Color.FromArgb(176, 212, 184);
            B5.FlatAppearance.BorderSize = 0;
            B5.FlatStyle = FlatStyle.Flat;
            B5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            B5.ForeColor = Color.Black;
            B5.Location = new Point(457, 145);
            B5.Name = "B5";
            B5.Size = new Size(77, 67);
            B5.TabIndex = 59;
            B5.Text = "B5";
            B5.UseVisualStyleBackColor = false;
            B5.Click += SeatButton_Click;
            // 
            // B1
            // 
            B1.BackColor = Color.FromArgb(176, 212, 184);
            B1.FlatAppearance.BorderSize = 0;
            B1.FlatStyle = FlatStyle.Flat;
            B1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            B1.ForeColor = Color.Black;
            B1.Location = new Point(9, 145);
            B1.Name = "B1";
            B1.Size = new Size(77, 67);
            B1.TabIndex = 58;
            B1.Text = "B1";
            B1.UseVisualStyleBackColor = false;
            B1.Click += SeatButton_Click;
            // 
            // A2
            // 
            A2.BackColor = Color.FromArgb(176, 212, 184);
            A2.FlatAppearance.BorderSize = 0;
            A2.FlatStyle = FlatStyle.Flat;
            A2.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            A2.ForeColor = Color.Black;
            A2.Location = new Point(121, 28);
            A2.Name = "A2";
            A2.Size = new Size(77, 67);
            A2.TabIndex = 57;
            A2.Text = "A2";
            A2.UseVisualStyleBackColor = false;
            A2.Click += SeatButton_Click;
            // 
            // A3
            // 
            A3.BackColor = Color.FromArgb(176, 212, 184);
            A3.FlatAppearance.BorderSize = 0;
            A3.FlatStyle = FlatStyle.Flat;
            A3.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            A3.ForeColor = Color.Black;
            A3.Location = new Point(233, 28);
            A3.Name = "A3";
            A3.Size = new Size(77, 67);
            A3.TabIndex = 56;
            A3.Text = "A3";
            A3.UseVisualStyleBackColor = false;
            A3.Click += SeatButton_Click;
            // 
            // A4
            // 
            A4.BackColor = Color.FromArgb(176, 212, 184);
            A4.FlatAppearance.BorderSize = 0;
            A4.FlatStyle = FlatStyle.Flat;
            A4.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            A4.ForeColor = Color.Black;
            A4.Location = new Point(345, 28);
            A4.Name = "A4";
            A4.Size = new Size(77, 67);
            A4.TabIndex = 55;
            A4.Text = "A4";
            A4.UseVisualStyleBackColor = false;
            A4.Click += SeatButton_Click;
            // 
            // A5
            // 
            A5.BackColor = Color.FromArgb(168, 195, 162);
            A5.FlatAppearance.BorderSize = 0;
            A5.FlatStyle = FlatStyle.Flat;
            A5.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            A5.ForeColor = Color.Black;
            A5.Location = new Point(457, 28);
            A5.Name = "A5";
            A5.Size = new Size(77, 67);
            A5.TabIndex = 54;
            A5.Text = "A5";
            A5.UseVisualStyleBackColor = false;
            A5.Click += SeatButton_Click;
            // 
            // A1
            // 
            A1.BackColor = Color.FromArgb(168, 195, 162);
            A1.FlatAppearance.BorderSize = 0;
            A1.FlatStyle = FlatStyle.Flat;
            A1.Font = new Font("Times New Roman", 12F, FontStyle.Bold);
            A1.ForeColor = Color.Black;
            A1.Location = new Point(9, 28);
            A1.Name = "A1";
            A1.Size = new Size(77, 67);
            A1.TabIndex = 53;
            A1.Text = "A1";
            A1.UseVisualStyleBackColor = false;
            A1.Click += SeatButton_Click;
            // 
            // ConnectButton
            // 
            ConnectButton.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ConnectButton.Location = new Point(775, 60);
            ConnectButton.Name = "ConnectButton";
            ConnectButton.Size = new Size(188, 66);
            ConnectButton.TabIndex = 67;
            ConnectButton.Text = "Kết nối";
            ConnectButton.UseVisualStyleBackColor = true;
            ConnectButton.Click += ConnectButton_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(215, 249, 250);
            ClientSize = new Size(985, 562);
            Controls.Add(ConnectButton);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(Total);
            Controls.Add(BookButton);
            Controls.Add(CustomerNameBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(RoomComboBox);
            Controls.Add(MovieComboBox);
            Controls.Add(groupBox3);
            Controls.Add(label1);
            Name = "Client";
            Text = "Client";
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label5;
        private TextBox Total;
        private Button BookButton;
        private TextBox CustomerNameBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox RoomComboBox;
        private ComboBox MovieComboBox;
        private GroupBox groupBox3;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label11;
        private FlowLayoutPanel flowLayoutPanel4;
        private FlowLayoutPanel flowLayoutPanel5;
        private FlowLayoutPanel flowLayoutPanel6;
        private Label label1;
        private GroupBox groupBox1;
        private Button C2;
        private Button C3;
        private Button C4;
        private Button C5;
        private Button C1;
        private Button B2;
        private Button B3;
        private Button B4;
        private Button B5;
        private Button B1;
        private Button A2;
        private Button A3;
        private Button A4;
        private Button A5;
        private Button A1;
        private Button LoadButton;
        private Button ConnectButton;
        private Label label13;
        private Label label14;
        private Label label12;
        private Label label10;
        private FlowLayoutPanel flowLayoutPanel2;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
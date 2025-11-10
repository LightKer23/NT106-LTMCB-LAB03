namespace Bai06
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
            grpBoxTCPServer = new GroupBox();
            textName = new TextBox();
            label1 = new Label();
            btnConnect = new Button();
            txtPort = new TextBox();
            txtHost = new TextBox();
            lblConnects = new Label();
            lblPort = new Label();
            lblStatus = new Label();
            lblIP = new Label();
            groupBox1 = new GroupBox();
            btnOpenConnect = new Button();
            txtMessage = new TextBox();
            label2 = new Label();
            grpBoxActivityLog = new GroupBox();
            lstTroChuyen = new ListBox();
            lstNguoiThamGia = new ListBox();
            label3 = new Label();
            btnOutRoom = new Button();
            grpBoxTCPServer.SuspendLayout();
            groupBox1.SuspendLayout();
            grpBoxActivityLog.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxTCPServer
            // 
            grpBoxTCPServer.Controls.Add(textName);
            grpBoxTCPServer.Controls.Add(label1);
            grpBoxTCPServer.Controls.Add(btnConnect);
            grpBoxTCPServer.Controls.Add(txtPort);
            grpBoxTCPServer.Controls.Add(txtHost);
            grpBoxTCPServer.Controls.Add(lblConnects);
            grpBoxTCPServer.Controls.Add(lblPort);
            grpBoxTCPServer.Controls.Add(lblStatus);
            grpBoxTCPServer.Controls.Add(lblIP);
            grpBoxTCPServer.Font = new Font("Tahoma", 10.2F);
            grpBoxTCPServer.Location = new Point(12, 6);
            grpBoxTCPServer.Name = "grpBoxTCPServer";
            grpBoxTCPServer.Size = new Size(591, 56);
            grpBoxTCPServer.TabIndex = 3;
            grpBoxTCPServer.TabStop = false;
            grpBoxTCPServer.Text = "Kết nối";
            // 
            // textName
            // 
            textName.Font = new Font("Tahoma", 10F);
            textName.Location = new Point(367, 17);
            textName.Name = "textName";
            textName.Size = new Size(126, 28);
            textName.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 20);
            label1.Name = "label1";
            label1.Size = new Size(59, 21);
            label1.TabIndex = 9;
            label1.Text = "Name:";
            // 
            // btnConnect
            // 
            btnConnect.FlatAppearance.BorderColor = Color.White;
            btnConnect.Location = new Point(499, 15);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(86, 30);
            btnConnect.TabIndex = 8;
            btnConnect.Text = "kết nối";
            btnConnect.TextAlign = ContentAlignment.BottomCenter;
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(229, 17);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(65, 28);
            txtPort.TabIndex = 6;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(59, 17);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(123, 28);
            txtHost.TabIndex = 4;
            // 
            // lblConnects
            // 
            lblConnects.AutoSize = true;
            lblConnects.Location = new Point(313, 60);
            lblConnects.Name = "lblConnects";
            lblConnects.Size = new Size(0, 21);
            lblConnects.TabIndex = 3;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(188, 20);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(46, 21);
            lblPort.TabIndex = 2;
            lblPort.Text = "Port:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(13, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 21);
            lblStatus.TabIndex = 1;
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(13, 24);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(50, 21);
            lblIP.TabIndex = 0;
            lblIP.Text = "Host:";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnOpenConnect);
            groupBox1.Controls.Add(txtMessage);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Tahoma", 10.2F);
            groupBox1.Location = new Point(12, 68);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(413, 58);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tin Nhắn";
            // 
            // btnOpenConnect
            // 
            btnOpenConnect.FlatAppearance.BorderColor = Color.White;
            btnOpenConnect.Location = new Point(319, 15);
            btnOpenConnect.Name = "btnOpenConnect";
            btnOpenConnect.Size = new Size(86, 30);
            btnOpenConnect.TabIndex = 8;
            btnOpenConnect.Text = "Gửi";
            btnOpenConnect.TextAlign = ContentAlignment.BottomCenter;
            btnOpenConnect.UseVisualStyleBackColor = true;
            btnOpenConnect.Click += btnOpenConnect_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(13, 17);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(300, 28);
            txtMessage.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(313, 24);
            label2.Name = "label2";
            label2.Size = new Size(0, 21);
            label2.TabIndex = 2;
            // 
            // grpBoxActivityLog
            // 
            grpBoxActivityLog.Controls.Add(lstTroChuyen);
            grpBoxActivityLog.Font = new Font("Tahoma", 10.2F);
            grpBoxActivityLog.Location = new Point(12, 132);
            grpBoxActivityLog.Name = "grpBoxActivityLog";
            grpBoxActivityLog.Size = new Size(413, 306);
            grpBoxActivityLog.TabIndex = 5;
            grpBoxActivityLog.TabStop = false;
            grpBoxActivityLog.Text = "Trò chuyện";
            // 
            // lstTroChuyen
            // 
            lstTroChuyen.FormattingEnabled = true;
            lstTroChuyen.ItemHeight = 21;
            lstTroChuyen.Location = new Point(6, 27);
            lstTroChuyen.Name = "lstTroChuyen";
            lstTroChuyen.Size = new Size(399, 277);
            lstTroChuyen.TabIndex = 0;
            // 
            // lstNguoiThamGia
            // 
            lstNguoiThamGia.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lstNguoiThamGia.FormattingEnabled = true;
            lstNguoiThamGia.ItemHeight = 23;
            lstNguoiThamGia.Location = new Point(431, 93);
            lstNguoiThamGia.Name = "lstNguoiThamGia";
            lstNguoiThamGia.Size = new Size(172, 303);
            lstNguoiThamGia.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(431, 66);
            label3.Name = "label3";
            label3.Size = new Size(135, 23);
            label3.TabIndex = 7;
            label3.Text = "Người Tham Gia";
            // 
            // btnOutRoom
            // 
            btnOutRoom.FlatAppearance.BorderColor = Color.White;
            btnOutRoom.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOutRoom.Location = new Point(431, 402);
            btnOutRoom.Name = "btnOutRoom";
            btnOutRoom.Size = new Size(166, 36);
            btnOutRoom.TabIndex = 11;
            btnOutRoom.Text = "Rời khỏi phòng";
            btnOutRoom.UseVisualStyleBackColor = true;
            btnOutRoom.Click += button1_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(611, 450);
            Controls.Add(btnOutRoom);
            Controls.Add(label3);
            Controls.Add(lstNguoiThamGia);
            Controls.Add(grpBoxActivityLog);
            Controls.Add(groupBox1);
            Controls.Add(grpBoxTCPServer);
            Name = "Client";
            Text = "Client";
            grpBoxTCPServer.ResumeLayout(false);
            grpBoxTCPServer.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            grpBoxActivityLog.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpBoxTCPServer;
        private Button btnConnect;
        private TextBox txtPort;
        private TextBox txtHost;
        private Label lblConnects;
        private Label lblPort;
        private Label lblStatus;
        private Label lblIP;
        private GroupBox groupBox1;
        private Button btnOpenConnect;
        private TextBox txtMessage;
        private Label label2;
        private GroupBox grpBoxActivityLog;
        private ListBox lstTroChuyen;
        private TextBox textName;
        private Label label1;
        private ListBox lstNguoiThamGia;
        private Label label3;
        private Button btnOutRoom;
    }
}
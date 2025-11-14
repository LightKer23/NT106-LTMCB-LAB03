namespace Bai06
{
    partial class Server
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
            grpBoxActivityLog = new GroupBox();
            lstBoxDiaryLog = new ListBox();
            grpBoxTCPServer = new GroupBox();
            btnCloseConnect = new Button();
            btnOpenConnect = new Button();
            txtBoxStatus = new TextBox();
            txtBoxPort = new TextBox();
            txtBoxConnects = new TextBox();
            txtBoxIP = new TextBox();
            lblConnects = new Label();
            lblPort = new Label();
            lblStatus = new Label();
            lblIP = new Label();
            grpBoxActivityLog.SuspendLayout();
            grpBoxTCPServer.SuspendLayout();
            SuspendLayout();
            // 
            // grpBoxActivityLog
            // 
            grpBoxActivityLog.Controls.Add(lstBoxDiaryLog);
            grpBoxActivityLog.Font = new Font("Tahoma", 10.2F);
            grpBoxActivityLog.Location = new Point(12, 106);
            grpBoxActivityLog.Name = "grpBoxActivityLog";
            grpBoxActivityLog.Size = new Size(694, 393);
            grpBoxActivityLog.TabIndex = 3;
            grpBoxActivityLog.TabStop = false;
            grpBoxActivityLog.Text = "Nhật ký hoạt động";
            // 
            // lstBoxDiaryLog
            // 
            lstBoxDiaryLog.FormattingEnabled = true;
            lstBoxDiaryLog.ItemHeight = 21;
            lstBoxDiaryLog.Location = new Point(6, 27);
            lstBoxDiaryLog.Name = "lstBoxDiaryLog";
            lstBoxDiaryLog.Size = new Size(673, 361);
            lstBoxDiaryLog.TabIndex = 0;
            // 
            // grpBoxTCPServer
            // 
            grpBoxTCPServer.Controls.Add(btnCloseConnect);
            grpBoxTCPServer.Controls.Add(btnOpenConnect);
            grpBoxTCPServer.Controls.Add(txtBoxStatus);
            grpBoxTCPServer.Controls.Add(txtBoxPort);
            grpBoxTCPServer.Controls.Add(txtBoxConnects);
            grpBoxTCPServer.Controls.Add(txtBoxIP);
            grpBoxTCPServer.Controls.Add(lblConnects);
            grpBoxTCPServer.Controls.Add(lblPort);
            grpBoxTCPServer.Controls.Add(lblStatus);
            grpBoxTCPServer.Controls.Add(lblIP);
            grpBoxTCPServer.Font = new Font("Tahoma", 10.2F);
            grpBoxTCPServer.Location = new Point(12, 6);
            grpBoxTCPServer.Name = "grpBoxTCPServer";
            grpBoxTCPServer.Size = new Size(694, 94);
            grpBoxTCPServer.TabIndex = 2;
            grpBoxTCPServer.TabStop = false;
            grpBoxTCPServer.Text = "TCP Server";
            // 
            // btnCloseConnect
            // 
            btnCloseConnect.FlatAppearance.BorderColor = Color.White;
            btnCloseConnect.Location = new Point(559, 57);
            btnCloseConnect.Name = "btnCloseConnect";
            btnCloseConnect.Size = new Size(120, 30);
            btnCloseConnect.TabIndex = 9;
            btnCloseConnect.Text = "Đóng kết nối";
            btnCloseConnect.UseVisualStyleBackColor = true;
            btnCloseConnect.Click += btnCloseConnect_Click;
            // 
            // btnOpenConnect
            // 
            btnOpenConnect.FlatAppearance.BorderColor = Color.White;
            btnOpenConnect.Location = new Point(559, 19);
            btnOpenConnect.Name = "btnOpenConnect";
            btnOpenConnect.Size = new Size(120, 30);
            btnOpenConnect.TabIndex = 8;
            btnOpenConnect.Text = "Mở kết nối";
            btnOpenConnect.TextAlign = ContentAlignment.BottomCenter;
            btnOpenConnect.UseVisualStyleBackColor = true;
            btnOpenConnect.Click += btnOpenConnect_Click;
            // 
            // txtBoxStatus
            // 
            txtBoxStatus.BackColor = SystemColors.ControlLight;
            txtBoxStatus.Location = new Point(105, 57);
            txtBoxStatus.Name = "txtBoxStatus";
            txtBoxStatus.ReadOnly = true;
            txtBoxStatus.Size = new Size(181, 28);
            txtBoxStatus.TabIndex = 7;
            // 
            // txtBoxPort
            // 
            txtBoxPort.Location = new Point(407, 17);
            txtBoxPort.Name = "txtBoxPort";
            txtBoxPort.Size = new Size(125, 28);
            txtBoxPort.TabIndex = 6;
            // 
            // txtBoxConnects
            // 
            txtBoxConnects.BackColor = SystemColors.ControlLight;
            txtBoxConnects.Location = new Point(407, 57);
            txtBoxConnects.Name = "txtBoxConnects";
            txtBoxConnects.ReadOnly = true;
            txtBoxConnects.Size = new Size(125, 28);
            txtBoxConnects.TabIndex = 5;
            // 
            // txtBoxIP
            // 
            txtBoxIP.Location = new Point(105, 21);
            txtBoxIP.Name = "txtBoxIP";
            txtBoxIP.Size = new Size(181, 28);
            txtBoxIP.TabIndex = 4;
            // 
            // lblConnects
            // 
            lblConnects.AutoSize = true;
            lblConnects.Location = new Point(313, 60);
            lblConnects.Name = "lblConnects";
            lblConnects.Size = new Size(88, 21);
            lblConnects.TabIndex = 3;
            lblConnects.Text = "SL kết nối:";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(313, 24);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(53, 21);
            lblPort.TabIndex = 2;
            lblPort.Text = "Cổng:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(13, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(92, 21);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "Trạng thái:";
            // 
            // lblIP
            // 
            lblIP.AutoSize = true;
            lblIP.Location = new Point(13, 24);
            lblIP.Name = "lblIP";
            lblIP.Size = new Size(31, 21);
            lblIP.TabIndex = 0;
            lblIP.Text = "IP:";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 507);
            Controls.Add(grpBoxActivityLog);
            Controls.Add(grpBoxTCPServer);
            Name = "Server";
            Text = "Server";
            FormClosing += Server_FormClosing;
            grpBoxActivityLog.ResumeLayout(false);
            grpBoxTCPServer.ResumeLayout(false);
            grpBoxTCPServer.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpBoxActivityLog;
        private ListBox lstBoxDiaryLog;
        private GroupBox grpBoxTCPServer;
        private Button btnCloseConnect;
        private Button btnOpenConnect;
        private TextBox txtBoxStatus;
        private TextBox txtBoxPort;
        private TextBox txtBoxConnects;
        private TextBox txtBoxIP;
        private Label lblConnects;
        private Label lblPort;
        private Label lblStatus;
        private Label lblIP;
    }
}
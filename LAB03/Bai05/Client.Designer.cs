namespace Bai05
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
            txtServerIP = new TextBox();
            lblServerIP = new Label();
            lblPort = new Label();
            txtPort = new TextBox();
            btnConnect = new Button();
            btnFind = new Button();
            lblResult = new Label();
            btnExit = new Button();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(188, 45);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(125, 27);
            txtServerIP.TabIndex = 0;
            // 
            // lblServerIP
            // 
            lblServerIP.AutoSize = true;
            lblServerIP.Location = new Point(75, 48);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(66, 20);
            lblServerIP.TabIndex = 1;
            lblServerIP.Text = "Server IP";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(75, 98);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(35, 20);
            lblPort.TabIndex = 2;
            lblPort.Text = "Port";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(188, 95);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(434, 44);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(94, 29);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // btnFind
            // 
            btnFind.Location = new Point(398, 94);
            btnFind.Name = "btnFind";
            btnFind.Size = new Size(167, 29);
            btnFind.TabIndex = 5;
            btnFind.Text = "Find a dish ";
            btnFind.UseVisualStyleBackColor = true;
            btnFind.Click += btnFind_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(75, 148);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(21, 20);
            lblResult.TabIndex = 6;
            lblResult.Text = "....";
            // 
            // btnExit
            // 
            btnExit.Location = new Point(434, 144);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 29);
            btnExit.TabIndex = 7;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 217);
            Controls.Add(btnExit);
            Controls.Add(lblResult);
            Controls.Add(btnFind);
            Controls.Add(btnConnect);
            Controls.Add(txtPort);
            Controls.Add(lblPort);
            Controls.Add(lblServerIP);
            Controls.Add(txtServerIP);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtServerIP;
        private Label lblServerIP;
        private Label lblPort;
        private TextBox txtPort;
        private Button btnConnect;
        private Button btnFind;
        private Label lblResult;
        private Button btnExit;
    }
}
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
            lblResult = new Label();
            txtResult = new TextBox();
            lblStatus = new Label();
            btnGetfood = new Button();
            SuspendLayout();
            // 
            // txtServerIP
            // 
            txtServerIP.Location = new Point(135, 33);
            txtServerIP.Name = "txtServerIP";
            txtServerIP.Size = new Size(204, 27);
            txtServerIP.TabIndex = 0;
            // 
            // lblServerIP
            // 
            lblServerIP.AutoSize = true;
            lblServerIP.Location = new Point(44, 36);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new Size(0, 20);
            lblServerIP.TabIndex = 1;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(44, 82);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(0, 20);
            lblPort.TabIndex = 2;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(135, 79);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(204, 27);
            txtPort.TabIndex = 3;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(414, 31);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 30);
            btnConnect.TabIndex = 4;
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(44, 136);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(0, 20);
            lblResult.TabIndex = 6;
            // 
            // txtResult
            // 
            txtResult.Location = new Point(135, 133);
            txtResult.Name = "txtResult";
            txtResult.ReadOnly = true;
            txtResult.Size = new Size(204, 27);
            txtResult.TabIndex = 8;
            // 
            // lblStatus
            // 
            lblStatus.Location = new Point(44, 180);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(295, 31);
            lblStatus.TabIndex = 9;
            // 
            // btnGetfood
            // 
            btnGetfood.Location = new Point(414, 73);
            btnGetfood.Name = "btnGetfood";
            btnGetfood.Size = new Size(100, 30);
            btnGetfood.TabIndex = 10;
            btnGetfood.UseVisualStyleBackColor = true;
            btnGetfood.Click += btnGetfood_Click;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 242);
            Controls.Add(btnGetfood);
            Controls.Add(lblStatus);
            Controls.Add(txtResult);
            Controls.Add(lblResult);
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
        private Label lblResult;
        private TextBox txtResult;
        private Label lblStatus;
        private Button btnGetfood;
    }
}
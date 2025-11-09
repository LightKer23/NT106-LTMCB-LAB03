namespace Bai03
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
            btnDisconnect = new Button();
            btnSend = new Button();
            btnConnect = new Button();
            txtMessage = new TextBox();
            SuspendLayout();
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(361, 153);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(109, 40);
            btnDisconnect.TabIndex = 7;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            btnDisconnect.Click += btnDisconnect_Click;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(361, 83);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(109, 40);
            btnSend.TabIndex = 6;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(361, 12);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(109, 40);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // txtMessage
            // 
            txtMessage.AcceptsReturn = true;
            txtMessage.Location = new Point(12, 12);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(343, 181);
            txtMessage.TabIndex = 4;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(479, 198);
            Controls.Add(btnDisconnect);
            Controls.Add(btnSend);
            Controls.Add(btnConnect);
            Controls.Add(txtMessage);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnDisconnect;
        private Button btnSend;
        private Button btnConnect;
        private TextBox txtMessage;
    }
}
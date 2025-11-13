namespace Bai05
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
            btnListen = new Button();
            lblStatus = new Label();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Font = new Font("Tahoma", 10.2F);
            btnListen.Location = new Point(114, 28);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(183, 29);
            btnListen.TabIndex = 5;
            btnListen.Text = "Lắng nghe";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click_1;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Tahoma", 10.2F);
            lblStatus.Location = new Point(36, 73);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(359, 30);
            lblStatus.TabIndex = 6;
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lstLog
            // 
            lstLog.Font = new Font("Tahoma", 10.2F);
            lstLog.FormattingEnabled = true;
            lstLog.ItemHeight = 21;
            lstLog.Location = new Point(36, 116);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(359, 487);
            lstLog.TabIndex = 7;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 630);
            Controls.Add(lstLog);
            Controls.Add(lblStatus);
            Controls.Add(btnListen);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
        }

        #endregion
        private Button btnAdd;
        private Button btnXoa;
        private Button btnListen;
        private Label lblStatus;
        private ListBox lstLog;
    }
}
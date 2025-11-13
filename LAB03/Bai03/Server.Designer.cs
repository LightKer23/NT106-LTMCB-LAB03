namespace Bai03
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
            label2 = new Label();
            btnCloseListen = new Button();
            label1 = new Label();
            lstMessage = new ListBox();
            btnOpenListen = new Button();
            btnStatus = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 15);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 9;
            // 
            // btnCloseListen
            // 
            btnCloseListen.Location = new Point(542, 15);
            btnCloseListen.Name = "btnCloseListen";
            btnCloseListen.Size = new Size(105, 35);
            btnCloseListen.TabIndex = 8;
            btnCloseListen.Text = "Close listen";
            btnCloseListen.UseVisualStyleBackColor = true;
            btnCloseListen.Click += btnCloseListen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 15);
            label1.Name = "label1";
            label1.Size = new Size(0, 20);
            label1.TabIndex = 7;
            // 
            // lstMessage
            // 
            lstMessage.FormattingEnabled = true;
            lstMessage.Location = new Point(8, 56);
            lstMessage.Name = "lstMessage";
            lstMessage.Size = new Size(643, 364);
            lstMessage.TabIndex = 6;
            // 
            // btnOpenListen
            // 
            btnOpenListen.Location = new Point(419, 15);
            btnOpenListen.Name = "btnOpenListen";
            btnOpenListen.Size = new Size(105, 35);
            btnOpenListen.TabIndex = 10;
            btnOpenListen.Text = "Open listen";
            btnOpenListen.UseVisualStyleBackColor = true;
            btnOpenListen.Click += btnOpenListen_Click;
            // 
            // btnStatus
            // 
            btnStatus.Location = new Point(14, 21);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(104, 29);
            btnStatus.TabIndex = 11;
            btnStatus.Text = "Don't listen";
            btnStatus.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, -2);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 12;
            label3.Text = "Status";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 430);
            Controls.Add(label3);
            Controls.Add(btnStatus);
            Controls.Add(btnOpenListen);
            Controls.Add(label2);
            Controls.Add(btnCloseListen);
            Controls.Add(label1);
            Controls.Add(lstMessage);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button btnCloseListen;
        private Label label1;
        private ListBox lstMessage;
        private Button btnOpenListen;
        private Button btnStatus;
        private Label label3;
    }
}
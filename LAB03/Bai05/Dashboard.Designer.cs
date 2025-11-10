namespace Bai05
{
    partial class Dashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnServer = new Button();
            btnClient = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnServer
            // 
            btnServer.Font = new Font("Tahoma", 10.2F);
            btnServer.Location = new Point(215, 40);
            btnServer.Name = "btnServer";
            btnServer.Size = new Size(120, 40);
            btnServer.TabIndex = 7;
            btnServer.Text = "Server";
            btnServer.UseVisualStyleBackColor = true;
            btnServer.Click += btnServer_Click;
            // 
            // btnClient
            // 
            btnClient.FlatAppearance.BorderColor = Color.White;
            btnClient.Font = new Font("Tahoma", 10.2F);
            btnClient.Location = new Point(45, 40);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(120, 40);
            btnClient.TabIndex = 6;
            btnClient.Text = "Client";
            btnClient.UseVisualStyleBackColor = true;
            btnClient.Click += btnClient_Click;
            // 
            // button1
            // 
            button1.Location = new Point(100, 100);
            button1.Name = "button1";
            button1.Size = new Size(178, 40);
            button1.TabIndex = 8;
            button1.Text = "Find dish for today";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 160);
            Controls.Add(button1);
            Controls.Add(btnServer);
            Controls.Add(btnClient);
            Name = "Dashboard";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bài 05";
            ResumeLayout(false);
        }

        #endregion

        private Button btnServer;
        private Button btnClient;
        private Button button1;
    }
}

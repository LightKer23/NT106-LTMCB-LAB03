namespace Bai06
{
    partial class ClientAndClient
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
            btnGuiRieng = new Button();
            txtMessClient = new TextBox();
            lstMessClient = new ListBox();
            btnThoatPhong = new Button();
            label1 = new Label();
            lblName = new Label();
            SuspendLayout();
            // 
            // btnGuiRieng
            // 
            btnGuiRieng.Font = new Font("Segoe UI", 10.2F);
            btnGuiRieng.Location = new Point(393, 35);
            btnGuiRieng.Name = "btnGuiRieng";
            btnGuiRieng.Size = new Size(94, 29);
            btnGuiRieng.TabIndex = 0;
            btnGuiRieng.Text = "Gửi";
            btnGuiRieng.UseVisualStyleBackColor = true;
            btnGuiRieng.Click += btnGuiRieng_Click;
            // 
            // txtMessClient
            // 
            txtMessClient.Font = new Font("Segoe UI", 10.2F);
            txtMessClient.Location = new Point(12, 35);
            txtMessClient.Name = "txtMessClient";
            txtMessClient.Size = new Size(368, 30);
            txtMessClient.TabIndex = 1;
            // 
            // lstMessClient
            // 
            lstMessClient.Font = new Font("Segoe UI", 10.2F);
            lstMessClient.FormattingEnabled = true;
            lstMessClient.ItemHeight = 23;
            lstMessClient.Location = new Point(12, 79);
            lstMessClient.Name = "lstMessClient";
            lstMessClient.Size = new Size(368, 188);
            lstMessClient.TabIndex = 2;
            // 
            // btnThoatPhong
            // 
            btnThoatPhong.Font = new Font("Segoe UI", 10.2F);
            btnThoatPhong.Location = new Point(393, 238);
            btnThoatPhong.Name = "btnThoatPhong";
            btnThoatPhong.Size = new Size(94, 29);
            btnThoatPhong.TabIndex = 3;
            btnThoatPhong.Text = "Thoát";
            btnThoatPhong.UseVisualStyleBackColor = true;
            btnThoatPhong.Click += btnThoatPhong_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 4;
            label1.Text = "tên người dùng:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(124, 5);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 20);
            lblName.TabIndex = 5;
            // 
            // ClientAndClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 279);
            Controls.Add(lblName);
            Controls.Add(label1);
            Controls.Add(btnThoatPhong);
            Controls.Add(lstMessClient);
            Controls.Add(txtMessClient);
            Controls.Add(btnGuiRieng);
            Name = "ClientAndClient";
            Text = "ClientAndClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuiRieng;
        private TextBox txtMessClient;
        private ListBox lstMessClient;
        private Button btnThoatPhong;
        private Label label1;
        private Label lblName;
    }
}
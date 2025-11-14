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
            btnGuiRieng.Font = new Font("Tahoma", 9F);
            btnGuiRieng.Location = new Point(330, 238);
            btnGuiRieng.Name = "btnGuiRieng";
            btnGuiRieng.Size = new Size(50, 30);
            btnGuiRieng.TabIndex = 0;
            btnGuiRieng.Text = "Gửi";
            btnGuiRieng.UseVisualStyleBackColor = true;
            btnGuiRieng.Click += btnGuiRieng_Click;
            // 
            // txtMessClient
            // 
            txtMessClient.Font = new Font("Tahoma", 9F);
            txtMessClient.Location = new Point(12, 241);
            txtMessClient.Name = "txtMessClient";
            txtMessClient.Size = new Size(312, 26);
            txtMessClient.TabIndex = 1;
            txtMessClient.Click += txtMessClient_Click;
            txtMessClient.TextChanged += txtMessClient_TextChanged;
            // 
            // lstMessClient
            // 
            lstMessClient.Font = new Font("Tahoma", 9F);
            lstMessClient.FormattingEnabled = true;
            lstMessClient.ItemHeight = 18;
            lstMessClient.Location = new Point(12, 42);
            lstMessClient.Name = "lstMessClient";
            lstMessClient.Size = new Size(368, 184);
            lstMessClient.TabIndex = 2;
            // 
            // btnThoatPhong
            // 
            btnThoatPhong.Font = new Font("Tahoma", 9F);
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
            label1.Font = new Font("Tahoma", 9F);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(116, 18);
            label1.TabIndex = 4;
            label1.Text = "Tên người dùng:";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Tahoma", 9F);
            lblName.Location = new Point(123, 9);
            lblName.Name = "lblName";
            lblName.Size = new Size(0, 18);
            lblName.TabIndex = 5;
            // 
            // ClientAndClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(499, 292);
            Controls.Add(lblName);
            Controls.Add(label1);
            Controls.Add(btnThoatPhong);
            Controls.Add(lstMessClient);
            Controls.Add(txtMessClient);
            Controls.Add(btnGuiRieng);
            Name = "ClientAndClient";
            Text = "ClientAndClient";
            FormClosing += ClientAndClient_FormClosing;
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
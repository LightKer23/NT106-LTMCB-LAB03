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
            lvMonAn = new ListView();
            txtTenMonAn = new TextBox();
            lblMonAn = new Label();
            btnThem = new Button();
            btnXoa = new Button();
            btnListen = new Button();
            lblStatus = new Label();
            lstLog = new ListBox();
            SuspendLayout();
            // 
            // lvMonAn
            // 
            lvMonAn.Location = new Point(36, 79);
            lvMonAn.Name = "lvMonAn";
            lvMonAn.Size = new Size(359, 121);
            lvMonAn.TabIndex = 0;
            lvMonAn.UseCompatibleStateImageBehavior = false;
            lvMonAn.View = View.List;
            // 
            // txtTenMonAn
            // 
            txtTenMonAn.Location = new Point(84, 38);
            txtTenMonAn.Name = "txtTenMonAn";
            txtTenMonAn.Size = new Size(191, 27);
            txtTenMonAn.TabIndex = 1;
            // 
            // lblMonAn
            // 
            lblMonAn.AutoSize = true;
            lblMonAn.Location = new Point(36, 41);
            lblMonAn.Name = "lblMonAn";
            lblMonAn.Size = new Size(42, 20);
            lblMonAn.TabIndex = 2;
            lblMonAn.Text = "Dish ";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(301, 37);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 3;
            btnThem.Text = "Add";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(36, 217);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(106, 29);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Remove dish";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnListen
            // 
            btnListen.Location = new Point(301, 217);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(94, 29);
            btnListen.TabIndex = 5;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(36, 267);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(21, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "....";
            // 
            // lstLog
            // 
            lstLog.FormattingEnabled = true;
            lstLog.Location = new Point(36, 309);
            lstLog.Name = "lstLog";
            lstLog.Size = new Size(359, 104);
            lstLog.TabIndex = 7;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(430, 450);
            Controls.Add(lstLog);
            Controls.Add(lblStatus);
            Controls.Add(btnListen);
            Controls.Add(btnXoa);
            Controls.Add(btnThem);
            Controls.Add(lblMonAn);
            Controls.Add(txtTenMonAn);
            Controls.Add(lvMonAn);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView lvMonAn;
        private TextBox txtTenMonAn;
        private Label lblMonAn;
        private Button btnThem;
        private Button btnXoa;
        private Button btnListen;
        private Label lblStatus;
        private ListBox lstLog;
    }
}
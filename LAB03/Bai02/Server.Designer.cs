namespace Bai02
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
            lvMessages = new ListView();
            columnHeader1 = new ColumnHeader();
            lblStatus = new Label();
            lblTitle = new Label();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnListen
            // 
            btnListen.Location = new Point(25, 38);
            btnListen.Name = "btnListen";
            btnListen.Size = new Size(130, 41);
            btnListen.TabIndex = 0;
            btnListen.Text = "Listen";
            btnListen.UseVisualStyleBackColor = true;
            btnListen.Click += btnListen_Click;
            // 
            // lvMessages
            // 
            lvMessages.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            lvMessages.Dock = DockStyle.Fill;
            lvMessages.Location = new Point(0, 0);
            lvMessages.Name = "lvMessages";
            lvMessages.Size = new Size(800, 336);
            lvMessages.TabIndex = 1;
            lvMessages.UseCompatibleStateImageBehavior = false;
            lvMessages.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Messages";
            columnHeader1.Width = 500;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(302, 46);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 25);
            lblStatus.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            lblTitle.Location = new Point(143, 23);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(0, 25);
            lblTitle.TabIndex = 3;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnListen);
            splitContainer1.Panel1.Controls.Add(lblStatus);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lvMessages);
            splitContainer1.Size = new Size(800, 450);
            splitContainer1.SplitterDistance = 110;
            splitContainer1.TabIndex = 4;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblTitle);
            Controls.Add(splitContainer1);
            Name = "Server";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListen;
        private ListView lvMessages;
        private Label lblStatus;
        private ColumnHeader columnHeader1;
        private Label lblTitle;
        private SplitContainer splitContainer1;
    }
}
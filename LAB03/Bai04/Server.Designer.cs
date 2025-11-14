namespace Bai04
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
            LoadDataButton = new Button();
            txtDataFile = new TextBox();
            StartButton = new Button();
            ExportReportButton = new Button();
            progressBar1 = new ProgressBar();
            lvLog = new ListBox();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // LoadDataButton
            // 
            LoadDataButton.Location = new Point(29, 100);
            LoadDataButton.Name = "LoadDataButton";
            LoadDataButton.Size = new Size(126, 73);
            LoadDataButton.TabIndex = 0;
            LoadDataButton.Text = "Chọn file";
            LoadDataButton.UseVisualStyleBackColor = true;
            LoadDataButton.Click += btnLoadFile_Click;
            // 
            // txtDataFile
            // 
            txtDataFile.Location = new Point(29, 50);
            txtDataFile.Name = "txtDataFile";
            txtDataFile.Size = new Size(379, 27);
            txtDataFile.TabIndex = 1;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(652, 50);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(126, 73);
            StartButton.TabIndex = 2;
            StartButton.Text = "Bắt đầu";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += btnStart_Click;
            // 
            // ExportReportButton
            // 
            ExportReportButton.Location = new Point(282, 100);
            ExportReportButton.Name = "ExportReportButton";
            ExportReportButton.Size = new Size(126, 73);
            ExportReportButton.TabIndex = 3;
            ExportReportButton.Text = "Xuất file";
            ExportReportButton.UseVisualStyleBackColor = true;
            ExportReportButton.Click += btnExport_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(282, 178);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(126, 13);
            progressBar1.TabIndex = 4;
            // 
            // lvLog
            // 
            lvLog.FormattingEnabled = true;
            lvLog.Location = new Point(29, 213);
            lvLog.Name = "lvLog";
            lvLog.Size = new Size(759, 204);
            lvLog.TabIndex = 5;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(29, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(115, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Đường dẫn File ";
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(lvLog);
            Controls.Add(progressBar1);
            Controls.Add(ExportReportButton);
            Controls.Add(StartButton);
            Controls.Add(txtDataFile);
            Controls.Add(LoadDataButton);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button LoadDataButton;
        private TextBox txtDataFile;
        private Button StartButton;
        private Button ExportReportButton;
        private ProgressBar progressBar1;
        private ListBox lvLog;
        private Label lblStatus;
    }
}
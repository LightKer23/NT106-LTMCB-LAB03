namespace Bai01
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
            PortBox = new TextBox();
            ListenButton = new Button();
            label1 = new Label();
            MessageListView = new ListView();
            label2 = new Label();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // PortBox
            // 
            PortBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortBox.Location = new Point(62, 71);
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(138, 30);
            PortBox.TabIndex = 0;
            // 
            // ListenButton
            // 
            ListenButton.Font = new Font("Times New Roman", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ListenButton.Location = new Point(479, 64);
            ListenButton.Name = "ListenButton";
            ListenButton.Size = new Size(138, 37);
            ListenButton.TabIndex = 1;
            ListenButton.Text = "Listen";
            ListenButton.UseVisualStyleBackColor = true;
            ListenButton.Click += ListenButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 24);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 2;
            label1.Text = "Port";
            // 
            // MessageListView
            // 
            MessageListView.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            MessageListView.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageListView.FullRowSelect = true;
            MessageListView.HeaderStyle = ColumnHeaderStyle.None;
            MessageListView.Location = new Point(62, 184);
            MessageListView.MultiSelect = false;
            MessageListView.Name = "MessageListView";
            MessageListView.ShowGroups = false;
            MessageListView.Size = new Size(555, 272);
            MessageListView.TabIndex = 3;
            MessageListView.UseCompatibleStateImageBehavior = false;
            MessageListView.View = View.Details;
            MessageListView.SizeChanged += MessageListView_SizeChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(62, 132);
            label2.Name = "label2";
            label2.Size = new Size(200, 25);
            label2.TabIndex = 4;
            label2.Text = "Received messages";
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Messages";
            columnHeader1.Width = 500;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(679, 468);
            Controls.Add(label2);
            Controls.Add(MessageListView);
            Controls.Add(label1);
            Controls.Add(ListenButton);
            Controls.Add(PortBox);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox PortBox;
        private Button ListenButton;
        private Label label1;
        private ListView MessageListView;
        private Label label2;
        private ColumnHeader columnHeader1;
    }
}
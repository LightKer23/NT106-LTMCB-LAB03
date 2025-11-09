namespace Bai01
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
            SendButton = new Button();
            MessageRTextBox = new RichTextBox();
            IPRemotehost = new TextBox();
            PortBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            Message = new Label();
            SuspendLayout();
            // 
            // SendButton
            // 
            SendButton.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SendButton.ForeColor = Color.Black;
            SendButton.Location = new Point(231, 390);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(205, 56);
            SendButton.TabIndex = 0;
            SendButton.Text = "Send";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // MessageRTextBox
            // 
            MessageRTextBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MessageRTextBox.Location = new Point(84, 166);
            MessageRTextBox.Name = "MessageRTextBox";
            MessageRTextBox.Size = new Size(504, 205);
            MessageRTextBox.TabIndex = 1;
            MessageRTextBox.Text = "";
            // 
            // IPRemotehost
            // 
            IPRemotehost.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            IPRemotehost.ForeColor = Color.Black;
            IPRemotehost.Location = new Point(84, 63);
            IPRemotehost.Name = "IPRemotehost";
            IPRemotehost.Size = new Size(192, 30);
            IPRemotehost.TabIndex = 2;
            // 
            // PortBox
            // 
            PortBox.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PortBox.ForeColor = SystemColors.WindowText;
            PortBox.Location = new Point(396, 63);
            PortBox.Name = "PortBox";
            PortBox.Size = new Size(192, 30);
            PortBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(84, 26);
            label1.Name = "label1";
            label1.Size = new Size(167, 25);
            label1.TabIndex = 4;
            label1.Text = "IP Remote host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(396, 26);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 5;
            label2.Text = "Port";
            // 
            // Message
            // 
            Message.AutoSize = true;
            Message.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Message.ForeColor = Color.Black;
            Message.Location = new Point(84, 138);
            Message.Name = "Message";
            Message.Size = new Size(99, 25);
            Message.TabIndex = 6;
            Message.Text = "Message";
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(672, 458);
            Controls.Add(Message);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PortBox);
            Controls.Add(IPRemotehost);
            Controls.Add(MessageRTextBox);
            Controls.Add(SendButton);
            ForeColor = Color.FromArgb(143, 171, 212);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SendButton;
        private RichTextBox MessageRTextBox;
        private TextBox IPRemotehost;
        private TextBox PortBox;
        private Label label1;
        private Label label2;
        private Label Message;
    }
}
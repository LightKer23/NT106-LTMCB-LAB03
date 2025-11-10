namespace Bai05
{
    partial class AddDish
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
            btnAdd = new Button();
            lblDish = new Label();
            label2 = new Label();
            txtDish = new TextBox();
            txtContributor = new TextBox();
            lblContriName = new Label();
            lblDongGop = new Label();
            chkTarget = new CheckedListBox();
            lvPersonal = new ListView();
            btnChooseToday = new Button();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(51, 335);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add dish";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblDish
            // 
            lblDish.AutoSize = true;
            lblDish.Location = new Point(51, 29);
            lblDish.Name = "lblDish";
            lblDish.Size = new Size(38, 20);
            lblDish.TabIndex = 2;
            lblDish.Text = "Dish";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 132);
            label2.Name = "label2";
            label2.Size = new Size(0, 20);
            label2.TabIndex = 3;
            // 
            // txtDish
            // 
            txtDish.Location = new Point(218, 26);
            txtDish.Name = "txtDish";
            txtDish.Size = new Size(125, 27);
            txtDish.TabIndex = 4;
            // 
            // txtContributor
            // 
            txtContributor.Location = new Point(218, 85);
            txtContributor.Name = "txtContributor";
            txtContributor.Size = new Size(125, 27);
            txtContributor.TabIndex = 5;
            // 
            // lblContriName
            // 
            lblContriName.AutoSize = true;
            lblContriName.Location = new Point(51, 88);
            lblContriName.Name = "lblContriName";
            lblContriName.Size = new Size(135, 20);
            lblContriName.TabIndex = 6;
            lblContriName.Text = "Contributor's name";
            // 
            // lblDongGop
            // 
            lblDongGop.AutoSize = true;
            lblDongGop.Location = new Point(51, 153);
            lblDongGop.Name = "lblDongGop";
            lblDongGop.Size = new Size(170, 20);
            lblDongGop.TabIndex = 7;
            lblDongGop.Text = "Đóng góp món ăn vào ?";
            // 
            // chkTarget
            // 
            chkTarget.FormattingEnabled = true;
            chkTarget.Location = new Point(51, 198);
            chkTarget.Name = "chkTarget";
            chkTarget.Size = new Size(150, 114);
            chkTarget.TabIndex = 8;
            // 
            // lvPersonal
            // 
            lvPersonal.Location = new Point(51, 407);
            lvPersonal.Name = "lvPersonal";
            lvPersonal.Size = new Size(151, 121);
            lvPersonal.TabIndex = 9;
            lvPersonal.UseCompatibleStateImageBehavior = false;
            // 
            // btnChooseToday
            // 
            btnChooseToday.Location = new Point(66, 578);
            btnChooseToday.Name = "btnChooseToday";
            btnChooseToday.Size = new Size(94, 29);
            btnChooseToday.TabIndex = 10;
            btnChooseToday.Text = "Get food";
            btnChooseToday.UseVisualStyleBackColor = true;
            btnChooseToday.Click += btnChooseToday_Click;
            // 
            // AddDish
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(563, 707);
            Controls.Add(btnChooseToday);
            Controls.Add(lvPersonal);
            Controls.Add(chkTarget);
            Controls.Add(lblDongGop);
            Controls.Add(lblContriName);
            Controls.Add(txtContributor);
            Controls.Add(txtDish);
            Controls.Add(label2);
            Controls.Add(lblDish);
            Controls.Add(btnAdd);
            Name = "AddDish";
            Text = "AddDish";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAdd;
        private Label lblDish;
        private Label label2;
        private TextBox txtDish;
        private TextBox txtContributor;
        private Label lblContriName;
        private Label lblDongGop;
        private CheckedListBox chkTarget;
        private ListView lvPersonal;
        private Button btnChooseToday;
    }
}
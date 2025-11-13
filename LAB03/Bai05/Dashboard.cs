using Exercise.Bai06;

namespace Bai05
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn muốn làm việc với dữ liệu nào?\n\n" +
                "• YES: Cộng đồng (qua Server)\n" +
                "• NO: Cá nhân (local database)\n",
                "Chọn nguồn dữ liệu",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                WhatEatTodayForm form = new WhatEatTodayForm(isCommunityMode: true);
                form.Show();
            }
            else if (result == DialogResult.No)
            {
                WhatEatTodayForm form = new WhatEatTodayForm(isCommunityMode: false);
                form.Show();
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            try
            {
                Server sv = new Server();
                sv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi mở Server: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

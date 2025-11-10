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
            try
            {
                AddDish ad = new AddDish();
                ad.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Add Dish form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error opening Server form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Client cf = new Client();
                cf.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Find Food: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

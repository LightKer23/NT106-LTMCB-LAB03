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
                "What would you like to do?\n\n" +
                "• YES: Add a new dish to personal or community\n" +
                "• NO: Find a random dish from community\n",
                "Client Menu",
                MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                AddDish ad = new AddDish();
                ad.Show();
            }
            else if (result == DialogResult.No)
            {
                Client client = new Client();
                client.Show();
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

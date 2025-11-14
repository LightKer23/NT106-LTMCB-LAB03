namespace Bai04
{
    public partial class Dashboard : Form
    {


        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Client clientForm = new Client();
            clientForm.Show();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server serverForm = new Server();
            serverForm.Show();
        }
    }
}

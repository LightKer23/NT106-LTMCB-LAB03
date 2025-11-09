namespace Bai02
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            Server sv = new Server();
            sv.Show();
        }
    }
}

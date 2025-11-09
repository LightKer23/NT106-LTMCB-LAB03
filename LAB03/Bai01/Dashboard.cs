namespace Bai01
{
    public partial class Form1 : Form
    {
        public Form1()
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

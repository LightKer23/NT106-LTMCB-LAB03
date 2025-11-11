using Bai03.TCPsocket;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class Client : Form
    {

        private string? _ip = ConfigurationManager.AppSettings["ServerIP"];
        private int _port = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);

        private TCPClient _client = new TCPClient();
        public Client()
        {
            InitializeComponent();

            btnDisconnect.Enabled = false;
            btnSend.Enabled = false;

            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (_client.Connect($"{_ip}", _port))
            {
                btnSend.Enabled = true;
                btnDisconnect.Enabled = true;
                btnConnect.Enabled = false;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text == "")
            {
                MessageBox.Show("Warning: Data not entered.", "Warning", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            _client.Send(txtMessage.Text);
            txtMessage.Clear();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            _client.Disconnect();
            btnSend.Enabled = false;
            btnDisconnect.Enabled = false;
            btnConnect.Enabled= true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai03.TCPsocket;
namespace Bai03
{
    public partial class Server : Form
    {
        TCPServer _server = new TCPServer();

        public Server()
        {
            InitializeComponent();

            _server.OnMessageReceived += (msg) =>
            {
                Invoke(new Action(() =>
                {
                    lstMessage.Items.Add(msg);
                }));
            };

            btnStatus.Enabled = false;
            btnCloseListen.Enabled = false;
        }

        private void btnOpenListen_Click(object sender, EventArgs e)
        {
            _server.Start(8080);
            btnStatus.Text = "Listened!";
            lstMessage.Items.Add("Server started, open connetion port 8080!\n");
            btnCloseListen.Enabled = true;
            btnOpenListen.Enabled = false;
        }

        private void btnCloseListen_Click(object sender, EventArgs e)
        {
            lstMessage.Items.Add("Server has stopped connecting!\n");
            btnStatus.Text = "Don't listen!";
            _server.Stop();
            btnCloseListen.Enabled = false;
            btnOpenListen.Enabled = true;
        }
    }
}

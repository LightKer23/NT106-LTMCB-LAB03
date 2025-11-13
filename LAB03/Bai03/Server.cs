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
    public partial class Server : Form
    {
        TCPServer _server = new TCPServer();

        private string _ip;
        private int _port;

        public Server()
        {
            InitializeComponent();



            _ip = ConfigurationManager.AppSettings["ServerIP"];
            _port = int.Parse(ConfigurationManager.AppSettings["ServerPort"]);


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
            _server.Start(_port);
            btnStatus.Text = "Listened!";
            lstMessage.Items.Add($"Server started, open connetion port {_port}!\n");
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

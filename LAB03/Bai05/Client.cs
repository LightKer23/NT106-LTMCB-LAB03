using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai05
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new TcpClient(txtServerIP.Text, int.Parse(txtPort.Text));
            stream = client.GetStream();
            lblResult.Text = "Đã kết nối server!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage("GET_FOOD");
            lblResult.Text = ReceiveMessage();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SendMessage("EXIT");
            client.Close();
            lblResult.Text = "Đã ngắt kết nối.";
        }

        private void SendMessage(string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            stream.Write(data, 0, data.Length);
        }

        private string ReceiveMessage()
        {
            byte[] buffer = new byte[1024];
            int bytes = stream.Read(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytes);
        }
    }
}

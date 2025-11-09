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

namespace Bai01
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string IPhost = IPRemotehost.Text.Trim();
            int Port = int.Parse(PortBox.Text.Trim());
            string Message = MessageRTextBox.Text;
            if (string.IsNullOrWhiteSpace(Message))
            {
                MessageBox.Show("Vui lòng không để trống thông điệp");
                return;
            }
            try
            {
                UdpClient udpClient = new UdpClient();
                byte[] sendBytes = Encoding.UTF8.GetBytes(Message);
                udpClient.Send(sendBytes, sendBytes.Length, IPhost, Port);
                udpClient.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu: " + ex.Message);
            }
        }
    }
}

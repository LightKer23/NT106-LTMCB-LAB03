using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
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
            string Message = MessageRTextBox.Text;
            if (string.IsNullOrWhiteSpace(IPhost) || !IPAddress.TryParse(IPhost, out _))
            {
                MessageBox.Show("Vui lòng không để trống IP Remote Host và nhập đúng định dạng (vd: 127.0.0.1)");
                return;
            }
            if (!int.TryParse(PortBox.Text.Trim(), out int Port) || Port < 1 || Port > 65535)
            {
                MessageBox.Show("Vui lòng không để trống Port và nhập Port hợp lệ (1-65535)");
                return;
            }
            if (string.IsNullOrWhiteSpace(Message))
            {
                MessageBox.Show("Vui lòng không để trống thông điệp");
                return;
            }
            try
            {
                UdpClient udpClient = new UdpClient();
                byte[] sendBytes = Encoding.UTF8.GetBytes(Message);
                udpClient.Send(sendBytes, sendBytes.Length,IPhost,Port);
                udpClient.Close();
            }    
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi dữ liệu ");
            }
        }
    }
}

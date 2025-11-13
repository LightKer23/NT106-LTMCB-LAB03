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

        private bool IsValidIPv4(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip)) return false;

            string[] parts = ip.Split('.');
            if (parts.Length != 4) return false;

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int value)) return false;
                if (value < 0 || value > 255) return false;
            }

            return true;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string IPhost = IPRemotehost.Text.Trim();
            string Message = MessageRTextBox.Text;
            if (!IsValidIPv4(IPhost))
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

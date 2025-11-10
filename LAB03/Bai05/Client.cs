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
        private string dishName;
        private string contributor;

        public Client()
        {
            InitializeComponent();
        }

        // Constructor mới nhận dữ liệu từ AddDish
        public Client(string dishName, string contributor)
        {
            InitializeComponent();
            this.dishName = dishName;
            this.contributor = string.IsNullOrEmpty(contributor) ? "Anonymous" : contributor;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtServerIP.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                using (TcpClient client = new TcpClient(ip, port))
                using (NetworkStream stream = client.GetStream())
                {
                    // Gửi dữ liệu món ăn đã nhập ở AddDish
                    string message = $"ADD:{dishName} by {contributor}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    MessageBox.Show($"Dish '{dishName}' sent successfully!\nServer response: {response}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close(); // đóng form sau khi gửi xong
            }
            catch (SocketException)
            {
                MessageBox.Show("Could not connect to the server.\n\nPlease make sure:\n" +
                    "1. Server form is opened\n" +
                    "2. 'Listen' button is clicked\n" +
                    "3. Server is running on port 12000",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

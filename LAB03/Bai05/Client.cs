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
        private bool isFromAddDish = false; 

        // Constructor mặc định (khi mở độc lập để Get Food)
        public Client()
        {
            InitializeComponent();
            InitializeUI();
        }

        // Constructor nhận dữ liệu từ AddDish (để gửi món ăn)
        public Client(string dishName, string contributor)
        {
            InitializeComponent();
            this.dishName = dishName;
            this.contributor = string.IsNullOrEmpty(contributor) ? "Anonymous" : contributor;
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Khởi tạo giá trị mặc định
            txtServerIP.Text = "127.0.0.1";
            txtPort.Text = "12000";

            if (lblStatus != null)
            {
                lblStatus.Text = isFromAddDish
                    ? $"Ready to send: {dishName}"
                    : "Ready to get food";
                lblStatus.ForeColor = Color.Blue;
            }

            // Đổi text của nút Connect tùy theo chức năng
            if (btnConnect != null)
            {
                btnConnect.Text = isFromAddDish ? "Send to Server" : "Connect";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isFromAddDish)
            {
                // Nếu form được mở từ AddDish, gửi món ăn lên server
                SendDishToServer();
            }
            else
            {
                // Nếu mở độc lập (từ Dashboard), chỉ kiểm tra kết nối
                try
                {
                    string ip = txtServerIP.Text.Trim();
                    if (!int.TryParse(txtPort.Text.Trim(), out int port))
                    {
                        MessageBox.Show("Invalid port number!", "Warning");
                        return;
                    }

                    using (TcpClient client = new TcpClient(ip, port))
                    {
                        MessageBox.Show("Connected successfully!", "Connection Test",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    lblStatus.Text = "Connected!";
                    lblStatus.ForeColor = Color.Green;
                }
                catch
                {
                    lblStatus.Text = "Connection failed!";
                    lblStatus.ForeColor = Color.Red;
                    MessageBox.Show("Cannot connect to server!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SendDishToServer()
        {
            try
            {
                string ip = txtServerIP.Text.Trim();

                if (!int.TryParse(txtPort.Text.Trim(), out int port))
                {
                    MessageBox.Show("Invalid port number!", "Warning");
                    return;
                }

                using (TcpClient client = new TcpClient(ip, port))
                using (NetworkStream stream = client.GetStream())
                {
                    // Gửi dữ liệu món ăn
                    string message = $"ADD:{dishName} by {contributor}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    if (lblStatus != null)
                    {
                        lblStatus.Text = "Sent successfully!";
                        lblStatus.ForeColor = Color.Green;
                    }

                    if (txtResult != null)
                    {
                        txtResult.Text = response;
                    }

                    MessageBox.Show($"Dish '{dishName}' sent successfully!\n\nServer response: {response}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Đóng form sau khi gửi thành công
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SocketException)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Connection failed!";
                    lblStatus.ForeColor = Color.Red;
                }

                MessageBox.Show("Could not connect to the server.\n\nPlease make sure:\n" +
                    "1. Server form is opened\n" +
                    "2. 'Listen' button is clicked\n" +
                    "3. Server is running on port 12000",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Error!";
                    lblStatus.ForeColor = Color.Red;
                }

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetfood_Click(object sender, EventArgs e)
        {
            try
            {
                string ip = txtServerIP.Text.Trim();

                if (string.IsNullOrEmpty(ip))
                {
                    MessageBox.Show("Please enter server IP!", "Warning");
                    return;
                }

                if (!int.TryParse(txtPort.Text.Trim(), out int port))
                {
                    MessageBox.Show("Invalid port number!", "Warning");
                    return;
                }

                using (TcpClient client = new TcpClient(ip, port))
                using (NetworkStream stream = client.GetStream())
                {
                    // Gửi yêu cầu lấy món ăn ngẫu nhiên
                    string message = "GET_FOOD";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    // Nhận phản hồi từ server
                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    if (lblStatus != null)
                    {
                        lblStatus.Text = "Food received!";
                        lblStatus.ForeColor = Color.Green;
                    }

                    if (txtResult != null)
                    {
                        txtResult.Text = response;
                    }

                    MessageBox.Show($"Random dish from community:\n\n{response}",
                        "Today's Suggestion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SocketException)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Connection failed!";
                    lblStatus.ForeColor = Color.Red;
                }

                MessageBox.Show("Could not connect to the server.\n\nPlease make sure:\n" +
                    "1. Server form is opened\n" +
                    "2. 'Listen' button is clicked\n" +
                    "3. Server is running on port 12000",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                if (lblStatus != null)
                {
                    lblStatus.Text = "Error!";
                    lblStatus.ForeColor = Color.Red;
                }

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
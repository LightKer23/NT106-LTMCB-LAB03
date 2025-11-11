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
        public Client()
        {
            InitializeComponent();
            InitializeUI();
        }
        public Client(string dishName, string contributor)
        {
            InitializeComponent();
            this.dishName = dishName;
            this.contributor = string.IsNullOrEmpty(contributor) ? "Anonymous" : contributor;
            InitializeUI();
        }

        private void InitializeUI()
        {
            txtServerIP.Text = "127.0.0.1";
            txtPort.Text = "12000";

            if (lblStatus != null)
            {
                lblStatus.Text = "Unconnected";
            }

            if (btnConnect != null)
            {
                btnConnect.Text = "Connect";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
                SendDishToServer();
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
                    string message = $"ADD:{dishName} by {contributor}";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    lblStatus.Text = "Dish sent successfully!";
                    txtResult.Text = $"Server response: {response}";

                    MessageBox.Show($"Dish '{dishName}' by '{contributor}' sent successfully!\n\n" +
                                    $"Server says: {response}",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SocketException)
            {
                lblStatus.Text = "Connection failed!";
                MessageBox.Show("Could not connect to the server.\n\nPlease make sure:\n" +
                    "1. Server form is opened\n" +
                    "2. 'Listen' button is clicked\n" +
                    "3. Server is running on port 12000",
                    "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error!";
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
                    string message = "GET_FOOD";
                    byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                    stream.Write(data, 0, data.Length);

                    byte[] buffer = new byte[1024];
                    int bytes = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();

                    if (lblStatus != null)
                    {
                        lblStatus.Text = "Food received!";
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
                }

                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
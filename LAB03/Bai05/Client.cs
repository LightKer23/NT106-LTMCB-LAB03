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
            try
            {
                string ip = txtServerIP.Text.Trim();
                int port = int.Parse(txtPort.Text.Trim());

                client = new TcpClient();
                client.Connect(ip, port);
                stream = client.GetStream();

                lblStatus.Text = "Connected to server successfully!";
                btnFind.Enabled = true;
                btnExit.Enabled = true;
            }
            catch (SocketException)
            {
                MessageBox.Show(
                    "Could not connect to the server.\n" +
                    "Please make sure the server is running and listening.",
                    "Connection Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                lblStatus.Text = "Connection failed.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            SendMessage("EXIT");
            client.Close();
            lblStatus.Text = "Disconnected!";
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessage("GET_FOOD");
                string response = ReceiveMessage();
                txtResult.Text = response;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while getting food: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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

namespace Bai05
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private bool isRunning = false;
        private List<string> dsMonAn = new List<string>();


        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isRunning) return;

            listener = new TcpListener(IPAddress.Any, 12000);
            listener.Start();
            isRunning = true;

            lblStatus.Text = "Server are listenning on port 12000...";
            new Thread(AcceptClients).Start();
        }

        private void AcceptClients()
        {
            while (isRunning)
            {
                TcpClient client = listener.AcceptTcpClient();
                lstLog.Items.Add("Client connected");
                new Thread(() => HandleClient(client)).Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string request = Encoding.UTF8.GetString(buffer, 0, byteCount).Trim();

                if (request == "GET_FOOD")
                {
                    if (dsMonAn.Count == 0)
                    {
                        SendMessage(stream, "List is empty!");
                    }
                    else
                    {
                        Random rnd = new Random();
                        string mon = dsMonAn[rnd.Next(dsMonAn.Count)];
                        SendMessage(stream, mon);
                        lstLog.Items.Add("Sent dish: " + mon);
                    }
                }
                else if (request.StartsWith("ADD:"))
                {
                    string monMoi = request.Substring(4);
                    dsMonAn.Add(monMoi);
                    lstLog.Items.Add("Added: " + monMoi);
                    SendMessage(stream, "Dish added: " + monMoi);
                }
                else if (request == "EXIT")
                {
                    lstLog.Items.Add("Client disconnected");
                    break;
                }
            }

            client.Close();
        }

        private void SendMessage(NetworkStream stream, string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            stream.Write(data, 0, data.Length);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTenMonAn.Text))
            {
                dsMonAn.Add(txtTenMonAn.Text.Trim());
                lvMonAn.Items.Add(txtTenMonAn.Text);
                txtTenMonAn.Clear();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvMonAn.SelectedItems.Count == 0)
            {
                MessageBox.Show("please select the dish to remove!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mon = lvMonAn.SelectedItems[0].Text;
            DialogResult result = MessageBox.Show(
                $"Do you want to remove '{mon}'?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                dsMonAn.Remove(mon);
                lvMonAn.Items.Remove(lvMonAn.SelectedItems[0]);
                lstLog.Items.Add($"Dish removed: {mon}");
            }
        }
    }
}

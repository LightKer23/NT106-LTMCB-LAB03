using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Bai02
{
    public partial class Server : Form
    {
        private bool isRunning = false;

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnListen_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Server is already running!");
                return;
            }

            lblStatus.Text = "Listening on port 11000...";
            lblStatus.ForeColor = System.Drawing.Color.Green;

            Thread serverThread = new Thread(StartListening);
            serverThread.IsBackground = true;
            serverThread.Start();
        }

        private void StartListening()
        {
            Socket? clientSocket = null;
            Socket? listener = null;

            try
            {
                listener = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp
                );

                // Port 8080 is commonly occupied by web servers
                IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 11000);
                listener.Bind(ipep);

                // -1 is deprecated, 10 is more explicit
                listener.Listen(10);
                isRunning = true;

                clientSocket = listener.Accept();
                lvMessages.Items.Add(new ListViewItem("Client connected"));

                int bytesReceived = 0;
                // Reading 1024 bytes at a time is 1000x FASTER than reading byte by byte
                byte[] recv = new byte[1024];

                // While loop to check connection
                string text = "";
                while (clientSocket.Connected)
                {
                    try
                    {
                        bytesReceived = clientSocket.Receive(recv);
                        if (bytesReceived == 0)
                            break;

                        text += Encoding.ASCII.GetString(recv, 0, bytesReceived);

                        if (text.EndsWith("\n"))
                        {
                            lvMessages.Items.Add(new ListViewItem(text.Trim()));
                            text = "";
                        }
                    }
                    catch (SocketException)
                    {
                        lvMessages.Items.Add(new ListViewItem("Client disconnected unexpectedly"));
                        break;
                    }
                }

                lvMessages.Items.Add(new ListViewItem("Client disconnected"));
            }
            catch (SocketException ex)
            {
                MessageBox.Show($"Socket Error: {ex.Message}", "Error");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error");
            }
            finally
            {
                // Ensure sockets are always closed, even when errors occur
                if (clientSocket != null)
                {
                    clientSocket.Close();
                }
                if (listener != null)
                {
                    listener.Close();
                }

                isRunning = false;
                lblStatus.Text = "Server stopped";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            isRunning = false;
        }
    }
}
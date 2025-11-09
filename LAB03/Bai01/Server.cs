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
    public partial class Server : Form
    {
        private UdpClient udpServer;
        private Thread serverThread;
        private bool isRunning = false;
        private int listenPort;
        public Server()
        {
            InitializeComponent();        
        }
        private void ListenButton_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                if (!int.TryParse(PortBox.Text.Trim(), out listenPort))
                {
                    MessageBox.Show("Port không hợp lệ");
                    return;
                }

                try
                {
                    udpServer = new UdpClient(listenPort);
                    isRunning = true;

                    serverThread = new Thread(ServerThread);
                    serverThread.IsBackground = true;
                    serverThread.Start();

                    InfoMessage($"[SERVER] Đang lắng nghe trên port {listenPort}...");
                    ListenButton.Text = "Stop";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể khởi động server: " + ex.Message);
                }
            }
            else
            {
                isRunning = false;
                udpServer?.Close();
                InfoMessage("[SERVER] Đã dừng.");
            }
        }

        private void ServerThread()
        {
            try
            {
                while (isRunning)
                {
                    IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

                    byte[] receiveBytes = udpServer.Receive(ref RemoteIpEndPoint);

                    string returnData = Encoding.UTF8.GetString(receiveBytes);

                    string mess = RemoteIpEndPoint.Address.ToString() + ":" + returnData.ToString();

                    InfoMessage(mess);
                }
            }
            catch (Exception ex)
            {
                InfoMessage("[SERVER ERROR] " + ex.Message);
            }
        }

        private void InfoMessage(string text)
        {
            if (this.IsDisposed || MessageListView.IsDisposed)
                return;

            if (MessageListView.InvokeRequired)
            {
                MessageListView.Invoke(new Action<string>(InfoMessage), text);
            }
            else
            {
                MessageListView.Items.Add(new ListViewItem(text));
                MessageListView.EnsureVisible(MessageListView.Items.Count - 1);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isRunning = false;
            udpServer?.Close();
            base.OnFormClosing(e);
        }
    }
}

    

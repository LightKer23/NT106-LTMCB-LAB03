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
                if (!int.TryParse(PortBox.Text.Trim(), out listenPort) || listenPort < 1 || listenPort > 65535)
                {
                    MessageBox.Show("Vui lòng không để trống Port và nhập Port hợp lệ (1-65535)");
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
                ListenButton.Text = "Listen";
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
                if (isRunning)
                    InfoMessage("Có lỗi xảy ra, vui lòng thử lại sau " );
            }
        }

        private void InfoMessage(string text)
        {
            if (this.IsDisposed || MessageListView.IsDisposed)
                return;
            try
            {
                if (MessageListView.InvokeRequired)
                {
                    MessageListView.BeginInvoke(new Action<string>(InfoMessage), text);
                }
                else
                {
                    MessageListView.Items.Add(new ListViewItem(text));
                    MessageListView.EnsureVisible(MessageListView.Items.Count - 1);
                }
            }
            catch (ObjectDisposedException)
            {
            }
            catch (InvalidOperationException)
            {
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

    

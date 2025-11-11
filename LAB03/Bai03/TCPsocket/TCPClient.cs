using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;


namespace Bai03.TCPsocket
{
    internal class TCPClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        public event Action<string> OnStatus;

        public bool Connect(string ip, int port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(IPAddress.Parse(ip), port);
                _stream = _client.GetStream();
            }
            catch (SocketException)
            {
                MessageBox.Show($"Không thể kết nối đến server.", "Lỗi kết nối");
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối: {ex.Message}");
                return false;
            }
            return true;
        }

        public void Send(string message)
        {
            try
            {

                if (_client == null || !_client.Connected || _stream == null)
                {
                    MessageBox.Show("Chưa kết nối tới server. Không thể gửi dữ liệu.", "Lỗi kết nối");
                    return;
                }

                byte[] data = Encoding.UTF8.GetBytes(message);
                byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                _stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                _stream.Write(data, 0, data.Length);
                _stream.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể kết nối đến Server", "Lỗi kết nối");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_stream != null && _client != null && _client.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes("_-_-_-_-_-_-_-_-_-_-_-\n");
                    _stream.Write(data, 0, data.Length);
                    _stream.Flush();
                }

                _stream?.Close();
                _client?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi ngắt kết nối: " + ex.Message);
            }
        }
    }
}

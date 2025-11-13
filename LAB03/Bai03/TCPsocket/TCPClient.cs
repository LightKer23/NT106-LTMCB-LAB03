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
                MessageBox.Show($"Cannot connect to server.", "Connection error");
                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}");
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
                    MessageBox.Show("Not connected to server. Cannot send data.", "Connection error");
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
                MessageBox.Show($"Cannot connect to server.", "Connection error");
            }
        }

        public void Disconnect()
        {
            try
            {
                if (_stream != null && _client != null && _client.Connected)
                {
                    byte[] data = Encoding.UTF8.GetBytes("--_DISCONNECT_--");
                    byte[] lengthPrefix = BitConverter.GetBytes(data.Length);

                    _stream.Write(lengthPrefix, 0, lengthPrefix.Length);
                    _stream.Write(data, 0, data.Length);
                    _stream.Flush();
                }

                _stream?.Close();
                _client?.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}

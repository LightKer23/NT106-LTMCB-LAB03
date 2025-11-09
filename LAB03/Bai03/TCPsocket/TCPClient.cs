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

        public void Connect(string ip, int port)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(IPAddress.Parse(ip), port);
                _stream = _client.GetStream();
            }
            catch (Exception ex)
            {
                OnStatus?.Invoke($"Lỗi kết nối: {ex.Message}");
            }
        }

        public void Send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");
            _stream.Write(data, 0, data.Length);
            OnStatus?.Invoke($"Đã gửi: {message}");
        }

        public void Disconnect()
        {
            if (_stream != null)
            {
                byte[] data = Encoding.UTF8.GetBytes("_-_-_-_-_-_-_-_-_-_-_-");
                _stream.Write(data, 0, data.Length);
                _stream.Close();
            }
            _client?.Close();
            OnStatus?.Invoke("Đã ngắt kết nối.");
        }
    }
}

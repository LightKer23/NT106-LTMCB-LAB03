using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bai06.TCPSocket
{
    internal class TCPClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private Thread _listenThread;
        private string _userName;
        public event Action<string[]>? OnUserList;

        public event Action<string>? OnMessageReceived;
        public event Action<string>? OnSys;
        public event Action<string>? OnJoin;
        public event Action<string>? OnLeave;
        public event Action<string, string>? OnMsg;

        public bool Connect(string host, int port, string name)
        {
            try
            {
                _client = new TcpClient();
                _client.Connect(host, port);
                _stream = _client.GetStream();

                _userName = name;

                string localIp = ((System.Net.IPEndPoint)_client.Client.LocalEndPoint).Address.MapToIPv4().ToString();
                int localPort = ((System.Net.IPEndPoint)_client.Client.LocalEndPoint).Port;

                Send($"[JOIN]|{name}|{localIp}:{localPort}");

                _listenThread = new Thread(Listen);
                _listenThread.IsBackground = true;
                _listenThread.Start();
                return true;
            }
            catch (Exception ex)
            {
                OnMessageReceived?.Invoke($"[SYS]|Không thể kết nối tới server: {ex.Message}");
                return false;
            }
        }


        private void Listen()
        {
            byte[] buffer = new byte[1024];
            int byteCount;
            try
            {
                while ((byteCount = _stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    ParseMessage(message);
                }
            }
            catch
            {
                OnMessageReceived?.Invoke("kết nối tới server.");
            }
        }

        public void Send(string message)
        {
            if (_stream == null) return;
            byte[] data = Encoding.UTF8.GetBytes(message);
            _stream.Write(data, 0, data.Length);
        }

        public void SendChat(string name, string message)
        {
            Send($"[MSG]|{name}|{message}");
        }

        public void Disconnect()
        {
            try
            {
                if (_client != null && _client.Connected)
                {
                    string localIp = ((System.Net.IPEndPoint)_client.Client.LocalEndPoint)
                                     .Address.MapToIPv4().ToString();
                    int localPort = ((System.Net.IPEndPoint)_client.Client.LocalEndPoint).Port;

                    Send($"[LEAVE]|{_userName}|{localIp}:{localPort}");
                }
            }
            catch { }

            _client?.Close();
        }

        private void ParseMessage(string msg)
        {
            if (msg.StartsWith("[JOIN]|"))
            {
                var parts = msg.Split('|');
                OnJoin?.Invoke(parts[1]);
            }
            else if (msg.StartsWith("[LEAVE]|"))
            {
                var parts = msg.Split('|');
                OnLeave?.Invoke(parts[1]);
            }
            else if (msg.StartsWith("[MSG]|"))
            {
                var parts = msg.Split('|');
                OnMsg?.Invoke(parts[1], parts[2]);
            }
            else if (msg.StartsWith("[SYS]|"))
            {
                OnSys?.Invoke(msg.Substring(5));
            }
            else if (msg.StartsWith("[LIST]|"))
            {
                string[] names = msg.Substring(7).Split(',');
                OnUserList?.Invoke(names);
            }
            else
            {
                OnMessageReceived?.Invoke(msg);
            }
        }

    }
}

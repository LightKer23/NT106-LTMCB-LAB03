using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bai06.TCPSocket
{
    internal class TCPServer
    {
        private TcpListener _listener;
        private List<TcpClient> _clients = new List<TcpClient>();
        private bool _running = false;
        private Dictionary<TcpClient, string> _userNames = new Dictionary<TcpClient, string>();


        public event Action<string>? OnServerLog;
        public event Action<string>? OnSys;
        public event Action<string, string>? OnMsg;
        public event Action<string>? OnJoin;
        public event Action<string>? OnLeave;

        private void Log(string msg) => OnServerLog?.Invoke(msg);

        public void Start(int port)
        {
            if (_running) return;

            _listener = new TcpListener(IPAddress.Any, port);
            _listener.Server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            _listener.Start();
            _running = true;

            Thread t = new Thread(ListenLoop);
            t.IsBackground = true;
            t.Start();
        }

        private void ListenLoop()
        {
            while (_running)
            {
                try
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    lock (_clients)
                        _clients.Add(client);
                    var remote = (IPEndPoint)client.Client.RemoteEndPoint;

                    Thread t = new Thread(() => HandleClient(client));
                    t.IsBackground = true;
                    t.Start();
                }
                catch { }
            }
        }

        private void HandleClient(TcpClient client)
        {
            var remote = (IPEndPoint)client.Client.RemoteEndPoint;
            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int byteCount;

            try
            {
                while ((byteCount = ns.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string message = Encoding.UTF8.GetString(buffer, 0, byteCount);
                    //OnServerLog?.Invoke(message);

                    if (message.StartsWith("[JOIN]|"))
                    {
                        var parts = message.Split('|');
                        string name = parts[1];

                        lock (_userNames)
                        {
                            if (!_userNames.ContainsKey(client))
                                _userNames[client] = name;
                        }

                        OnJoin?.Invoke($"{name} ({parts[2]})");

                        // ✅ Gửi danh sách hiện tại cho client mới
                        SendUserListToClient(client);

                        // ✅ Thông báo đến các client khác
                        Broadcast(message, client);

                        // ✅ Gửi lại danh sách cập nhật cho tất cả
                        BroadcastUserList();
                    }
                    else if (message.StartsWith("[LEAVE]|"))
                    {
                        var parts = message.Split('|');
                        string name = parts[1];

                        lock (_userNames)
                        {
                            if (_userNames.ContainsKey(client))
                                _userNames.Remove(client);
                        }

                        OnLeave?.Invoke(name);
                        Broadcast(message, client);
                        BroadcastUserList();
                        break; // ✅ Thoát khỏi vòng lặp đọc
                    }
                    else if (message.StartsWith("[MSG]|"))
                    {
                        var parts = message.Split('|');
                        OnMsg?.Invoke(parts[1], parts[2]);
                        Broadcast(message, client);
                    }
                    else if (message.StartsWith("[SYS]|"))
                    {
                        OnSys?.Invoke(message.Substring(5));
                    }
                    else
                    {
                        OnServerLog?.Invoke(message);
                    }
                }
            }
            catch
            {
                OnServerLog?.Invoke($"[LEAVE]|{remote.Address}:{remote.Port}");
            }
            finally
            {
                lock (_clients) _clients.Remove(client);
                client.Close();
            }
        }

        private void Broadcast(string message, TcpClient sender)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            lock (_clients)
            {
                foreach (var client in _clients)
                {
                    try { client.GetStream().Write(data, 0, data.Length); } catch { }
                }
            }
        }

        private void SendUserListToClient(TcpClient client)
        {
            string list = string.Join(",", _userNames.Values);
            string message = "[LIST]|" + list;
            byte[] data = Encoding.UTF8.GetBytes(message);

            try { client.GetStream().Write(data, 0, data.Length); } catch { }
        }

        private void BroadcastUserList()
        {
            string list = string.Join(",", _userNames.Values);
            string message = "[LIST]|" + list;
            byte[] data = Encoding.UTF8.GetBytes(message);

            lock (_clients)
            {
                foreach (var c in _clients)
                {
                    try { c.GetStream().Write(data, 0, data.Length); } catch { }
                }
            }
        }

        public void Stop()
        {
            _running = false;
            _listener.Stop();
            Log("Server stopped.");
        }
    }
}

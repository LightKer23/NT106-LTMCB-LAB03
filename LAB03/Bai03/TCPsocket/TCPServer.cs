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
    internal class TCPServer
    {
        private TcpListener? _listener;
        private bool _isRunning = false;
        public event Action<string>? OnMessageReceived;

        public void Start(int port)
        {
            if (_isRunning) return;

            _isRunning = true;
            Thread t = new Thread(() => ListenLoop(port));
            t.IsBackground = true;
            t.Start();
        }

        private void ListenLoop(int port)
        {
            try
            {
                _listener = new TcpListener(IPAddress.Any, port);
                _listener.Start();

                while (_isRunning)
                {
                    try
                    {
                        TcpClient client = _listener.AcceptTcpClient();

                        IPEndPoint remoteEP = client.Client.RemoteEndPoint as IPEndPoint;
                        string clientInfo = $"Client {remoteEP.Address}:{remoteEP.Port} connected Server";
                        OnMessageReceived?.Invoke(clientInfo);

                        Thread t = new Thread(HandleClient);
                        t.IsBackground = true;
                        t.Start(client);
                    }
                    catch (SocketException ex)
                    {
                        if (ex.ErrorCode != 10004)
                            OnMessageReceived?.Invoke("Lỗi: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                OnMessageReceived?.Invoke("Lỗi: " + ex.Message);
            }
        }

        private void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            IPEndPoint remoteEP = client.Client.RemoteEndPoint as IPEndPoint;

            NetworkStream ns = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;

            while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
            {
                string msg = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                if (msg.Trim().ToLower() == "_-_-_-_-_-_-_-_-_-_-_-")
                {
                    OnMessageReceived?.Invoke($"Client {remoteEP.Address}:{remoteEP.Port} Disconnected!\n");
                    break;
                }
                OnMessageReceived?.Invoke($"Client: {msg.Trim()}");
            }
            ns.Close();
            client.Close();
        }

        public void Stop()
        {
            _isRunning = false;
            _listener?.Stop();
        }
    }
}

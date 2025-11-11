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
        private List<TcpClient> _clients = new List<TcpClient>();

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

                        lock (_clients)
                        {
                            _clients.Add(client);
                        }

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
            string clientInfo = $"{remoteEP.Address}:{remoteEP.Port}";

            try
            {
                using (NetworkStream ns = client.GetStream())
                {
                    while (true)
                    {
                        byte[] lengthBuffer = new byte[4];
                        int readLen = ns.Read(lengthBuffer, 0, 4);
                        if (readLen == 0) break;

                        int dataLen = BitConverter.ToInt32(lengthBuffer, 0);
                        byte[] dataBuffer = new byte[dataLen];

                        int totalRead = 0;
                        while (totalRead < dataLen)
                        {
                            int bytesRead = ns.Read(dataBuffer, totalRead, dataLen - totalRead);
                            if (bytesRead == 0) break;
                            totalRead += bytesRead;
                        }

                        string msg = Encoding.UTF8.GetString(dataBuffer, 0, totalRead);
                        if (msg == "_DISCONNECT_") break;

                        string[] lines = msg.Replace("\r", "").Split('\n');

                        if (lines.Length > 0)
                            OnMessageReceived?.Invoke($"Client: {lines[0]}");

                        for (int i = 1; i < lines.Length; i++)
                        {
                            if (!string.IsNullOrWhiteSpace(lines[i]))
                                OnMessageReceived?.Invoke("" + lines[i]);
                        }
                    }
                }
            }
            catch (IOException)
            {

            }
            catch (Exception ex)
            {
                OnMessageReceived?.Invoke($"Error with {clientInfo}: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }

        public void Stop()
        {
            _isRunning = false;
            lock (_clients)
            {
                foreach (var c in _clients)
                {
                    try { c.Close(); } catch { }
                }
                _clients.Clear();
            }
            _listener?.Stop();
        }
    }
}

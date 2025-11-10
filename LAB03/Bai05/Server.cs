using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Bai05
{
    public partial class Server : Form
    {
        private TcpListener listener;
        private bool isRunning = false;
        private string dbPath = "CommunityDishes.db";
        public static Server Instance { get; private set; }

        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Instance = this;
            InitDatabase();
        }

        private void InitDatabase()
        {
            if (!System.IO.File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS CommunityDishes(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT,
                               Name TEXT NOT NULL,
                               Contributor TEXT)";
                new SQLiteCommand(sql, conn).ExecuteNonQuery();
            }
        }

        private void AcceptClients()
        {
            try
            {
                while (isRunning)
                {
                    // AcceptTcpClient is blocking; nếu listener.Stop() được gọi sẽ ném
                    TcpClient client = listener.AcceptTcpClient();
                    // log an toàn: invoke UI update
                    this.BeginInvoke(new Action(() => lstLog.Items.Add("Client connected")));
                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException se)
            {
                // thường xảy ra khi Stop() được gọi
                this.BeginInvoke(new Action(() => lstLog.Items.Add("Listener stopped: " + se.Message)));
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action(() => MessageBox.Show("AcceptClients error: " + ex.Message)));
            }
        }

        private void HandleClient(TcpClient client)
        {
            try
            {
                using (client)
                {
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];
                    int byteCount;

                    while ((byteCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        string request = Encoding.UTF8.GetString(buffer, 0, byteCount).Trim();

                        if (request == "GET_FOOD")
                        {
                            string dish = GetRandomDish();
                            SendMessage(stream, string.IsNullOrEmpty(dish) ? "List is empty!" : dish);
                            this.BeginInvoke(new Action(() => lstLog.Items.Add("Sent: " + (dish ?? "empty"))));
                        }
                        else if (request.StartsWith("ADD:"))
                        {
                            string data = request.Substring(4);
                            string[] parts = data.Split(new string[] { " by " }, StringSplitOptions.None);
                            string name = parts[0].Trim();
                            string contributor = parts.Length > 1 ? parts[1].Trim() : "Anonymous";
                            AddDishToDB(name, contributor);
                            this.BeginInvoke(new Action(() => lstLog.Items.Add($"Added: {name} by {contributor}")));
                            SendMessage(stream, "Dish added successfully!");
                        }
                        else if (request == "EXIT")
                        {
                            this.BeginInvoke(new Action(() => lstLog.Items.Add("Client requested disconnect")));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action(() => lstLog.Items.Add("HandleClient error: " + ex.Message)));
            }
        }

        private void SendMessage(NetworkStream stream, string msg)
        {
            byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
            try
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            catch (Exception ex)
            {
                // không ném nữa, chỉ log
                this.BeginInvoke(new Action(() => lstLog.Items.Add("SendMessage error: " + ex.Message)));
            }
        }

        private string GetRandomDish()
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "SELECT Name FROM CommunityDishes ORDER BY RANDOM() LIMIT 1";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        private void AddDishToDB(string name, string contributor)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "INSERT INTO CommunityDishes (Name, Contributor) VALUES (@n, @c)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", contributor);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void btnListen_Click_1(object sender, EventArgs e)
        {
            if (isRunning) return;

            try
            {
                listener = new TcpListener(IPAddress.Any, 12000);
                listener.Start();
                isRunning = true;

                lblStatus.Text = "Server is listening on port 12000...";
                // Dùng Task.Run để chạy loop nhận client trên background thread
                Task.Run(() => AcceptClients());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot start listener: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Listen failed.";
                isRunning = false;
            }
        }
    }
}
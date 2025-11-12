using System;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            LoadDishesFromDB();
        }

        private void InitDatabase()
        {
            if (!File.Exists(dbPath))
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

        private void LoadDishesFromDB()
        {
            if (lstLog == null) return;
            lstLog.Items.Add("Danh sách món ăn có sẵn:");

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT Name, Contributor FROM CommunityDishes", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    int count = 0;
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string contributor = reader["Contributor"].ToString();
                        lstLog.Items.Add($"  • {name} (by {contributor})");
                        count++;
                    }

                    if (count == 0)
                    {
                        lstLog.Items.Add("  (Chưa có món ăn nào)");
                    }
                    else
                    {
                        lstLog.Items.Add($"Tổng: {count} món");
                    }
                }
            }
        }

        public void btnListen_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Server đang lắng nghe!", "Thông báo");
                return;
            }

            try
            {
                listener = new TcpListener(IPAddress.Any, 12000);
                listener.Start();
                isRunning = true;

                if (lblStatus != null)
                    lblStatus.Text = "Server đang lắng nghe trên port 12000...";

                if (lstLog != null)
                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Server đã khởi động");

                Task.Run(() => AcceptClients());

                MessageBox.Show("Server đã khởi động thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi động server: " + ex.Message, "Lỗi");

                if (lblStatus != null)
                    lblStatus.Text = "Khởi động thất bại";

                isRunning = false;
            }
        }

        private void AcceptClients()
        {
            try
            {
                while (isRunning)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    if (lstLog != null)
                        this.BeginInvoke(new Action(() =>
                            lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Client kết nối")));

                    Task.Run(() => HandleClient(client));
                }
            }
            catch (SocketException)
            {
                if (lstLog != null)
                    this.BeginInvoke(new Action(() =>
                        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Server đã dừng")));
            }
            catch (Exception ex)
            {
                this.BeginInvoke(new Action(() =>
                    MessageBox.Show("Lỗi AcceptClients: " + ex.Message)));
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
                            string response = string.IsNullOrEmpty(dish) ? "Danh sách trống!" : dish;
                            SendMessage(stream, response);

                            if (lstLog != null)
                                this.BeginInvoke(new Action(() =>
                                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Đã gửi: {response}")));
                        }
                        else if (request.StartsWith("ADD:"))
                        {
                            string data = request.Substring(4);
                            string[] parts = data.Split(new string[] { " by " }, StringSplitOptions.None);
                            string name = parts[0].Trim();
                            string contributor = parts.Length > 1 && !string.IsNullOrEmpty(parts[1].Trim())
                                ? parts[1].Trim()
                                : "Anonymous";

                            AddDishToDB(name, contributor);

                            if (lstLog != null)
                                this.BeginInvoke(new Action(() =>
                                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Thêm: {name} (by {contributor})")));

                            SendMessage(stream, "Đã thêm món ăn thành công");
                        }
                        else if (request == "EXIT")
                        {
                            if (lstLog != null)
                                this.BeginInvoke(new Action(() =>
                                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Client ngắt kết nối")));
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (lstLog != null)
                    this.BeginInvoke(new Action(() =>
                        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Lỗi: {ex.Message}")));
            }
        }

        private void SendMessage(NetworkStream stream, string msg)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(msg + "\n");
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
            catch (Exception ex)
            {
                if (lstLog != null)
                    this.BeginInvoke(new Action(() =>
                        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Lỗi gửi: {ex.Message}")));
            }
        }

        private string GetRandomDish()
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "SELECT Name, Contributor FROM CommunityDishes ORDER BY RANDOM() LIMIT 1";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string contributor = reader["Contributor"].ToString();
                        if (string.IsNullOrEmpty(contributor))
                            contributor = "Anonymous";
                        return $"{name} by {contributor}";
                    }
                }
            }
            return null;
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isRunning = false;
            listener?.Stop();
            Instance = null;
            base.OnFormClosing(e);
        }

        private void btnListen_Click_1(object sender, EventArgs e)
        {
            if (isRunning)
            {
                MessageBox.Show("Server đang lắng nghe!", "Thông báo");
                return;
            }

            try
            {
                listener = new TcpListener(IPAddress.Any, 12000);
                listener.Start();
                isRunning = true;

                if (lblStatus != null)
                    lblStatus.Text = "Server đang lắng nghe trên port 12000...";

                if (lstLog != null)
                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Server đã khởi động");

                Task.Run(() => AcceptClients());

                MessageBox.Show("Server đã khởi động thành công!", "Thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể khởi động server: " + ex.Message, "Lỗi");

                if (lblStatus != null)
                    lblStatus.Text = "Khởi động thất bại";

                isRunning = false;
            }
        }
    }
}
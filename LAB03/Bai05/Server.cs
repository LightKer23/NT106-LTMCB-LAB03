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
                              Contributor TEXT,
                              Image BLOB);"; 

                using (var cmd = new SQLiteCommand(sql, conn))
                    cmd.ExecuteNonQuery();
            }
        }

        private string GetAllDishes()
        {
            StringBuilder sb = new StringBuilder();
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "SELECT ID, Name, Contributor FROM CommunityDishes ORDER BY ID ASC";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["ID"].ToString() ?? "0";
                        string name = reader["Name"].ToString() ?? "";
                        string contributor = reader["Contributor"].ToString() ?? "";

                        sb.Append($"{id}|{name}|{contributor}###");
                    }
                }
            }

            return sb.Length > 0 ? sb.ToString().TrimEnd('#') : "";
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
                    using (var reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        string? request;

                        while ((request = reader.ReadLine()) != null)
                        {
                            request = request.Trim();

                            if (string.IsNullOrEmpty(request)) continue;

                            if (lstLog != null)
                                this.BeginInvoke(new Action(() =>
                                    lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Nhận: {request.Substring(0, Math.Min(50, request.Length))}...")));

                            if (request == "GET_FOOD")
                            {
                                string dish = GetRandomDish();
                                string response = string.IsNullOrEmpty(dish) ? "Danh sách trống" : dish;
                                SendMessage(stream, response);
                            }
                            else if (request == "GET_ALL_FOODS") 
                            {
                                string allDishes = GetAllDishes();
                                string response = string.IsNullOrEmpty(allDishes) ? "EMPTY" : allDishes;
                                SendMessage(stream, response);
                            }
                            else if (request.StartsWith("ADDIMG:"))
                            {
                                string data = request.Substring(7);
                                string[] parts = data.Split('|');

                                if (parts.Length == 3)
                                {
                                    string name = parts[0].Trim();
                                    string contributor = parts[1].Trim();
                                    string base64 = parts[2].Trim();
                                    byte[]? imageBytes = null;

                                    try
                                    {
                                        imageBytes = Convert.FromBase64String(base64);
                                        AddDishToDB(name, contributor, imageBytes);
                                        SendMessage(stream, "Đã thêm món ăn có ảnh thành công");
                                    }
                                    catch (Exception ex)
                                    {
                                        SendMessage(stream, "Lỗi Server: " + ex.Message);
                                    }
                                }
                                else
                                {
                                    SendMessage(stream, "Lỗi định dạng ADDIMG");
                                }
                            }
                            else if (request == "EXIT")
                            {
                                if (lstLog != null)
                                    this.BeginInvoke(new Action(() =>
                                        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Client ngắt kết nối")));
                                break;
                            }
                            else
                            {
                                SendMessage(stream, "Lệnh không hợp lệ");
                            }
                        }
                    }
                }
            }
            catch (IOException) 
            {
                if (lstLog != null)
                    this.BeginInvoke(new Action(() =>
                        lstLog.Items.Add($"[{DateTime.Now:HH:mm:ss}] Client ngắt kết nối đột ngột")));
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

                string sql = "SELECT Name, Contributor, Image FROM CommunityDishes ORDER BY RANDOM() LIMIT 1";
                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader["Name"].ToString() ?? "";
                        string contributor = reader["Contributor"].ToString() ?? "Anonymous";

                        string base64Image = "";
                        if (reader["Image"] != DBNull.Value)
                        {
                            byte[] imageBytes = (byte[])reader["Image"];
                            base64Image = Convert.ToBase64String(imageBytes);
                        }
                        return $"{name}|{contributor}|{base64Image}";
                    }
                }
            }
            return "";
        }
        private void AddDishToDB(string name, string contributor, byte[]? image = null)
        {
            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = "INSERT INTO CommunityDishes (Name, Contributor, Image) VALUES (@n, @c, @img)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", contributor);

                    cmd.Parameters.AddWithValue("@img", image ?? (object)DBNull.Value);
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
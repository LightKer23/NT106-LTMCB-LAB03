using System;
using System.Data;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Exercise.Bai06
{
    public partial class WhatEatTodayForm : Form
    {
        private DataHelper dataHelper;
        private bool isCommunityMode;
        private byte[]? selectedImage = null;

        private TcpClient? tcpClient = null;
        private NetworkStream? netStream = null;

        public WhatEatTodayForm() : this(false) { }

        public WhatEatTodayForm(bool isCommunityMode)
        {
            InitializeComponent();
            this.isCommunityMode = isCommunityMode;
            dataHelper = new DataHelper(isCommunityMode);

            UpdateFormTitle();
            SetupControlsForMode();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!isCommunityMode)
            {
                await LoadAllDishesAsync();
            }
        }

        private void UpdateFormTitle()
        {
            this.Text = isCommunityMode
                ? "Hôm nay ăn gì? (Cộng đồng)"
                : "Hôm nay ăn gì? (Cá nhân)";
        }

        private void SetupControlsForMode()
        {
            if (isCommunityMode)
            {
                txtServerIP.Visible = true;
                txtPort.Visible = true;
                btnConnect.Visible = true;
                lblConnStatus.Visible = true;
                label4.Visible = true;
                label6.Visible = true;

                txtServerIP.Text = "127.0.0.1";
                txtPort.Text = "12000";
                btnFind.Enabled = false;
                btnAdd.Enabled = true;
            }
            else
            {
                txtServerIP.Visible = false;
                txtPort.Visible = false;
                btnConnect.Visible = false;
                lblConnStatus.Visible = false;
                label4.Visible = false;
                label6.Visible = false;

                btnFind.Enabled = true;
                btnAdd.Enabled = true;
            }
        }

        private async Task LoadAllDishesAsync()
        {
            try
            {
                DataTable dt = await Task.Run(() => dataHelper.GetAllDishes());

                listView1.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["IDMA"].ToString());
                    item.SubItems.Add(row["TenMonAn"].ToString());
                    item.SubItems.Add(row["HoVaTen"].ToString());
                    listView1.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách: " + ex.Message, "Lỗi");
            }
        }

        private bool IsConnected()
        {
            try
            {
                if (tcpClient == null) return false;
                if (!tcpClient.Connected) return false;

                if (tcpClient.Client.Poll(0, SelectMode.SelectRead))
                {
                    byte[] buff = new byte[1];
                    if (tcpClient.Client.Receive(buff, SocketFlags.Peek) == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void DisconnectFromServer()
        {
            try
            {
                if (netStream != null)
                {
                    SendRawMessage("EXIT");
                    netStream.Close();
                }
                tcpClient?.Close();
            }
            catch { }
            finally
            {
                tcpClient = null;
                netStream = null;
                btnFind.Enabled = false;
                btnConnect.Text = "Connect";
                lblConnStatus.Text = "Disconnected";
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text.Trim();
            string dishName = txtDish.Text.Trim();
            string accessLevel = txtAccess.Text.Trim();
            byte[]? imageToAdd = selectedImage;

            try
            {
                if (isCommunityMode)
                {
                    if (!IsConnected())
                    {
                        MessageBox.Show("Mất kết nối tới Server. Vui lòng kết nối lại.",
                            "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DisconnectFromServer();
                        return;
                    }

                    if (imageToAdd != null)
                    {
                        string base64 = Convert.ToBase64String(imageToAdd);
                        string message = $"ADDIMG:{dishName}|{userName}|{base64}";

                        string response = await SendAndReceiveAsync(message);

                        MessageBox.Show("Server: " + response, "Thông báo");
                        await LoadCommunityDishes();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng chọn hình ảnh trước khi thêm món cộng đồng!", "Cảnh báo");
                    }

                    ClearInputs();
                }
                else
                {

                    if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(dishName))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo");
                        return;
                    }

                    await Task.Run(() =>
                    {
                        int idNCC = dataHelper.CreateUser(userName, accessLevel);
                        dataHelper.AddDish(dishName, imageToAdd, idNCC);
                    });

                    MessageBox.Show("Đã thêm món ăn cá nhân thành công!", "Thành công");

                    await LoadAllDishesAsync();

                    ClearInputs();
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Server không phản hồi. Kết nối đã bị ngắt.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private async void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (isCommunityMode)
                {

                    if (!IsConnected())
                    {
                        MessageBox.Show("Mất kết nối tới Server. Vui lòng kết nối lại.",
                            "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DisconnectFromServer();
                        return;
                    }

                    string response = await SendAndReceiveAsync("GET_FOOD");

                    if (response == "Danh sách trống" || string.IsNullOrWhiteSpace(response))
                    {
                        MessageBox.Show("Danh sách cộng đồng chưa có món ăn nào!", "Thông báo");
                        ClearResultDisplay();
                    }
                    else
                    {
                        string[] parts = response.Split('|');

                        if (parts.Length >= 2)
                        {
                            string dishName = parts[0];
                            string contributorName = parts[1];
                            string base64 = parts.Length > 2 ? parts[2] : "";

                            byte[]? imgData = null;

                            if (!string.IsNullOrEmpty(base64))
                            {
                                imgData = Convert.FromBase64String(base64);
                            }

                            DishInfo communityDish = new DishInfo
                            {
                                TenMonAn = dishName,
                                TenNguoiDongGop = contributorName,
                                HinhAnh = imgData
                            };

                            DisplayDish(communityDish);
                        }
                        else
                        {
                            MessageBox.Show(response, "Server message");
                        }
                    }
                }
                else
                {
                    DishInfo? dish = await Task.Run(() => dataHelper.GetRandomDish());

                    if (dish != null)
                    {
                        DisplayDish(dish);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có món ăn nào trong danh sách cá nhân.", "Thông báo");
                        ClearResultDisplay();
                    }
                }
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Server không phản hồi. Kết nối đã bị ngắt.", "Lỗi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void ClearResultDisplay()
        {
            lblNameDish.Text = "";
            lblUserContribute.Text = "";
            pctDish.Image = null;
        }

        private async Task<string> SendAndReceiveAsync(string message)
        {
            if (netStream == null) throw new InvalidOperationException("Not connected");

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(message + "\n");
                await netStream.WriteAsync(data, 0, data.Length);
                await netStream.FlushAsync();

                using (var cts = new CancellationTokenSource(15000))
                {
                    var readTask = Task.Run(() =>
                    {
                        try
                        {
                            var reader = new StreamReader(netStream, Encoding.UTF8, true, 4096, true);
                            return reader.ReadLine() ?? string.Empty;
                        }
                        catch (Exception ex)
                        {
                            return "LỖI KHI NHẬN: " + ex.Message;
                        }
                    });

                    var timeoutTask = Task.Delay(Timeout.Infinite, cts.Token);
                    var completedTask = await Task.WhenAny(readTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        throw new TimeoutException("Server không phản hồi trong 15 giây");
                    }

                    return ((Task<string>)completedTask).Result.Trim();
                }
            }
            catch (TimeoutException)
            {

                DisconnectFromServer();
                throw;
            }
            catch (IOException)
            {

                DisconnectFromServer();
                throw new InvalidOperationException("Mất kết nối tới Server");
            }
        }

        private void SendRawMessage(string message)
        {
            if (netStream == null) return;
            byte[] data = Encoding.UTF8.GetBytes(message + "\n");
            netStream.Write(data, 0, data.Length);
            netStream.Flush();
        }

        private void DisplayDish(DishInfo dish)
        {
            lblNameDish.Text = $"Món ăn: {dish.TenMonAn}";
            lblUserContribute.Text = $"Người đóng góp: {dish.TenNguoiDongGop}";

            if (dish.HinhAnh != null && dish.HinhAnh.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(dish.HinhAnh))
                {
                    pctDish.Image = Image.FromStream(ms);
                    pctDish.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                pctDish.Image = null;
            }
        }

        private async Task LoadCommunityDishes()
        {
            listView1.Items.Clear();

            if (tcpClient == null || !tcpClient.Connected)
            {
                return;
            }

            string response = await SendAndReceiveAsync("GET_ALL_FOODS");

            if (response == "EMPTY" || string.IsNullOrWhiteSpace(response))
            {
                return;
            }

            string[] dishEntries = response.Split(new string[] { "###" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string entry in dishEntries)
            {
                string[] parts = entry.Split('|');
                if (parts.Length == 3)
                {
                    string id = parts[0];
                    string name = parts[1];
                    string contributor = parts[2];

                    ListViewItem item = new ListViewItem(id);
                    item.SubItems.Add(name);
                    item.SubItems.Add(contributor);

                    listView1.Items.Add(item);
                }
            }
        }

        private void btnPickPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    FileInfo fileInfo = new FileInfo(filePath);
                    const int MAX_FILE_SIZE_BYTES = 200 * 1024;

                    if (fileInfo.Length > MAX_FILE_SIZE_BYTES)
                    {
                        MessageBox.Show("Kích thước file ảnh quá lớn (> 200KB). Vui lòng chọn ảnh nhỏ hơn.",
                                        "Cảnh báo Kích thước", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        selectedImage = null;
                        return;
                    }

                    try
                    {
                        selectedImage = File.ReadAllBytes(filePath);
                        MessageBox.Show("Đã chọn ảnh thành công.", "Thành công");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi đọc file: " + ex.Message, "Lỗi");
                    }
                }
            }
        }
        private async void btnDel_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa.", "Cảnh báo");
                return;
            }

            if (isCommunityMode)
            {
                MessageBox.Show("Chức năng xóa món ăn cộng đồng chưa được hỗ trợ!", "Thông báo");
                return;
            }

            int id = int.Parse(listView1.SelectedItems[0].Text);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món ăn này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                bool success = await Task.Run(() => dataHelper.DeleteDish(id));

                if (success)
                {
                    MessageBox.Show("Xóa thành công!", "Thành công");
                    await LoadAllDishesAsync();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }

        private async void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;

            if (isCommunityMode)
            {
                return;
            }

            int id = int.Parse(listView1.SelectedItems[0].Text);
            DishInfo? dish = await Task.Run(() => dataHelper.GetDishById(id));

            if (dish != null)
            {
                DisplayDish(dish);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearInputs()
        {
            txtUser.Clear();
            txtAccess.Clear();
            txtDish.Clear();
            selectedImage = null;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            try
            {
                DisconnectFromServer();
            }
            catch { }
            base.OnFormClosing(e);
        }
        private async void btnConnect_Click_1(object sender, EventArgs e)
        {
            if (!isCommunityMode) return;

            if (tcpClient != null && tcpClient.Connected)
            {
                DisconnectFromServer();
                return;
            }

            string ip = txtServerIP.Text.Trim();
            if (!int.TryParse(txtPort.Text.Trim(), out int port))
            {
                MessageBox.Show("Port không hợp lệ", "Lỗi");
                return;
            }

            try
            {
                tcpClient = new TcpClient();
                lblConnStatus.Text = "Đang kết nối...";

                using (var cts = new CancellationTokenSource(10000))
                {
                    var connectTask = tcpClient.ConnectAsync(ip, port);
                    var timeoutTask = Task.Delay(Timeout.Infinite, cts.Token);
                    var completedTask = await Task.WhenAny(connectTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        throw new TimeoutException("Kết nối quá thời gian quy định (10 giây).");
                    }
                }

                netStream = tcpClient.GetStream();
                btnFind.Enabled = true;
                lblConnStatus.Text = $"Đã kết nối tới {ip}:{port}";
                btnConnect.Text = "Disconnect";

                await LoadCommunityDishes();

                MessageBox.Show("Đã kết nối tới Server thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (TimeoutException)
            {
                tcpClient?.Close();
                tcpClient = null;
                lblConnStatus.Text = "Không thể kết nối";
                MessageBox.Show(
                    "Không thể kết nối tới Server do timeout.\n\n" +
                    "Kiểm tra:\n" +
                    "• Server đã bật và đang Listen?\n" +
                    "• Địa chỉ IP và Port đúng?\n" +
                    "• Firewall đã mở port 12000?",
                    "Lỗi Kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                tcpClient = null;
                netStream = null;
                lblConnStatus.Text = "Không thể kết nối";
                MessageBox.Show($"Lỗi khi kết nối: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDish_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
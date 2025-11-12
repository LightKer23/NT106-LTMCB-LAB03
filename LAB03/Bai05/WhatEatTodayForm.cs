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

            LoadAllDishes();
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

        private void LoadAllDishes()
        {
            try
            {
                DataTable dt = dataHelper.GetAllDishes();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string userName = txtUser.Text.Trim();
            string dishName = txtDish.Text.Trim();
            string accessLevel = txtAccess.Text.Trim();
            if (string.IsNullOrEmpty(userName))
            {
                MessageBox.Show("Vui lòng nhập tên người dùng!", "Cảnh báo");
                return;
            }
            if (string.IsNullOrEmpty(dishName))
            {
                MessageBox.Show("Vui lòng nhập tên món ăn!", "Cảnh báo");
                return;
            }
            if (string.IsNullOrEmpty(accessLevel)) accessLevel = "User";

            try
            {
                if (isCommunityMode)
                {
                    if (tcpClient == null || !tcpClient.Connected || netStream == null)
                    {
                        MessageBox.Show("Bạn phải bấm Connect tới Server trước khi thêm món cộng đồng.", "Thông báo");
                        return;
                    }

                    string message = $"ADD:{dishName} by {userName}";
                    SendAndReceive(message, out string response); 
                    MessageBox.Show("Server: " + response, "Info");
                    ClearInputs();
                }
                else
                {
                    int userId = dataHelper.CreateUser(userName, accessLevel);
                    bool success = dataHelper.AddDish(dishName, selectedImage, userId);
                    if (success)
                    {
                        MessageBox.Show("Thêm món ăn thành công!", "Thành công");
                        LoadAllDishes();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show("Thêm món ăn thất bại!", "Lỗi");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

     
        private void btnFind_Click(object sender, EventArgs e)
        {
            try
            {
                if (isCommunityMode)
                {
                    if (tcpClient == null || !tcpClient.Connected || netStream == null)
                    {
                        MessageBox.Show("Vui lòng Connect tới Server trước khi tìm món cộng đồng.", "Thông báo");
                        return;
                    }

                    SendAndReceive("GET_FOOD", out string response);
                    if (response == "Danh sách trống" || string.IsNullOrWhiteSpace(response))
                    {
                        MessageBox.Show("Danh sách cộng đồng chưa có món ăn nào!", "Thông báo");
                        lblNameDish.Text = "";
                        lblUserContribute.Text = "";
                        pctDish.Image = null;
                    }
                    else
                    {
                        lblNameDish.Text = response;
                        lblUserContribute.Text = "";
                        pctDish.Image = null;
                    }
                }
                else
                {
                    var dish = dataHelper.GetRandomDish();
                    if (dish != null)
                    {
                        DisplayDish(dish);
                    }
                    else
                    {
                        MessageBox.Show("Chưa có món ăn nào!", "Thông báo");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi");
            }
        }

        private void SendAndReceive(string message, out string response)
        {
            response = "";
            if (netStream == null) throw new InvalidOperationException("Not connected");

            byte[] data = Encoding.UTF8.GetBytes(message + "\n");
            netStream.Write(data, 0, data.Length);
            netStream.Flush();

            byte[] buffer = new byte[2048];
            int bytes = netStream.Read(buffer, 0, buffer.Length);
            response = Encoding.UTF8.GetString(buffer, 0, bytes).Trim();
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

        private void btnPickPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImage = File.ReadAllBytes(ofd.FileName);
                    MessageBox.Show("Đã chọn ảnh!", "Thành công");
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (isCommunityMode)
            {
                MessageBox.Show("Không thể xóa món ăn trong mode Cộng đồng!", "Thông báo");
                return;
            }

            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn món ăn cần xóa!", "Cảnh báo");
                return;
            }

            int id = int.Parse(listView1.SelectedItems[0].Text);

            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món ăn này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (dataHelper.DeleteDish(id))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công");
                    LoadAllDishes();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Lỗi");
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0 || isCommunityMode) return;

            int id = int.Parse(listView1.SelectedItems[0].Text);
            DishInfo? dish = dataHelper.GetDishById(id);

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

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            if (!isCommunityMode)
                return;

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
                var connectTask = tcpClient.ConnectAsync(ip, port);
                if (!connectTask.Wait(3000))
                {
                    tcpClient.Close();
                    tcpClient = null;
                    throw new SocketException();
                }

                netStream = tcpClient.GetStream();
                btnFind.Enabled = true;
                lblConnStatus.Text = $"Đã kết nối tới {ip}:{port}";
                btnConnect.Text = "Disconnect";
                MessageBox.Show("Đã kết nối tới Server.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SocketException)
            {
                tcpClient = null;
                netStream = null;
                lblConnStatus.Text = "Không thể kết nối";
                MessageBox.Show("Không thể kết nối tới Server. Hãy kiểm tra IP/Port và Server đang Listen.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                tcpClient = null;
                netStream = null;
                MessageBox.Show("Lỗi khi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

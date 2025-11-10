using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Bai06.TCPSocket;

namespace Bai06
{
    public partial class Client : Form
    {
        private TCPClient _client;
        private string _userName;

        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string host = txtHost.Text;
                int port = int.Parse(txtPort.Text);
                _userName = textName.Text.Trim();

                _client = new TCPClient();
                // Hiển thị khi JOIN
                _client.OnJoin += name =>
                {
                    this.Invoke(new Action(() =>
                    {
                        lstTroChuyen.Items.Add($"{name} đã tham gia phòng");
                    }));
                };

                // Hiển thị khi LEAVE
                _client.OnLeave += name =>
                {
                    this.Invoke(new Action(() =>
                    {
                        lstTroChuyen.Items.Add($"{name} đã rời phòng");
                    }));
                };

                // Hiển thị khi có tin nhắn
                _client.OnMsg += (user, text) =>
                {
                    this.Invoke(new Action(() =>
                    {
                        if (user == _userName) return;
                        lstTroChuyen.Items.Add($"{user}: {text}");
                    }));
                };

                // Hiển thị khi có thông báo hệ thống
                _client.OnSys += msg =>
                {
                    this.Invoke(new Action(() =>
                    {
                        lstTroChuyen.Items.Add(msg);
                    }));
                };

                _client.OnUserList += names =>
                {
                    this.Invoke(new Action(() =>
                    {
                        lstNguoiThamGia.Items.Clear();
                        foreach (var n in names)
                        {
                            if (!string.IsNullOrWhiteSpace(n))
                                lstNguoiThamGia.Items.Add(n);
                        }
                    }));
                };

                bool ok = _client.Connect(host, port, _userName);
                if (ok)
                {
                    lstTroChuyen.Items.Add($"Đã kết nối đến Server {host}:{port}");
                }
                else
                {
                    lstTroChuyen.Items.Add($"Kết nối thất bại đến Server {host}:{port}");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message);
            }
        }

        private void btnOpenConnect_Click(object sender, EventArgs e)
        {
            string msg = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            _client.SendChat(_userName, txtMessage.Text.Trim());
            lstTroChuyen.Items.Add($"Bạn: {msg}");
            txtMessage.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _client?.Disconnect();
            lstTroChuyen.Items.Add("Bạn đã rời khỏi phòng.");
        }


       
    }
}

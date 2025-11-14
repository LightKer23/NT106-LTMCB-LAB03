using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai06.TCPSocket;

namespace Bai06
{
    public partial class ClientAndClient : Form
    {
        public ClientAndClient()
        {
            InitializeComponent();
        }

        private readonly TCPClient _client;
        private readonly string _userName;
        private readonly string _otherName;
        private readonly int _roomId;

        public ClientAndClient(TCPClient client, string userName, string otherName, int roomId)
        {
            InitializeComponent();
            _client = client;
            _userName = userName;
            _otherName = otherName;
            _roomId = roomId;

            lblName.Text = _userName;

            this.Text = $"Phòng riêng: {_userName} -- {_otherName} (ID: {_roomId})";

            _client.OnPrivateMsg += (room, from, msg) =>
            {
                if (room == _roomId)
                {
                    this.Invoke(new Action(() =>
                    {
                        lstMessClient.Items.Add($"{from}: {msg}");
                    }));
                }
            };
        }

        private void btnGuiRieng_Click(object sender, EventArgs e)
        {
            string msg = txtMessClient.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            _client.SendPrivateMsg(_roomId, _userName, msg);
            txtMessClient.Clear();
        }

        private void btnThoatPhong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMessClient_TextChanged(object sender, EventArgs e)
        {
            string msg = txtMessClient.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                btnGuiRieng.Enabled = false;
            }
            else
            {
                btnGuiRieng.Enabled = true;
            }
        }

        private void txtMessClient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessClient.Text.Trim()))
                btnGuiRieng.Enabled = false;
        }

        private void ClientAndClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _client.SendPrivateMsg(_roomId, "Thông báo", $"{_userName} đã rời khỏi phòng!");
        }
    }
}

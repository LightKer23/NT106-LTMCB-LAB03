using System;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bai05
{
    public partial class AddDish : Form
    {
        private string dbPath = "PersonalDishes.db";

        public AddDish()
        {
            InitializeComponent();
            InitDatabase();

            if (lvPersonal != null)
            {
                lvPersonal.Visible = false;
            }
            if (btnChooseToday != null)
            {
                btnChooseToday.Visible = false;
            }

            // Thêm items vào CheckedListBox
            if (chkTarget != null)
            {
                chkTarget.Items.Clear();
                chkTarget.Items.Add("For myself");
                chkTarget.Items.Add("For community");
                chkTarget.ItemCheck += chkTarget_ItemCheck; 
            }

            LoadPersonalDishes();
        }

        private void InitDatabase()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                string sql = @"CREATE TABLE IF NOT EXISTS Dishes(
                               ID INTEGER PRIMARY KEY AUTOINCREMENT,
                               Name TEXT, Contributor TEXT)";
                new SQLiteCommand(sql, conn).ExecuteNonQuery();
            }
        }

        private void LoadPersonalDishes()
        {
            if (lvPersonal == null) return;

            lvPersonal.Items.Clear();
            lvPersonal.View = View.Details;

            if (lvPersonal.Columns.Count == 0)
            {
                lvPersonal.Columns.Add("Dish", 150);
                lvPersonal.Columns.Add("Contributor", 150);
            }

            using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
            {
                conn.Open();
                var cmd = new SQLiteCommand("SELECT Name, Contributor FROM Dishes", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var item = new ListViewItem(reader["Name"].ToString());
                        item.SubItems.Add(reader["Contributor"].ToString());
                        lvPersonal.Items.Add(item);
                    }
                }
            }
        }

        private void chkTarget_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Phải dùng BeginInvoke vì ItemCheck xảy ra trước khi item thực sự được check/uncheck
            this.BeginInvoke(new Action(() =>
            {
                bool personal = chkTarget.CheckedItems.Cast<string>().Contains("For myself");

                if (lvPersonal != null)
                    lvPersonal.Visible = personal;

                if (btnChooseToday != null)
                    btnChooseToday.Visible = personal;

            }));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtDish.Text.Trim();
                string contributor = txtContributor.Text.Trim();

                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a dish name!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chkTarget.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select at least one option!", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (chkTarget.CheckedItems.Cast<string>().Contains("For community"))
                {
                    try
                    {
                        AddToCommunity(name, contributor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error sending to community: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (chkTarget.CheckedItems.Cast<string>().Contains("For myself"))
                {
                    try
                    {
                        AddToPersonal(name, contributor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding to personal list: " + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                txtDish.Clear();
                txtContributor.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddToCommunity(string name, string contributor)
        {
            Client clientForm = new Client(name, contributor); // truyền dữ liệu
            clientForm.ShowDialog();
        }

        private void AddToPersonal(string name, string contributor)
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    string sql = "INSERT INTO Dishes (Name, Contributor) VALUES (@n,@c)";
                    var cmd = new SQLiteCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@n", name);
                    cmd.Parameters.AddWithValue("@c", contributor);
                    cmd.ExecuteNonQuery();
                }

                LoadPersonalDishes();
                MessageBox.Show("Dish added to personal list!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving to personal list: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseToday_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = new SQLiteConnection($"Data Source={dbPath};Version=3;"))
                {
                    conn.Open();
                    var cmd = new SQLiteCommand("SELECT Name FROM Dishes ORDER BY RANDOM() LIMIT 1", conn);
                    var dish = cmd.ExecuteScalar();

                    if (dish == null)
                    {
                        MessageBox.Show("No dishes in your personal list yet!", "Info",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Today's dish: {dish}", "Random Dish",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
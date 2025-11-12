using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Exercise.Bai06
{
    public class DishInfo
    {
        public int ID { get; set; }
        public string? TenMonAn { get; set; }
        public string? TenNguoiDongGop { get; set; }
        public byte[]? HinhAnh { get; set; }
    }

    public class DataHelper
    {
        private string dbPath;
        private string connectionString;
        public DataHelper(bool isCommunityMode = false)
        {
            dbPath = isCommunityMode ? "CommunityDishes.db" : "PersonalDishes.db";
            connectionString = $"Data Source={dbPath};Version=3;";

            InitDatabase();
        }

        private void InitDatabase()
        {
            if (!System.IO.File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string createUser = @"CREATE TABLE IF NOT EXISTS NguoiDung (
                    IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                    HoVaTen TEXT NOT NULL,
                    QuyenHan TEXT NOT NULL)";

                using (var cmd = new SQLiteCommand(createUser, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                string createDish = @"CREATE TABLE IF NOT EXISTS MonAn (
                    IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenMonAn TEXT NOT NULL,
                    HinhAnh BLOB,
                    IDNCC INTEGER,
                    FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC))";

                using (var cmd = new SQLiteCommand(createDish, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int CreateUser(string hoVaTen, string quyenHan)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string checkUser = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @ten AND QuyenHan = @quyen";
                using (var cmd = new SQLiteCommand(checkUser, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", hoVaTen);
                    cmd.Parameters.AddWithValue("@quyen", quyenHan);
                    object? result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                string insertUser = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@ten, @quyen)";
                using (var cmd = new SQLiteCommand(insertUser, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", hoVaTen);
                    cmd.Parameters.AddWithValue("@quyen", quyenHan);
                    cmd.ExecuteNonQuery();
                }

                string getLastId = "SELECT last_insert_rowid()";
                using (var cmd = new SQLiteCommand(getLastId, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        public bool AddDish(string tenMonAn, byte[]? hinhAnh, int idNCC)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string insertDish = "INSERT INTO MonAn (TenMonAn, HinhAnh, IDNCC) VALUES (@tenMonAn, @hinhAnh, @idNCC)";
                    using (var cmd = new SQLiteCommand(insertDish, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenMonAn", tenMonAn);
                        cmd.Parameters.AddWithValue("@hinhAnh", hinhAnh != null ? (object)hinhAnh : DBNull.Value);
                        cmd.Parameters.AddWithValue("@idNCC", idNCC);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public DataTable GetAllDishes()
        {
            DataTable dt = new DataTable();

            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT m.IDMA, m.TenMonAn, n.HoVaTen 
                               FROM MonAn m 
                               INNER JOIN NguoiDung n ON m.IDNCC = n.IDNCC";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public DishInfo? GetDishById(int idma)
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen 
                               FROM MonAn m 
                               INNER JOIN NguoiDung n ON m.IDNCC = n.IDNCC 
                               WHERE m.IDMA = @id";

                using (var cmd = new SQLiteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idma);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new DishInfo
                            {
                                ID = Convert.ToInt32(reader["IDMA"]),
                                TenMonAn = reader["TenMonAn"].ToString(),
                                TenNguoiDongGop = reader["HoVaTen"].ToString(),
                                HinhAnh = reader["HinhAnh"] != DBNull.Value ? (byte[])reader["HinhAnh"] : null
                            };
                        }
                    }
                }
            }
            return null;
        }

        public DishInfo? GetRandomDish()
        {
            using (var conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string countQuery = "SELECT COUNT(*) FROM MonAn";
                using (var cmd = new SQLiteCommand(countQuery, conn))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0) return null;
                }
                string query = @"SELECT m.IDMA, m.TenMonAn, m.HinhAnh, n.HoVaTen 
                               FROM MonAn m 
                               INNER JOIN NguoiDung n ON m.IDNCC = n.IDNCC 
                               ORDER BY RANDOM() 
                               LIMIT 1";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new DishInfo
                        {
                            ID = Convert.ToInt32(reader["IDMA"]),
                            TenMonAn = reader["TenMonAn"].ToString(),
                            TenNguoiDongGop = reader["HoVaTen"].ToString(),
                            HinhAnh = reader["HinhAnh"] != DBNull.Value ? (byte[])reader["HinhAnh"] : null
                        };
                    }
                }
            }
            return null;
        }

        public bool DeleteDish(int idma)
        {
            try
            {
                using (var conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM MonAn WHERE IDMA = @id";
                    using (var cmd = new SQLiteCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idma);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

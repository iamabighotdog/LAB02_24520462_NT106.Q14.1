using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class LAB02_BAI06 : Form
    {
        Random rd = new Random();

        string dbPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "food.db");
        string connStr => $"Data Source={dbPath};Version=3;";
        string duongDanAnh = "";

        public LAB02_BAI06()
        {
            InitializeComponent();
            Shown += Lab01_Bai08_Shown;
        }

        void Lab01_Bai08_Shown(object sender, EventArgs e)
        {
            TaoDbNeuChuaCo();
            NapListView();
        }

        void TaoDbNeuChuaCo()
        {
            if (!File.Exists(dbPath))
                SQLiteConnection.CreateFile(dbPath);
            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText =
                    @"
                    CREATE TABLE IF NOT EXISTS NguoiDung(
                    IDNCC    INTEGER PRIMARY KEY AUTOINCREMENT,
                    HoVaTen  TEXT NOT NULL,
                    QuyenHan TEXT
                    );
                    CREATE TABLE IF NOT EXISTS MonAn(
                    IDMA     INTEGER PRIMARY KEY AUTOINCREMENT,
                    TenMonAn TEXT NOT NULL,
                    HinhAnh  TEXT,
                    IDNCC    INTEGER,
                    FOREIGN KEY(IDNCC) REFERENCES NguoiDung(IDNCC)
                    );
                    ";
                    cmd.ExecuteNonQuery();
                }
            }
        }
        int EnsureNguoi(string hoTen)
        {
            if (string.IsNullOrWhiteSpace(hoTen)) return -1;
            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @t LIMIT 1;";
                    cmd.Parameters.AddWithValue("@t", hoTen.Trim());
                    var o = cmd.ExecuteScalar();
                    if (o != null && o != DBNull.Value) return Convert.ToInt32(o);
                }
                using (var cmd2 = cnn.CreateCommand())
                {
                    cmd2.CommandText = "INSERT INTO NguoiDung(HoVaTen, QuyenHan) VALUES(@t,'user'); SELECT last_insert_rowid();";
                    cmd2.Parameters.AddWithValue("@t", hoTen.Trim());
                    return Convert.ToInt32(cmd2.ExecuteScalar());
                }
            }
        }
        void NapListView()
        {
            lvMon.Items.Clear();

            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText =
                        @"SELECT MonAn.IDMA, MonAn.TenMonAn, MonAn.HinhAnh, IFNULL(NguoiDung.HoVaTen,'(không rõ)') AS TenNguoi
                          FROM MonAn
                          LEFT JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC
                          ORDER BY MonAn.IDMA DESC;";
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            var id = rd.GetInt64(0);
                            var ten = rd.GetString(1);
                            var img = rd.IsDBNull(2) ? "" : rd.GetString(2);
                            var nguoi = rd.GetString(3);

                            var it = new ListViewItem(id.ToString());
                            it.SubItems.Add(ten);
                            it.SubItems.Add(nguoi);
                            it.Tag = img;
                            lvMon.Items.Add(it);
                        }
                    }
                }
            }
        }
        private void btnNapDb_Click(object sender, EventArgs e)
        {
            NapListView();
        }
        private void btnLuuDb_Click(object sender, EventArgs e)
        {
            var ten = textBox1.Text.Trim();
            var nguoi = txtNguoi.Text.Trim();

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Nhập tên món.");
                return;
            }
            int idncc = EnsureNguoi(nguoi);

            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO MonAn(TenMonAn, HinhAnh, IDNCC) VALUES(@a, @b, @c);";
                    cmd.Parameters.AddWithValue("@a", ten);
                    cmd.Parameters.AddWithValue("@b", string.IsNullOrWhiteSpace(duongDanAnh) ? (object)DBNull.Value : duongDanAnh);
                    if (idncc <= 0) cmd.Parameters.AddWithValue("@c", DBNull.Value);
                    else cmd.Parameters.AddWithValue("@c", idncc);
                    cmd.ExecuteNonQuery();
                }
            }

            textBox1.Clear();
            duongDanAnh = "";
            pbHinh.Image = null;
            NapListView();
        }
        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Title = "Chọn ảnh món ăn",
                Filter = "Ảnh|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Tất cả|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            duongDanAnh = ofd.FileName;
            try
            {
                using (var bmpTemp = new Bitmap(duongDanAnh))
                {
                    pbHinh.Image = new Bitmap(bmpTemp);
                }
            }
            catch
            {
                pbHinh.Image = null;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn món trong danh sách (bên phải) để xoá.");
                return;
            }
            var it = lvMon.SelectedItems[0];
            if (!long.TryParse(it.Text, out var id)) return;

            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM MonAn WHERE IDMA = @id;";
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
            }
            NapListView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var cnn = new SQLiteConnection(connStr))
            {
                cnn.Open();
                using (var cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM MonAn;";
                    var cnt = Convert.ToInt32(cmd.ExecuteScalar());
                    if (cnt == 0)
                    {
                        MessageBox.Show("Chưa có dữ liệu món ăn trong DB!");
                        return;
                    }
                    int skip = rd.Next(cnt);
                    cmd.CommandText =
                        @"SELECT MonAn.TenMonAn, MonAn.HinhAnh, IFNULL(NguoiDung.HoVaTen,'(không rõ)')
                          FROM MonAn LEFT JOIN NguoiDung ON MonAn.IDNCC = NguoiDung.IDNCC
                          LIMIT 1 OFFSET @k;";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@k", skip);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            var ten = r.GetString(0);
                            var img = r.IsDBNull(1) ? "" : r.GetString(1);
                            var nguoi = r.GetString(2);
                            textBox2.Text = $"{ten}  —  {nguoi}";
                            try
                            {
                                if (!string.IsNullOrWhiteSpace(img) && File.Exists(img))
                                {
                                    using (var bmpT = new Bitmap(img))
                                        pbHinh.Image = new Bitmap(bmpT);
                                }
                                else pbHinh.Image = null;
                            }
                            catch { pbHinh.Image = null; }
                        }
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void lvMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMon.SelectedItems.Count == 0) return;
            var it = lvMon.SelectedItems[0];
            var path = it.Tag as string;
            try
            {
                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    using (var b = new Bitmap(path))
                        pbHinh.Image = new Bitmap(b);
                }
                else pbHinh.Image = null;
            }
            catch { pbHinh.Image = null; }
        }
    }
}

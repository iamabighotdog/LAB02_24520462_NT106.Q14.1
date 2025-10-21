using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class LAB02_BAI04 : Form
    {
        [Serializable]
        public class SinhVien
        {
            public string HoTen { get; set; }
            public int MSSV { get; set; }
            public string DienThoai { get; set; }
            public float Diem1 { get; set; }
            public float Diem2 { get; set; }
            public float Diem3 { get; set; }

            public float DTB { get { return (Diem1 + Diem2 + Diem3) / 3f; } }
        }

        private List<SinhVien> ds = new List<SinhVien>();
        private List<SinhVien> dsHienThi = new List<SinhVien>();
        private int trang = 1;
        private int tongTrang = 1;
        private int kichThuocTrang = 10;
        private string thuMucLuu = "";

        public LAB02_BAI04()
        {
            InitializeComponent();
            KhoiTaoBang();
        }

        private void KhoiTaoBang()
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("HoTen", "Họ tên");
            dgv.Columns.Add("MSSV", "MSSV");
            dgv.Columns.Add("DienThoai", "SĐT");
            dgv.Columns.Add("D1", "Điểm 1");
            dgv.Columns.Add("D2", "Điểm 2");
            dgv.Columns.Add("D3", "Điểm 3");
            dgv.Columns.Add("DTB", "ĐTB");
        }
        private bool KiemChuoiSo(string s)
        {
            int tmp;
            return int.TryParse(s, out tmp);
        }
        private bool KiemDiem(string s, out float diem)
        {
            if (float.TryParse(s, out diem))
                return diem >= 0 && diem <= 10;
            return false;
        }
        private bool HopLe(SinhVien sv, out string loi)
        {
            loi = "";
            if (!Regex.IsMatch(sv.DienThoai ?? "", @"^0\d{9}$"))
                loi = "SĐT phải 10 số và bắt đầu bằng 0";
            else if (sv.MSSV < 10000000 || sv.MSSV > 99999999)
                loi = "MSSV phải đúng 8 chữ số";
            else if (sv.Diem1 < 0 || sv.Diem1 > 10 || sv.Diem2 < 0 || sv.Diem2 > 10 || sv.Diem3 < 0 || sv.Diem3 > 10)
                loi = "Điểm mỗi môn từ 0 đến 10";
            return loi == "";
        }
        private void CapNhatTrang()
        {
            tongTrang = Math.Max(1, (int)Math.Ceiling(ds.Count / (double)kichThuocTrang));
            if (trang > tongTrang) trang = tongTrang;
            if (trang < 1) trang = 1;

            dsHienThi = ds.Skip((trang - 1) * kichThuocTrang).Take(kichThuocTrang).ToList();

            dgv.Rows.Clear();
            foreach (var sv in dsHienThi)
                dgv.Rows.Add(sv.HoTen, sv.MSSV, sv.DienThoai, sv.Diem1, sv.Diem2, sv.Diem3, Math.Round(sv.DTB, 2));

            lbTrang.Text = $"Trang {trang}/{tongTrang}";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            float d1, d2, d3;
            if (!KiemDiem(txtD1.Text, out d1) || !KiemDiem(txtD2.Text, out d2) || !KiemDiem(txtD3.Text, out d3))
            {
                MessageBox.Show("Điểm không hợp lệ (0..10)!", "Lỗi");
                return;
            }
            int mssv;
            if (!int.TryParse(txtMssv.Text, out mssv))
            {
                MessageBox.Show("MSSV phải là số!", "Lỗi");
                return;
            }

            var sv = new SinhVien
            {
                HoTen = txtHoTen.Text?.Trim(),
                MSSV = mssv,
                DienThoai = txtSdt.Text?.Trim(),
                Diem1 = d1,
                Diem2 = d2,
                Diem3 = d3
            };

            string loi;
            if (!HopLe(sv, out loi))
            {
                MessageBox.Show(loi, "Lỗi");
                return;
            }

            ds.Add(sv);
            if (string.IsNullOrEmpty(thuMucLuu))
                thuMucLuu = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            CapNhatTrang();

            txtHoTen.Clear(); txtMssv.Clear(); txtSdt.Clear(); txtD1.Clear(); txtD2.Clear(); txtD3.Clear();
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;
            int index = (trang - 1) * kichThuocTrang + dgv.CurrentRow.Index;
            if (index >= 0 && index < ds.Count)
            {
                ds.RemoveAt(index);
                CapNhatTrang();
            }
        }
        private void btnGhiInput_Click(object sender, EventArgs e)
        {
            if (ds.Count == 0)
            {
                MessageBox.Show("Danh sách đang trống, hãy Thêm trước!", "Thông báo");
                return;
            }

            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Chọn nơi lưu input4.txt (nhị phân)";
                sfd.Filter = "Binary files (*.dat;*.bin;*.txt)|*.dat;*.bin;*.txt";
                sfd.FileName = "input4.txt";
                if (sfd.ShowDialog() != DialogResult.OK) return;

                thuMucLuu = Path.GetDirectoryName(sfd.FileName);

                BinaryFormatter bf = new BinaryFormatter();
                using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                {
                    bf.Serialize(fs, ds);
                }
                MessageBox.Show("Đã ghi input4.txt (BinaryFormatter). Lưu ý: đây là file NHỊ PHÂN.");
            }
        }
        private void btnDocTinh_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn input4.txt (nhị phân)";
                ofd.Filter = "Binary files (*.dat;*.bin;*.txt)|*.dat;*.bin;*.txt|All files (*.*)|*.*";
                if (ofd.ShowDialog() != DialogResult.OK) return;
                thuMucLuu = Path.GetDirectoryName(ofd.FileName);
                List<SinhVien> dsInput = null;
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        dsInput = (List<SinhVien>)bf.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không đọc được file nhị phân: " + ex.Message, "Lỗi");
                    return;
                }
                foreach (var sv in dsInput)
                {
                    string loi;
                    if (!HopLe(sv, out loi))
                        MessageBox.Show("Dòng lỗi: " + sv.HoTen + " - " + loi, "Cảnh báo");
                }

                ds = dsInput ?? new List<SinhVien>();
                trang = 1;
                CapNhatTrang();
                string outPath = Path.Combine(thuMucLuu, "output4.txt");
                using (var sw = new StreamWriter(outPath, false, Encoding.UTF8))
                {
                    sw.WriteLine("HoTen,MSSV,DienThoai,Diem1,Diem2,Diem3,DTB");
                    foreach (var sv in ds)
                    {
                        sw.WriteLine($"{sv.HoTen},{sv.MSSV},{sv.DienThoai},{sv.Diem1},{sv.Diem2},{sv.Diem3},{Math.Round(sv.DTB, 2)}");
                    }
                }

                MessageBox.Show("Đã đọc input4 (binary) và ghi output4.txt (text).");
            }
        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            trang--;
            CapNhatTrang();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            trang++;
            CapNhatTrang();
        }
    }
}

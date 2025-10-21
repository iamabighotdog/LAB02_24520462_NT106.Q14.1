using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class LAB02_BAI07 : Form
    {
        string thuMucHienTai = "";
        public LAB02_BAI07()
        {
            InitializeComponent();
        }
        private void LAB02_BAI07_Load(object sender, EventArgs e)
        {
            TaiDanhSachODia();
        }
        void TaiDanhSachODia()
        {
            thuMucHienTai = "";
            txtDuongDan.Text = "(Máy tính)";
            rtb.Clear();

            lv.BeginUpdate();
            lv.Items.Clear();
            foreach (var d in DriveInfo.GetDrives().Where(x => x.IsReady))
            {
                var it = new ListViewItem(d.Name.TrimEnd('\\'));
                it.SubItems.Add("Ổ đĩa");
                it.SubItems.Add(string.Format("{0:N0} MB", d.TotalSize / (1024 * 1024)));
                it.SubItems.Add("");
                it.Tag = d.RootDirectory.FullName;
                lv.Items.Add(it);
            }
            lv.EndUpdate();

            lbTrangThai.Text = $"{lv.Items.Count}";
        }
        void TaiThuMuc(string path)
        {
            try
            {
                var dir = new DirectoryInfo(path);
                if (!dir.Exists) return;

                thuMucHienTai = dir.FullName;
                txtDuongDan.Text = thuMucHienTai;
                rtb.Clear();

                lv.BeginUpdate();
                lv.Items.Clear();
                if (dir.Parent != null)
                {
                    var back = new ListViewItem("..");
                    back.SubItems.Add("Thư mục");
                    back.SubItems.Add("");
                    back.SubItems.Add("");
                    back.Tag = dir.Parent.FullName;
                    lv.Items.Add(back);
                }
                foreach (var f in dir.EnumerateDirectories())
                {
                    var it = new ListViewItem(f.Name);
                    it.SubItems.Add("Thư mục");
                    it.SubItems.Add("");
                    it.SubItems.Add(f.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    it.Tag = f.FullName;
                    lv.Items.Add(it);
                }
                foreach (var f in dir.EnumerateFiles())
                {
                    var it = new ListViewItem(f.Name);
                    it.SubItems.Add(f.Extension.ToLower());
                    it.SubItems.Add(string.Format("{0:N0} KB", Math.Max(1, f.Length / 1024)));
                    it.SubItems.Add(f.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    it.Tag = f.FullName;
                    lv.Items.Add(it);
                }

                lv.EndUpdate();
                lbTrangThai.Text = $"Thư mục: {dir.GetDirectories().Length} | File: {dir.GetFiles().Length}";
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Không có quyền truy cập thư mục này.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void btnChon_Click(object sender, EventArgs e)
        {
            using (var f = new FolderBrowserDialog())
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    TaiThuMuc(f.SelectedPath);
                }
            }
        }
        private void btnLen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(thuMucHienTai))
            {
                TaiDanhSachODia();
                return;
            }

            var p = Directory.GetParent(thuMucHienTai);
            if (p == null) { TaiDanhSachODia(); return; }
            TaiThuMuc(p.FullName);
        }
        private void btnTaiOC_Click(object sender, EventArgs e)
        {
            TaiDanhSachODia();
        }
        private void lv_ItemActivate(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0) return;
            var it = lv.SelectedItems[0];
            var path = it.Tag as string;
            if (string.IsNullOrEmpty(path)) return;
            if (Directory.Exists(path))
            {
                TaiThuMuc(path);
                return;
            }
            if (File.Exists(path))
            {
                HienNoiDungFile(path);
            }
        }
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lv.SelectedItems.Count == 0) return;
            var path = lv.SelectedItems[0].Tag as string;
            if (File.Exists(path))
            {
                HienNoiDungFile(path);
            }
            else
            {
                rtb.Clear();
            }
        }
        void HienNoiDungFile(string path)
        {
            var ext = Path.GetExtension(path).ToLower();
            var imgExt = new[] { ".jpg", ".jpeg", ".png", ".bmp", ".gif", ".tif", ".tiff" };

            try
            {
                if (imgExt.Contains(ext))
                {
                    ShowImage(path);
                    lbTrangThai.Text = $"Xem ảnh: {Path.GetFileName(path)}";
                    return;
                }
                string s = DocTextCoFallback(path);
                if (s.Length > 500_000)
                s = s.Substring(0, 500_000) + "\n...\n[Đã cắt vì file quá lớn]";
                ShowText(s);
                lbTrangThai.Text = $"Đang xem: {Path.GetFileName(path)}";
                return;
            }
            catch (Exception ex)
            {
                ShowText("[Không đọc được file]\n" + ex.Message);
            }
        }

        void ShowText(string content)
        {
            if (pb.Image != null) { pb.Image.Dispose(); pb.Image = null; }
            pb.Visible = false;
            rtb.Visible = true;
            rtb.Text = content ?? "";
        }
        void ShowImage(string path)
        {
            if (pb.Image != null) { pb.Image.Dispose(); pb.Image = null; }
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var img = Image.FromStream(fs))
            {
                pb.Image = new Bitmap(img);
            }
            rtb.Visible = false;
            pb.Visible = true;
        }
        string DocTextCoFallback(string path)
        {
            try
            {
                return File.ReadAllText(path, new UTF8Encoding(false, true));
            }
            catch
            {
                return File.ReadAllText(path, Encoding.Default);
            }
        }

    }
}

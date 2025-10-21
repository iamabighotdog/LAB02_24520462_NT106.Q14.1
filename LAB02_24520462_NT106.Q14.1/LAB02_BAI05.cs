using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class LAB02_BAI05 : Form
    {
        private readonly Dictionary<string, (int BasePrice, int[] Rooms)> _movies =
            new Dictionary<string, (int, int[])>();
        private readonly Dictionary<string, double> _multipliers = new Dictionary<string, double>
        {
            { "Vớt",    0.25 },
            { "Thường", 1.0  },
            { "VIP",    2.0  },
        };
        private readonly Dictionary<string, HashSet<string>> _sold = new Dictionary<string, HashSet<string>>();
        private int? _lockedRoom = null;
        private const int SEATS_PER_ROOM = 15;
        public LAB02_BAI05()
        {
            InitializeComponent();
            this.Load += Lab01_Bai04_Load;
            this.checkedListBox1.ItemCheck += checkedListBox1_ItemCheck;
        }
        private void Lab01_Bai04_Load(object sender, EventArgs e)
        {
            PopulateSeatsList();
            string autoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input5.txt");
            if (File.Exists(autoPath) && TryLoadMovies(autoPath))
            {
                BindMoviesToUI();
                textBox2.Text = "Đã nạp cấu hình từ input5.txt";
            }
            else
            {
                SeedSampleMovies();
                BindMoviesToUI();
            }
        }
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "Chọn input5.txt",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
            };
            if (ofd.ShowDialog() != DialogResult.OK) return;

            if (TryLoadMovies(ofd.FileName))
            {
                _sold.Clear();
                BindMoviesToUI();
                textBox2.Text = "Đã nạp cấu hình từ input5.txt";
            }
        }

        private bool TryLoadMovies(string path)
        {
            try
            {
                _movies.Clear();
                string[] raw = File.ReadAllLines(path, Encoding.UTF8);
                List<string> lines = new List<string>();
                foreach (var r in raw)
                {
                    string s = (r ?? "").Trim();
                    if (s.Length > 0) lines.Add(s);
                }

                for (int i = 0; i + 2 < lines.Count; i += 3)
                {
                    string name = lines[i];
                    int price = int.Parse(lines[i + 1], CultureInfo.InvariantCulture);
                    string roomsLine = lines[i + 2];

                    List<int> rooms = new List<int>();
                    foreach (var token in roomsLine.Split(new[] { ',', ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        int r;
                        if (int.TryParse(token, out r)) rooms.Add(r);
                    }

                    _movies[name] = (price, rooms.ToArray());
                }

                if (_movies.Count == 0)
                {
                    MessageBox.Show("input5.txt không đúng format (cần block 3 dòng).", "Lỗi");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đọc input5.txt: " + ex.Message, "Lỗi");
                return false;
            }
        }
        private void SeedSampleMovies()
        {
            _movies.Clear();
            _movies["Đào, phở và piano"] = (45000, new[] { 1, 2, 3 });
            _movies["Mai"] = (100000, new[] { 2, 3 });
            _movies["Gặp lại chị bầu"] = (70000, new[] { 1 });
            _movies["Tarot"] = (90000, new[] { 3 });
        }
        private void BindMoviesToUI()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(_movies.Keys.ToArray());
            if (comboBox1.Items.Count > 0) comboBox1.SelectedIndex = 0;
            comboBox1_SelectedIndexChanged(null, EventArgs.Empty);
            MarkSoldSeatsOnUI();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            _lockedRoom = null;
            comboBox2.Enabled = true;

            if (comboBox1.SelectedItem == null) return;
            string mv = comboBox1.SelectedItem.ToString();
            if (!_movies.ContainsKey(mv)) return;

            foreach (var r in _movies[mv].Rooms) comboBox2.Items.Add(r);
            if (comboBox2.Items.Count > 0) comboBox2.SelectedIndex = 0;

            UncheckAllSeats();
            MarkSoldSeatsOnUI();
            UpdatePreview();
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_lockedRoom != null && comboBox2.SelectedItem != null)
            {
                int newRoom = Convert.ToInt32(comboBox2.SelectedItem);
                if (newRoom != _lockedRoom.Value)
                {
                    MessageBox.Show("Chỉ được mua vé từ 1 phòng. Bỏ chọn ghế để đổi phòng.",
                                    "Ràng buộc", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    comboBox2.SelectedItem = _lockedRoom.Value;
                    return;
                }
            }
            UncheckAllSeats();
            MarkSoldSeatsOnUI();
            UpdatePreview();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            UncheckAllSeats();
            _lockedRoom = null;
            comboBox2.Enabled = true;
            UpdatePreview();
        }
        private void UncheckAllSeats()
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemCheckState(i) != CheckState.Unchecked)
                    checkedListBox1.SetItemChecked(i, false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Chọn phim và phòng chiếu."); return;
            }

            string movie = comboBox1.SelectedItem.ToString();
            int room = Convert.ToInt32(comboBox2.SelectedItem);
            int basePrice = _movies[movie].BasePrice;

            var chosen = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    chosen.Add(checkedListBox1.Items[i].ToString());

            if (chosen.Count == 0)
            {
                MessageBox.Show("Hãy chọn ít nhất 1 ghế."); return;
            }

            string key = $"{movie}|{room}";
            if (!_sold.ContainsKey(key)) _sold[key] = new HashSet<string>();
            var soldSet = _sold[key];

            foreach (var seat in chosen)
            {
                if (soldSet.Contains(seat))
                {
                    MessageBox.Show($"Ghế {seat} đã được bán."); return;
                }
            }

            double total = 0;
            var details = new List<string>();
            foreach (var seat in chosen)
            {
                string cat = SeatCategory(seat);
                double price = basePrice * _multipliers[cat];
                total += price;
                details.Add($"{seat} ({cat}): {price:N0} đ");
            }

            foreach (var seat in chosen) soldSet.Add(seat);

            textBox2.Text =
                $"Khách: {textBox1.Text}\r\n" +
                $"Phim: {movie}\r\n" +
                $"Phòng: {room}\r\n" +
                $"Ghế: {string.Join(", ", chosen)}\r\n\r\n" +
                "Chi tiết:\r\n - " + string.Join("\r\n - ", details) +
                $"\r\n\r\nTỔNG: {total:N0} đ";

            UncheckAllSeats();
            _lockedRoom = null;
            comboBox2.Enabled = true;
            MarkSoldSeatsOnUI();
            UpdatePreview();
        }
        private void UpdatePreview()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                textBox2.Text = "";
                return;
            }
            string mv = comboBox1.SelectedItem.ToString();
            int room = Convert.ToInt32(comboBox2.SelectedItem);
            int basePrice = _movies[mv].BasePrice;

            var chosen = new List<string>();
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
                if (checkedListBox1.GetItemCheckState(i) == CheckState.Checked)
                    chosen.Add(checkedListBox1.Items[i].ToString());

            double sum = 0;
            var lines = new List<string>();
            foreach (var s in chosen)
            {
                string cat = SeatCategory(s);
                double price = basePrice * _multipliers[cat];
                sum += price;
                lines.Add($"{s} ({cat}) = {price:N0} đ");
            }

            if (chosen.Count > 0)
                textBox2.Text = $"Tạm tính ({mv} - P{room}):\r\n - " + string.Join("\r\n - ", lines) + $"\r\nTỔNG: {sum:N0} đ";
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int checkedCount = 0;
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                var state = checkedListBox1.GetItemCheckState(i);
                if (i == e.Index) state = e.NewValue;
                if (state == CheckState.Checked) checkedCount++;
            }
            if (checkedCount > 0)
            {
                if (_lockedRoom == null && comboBox2.SelectedItem != null)
                {
                    _lockedRoom = Convert.ToInt32(comboBox2.SelectedItem);
                    comboBox2.Enabled = false;
                }
            }
            else
            {
                _lockedRoom = null;
                comboBox2.Enabled = true;
            }

            BeginInvoke(new Action(UpdatePreview));
        }
        private void PopulateSeatsList()
        {
            checkedListBox1.Items.Clear();
            foreach (var row in new[] { 'A', 'B', 'C' })
                for (int n = 1; n <= 5; n++)
                    checkedListBox1.Items.Add($"{row}{n}", false);
        }
        private void MarkSoldSeatsOnUI()
        {
            if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null) return;

            string movie = comboBox1.SelectedItem.ToString();
            int room = Convert.ToInt32(comboBox2.SelectedItem);
            string key = $"{movie}|{room}";

            var soldSet = _sold.ContainsKey(key) ? _sold[key] : new HashSet<string>();

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                string seat = checkedListBox1.Items[i].ToString();
                if (soldSet.Contains(seat))
                    checkedListBox1.SetItemCheckState(i, CheckState.Indeterminate);
                else if (checkedListBox1.GetItemCheckState(i) == CheckState.Indeterminate)
                    checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }
        }
        private string SeatCategory(string seat)
        {
            if (seat == "A1" || seat == "A5" || seat == "C1" || seat == "C5") return "Vớt";
            if (seat == "B2" || seat == "B3" || seat == "B4") return "VIP";
            return "Thường";
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (_movies.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu phim. Hãy nạp input5.txt trước!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Title = "Lưu output5.txt",
                Filter = "Text files (*.txt)|*.txt",
                FileName = "output5.txt"
            };
            if (sfd.ShowDialog() != DialogResult.OK) return;
            BeginProgress(100, "Đang xuất...");
            try
            {
                var stats = new List<MovieStat>();
                int nMovie = _movies.Count;
                int perMovie = Math.Max(1, 60 / (nMovie == 0 ? 1 : nMovie));
                int progressed = 0;
                foreach (var kv in _movies)
                {
                    string name = kv.Key;
                    var cfg = kv.Value;

                    int sold = 0;
                    double revenue = 0;

                    foreach (int room in cfg.Rooms)
                    {
                        string key = $"{name}|{room}";
                        var soldSet = _sold.ContainsKey(key) ? _sold[key] : new HashSet<string>();
                        sold += soldSet.Count;

                        foreach (var seat in soldSet)
                        {
                            string cat = SeatCategory(seat);
                            revenue += cfg.BasePrice * _multipliers[cat];
                        }
                    }

                    int capacity = cfg.Rooms.Length * SEATS_PER_ROOM;
                    int remain = Math.Max(0, capacity - sold);
                    double rate = capacity == 0 ? 0 : (sold * 100.0 / capacity);

                    stats.Add(new MovieStat
                    {
                        Name = name,
                        Sold = sold,
                        Remain = remain,
                        Rate = rate,
                        Revenue = revenue
                    });

                    progressed += perMovie;
                    StepProgress(perMovie);
                    lblProg.Text = $"Tính: {Math.Min(progressed, 60)}%";
                }
                stats = stats.OrderByDescending(s => s.Revenue).ToList();
                for (int i = 0; i < stats.Count; i++) stats[i].Rank = i + 1;
                int perWrite = Math.Max(1, 40 / (stats.Count == 0 ? 1 : stats.Count));
                int baseVal = progressBar1.Value;
                using (var sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
                {
                    sw.WriteLine("TenPhim|SoVeBan|SoVeTon|TiLeBan(%)|DoanhThu|XepHang");
                    foreach (var s in stats)
                    {
                        sw.WriteLine($"{s.Name}|{s.Sold}|{s.Remain}|{s.Rate:F2}|{s.Revenue:N0}|{s.Rank}");
                        StepProgress(perWrite);
                        lblProg.Text = $"Ghi: {Math.Min(progressBar1.Value, 100)}%";
                    }
                }
                EndProgress("Xuất xong");
                MessageBox.Show("Đã xuất " + sfd.FileName);
            }
            catch (Exception ex)
            {
                EndProgress("Lỗi");
                MessageBox.Show("Lỗi khi xuất: " + ex.Message, "Lỗi");
            }
        }
        private void BeginProgress(int maxPercent, string text)
        {
            progressBar1.Minimum = 0;
            progressBar1.Maximum = maxPercent;
            progressBar1.Value = 0;
            lblProg.Text = text;
            ToggleUI(false);
            Application.DoEvents();
        }
        private void StepProgress(int step)
        {
            int val = Math.Min(progressBar1.Value + step, progressBar1.Maximum);
            progressBar1.Value = val;
            Application.DoEvents();
        }
        private void EndProgress(string doneText)
        {
            progressBar1.Value = progressBar1.Maximum;
            lblProg.Text = doneText;
            ToggleUI(true);
            Application.DoEvents();
        }
        private void ToggleUI(bool enable)
        {
            buttonLoad.Enabled = enable;
            buttonExport.Enabled = enable;
            button1.Enabled = enable;
            button2.Enabled = enable;
            comboBox1.Enabled = enable;
            if (_lockedRoom != null) comboBox1.Enabled = false;
        }
        private class MovieStat
        {
            public string Name;
            public int Sold;
            public int Remain;
            public double Rate;
            public double Revenue;
            public int Rank;
        }
    }
}

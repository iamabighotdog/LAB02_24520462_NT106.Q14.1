using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class LAB02_BAI03 : Form
    {
        private string Input = "";

        public LAB02_BAI03()
        {
            InitializeComponent();
        }
        private void btnRead_Click(object sender, EventArgs e)
        {
            OpenFileDialog hopMo = new OpenFileDialog();
            hopMo.Title = "Chọn file input3.txt";
            hopMo.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (hopMo.ShowDialog() == DialogResult.OK)
            {
                Input = hopMo.FileName;
                rtbInput.Text = File.ReadAllText(Input);
                rtbOutput.Clear();
                MessageBox.Show("Đọc file thành công!", "Thông báo");
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbInput.Text))
            {
                MessageBox.Show("Vui lòng chọn file trước!", "Lỗi");
                return;
            }

            string[] dong = rtbInput.Text.Replace("\r\n", "\n").Split('\n');
            StringBuilder kq = new StringBuilder();

            foreach (string CongThuc in dong)
            {
                string bthuc = CongThuc.Trim();
                if (bthuc.Length == 0) continue;

                try
                {
                    double giaTri = TinhBieuThuc(bthuc);
                    kq.AppendLine(bthuc + " = " + giaTri.ToString(CultureInfo.InvariantCulture));
                }
                catch
                {
                    kq.AppendLine("ERROR");
                }
            }

            rtbOutput.Text = kq.ToString();

            string duongDanOut = Path.Combine(Path.GetDirectoryName(Input), "output3.txt");
            File.WriteAllText(duongDanOut, rtbOutput.Text);

            MessageBox.Show("Đã ghi kết quả ra: " + duongDanOut, "Thành công");
        }
        private static double TinhBieuThuc(string bthuc)
        {
            Stack<double> giaTri = new Stack<double>();
            Stack<char> toanTu = new Stack<char>();

            for (int i = 0; i < bthuc.Length; i++)
            {
                char c = bthuc[i];
                if (c == ' ') continue;
                if (char.IsDigit(c))
                {
                    StringBuilder soTam = new StringBuilder();
                    while (i < bthuc.Length && (char.IsDigit(bthuc[i]) || bthuc[i] == '.'))
                    {
                        soTam.Append(bthuc[i]);
                        i++;
                    }
                    i--;
                    giaTri.Push(double.Parse(soTam.ToString(), CultureInfo.InvariantCulture));
                }
                else if (c == '(')
                {
                    toanTu.Push(c);
                }
                else if (c == ')')
                {
                    while (toanTu.Count > 0 && toanTu.Peek() != '(')
                    {
                        giaTri.Push(TinhToan(toanTu.Pop(), giaTri.Pop(), giaTri.Pop()));
                    }
                    if (toanTu.Count > 0 && toanTu.Peek() == '(')
                        toanTu.Pop();
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (toanTu.Count > 0 && UuTien(toanTu.Peek()) >= UuTien(c))
                    {
                        giaTri.Push(TinhToan(toanTu.Pop(), giaTri.Pop(), giaTri.Pop()));
                    }
                    toanTu.Push(c);
                }
            }

            while (toanTu.Count > 0)
            {
                giaTri.Push(TinhToan(toanTu.Pop(), giaTri.Pop(), giaTri.Pop()));
            }

            return giaTri.Pop();
        }
        private static double TinhToan(char op, double b, double a)
        {
            switch (op)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/':
                    if (Math.Abs(b) < 1e-12)
                        throw new DivideByZeroException();
                    return a / b;
            }
            return 0;
        }
        private static int UuTien(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }
    }
}

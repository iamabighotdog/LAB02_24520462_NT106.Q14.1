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
    public partial class LAB02_BAI02 : Form
    {
        public LAB02_BAI02()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file .txt để đọc";
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                string content = sr.ReadToEnd();
                sr.Close();
                fs.Close();
                richTextBox1.Text = content;
                txtFileName.Text = ofd.SafeFileName.ToString();
                txtURL.Text = fs.Name.ToString();
                FileInfo fi = new FileInfo(ofd.FileName);
                txtSize.Text = fi.Length.ToString() + " bytes";
                int lineCount = File.ReadAllLines(ofd.FileName).Length;
                txtLine.Text = lineCount.ToString();

                int wordCount = content.Split(
                    new char[] { ' ', '\n', '\r', '\t' },
                    StringSplitOptions.RemoveEmptyEntries
                ).Length;
                txtWord.Text = wordCount.ToString();

                txtChar.Text = content.Length.ToString();

                MessageBox.Show("Đọc file thành công!", "Thông báo");
            }
        }
    }
}

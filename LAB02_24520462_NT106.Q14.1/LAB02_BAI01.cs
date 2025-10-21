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
    public partial class LAB02_BAI01 : Form
    {
        public LAB02_BAI01()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string currentFile = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Chọn file input1.txt để đọc";
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                currentFile = ofd.FileName;
                using (StreamReader sr = new StreamReader(currentFile))
                {
                    richTextBox1.Text = sr.ReadToEnd();
                }
                MessageBox.Show("Đã đọc file!", "Thông báo");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string currentFile = "";
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Chọn nơi lưu file output1.txt";
            sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                currentFile = sfd.FileName;
                using (StreamWriter sw = new StreamWriter(currentFile))
                {
                    sw.Write(richTextBox1.Text);
                }
                MessageBox.Show("Đã ghi file!", "Thông báo");
            }
        }
    }
}

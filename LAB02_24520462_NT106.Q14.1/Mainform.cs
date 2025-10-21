using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB02_24520462_NT106.Q14._1
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LAB02_BAI01 lab01 = new LAB02_BAI01();
            lab01.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LAB02_BAI02 lab02 = new LAB02_BAI02();
            lab02.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LAB02_BAI03 lab03 = new LAB02_BAI03();
            lab03.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LAB02_BAI04 lab04 = new LAB02_BAI04();
            lab04.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LAB02_BAI05 lab05 = new LAB02_BAI05();
            lab05.Show();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            LAB02_BAI06 lab06 = new LAB02_BAI06();
            lab06.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            LAB02_BAI07 lab07 = new LAB02_BAI07();
            lab07.Show();
        }

    }
}

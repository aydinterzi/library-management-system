using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyonu
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            this.panel2.Controls.Add(form3);
            form3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Form4 form4 = new Form4();
            form4.MdiParent = this;
            this.panel2.Controls.Add(form4);
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.panel2.Controls.Clear();
            Form5 form5 = new Form5();
            form5.MdiParent = this;
            this.panel2.Controls.Add(form5);
            form5.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

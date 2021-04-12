using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace KutuphaneOtomasyonu
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");


        private void textBoxes_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "" || textBox4.Text != "" || textBox5.Text != "" || textBox6.Text != "" || textBox7.Text != "" || textBox8.Text != "" || textBox9.Text != "" || textBox10.Text != "" || comboBox1.Text != "")
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("insert into kitaplar(kitapadi,yazar,adet,basimyili,kategori,barkodno,sayfasayisi,yayinevi,rafno,aciklama) values('" + textBox1.Text + "','" + textBox6.Text + "','" + textBox2.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "','" + textBox9.Text + "','" + textBox4.Text + "','" + textBox10.Text + "','" + textBox5.Text + "','" + textBox8.Text + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kitap Eklendi!", "Kitap İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                }
                catch (Exception message)
                {
                    MessageBox.Show(message.Message);
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Boş yer bırakmadığınızı tekrar kontol ediniz!!");
            }
        }

       
    }
}

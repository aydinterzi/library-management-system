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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text =="" || textBox5.Text == "" || textBox6.Text == "" || textBox1.Text == "Numara" || textBox2.Text == "Kullanıcı Adı" || textBox3.Text == "Bölüm" || textBox4.Text == "Ad Soyad" || textBox5.Text == "Şifre" || textBox6.Text == "Eposta" )
            {
                MessageBox.Show("Boş yer bırakmadığınıza emin olun!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("insert into ogrenciler (numara,adsoyad,kullaniciadi,sifre,bolum,eposta) values('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox3.Text + "','" + textBox6.Text + "')", baglanti);
                select.ExecuteNonQuery();
                baglanti.Close();
            }
            catch(Exception hata)
            {
                baglanti.Close();
                MessageBox.Show(hata.Message);
            }
        }
    }
}

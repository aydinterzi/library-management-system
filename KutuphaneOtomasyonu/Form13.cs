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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void Form13_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select numara AS Numara,adsoyad AS AdSoyad,kullaniciadi AS KullanıcıAdı,sifre AS Sifre,bolum AS Bolum,eposta AS Eposta,kitaplar AS Kitaplar from ogrenciler", baglanti);
                DataSet dshafiza = new DataSet();
                selectkomutu.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglanti.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox1.Text=="Numara")
            {
                MessageBox.Show("Numarayı giriniz!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand delete = new OleDbCommand("delete from ogrenciler where numara='" + textBox1.Text + "'", baglanti);
                delete.ExecuteNonQuery();
                baglanti.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

      
    }
}

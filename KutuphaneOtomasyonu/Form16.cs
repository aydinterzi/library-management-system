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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void Form16_Load(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,ogrenciadi AS OgrenciAdı,barkodno AS BarkodNumarası,teslimtarihi AS TeslimTarihi,iadetarihi AS İadeTarihi from emanetkitap where'" + DateTime.Now.ToLongDateString() + "'>iadetarihi", baglanti);
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
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select numara AS Numara,adsoyad AS AdSoyad,kullaniciadi AS KullanıcıAdı,sifre AS Sifre,bolum AS Bolum,eposta AS Eposta,kitaplar AS Kitaplar from ogrenciler", baglanti);
                DataSet dshafiza = new DataSet();
                selectkomutu.Fill(dshafiza);
                dataGridView2.DataSource = dshafiza.Tables[0];
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
            if(textBox1.Text==""|| textBox1.Text=="Öğrenci")
            {
                MessageBox.Show("Lütfen öğrenci adı ve soyadını giriniz!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand update = new OleDbCommand("update ogrenciler set cezadurumu='"+"VAR"+"' where adsoyad='" + textBox1.Text + "'", baglanti);
                update.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ceza Verildi!!");

            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox1.Text == "Öğrenci")
            {
                MessageBox.Show("Lütfen öğrenci adı ve soyadını giriniz!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand update = new OleDbCommand("update ogrenciler set cezadurumu='" + "YOK" + "' where adsoyad='" + textBox1.Text + "'", baglanti);
                update.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ceza kaldırıldı!!");
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }
    }
}

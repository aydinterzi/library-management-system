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
using System.Runtime.InteropServices;

namespace KutuphaneOtomasyonu
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        string kitaplar,kitap;
        int kitapsayisi;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }
        private void kayitlarilistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,ogrenciadi AS Ogrenci,barkodno AS BarkodNo,teslimtarihi AS TeslimTarihi,iadetarihi AS İadeTarihi from emanetkitap", baglanti);
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
        private void Form10_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" || textBox2.Text=="" || textBox1.Text=="Barkod No" || textBox2.Text == "Öğrenci Adı")
            {
                MessageBox.Show("Boş bir yer bırakmadığınızı tekrar kontrol ediniz!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select * from kitaplar where barkodno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while(oku.Read())
                {
                    kitapsayisi = Convert.ToInt32(oku.GetValue(2));
                }
                baglanti.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }

            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select * from emanetkitap where barkodno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while (oku.Read())
                {
                    kitap = Convert.ToString(oku.GetValue(0));
                }
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
                OleDbCommand select = new OleDbCommand("select * from ogrenciler where adsoyad='" + textBox2.Text + "'", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while (oku.Read())
                {
                    kitaplar = Convert.ToString(oku.GetValue(6));
                }
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
                OleDbDataAdapter silme = new OleDbDataAdapter("delete from emanetkitap where barkodno='" + textBox1.Text + "'and ogrenciadi='"+textBox2.Text+"'", baglanti);
                DataSet dshafiza = new DataSet();
                silme.Fill(dshafiza);
                baglanti.Close();
                MessageBox.Show("Kitap iade alındı.");
                kayitlarilistele();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
            int index = kitaplar.IndexOf(kitap);
            if(index!=-1)
            {
                kitaplar = kitaplar.Remove(index);
            }
            else
            {
                MessageBox.Show("kitap bulunamadi");
            }

            try
            {
                baglanti.Open();
                OleDbCommand update2 = new OleDbCommand("update kitaplar set adet='" + (kitapsayisi + 1) + "'where barkodno='"+textBox1.Text+"'", baglanti);
                update2.ExecuteNonQuery();
                OleDbCommand update = new OleDbCommand("update ogrenciler set kitaplar='"+kitaplar+"' where adsoyad='"+textBox2.Text+"'",baglanti);
                update.ExecuteNonQuery();
                baglanti.Close();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }
    }
}

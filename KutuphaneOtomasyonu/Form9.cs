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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        string kitapadi,kitaplar,ogrenciadi,cezadurumu;
        int adet=0,barkodno;
        private void kitaplistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,barkodno AS BarkodNumarası ,yazar AS Yazar,adet AS Adet,kategori AS Kategori from kitaplar", baglanti);
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
        private void ogrencilistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select numara AS Numara,adsoyad AS AdSoyad,bolum AS Bölüm from ogrenciler", baglanti);
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
        private void Form9_Load(object sender, EventArgs e)
        {
            ogrencilistele();
            kitaplistele();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox1.Text=="Barkod No" || textBox2.Text=="Öğrenci Numarası" ||textBox3.Text=="Teslim Tarihi" )
            {
                MessageBox.Show("Boş bir yer bırakmadığınızı tekrar kontrol ediniz!!");
                return;
            }
           
            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select * from ogrenciler where numara='"+textBox2.Text+"'",baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while(oku.Read())
                {
                    ogrenciadi = Convert.ToString(oku.GetValue(1));
                    kitaplar = Convert.ToString(oku.GetValue(6));
                    cezadurumu = Convert.ToString(oku.GetValue(7));
                }
                baglanti.Close();
            }
            catch(Exception hata)
            {
               
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
            if (cezadurumu == "VAR")
            {
                MessageBox.Show("Öğrencinin cezası bulunmaktadır!!");
                return;
            }
            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select * from kitaplar where barkodno='" + textBox1.Text + "'", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                
                while (oku.Read())
                {
                    kitapadi = Convert.ToString(oku.GetValue(0));
                    barkodno = Convert.ToInt32(oku.GetValue(5));
                    adet = Convert.ToInt32(oku.GetValue(2));
                   
                    adet--;
                }
                if (adet == -1)
                {
                    MessageBox.Show("Rafta kitaptan kalmamıştır!!");
                    baglanti.Close();
                }
                else
                {
                    OleDbCommand update = new OleDbCommand("update kitaplar set adet='" + (adet) + "'where barkodno='" + textBox1.Text + "'", baglanti);
                    update.ExecuteNonQuery();
                    OleDbCommand update2 = new OleDbCommand("update ogrenciler set kitaplar='" + kitaplar + kitapadi + "-" + "'where numara='" + textBox2.Text + "'", baglanti);
                    update2.ExecuteNonQuery();
                    OleDbCommand insert = new OleDbCommand("insert into emanetkitap values('"+kitapadi+"','"+ogrenciadi+"','"+barkodno+"','"+DateTime.Now+"','"+textBox3.Text+"')",baglanti);
                    MessageBox.Show("Kitap başarıyla teslim edilmiştir!!!");
                    insert.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            catch (Exception hata)
            {
              
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,yazar AS Yazar,adet AS Adet,kategori AS Kategori,barkodno AS BarkodNumarası from kitaplar where kategori='"+comboBox1.Text+"'", baglanti);
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
    }
}

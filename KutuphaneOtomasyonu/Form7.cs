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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        int adet;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void kayitlarilistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,yazar AS Yazar,adet AS Adet,basimyili AS BasımYılı,kategori AS Kategori,barkodno AS BarkodNumarası,sayfasayisi AS SayfaSayısı,yayinevi AS Yayınevi from kitaplar", baglanti);
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
        private void Form7_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select adet from kitaplar where barkodno ='" + textBox1.Text + "'", baglanti);
                adet = Convert.ToInt32(select.ExecuteScalar());
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Değerler boş bırakılamaz!!");
                    baglanti.Close();
                }
                else if(adet < Convert.ToInt32(textBox2.Text))
                {
                    MessageBox.Show("Girdiğiniz sayı mevcut kitap sayısından daha fazla!");
                    baglanti.Close();
                }
                else
                {
                    if (adet== Convert.ToInt32(textBox2.Text))
                    {
                        OleDbDataAdapter silme = new OleDbDataAdapter("delete from kitaplar where barkodno='" + textBox1.Text + "'", baglanti);
                        DataSet dshafiza = new DataSet();
                        silme.Fill(dshafiza);
                    }
                    else
                    {
                        OleDbDataAdapter update = new OleDbDataAdapter("update kitaplar set adet='" + (adet - Convert.ToInt32(textBox2.Text)) + "'where barkodno='" + textBox1.Text + "'", baglanti);
                        DataSet dshafiza2 = new DataSet();
                        update.Fill(dshafiza2);
                    }

                    baglanti.Close();
                    MessageBox.Show("Kitap Silindi!", "Kitap İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    baglanti.Close();
                    kayitlarilistele();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }
    }
}

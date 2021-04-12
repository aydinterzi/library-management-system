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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void kayitlarilistele()
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,yazar AS Yazar,adet AS Adet,basimyili AS BasımYılı,kategori AS Kategori,barkodno AS BarkodNumarası,sayfasayisi AS SayfaSayısı,yayinevi AS Yayınevi,rafno AS RafNumarası,aciklama AS Açıklama from kitaplar", baglanti);
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
        private void Form8_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                baglanti.Open();
                OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,yazar AS Yazar,adet AS Adet,kategori AS Kategori,barkodno AS BarkodNumarası from kitaplar where kategori='" + comboBox1.Text + "'", baglanti);
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

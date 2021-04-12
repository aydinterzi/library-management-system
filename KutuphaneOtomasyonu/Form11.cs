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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void kayitlarigoster()
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
        private void Form11_Load(object sender, EventArgs e)
        {
            kayitlarigoster();  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex==1)
            {
                try
                {
                    baglanti.Open();
                    OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,ogrenciadi AS OgrenciAdı,barkodno AS BarkodNumarası,teslimtarihi AS TeslimTarihi,iadetarihi AS İadeTarihi from emanetkitap where'" + DateTime.Now.ToLongDateString()+"'>iadetarihi", baglanti);
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
            else if(comboBox1.SelectedIndex==2)
            {
                try
                {
                    baglanti.Open();
                    OleDbDataAdapter selectkomutu = new OleDbDataAdapter("select kitapadi AS KitapAdı,ogrenciadi AS OgrenciAdı,barkodno AS BarkodNumarası,teslimtarihi AS TeslimTarihi,iadetarihi AS İadeTarihi from emanetkitap where '" + DateTime.Now.ToLongDateString() + "'<iadetarihi", baglanti);
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
            else
            {
                kayitlarigoster();
            }
        }
    }
}

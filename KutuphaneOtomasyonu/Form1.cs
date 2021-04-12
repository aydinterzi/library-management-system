using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb;
namespace KutuphaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string kullanici;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=database.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select *from ogrenciler", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while(oku.Read())
                {

                    if(oku["kullaniciadi"].ToString()==textBox1.Text && oku["sifre"].ToString()==textBox2.Text)
                    {
                        kullanici = Convert.ToString(oku.GetValue(1));
                        MessageBox.Show("Başarıyla sisteme giriş yapıldı!", "Giriş İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Hide();
                        Form14 form14 = new Form14();
                        form14.Show();
                        return;
                    }
                }
                MessageBox.Show("Yanlış kullanıcı adı veya şifre girişi!");
                baglanti.Close();
            }
           else if (radioButton2.Checked == true)
            {
                baglanti.Open();
                OleDbCommand select = new OleDbCommand("select *from personeller", baglanti);
                OleDbDataReader oku = select.ExecuteReader();
                while (oku.Read())
                {
                    if (oku["kullaniciadi"].ToString() == textBox1.Text && oku["sifre"].ToString() == textBox2.Text)
                    {
                        MessageBox.Show("Başarıyla sisteme giriş yapıldı!", "Giriş İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Hide();
                        Form2 form2 = new Form2();
                        form2.Show();
                        return;
                    }
                   
                }
                 
                    MessageBox.Show("Yanlış kullanıcı adı veya şifre girişi!");
                
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Yanlış kullanıcı adı veya şifre girişi!");
            }

        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            int parola_skoru = 0;
            string parolaseviyesi = "";
            int kucuk_harf_skoru = 0, buyuk_harf_skoru = 0, rakam_skoru = 0, sembol_skoru = 0;
            string sifre = textBox4.Text;
            bool kayitdurumu = true;
            if (textBox3.Text.Length < 5)
            {
                errorProvider1.SetError(textBox3, "Kullanıcı adı minimum 5 karakterli olmalı!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox3, "");

            if (textBox6.Text != textBox4.Text)
            {
                errorProvider1.SetError(textBox6, "Şifreler eşleşmiyor!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox6, "");

            if(textBox5.Text=="")
            {
                errorProvider1.SetError(textBox5, "Email boş bırakılamaz!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox5, "");
            if (textBox7.Text == "")
            {
                errorProvider1.SetError(textBox7, "Ad Soyad boş bırakılamaz!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox7, "");
            if (textBox8.Text == "")
            {
                errorProvider1.SetError(textBox8, "Numara boş bırakılamaz!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox8, "");
            if (textBox9.Text == "")
            {
                errorProvider1.SetError(textBox9, "Email boş bırakılamaz!!");
                errorProvider1.BlinkRate = 400;
                errorProvider1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            }
            else
                errorProvider1.SetError(textBox9, "");

            int az_karaker_sayisi = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;
            kucuk_harf_skoru = Math.Min(2, az_karaker_sayisi) * 10;
          
            int AZ_karaker_sayisi = sifre.Length - Regex.Replace(sifre, "[A-Z]", "").Length;
            buyuk_harf_skoru = Math.Min(2, AZ_karaker_sayisi) * 10;
         
            int rakam_sayisi = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;
            rakam_skoru = Math.Min(2, rakam_sayisi) * 10;

            int sembol_sayisi = sifre.Length - az_karaker_sayisi - AZ_karaker_sayisi - rakam_sayisi;
            sembol_skoru = Math.Min(2, sembol_sayisi) * 10;

            parola_skoru = kucuk_harf_skoru + buyuk_harf_skoru + rakam_skoru + sembol_skoru;

            if (sifre.Length <= 9)
                parola_skoru += 10;
            else if (sifre.Length > 9)
                parola_skoru += 20;

            if (buyuk_harf_skoru == 0 || kucuk_harf_skoru == 0 || rakam_skoru == 0 || sembol_skoru == 0)
            {

                errorProvider1.SetError(textBox4, "Büyük harf, küçük harf, rakam ve sembol mutlaka kullanmalısınız!");
            }
            else
            {
                errorProvider1.SetError(textBox4, "");

            }

            if (textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" &&textBox3.Text.Length >= 5 && textBox6.Text == textBox4.Text && parola_skoru>=70 && textBox5.Text!="")
            {
                try
                {
                    baglanti.Open();
                    OleDbCommand ekle = new OleDbCommand("INSERT INTO ogrenciler (numara,adsoyad,kullaniciadi,sifre,bolum,eposta,cezadurumu) values('" + textBox8.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','"+textBox5.Text+"','"+"YOK"+"')", baglanti);
                    ekle.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Yeni öğrenci kaydı oluşturuldu!", "Kayıt İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
             
                 catch (Exception message)
                {
                MessageBox.Show(message.Message);
                baglanti.Close();
                }

        }
                
        }

        private void textBox_Click(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = "";
        }

      
    }
}

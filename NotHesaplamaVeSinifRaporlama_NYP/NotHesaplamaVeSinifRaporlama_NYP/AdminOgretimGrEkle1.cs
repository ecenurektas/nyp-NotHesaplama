using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrnekProje;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class AdminOgretimGrEkle1 : Form
    {
        public AdminOgretimGrEkle1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Database.Connection.State != ConnectionState.Open)
                    Database.Connection.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO OgretimGorevlisi (AdSoyad, KullaniciAdi) VALUES (@isim, @kullaniciad)", Database.Connection);
                cmd.Parameters.AddWithValue("@isim", textBox1.Text.ToString());
                string girilenIsim = textBox1.Text;
                string kullaniciAdi = girilenIsim.Replace(" ", "").ToLower();
                cmd.Parameters.AddWithValue("@kullaniciad", kullaniciAdi);
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                else
                    MessageBox.Show("Kullanıcı eklenemedi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}

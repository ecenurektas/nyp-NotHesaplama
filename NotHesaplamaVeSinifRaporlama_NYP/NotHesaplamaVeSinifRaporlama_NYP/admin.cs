using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using OrnekProje;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    
    public partial class admin : MaterialForm
    {
        public admin()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, AdminPanel);
        }

        static public string adminPassword;
        private void admin_Load(object sender, EventArgs e)
        {
            string kullaniciAdi = login.loginUserID.ToString();
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM OgretimGorevlisi WHERE KullaniciAdi = @kadi", Database.Connection);
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materialTextBox1.Text = reader["AdSoyad"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComboBox veri yüklenemedi: " + ex.Message);
            }
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Sifreler WHERE KullaniciAdi = @kadi", Database.Connection);
            cmd2.Parameters.AddWithValue("@kadi", login.loginUserID);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                adminPassword = reader2["Sifre"].ToString();
            }
            reader2.Close();

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            login login = new login();
            DialogResult result = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                login.Show();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
                return;
            }
            else
            {
                switch (materialComboBox1.SelectedItem.ToString())
                {
                    case "Ders Notu Gir":
                        ogretmen ogretmen = new ogretmen();
                        ogretmen.Show();
                        break;
                    case "Şifre Değiştir":
                        AdminSifre adminSifre = new AdminSifre();
                        adminSifre.Show();
                        break;
                    case "Veritabanına Ders Ekle":
                        admin_DB_dersEkle admin_DB_dersEkle = new admin_DB_dersEkle();
                        admin_DB_dersEkle.Show();
                        break;
                    case "Öğrenciye Ders Ekle":
                        adminOgrenciDersEkle adminOgrenciDersEkle = new adminOgrenciDersEkle();
                        adminOgrenciDersEkle.Show();
                        break;
                    case "Öğrenci Ekle":
                        adminOgrenciEkle adminEkle = new adminOgrenciEkle();
                        adminEkle.Show();
                        break;
                    case "Öğretim Görevlisi Ekle":
                        AdminOgretimGrEkle1 adminOgretimGrEkle1 = new AdminOgretimGrEkle1();
                        adminOgretimGrEkle1.Show();
                        break;
                    case "Öğrenci Sil":
                        adminOgrenciSil adminOgrenciSil = new adminOgrenciSil();
                        adminOgrenciSil.Show();
                        break;
                    case "Öğretim Görevlisi Sil":
                        adminOgretimGorevlisiSil adminOgretimGorevlisiSil = new adminOgretimGorevlisiSil();
                        adminOgretimGorevlisiSil.Show();
                        break;
                }
            }
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

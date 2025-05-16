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
using OrnekProje;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
                return;
            }
            else
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Admin Şifre Değiştir":
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
        static public string adminPassword;
        private void admin_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sifreler WHERE KullaniciAdi = @kadi", Database.Connection);
            cmd.Parameters.AddWithValue("@kadi", login.loginUserID);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                adminPassword = reader["Sifre"].ToString();
            }
            reader.Close();

        }
    }
}

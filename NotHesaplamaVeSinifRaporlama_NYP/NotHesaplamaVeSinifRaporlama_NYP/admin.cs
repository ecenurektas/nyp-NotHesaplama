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
                        //admin_DB_dersEkle adminEkle = new admin_DB_dersEkle();
                        break;
                    case "Öğrenciye Ders Ekle":
                        //admin_DB_ogrEkle adminEkle = new admin_DB_ogrEkle();
                        break;
                    case "Öğretim Görevlisine Ders Ekle":
                        //admin_DB_ogrEkle adminEkle = new admin_DB_ogrEkle();
                        break;
                    case "Öğrenci Ekle":
                        adminOgrenciEkle adminEkle = new adminOgrenciEkle();
                        adminEkle.Show();
                        break;
                    case "Öğretim Görevlisi Ekle":
                        //admin_DB_ogrSil adminEkle = new admin_DB_ogrSil();
                        break;
                    case "Öğrenci Sil":
                        //admin_DB_ogrEkle adminEkle = new admin_DB_ogrEkle();
                        break;
                    case "Öğretim Görevlisi Sil":
                        //admin_DB_ogrEkle adminEkle = new admin_DB_ogrEkle();
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

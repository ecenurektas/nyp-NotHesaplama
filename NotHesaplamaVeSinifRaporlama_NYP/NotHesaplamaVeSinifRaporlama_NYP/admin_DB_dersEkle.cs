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

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class admin_DB_dersEkle : Form
    {
        public admin_DB_dersEkle()
        {
            InitializeComponent();
        }

        private void admin_DB_dersEkle_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=NYPdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    DersleriListele();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT OgretimGrID, AdSoyad FROM OgretimGorevlisi", connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    comboBoxOgrGorevlisi.DisplayMember = "AdSoyad";
                    comboBoxOgrGorevlisi.ValueMember = "OgretimGrID";
                    comboBoxOgrGorevlisi.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Öğretim Görevlisi listesi yüklenemedi: " + ex.Message);
                }
            }
        }

        private void DersleriListele()
        {
            string connectionString = "Server=localhost;Database=NYPdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(@"
                    SELECT d.DersID, d.DersAdi, d.BolumKodu, d.Sinif, d.DersSirasi, d.Donem,
                    o.AdSoyad FROM Dersler d
                    LEFT JOIN OgretimGorevlisiDersleri od ON d.DersID = od.DersID
                    LEFT JOIN OgretimGorevlisi o ON od.OgretimGrID = o.OgretimGrID", connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            string bolum = comboBoxBolum.SelectedItem.ToString();
            int sinif = (int)numericUpDownSinif.Value;
            int sira = (int)numericUpDownSira.Value;
            int donem = (sira % 2 == 0) ? 2 : 1;
            string dersAdi = txtDersAdi.Text.Trim().ToUpper();
            string dersKodu = $"{bolum}{sinif}{sira:D2}";

            string connectionString = "Server=localhost;Database=NYPdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Dersler (DersID, DersAdi, BolumKodu, Sinif, DersSirasi, Donem) VALUES (@id, @adi, @bolum, @sinif, @sira, @donem)", connection);
                command.Parameters.AddWithValue("@id", dersKodu);
                command.Parameters.AddWithValue("@adi", dersAdi);
                command.Parameters.AddWithValue("@bolum", bolum);
                command.Parameters.AddWithValue("@sinif", sinif);
                command.Parameters.AddWithValue("@sira", sira);
                command.Parameters.AddWithValue("@donem", donem);
                command.ExecuteNonQuery();

                int ogretimGrID = Convert.ToInt32(comboBoxOgrGorevlisi.SelectedValue);
                SqlCommand command2 = new SqlCommand("INSERT INTO OgretimGorevlisiDersleri (OgretimGrID, DersID) VALUES (@ogrGrID, @dersID)", connection);
                command2.Parameters.AddWithValue("@ogrGrID", ogretimGrID);
                command2.Parameters.AddWithValue("@dersID", dersKodu);
                command2.ExecuteNonQuery();

                MessageBox.Show("Ders başarıyla eklendi.");
            }
            DersleriListele();
        }

        private void secButton_Click(object sender, EventArgs e)
        {
            int ogretimGrID = Convert.ToInt32(comboBoxOgrGorevlisi.SelectedValue);

            string connectionString = "Server=localhost;Database=NYPdb;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter(@"
                    SELECT d.DersID, d.DersAdi, d.BolumKodu, d.Sinif, d.DersSirasi, d.Donem,
                    o.AdSoyad AS OgretimGorevlisi FROM Dersler d 
                    INNER JOIN OgretimGorevlisiDersleri od ON d.DersID = od.DersID
                    INNER JOIN OgretimGorevlisi o ON od.OgretimGrID = o.OgretimGrID
                    WHERE od.OgretimGrID = @ogrGrID", connection);
                
                adapter.SelectCommand.Parameters.AddWithValue("@ogrGrID", ogretimGrID);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }
    }
}

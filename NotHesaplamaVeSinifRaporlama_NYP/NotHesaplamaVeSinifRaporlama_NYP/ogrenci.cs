using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using OrnekProje;
using MaterialSkin;
using MaterialSkin.Controls;
using System.Diagnostics;


namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class ogrenci : MaterialForm
    {
        public ogrenci()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, OgrenciPanel);
        }
        private void ortalamaHesapla()
        {
            Database.InitializeConnection();
            double toplamNot = 0.0;
            int gecerliNotSayisi = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    object harfNotuObj = row.Cells["HarfNotu"].Value;
                    if (harfNotuObj == DBNull.Value || string.IsNullOrWhiteSpace(harfNotuObj.ToString()))
                    {
                        continue;
                    }
                    materialTextBox1.Text+=gecerliNotSayisi.ToString() + " - " + harfNotuObj.ToString() + "\n";
                    string harfNotu = harfNotuObj.ToString();
                    double notDegeri = 0.0;

                    switch (harfNotu)
                    {
                        case "AA": notDegeri = 4.0; break;
                        case "BA": notDegeri = 3.5; break;
                        case "BB": notDegeri = 3.0; break;
                        case "CB": notDegeri = 2.5; break;
                        case "CC": notDegeri = 2.0; break;
                        case "DC": notDegeri = 1.5; break;
                        case "DD": notDegeri = 1.0; break;
                        case "FF": notDegeri = 0.0; break;
                        default: continue;
                    }

                    toplamNot += notDegeri;
                    gecerliNotSayisi++;
                }
            }

            if (gecerliNotSayisi > 0)
            {
                double ortalama = toplamNot / gecerliNotSayisi;
                ynoTextBox1.Text = ortalama.ToString();
            }
            else
            {
                ynoTextBox1.Text = "31.00";
            }
        }
        private void ogrenci_Load(object sender, EventArgs e)
        {
            DesignManager.StyleDataGridView(dataGridView1);
            string ogrenciID = login.loginUserID.ToString();
            string OgretimGrID = "";
            ortalamaHesapla();
            try
            {
                using (SqlCommand command = new SqlCommand("SELECT * FROM Ogrenci WHERE OgrenciID = @ogrenciID", Database.Connection))
                {
                    command.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        noTextBox1.Text = reader["OgrenciID"].ToString();
                        donemTextBox1.Text = reader["OgrenciDonem"].ToString();
                        //ynoTextBox1.Text = reader["YNO"].ToString();
                        OgretimGrID = reader["OgretimGrID"].ToString();
                    }
                    reader.Close();
                }

                // Danışman bilgilerini çekme
                using (SqlCommand command2 = new SqlCommand("SELECT * FROM OgretimGorevlisi WHERE OgretimGrID = @OgretimGrID", Database.Connection))
                {
                    command2.Parameters.AddWithValue("@OgretimGrID", OgretimGrID);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    if (reader2.Read())
                    {
                        danismanTextBox1.Text = reader2["AdSoyad"].ToString();
                    }
                    reader2.Close();
                }

                // Not bilgilerini çekme
                string notQuery = @"
            SELECT d.DersAdi, n.Vize, n.Final, n.HarfNotu 
            FROM Notlar n 
            JOIN Dersler d ON n.DersID = d.DersID 
            WHERE n.OgrenciID = @ogrenciID";

                using (SqlCommand command3 = new SqlCommand(notQuery, Database.Connection))
                {
                    command3.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command3);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sağlanamadı: " + ex.Message);
            }
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
    }
}

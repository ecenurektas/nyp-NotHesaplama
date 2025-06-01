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
        private void ogrenci_Load(object sender, EventArgs e)
        {
            DesignManager.StyleDataGridView(dataGridView1);
            string ogrenciID = login.loginUserID.ToString();
            string OgretimGrID = "";

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
                        ynoTextBox1.Text = reader["YNO"].ToString();
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

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


namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class ogrenci : Form
    {
        public ogrenci()
        {
            InitializeComponent();
        }

        private void ogrenci_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=.;Database=NYPdb;Trusted_Connection=True;";
            string ogrenciID = "20234410078";
            string OgretimGrID = "2";

            //Ogrenci bilgilerini cekme
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Ogrenci WHERE OgrenciID = @ogrenciID";

                using (SqlCommand command = new SqlCommand(query, connection)) 
                {
                    command.Parameters.AddWithValue("@ogrenciID", ogrenciID);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        noTextBox.Text = reader["OgrenciID"].ToString();
                        donemTextBox.Text = reader["OgrenciDonem"].ToString();
                        ynoTextBox.Text = reader["YNO"].ToString();
                    }
                    reader.Close();
                }

                // Danisman bilgilerini cekme
                string query2 = "SELECT * FROM OgretimGorevlisi WHERE OgretimGrID = @OgretimGrID";

                using (SqlCommand command2 = new SqlCommand(query2, connection))
                {
                    command2.Parameters.AddWithValue("@OgretimGrID", OgretimGrID);
                    SqlDataReader reader2 = command2.ExecuteReader();
                    if (reader2.Read())
                    {
                        danismanTextBox.Text = reader2["AdSoyad"].ToString();
                    }
                    reader2.Close();
                }

                // Not bilgilerini cekme
                string query3 = "SELECT d.DersAdi, n.Vize, n.Final, n.HarfNotu FROM Notlar n JOIN Dersler d ON n.DersID = d.DersID WHERE n.OgrenciID = @ogrenciID";
                using (SqlCommand command3 = new SqlCommand(query3, connection))
                {
                    command3.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                    SqlDataAdapter adapter = new SqlDataAdapter(command3);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }
    }
}

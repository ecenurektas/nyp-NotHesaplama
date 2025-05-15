using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OrnekProje;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class adminOgrenciEkle : Form
    {
        public adminOgrenciEkle()
        {
            InitializeComponent();
        }

        private void adminOgrenciEkle_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            SqlCommand cmd = new SqlCommand("SELECT * FROM OgretimGorevlisi", Database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["AdSoyad"].ToString());
            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Database.Connection.State != ConnectionState.Open)
                    Database.Connection.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO Ogrenci (OgrenciID, AdSoyad, OgretimGrID,OgrenciDonem) VALUES (@id, @isim, @ogrgr, @ogrdonem)", Database.Connection);
                cmd.Parameters.AddWithValue("@id", textBox1.Text.ToString());
                cmd.Parameters.AddWithValue("@isim", textBox2.Text.ToString());
                cmd.Parameters.AddWithValue("@ogrdonem", textBox3.Text.ToString());
                SqlCommand cmd2 = new SqlCommand("SELECT * FROM OgretimGorevlisi WHERE AdSoyad=@ad", Database.Connection);
                cmd2.Parameters.AddWithValue("@ad", comboBox1.SelectedItem.ToString());
                SqlDataReader reader = cmd2.ExecuteReader();
                string ogrGrID="";
                while (reader.Read())
                {
                    ogrGrID = reader["OgretimGrID"].ToString();
                }
                reader.Close();

                cmd.Parameters.AddWithValue("@ogrgr", ogrGrID);


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

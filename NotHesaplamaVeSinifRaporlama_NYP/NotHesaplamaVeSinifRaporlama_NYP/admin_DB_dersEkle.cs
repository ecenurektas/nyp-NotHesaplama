﻿using System;
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
using MaterialSkin.Controls;
using MaterialSkin;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class admin_DB_dersEkle : MaterialForm
    {
        public admin_DB_dersEkle()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, DersEklePanel);
        }

        private void admin_DB_dersEkle_Load(object sender, EventArgs e)
        {
            try
            {
                DesignManager.StyleDataGridView(dataGridView1);
                DersleriListele();

                SqlDataAdapter adapter = new SqlDataAdapter(
                    "SELECT OgretimGrId, AdSoyad FROM OgretimGorevlisi", Database.Connection);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                materialComboBox1.DisplayMember = "AdSoyad";
                materialComboBox1.ValueMember = "OgretimGrID";
                materialComboBox1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğretim Görevlisi listesi yüklenemedi: " + ex.Message);
            }
        }

        private void DersleriListele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(@"
        SELECT d.DersID, d.DersAdi, d.BolumKodu, d.Sinif, d.DersSirasi, d.Donem,
        o.AdSoyad FROM Dersler d
        LEFT JOIN OgretimGorevlisiDersleri od ON d.DersID = od.DersID
        LEFT JOIN OgretimGorevlisi o ON od.OgretimGrID = o.OgretimGrID", Database.Connection);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            string bolum = materialComboBox2.SelectedItem.ToString();
            int sinif = (int)numericUpDownSinif.Value;
            int sira = (int)numericUpDownSira.Value;
            int donem = (sira % 2 == 0) ? 2 : 1;
            string dersAdi = materialTextBox1.Text.Trim().ToUpper();
            string dersKodu = $"{bolum}{sinif}{sira:D2}";

            SqlCommand command = new SqlCommand(@"
        INSERT INTO Dersler (DersID, DersAdi, BolumKodu, Sinif, DersSirasi, Donem) 
        VALUES (@id, @adi, @bolum, @sinif, @sira, @donem)", Database.Connection);

            command.Parameters.AddWithValue("@id", dersKodu);
            command.Parameters.AddWithValue("@adi", dersAdi);
            command.Parameters.AddWithValue("@bolum", bolum);
            command.Parameters.AddWithValue("@sinif", sinif);
            command.Parameters.AddWithValue("@sira", sira);
            command.Parameters.AddWithValue("@donem", donem);
            command.ExecuteNonQuery();

            int ogretimGrID = Convert.ToInt32(materialComboBox1.SelectedValue);

            SqlCommand command2 = new SqlCommand(@"
        INSERT INTO OgretimGorevlisiDersleri (OgretimGrID, DersID) 
        VALUES (@ogrGrID, @dersID)", Database.Connection);

            command2.Parameters.AddWithValue("@ogrGrID", ogretimGrID);
            command2.Parameters.AddWithValue("@dersID", dersKodu);
            command2.ExecuteNonQuery();

            MessageBox.Show("Ders başarıyla eklendi.");
            DersleriListele();
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            int ogretimGrID = Convert.ToInt32(materialComboBox1.SelectedValue);

            SqlDataAdapter adapter = new SqlDataAdapter(@"
        SELECT d.DersID, d.DersAdi, d.BolumKodu, d.Sinif, d.DersSirasi, d.Donem,
               o.AdSoyad AS OgretimGorevlisi 
        FROM Dersler d 
        INNER JOIN OgretimGorevlisiDersleri od ON d.DersID = od.DersID
        INNER JOIN OgretimGorevlisi o ON od.OgretimGrID = o.OgretimGrID
        WHERE od.OgretimGrID = @ogrGrID", Database.Connection);

            adapter.SelectCommand.Parameters.AddWithValue("@ogrGrID", ogretimGrID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel3_Click(object sender, EventArgs e)
        {

        }

        private void materialLabel6_Click(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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
    public partial class adminOgrenciDersEkle : MaterialForm
    {
        public adminOgrenciDersEkle()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, OgrenciDersEklePanel);
        }

        private void adminOgrenciDersEkle_Load(object sender, EventArgs e)
        {
            SqlCommand cmd1 = new SqlCommand("SELECT * FROM Ogrenci", Database.Connection);
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                materialComboBox1.Items.Add(reader1["OgrenciID"].ToString() + " - " + reader1["AdSoyad"].ToString());
            }
            reader1.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Dersler", Database.Connection);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                checkedListBox1.Items.Add(reader2["DersID"].ToString() + " - " + reader2["DersAdi"].ToString());
            }
            reader2.Close();
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir öğrenci seçin.");
                return;
            }
            string secilenOgrenci = materialComboBox1.SelectedItem.ToString();
            string ogrenciID = secilenOgrenci.Split('-')[0].Trim();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                string ders = item.ToString();
                string dersID = ders.Split('-')[0].Trim();

                SqlCommand cmd = new SqlCommand("INSERT INTO OgrenciDersleri (OgrenciID, DersID, Donem) VALUES (@ogrenciID, @dersID, @donem)", Database.Connection);
                cmd.Parameters.AddWithValue("@ogrenciID", ogrenciID);
                cmd.Parameters.AddWithValue("@dersID", dersID);
                cmd.Parameters.AddWithValue("@donem", materialTextBox1.Text.ToString());

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }

            MessageBox.Show("Ders(ler) başarıyla eklendi.");
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

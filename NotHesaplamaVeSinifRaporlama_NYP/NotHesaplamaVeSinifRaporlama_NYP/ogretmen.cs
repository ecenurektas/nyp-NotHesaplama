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
using NotHesaplamaVeSinifRaporlama_NYP;
using OrnekProje;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MaterialSkin;
using MaterialSkin.Controls;


namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class ogretmen : MaterialForm
    {
        public ogretmen()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, OgretmenPanel);
        }
        private string ogrGorevlisiID = "";
        private void ogretmen_Load(object sender, EventArgs e)
        {
            DesignManager.StyleDataGridView(dataGridView1);
            string kullaniciAdi = login.loginUserID.ToString();
            materialComboBox1.SelectedIndex = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM OgretimGorevlisi WHERE KullaniciAdi = @kadi", Database.Connection);
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    materialTextBox1.Text = reader["AdSoyad"].ToString();
                    this.ogrGorevlisiID = reader["OgretimGrId"].ToString();
                }
                reader.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM OgretimGorevlisiDersleri WHERE OgretimGrID=" + this.ogrGorevlisiID, Database.Connection);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    materialComboBox1.Items.Add(reader2["DersID"].ToString());
                }
                reader2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComboBox veri yüklenemedi: " + ex.Message);
            }

        }
        private string secilen = "";
        private SqlDataAdapter adapter;
        private DataTable tablo;

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT * FROM Dersler WHERE DersID = @ad", Database.Connection);
                cmd1.Parameters.AddWithValue("@ad", materialComboBox1.SelectedItem.ToString());
                SqlDataReader reader1 = cmd1.ExecuteReader();
                while (reader1.Read())
                {
                    this.secilen = reader1["DersID"].ToString();
                }
                reader1.Close();
                if (Database.Connection.State != ConnectionState.Open)
                    Database.Connection.Open();
                SqlCommand komut = new SqlCommand("SELECT * FROM Notlar WHERE DersID = @id", Database.Connection);
                komut.Parameters.AddWithValue("@id", this.secilen);

                this.adapter = new SqlDataAdapter(komut);
                this.tablo = new DataTable();
                adapter.Fill(tablo);
                dataGridView1.DataSource = tablo;
                dataGridView1.ReadOnly = false;
                dataGridView1.Columns["Vize"].ReadOnly = false;
                dataGridView1.Columns["Final"].ReadOnly = false;
                dataGridView1.Columns["OgrenciID"].ReadOnly = true;
                dataGridView1.Columns["DersID"].ReadOnly = true;
                dataGridView1.Columns["HarfNotu"].ReadOnly = true;
                vizeFinalOrtalamaHesapla hesap1 = new vizeFinalOrtalamaHesapla();
                hesap1.hesapla(dataGridView1, materialTextBox2);
                harfNotuHesaplama hesap2 = new harfNotuHesaplama();
                hesap2.hesapla(dataGridView1, materialTextBox2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            try
            {
                vizeFinalOrtalamaHesapla hesap1 = new vizeFinalOrtalamaHesapla();
                hesap1.hesapla(dataGridView1, materialTextBox2);
                harfNotuHesaplama hesap2 = new harfNotuHesaplama();
                hesap2.hesapla(dataGridView1,materialTextBox2);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                this.adapter.Update(this.tablo);
                MessageBox.Show("Değişiklikler kaydedildi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
    public abstract class hesap
    {
        public abstract void hesapla(DataGridView datagrid,MaterialTextBox textbox);
    }
    public class harfNotuHesaplama : hesap
    {
        public override void hesapla(DataGridView datagrid, MaterialTextBox textbox)
        {
            foreach (DataGridViewRow row in datagrid.Rows)
            {
                if (!row.IsNewRow)
                {
                    object vizeObj = row.Cells["Vize"].Value;
                    object finalObj = row.Cells["Final"].Value;

                    if (vizeObj == DBNull.Value || finalObj == DBNull.Value ||
                        vizeObj == null || finalObj == null ||
                        string.IsNullOrWhiteSpace(vizeObj.ToString()) ||
                        string.IsNullOrWhiteSpace(finalObj.ToString()))
                    {
                        row.Cells["HarfNotu"].Value = DBNull.Value;
                        continue;
                    }
                    double vize = Convert.ToDouble(row.Cells["Vize"].Value);
                    double final = Convert.ToDouble(row.Cells["Final"].Value);
                    double ortalama = vize * 0.4 + final * 0.6;
                    if (ortalama > 90)
                    {
                        row.Cells["HarfNotu"].Value = "AA";
                    }
                    else if (ortalama > 85)
                    {
                        row.Cells["HarfNotu"].Value = "BA";
                    }
                    else if (ortalama > 75)
                    {
                        row.Cells["HarfNotu"].Value = "BB";
                    }
                    else if (ortalama > 65)
                    {
                        row.Cells["HarfNotu"].Value = "CB";
                    }
                    else if (ortalama > 60)
                    {
                        row.Cells["HarfNotu"].Value = "CC";
                    }
                    else if (ortalama > 55)
                    {
                        row.Cells["HarfNotu"].Value = "DC";
                    }
                    else if (ortalama > 50)
                    {
                        row.Cells["HarfNotu"].Value = "DD";
                    }
                    else if (ortalama > 40)
                    {
                        row.Cells["HarfNotu"].Value = "FD";
                    }
                    else
                    {
                        row.Cells["HarfNotu"].Value = "FF";
                    }
                }
            }
        }
    }
    public class vizeFinalOrtalamaHesapla : hesap
    {
        public override void hesapla(DataGridView datagrid, MaterialTextBox textbox)
        {
            int toplamVize = 0;
            int toplamFinal = 0;
            int sayac = 0;

            foreach (DataGridViewRow row in datagrid.Rows)
            {
                if (row.IsNewRow) continue;
                int vize, final;
                if (row.Cells["Vize"].Value != null && int.TryParse(row.Cells["Vize"].Value.ToString(), out vize))
                {
                    toplamVize += vize;
                }
                if (row.Cells["Final"].Value != null && int.TryParse(row.Cells["Final"].Value.ToString(), out final))
                {
                    toplamFinal += final;
                }

                sayac++;
            }

            if (sayac > 0)
            {
                double ortVize = (double)toplamVize / sayac;
                double ortFinal = (double)toplamFinal / sayac;

                textbox.Text = ("Vize: " + ortVize.ToString("0.00") +
                                " Final: " + ortFinal.ToString("0.00"));
            }
            else
            {
                textbox.Text = ("Ortalama hesaplanacak veri yok.");
            }
        }
    }
}
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
        private readonly MaterialSkinManager materialSkinManager;
        public ogretmen()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,     // Ana renk (arka plan)
                Primary.Blue900,     // Daha koyu ton
                Primary.Blue500,     // Butonlar vs.
                Accent.LightBlue200,     // Vurgu rengi
                TextShade.WHITE
            );
        }
        private string ogrGorevlisiID = "";
        private void ogretmen_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
            string kullaniciAdi = login.loginUserID.ToString();
            materialComboBox1.SelectedIndex = 0;
            try
            {

                SqlCommand cmd = new SqlCommand("SELECT * FROM OgretimGorevlisi WHERE KullaniciAdi = @kadi", Database.Connection);
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    textBox1.Text=reader["AdSoyad"].ToString();
                    this.ogrGorevlisiID = reader["OgretimGrId"].ToString();
                }
                reader.Close();

                SqlCommand cmd2 = new SqlCommand("SELECT * FROM OgretimGorevlisiDersleri WHERE OgretimGrID="+this.ogrGorevlisiID, Database.Connection);
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
        public void StyleDataGridView()
        {
            // Başlıkların kendi Windows temasını kapat, kendi stilimizi uygula
            dataGridView1.EnableHeadersVisualStyles = false;

            // Başlık arka plan ve yazı rengi
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);  // Material Blue 500
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Hücre stili
            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);  // Material Light Blue 300
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Satır yüksekliği
            dataGridView1.RowTemplate.Height = 35;

            // Grid çizgileri ve seçim modu
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.GridColor = Color.LightGray;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;

            // Alternatif satır rengini aç (opsiyonel)
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private string secilen = "";
        private SqlDataAdapter adapter;
        private DataTable tablo;
        private void harfNotuHesapla()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
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
        private void vizeFinalOrt()
        {
            int toplamVize = 0;
            int toplamFinal = 0;
            int sayac = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
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

                textBox2.Text = ("Vize Ortalaması: " + ortVize.ToString("0.00") +
                                "\r\nFinal Ortalaması: " + ortFinal.ToString("0.00"));
            }
            else
            {
                textBox2.Text = ("Ortalama hesaplanacak veri yok.");
            }
        }

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
                harfNotuHesapla();
                this.vizeFinalOrt();
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
                this.vizeFinalOrt();
                harfNotuHesapla();
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);
                this.adapter.Update(this.tablo);
                MessageBox.Show("Değişiklikler kaydedildi.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}

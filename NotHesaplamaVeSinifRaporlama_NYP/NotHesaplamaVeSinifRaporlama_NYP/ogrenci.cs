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
        private readonly MaterialSkinManager materialSkinManager;
        public ogrenci()
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
        private void ogrenci_Load(object sender, EventArgs e)
        {
            StyleDataGridView();
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
                        noTextBox.Text = reader["OgrenciID"].ToString();
                        donemTextBox.Text = reader["OgrenciDonem"].ToString();
                        ynoTextBox.Text = reader["YNO"].ToString();
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
                        danismanTextBox.Text = reader2["AdSoyad"].ToString();
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
    }
}

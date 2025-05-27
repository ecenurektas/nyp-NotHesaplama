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
using OrnekProje;
using MaterialSkin.Controls;
using MaterialSkin;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class adminOgretimGorevlisiSil : MaterialForm
    {
        public adminOgretimGorevlisiSil()
        {
            InitializeComponent();

            DesignManager.ApplyTheme(this);
        }

        private void adminOgretimGorevlisiSil_Load(object sender, EventArgs e)
        {
            tablo();
        }
        private void tablo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM OgretimGorevlisi", Database.Connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(materialTextBox1.Text))
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğretim görevlisinin ID'sini girin.");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM OgretimGorevlisi WHERE OgretimGrID = @ID", Database.Connection);
                    cmd.Parameters.AddWithValue("@ID", materialTextBox1.Text.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğretim görevlisi silindi.");
                    tablo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğretim görevlisi silinemedi: " + ex.Message);
            }
        }
    }
}

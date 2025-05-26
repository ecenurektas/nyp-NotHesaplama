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
    public partial class adminOgrenciSil : MaterialForm
    {
        public adminOgrenciSil()
        {
            InitializeComponent();

            DesignManager.ApplyTheme(this);
        }

        private void adminOgrenciSil_Load(object sender, EventArgs e)
        {
            tablo();
            DesignManager.StyleDataGridView(dataGridView1);

        }
        private void tablo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenci", Database.Connection);
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
                    MessageBox.Show("Lütfen silmek istediğiniz öğrencinin ID'sini girin.");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Ogrenci WHERE OgrenciID = @OgrenciID", Database.Connection);
                    cmd.Parameters.AddWithValue("@OgrenciID", materialTextBox1.Text.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci silindi.");
                    tablo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Öğrenci silinemedi: " + ex.Message);
            }
        }
    }
}

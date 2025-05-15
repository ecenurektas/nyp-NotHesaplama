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

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class adminOgrenciSil : Form
    {
        public adminOgrenciSil()
        {
            InitializeComponent();
        }

        private void adminOgrenciSil_Load(object sender, EventArgs e)
        {
            tablo();

        }
        private void tablo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenci", Database.Connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Lütfen silmek istediğiniz öğrencinin ID'sini girin.");
                    return;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand("DELETE FROM Ogrenci WHERE OgrenciID = @OgrenciID", Database.Connection);
                    cmd.Parameters.AddWithValue("@OgrenciID", textBox1.Text.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci silindi.");
                    tablo();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Öğrenci silinemedi: " + ex.Message);
            }
        }
    }
}

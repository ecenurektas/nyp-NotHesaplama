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
using NotHesaplamaVeSinifRaporlama_NYP;
using OrnekProje;


namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class ogretmen : Form
    {
        public ogretmen()
        {
            InitializeComponent();
            this.Load += ogretmen_Load;

        }

        private void ogretmen_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT KitapAdi FROM Kitaplar", Database.Connection);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["KitapAdi"].ToString());
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ComboBox veri yüklenemedi: " + ex.Message);
            }
        }
    }
}

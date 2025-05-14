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
    public partial class AdminSifre : Form
    {
        public AdminSifre()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == admin.adminPassword)
            {
                if (textBox2.Text == textBox3.Text)
                {
                    if (Database.Connection.State != ConnectionState.Open)
                        Database.Connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Sifreler SET Sifre = @sifre WHERE KullaniciAdi = @kadi", Database.Connection);
                    cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                    cmd.Parameters.AddWithValue("@kadi", login.loginUserID);
                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0) {
                        MessageBox.Show("Şifre başarıyla değiştirildi.");
                    }
                    else
                    {
                        MessageBox.Show("Şifre değiştirilemedi.");
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Yeni şifreler eşleşmiyor.");
                }
            }
            else
            {
                MessageBox.Show("Eski şifre yanlış.");
            }
        }
    }
}

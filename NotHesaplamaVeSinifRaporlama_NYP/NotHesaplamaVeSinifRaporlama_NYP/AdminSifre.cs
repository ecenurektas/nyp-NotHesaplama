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
    public partial class AdminSifre : MaterialForm
    {
        public AdminSifre()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, AdminSifreOlusturPanel);
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (materialTextBox1.Text == admin.adminPassword)
            {
                if (materialTextBox2.Text == materialTextBox3.Text)
                {
                    if (Database.Connection.State != ConnectionState.Open)
                        Database.Connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Sifreler SET Sifre = @sifre WHERE KullaniciAdi = @kadi", Database.Connection);
                    cmd.Parameters.AddWithValue("@sifre", materialTextBox2.Text);
                    cmd.Parameters.AddWithValue("@kadi", login.loginUserID);
                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

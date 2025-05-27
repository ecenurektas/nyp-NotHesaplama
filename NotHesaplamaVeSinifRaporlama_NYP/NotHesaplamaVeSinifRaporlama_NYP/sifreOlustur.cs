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
using MaterialSkin;
using MaterialSkin.Controls;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class sifreOlustur : MaterialForm
    {
        public sifreOlustur()
        {
            InitializeComponent();

            DesignManager.ApplyTheme(this);
        }

        private void sifreOlustur_Load(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            int login = 0;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sifreler", Database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (materialTextBox1.Text == reader["KullaniciAdi"].ToString())
                {
                    if (reader["Sifre"].ToString() != "")
                    {
                        MessageBox.Show("Bu kullanıcıya ait bir şifre zaten var.");
                        return;
                    }
                    else
                    {
                        login = 1;
                        SqlCommand cmd2 = new SqlCommand("UPDATE Sifreler SET Sifre=@sifre WHERE KullaniciAdi=@kullaniciadi", Database.Connection);
                        cmd2.Parameters.AddWithValue("@sifre", materialTextBox2.Text);
                        cmd2.Parameters.AddWithValue("@kullaniciadi", materialTextBox1.Text);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Şifre başarıyla oluşturuldu.");
                        this.Close();
                    }
                }
            }
            if (login == 0)
            {
                MessageBox.Show("Kullanıcı adı bulunamadı.");
            }
            reader.Close();
        }
    }
}

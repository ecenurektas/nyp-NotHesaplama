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
    public partial class sifreOlustur : Form
    {
        public sifreOlustur()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int login = 0;
            SqlCommand cmd = new SqlCommand("SELECT * FROM Sifreler", Database.Connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (textBox1.Text == reader["KullaniciAdi"].ToString())
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
                        cmd2.Parameters.AddWithValue("@sifre", textBox2.Text);
                        cmd2.Parameters.AddWithValue("@kullaniciadi", textBox1.Text);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Şifre başarıyla oluşturuldu.");
                        this.Close();
                    }
                }
            }
            if(login == 0)
            {
                MessageBox.Show("Kullanıcı adı bulunamadı.");
            }
            reader.Close();
        }
    }
}

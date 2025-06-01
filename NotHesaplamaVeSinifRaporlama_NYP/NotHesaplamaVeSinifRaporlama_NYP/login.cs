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
    public partial class login : MaterialForm
    {
        public login()
        {
            InitializeComponent();
            DesignManager.ApplyTheme(this);
            DesignManager.CenterControl(this, LoginPanel);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        static public string loginUserID;

        private void materialButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int login = 0;
                SqlCommand cmd = new SqlCommand("SELECT * FROM Sifreler", Database.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (materialTextBox1.Text == reader["KullaniciAdi"].ToString() && materialTextBox2.Text == reader["Sifre"].ToString())
                    {
                        if (materialTextBox2.Text == "")
                        {
                            MessageBox.Show("Şifre boş olamaz.");
                            return;
                        }
                        if (reader["Rol"].ToString() == "OgrGr")
                        {
                            login = 1;
                            loginUserID = reader["KullaniciAdi"].ToString();
                            admin ogretmenForm = new admin();
                            ogretmenForm.Show();
                            this.Hide();
                        }
                        else if (reader["Rol"].ToString() == "ogr")
                        {
                            login = 1;
                            loginUserID = reader["KullaniciAdi"].ToString();
                            ogrenci ogrenciForm = new ogrenci();
                            ogrenciForm.Show();
                            this.Hide();
                        }
                    }
                }
                if (login == 0)
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına baplantı hatası: " + ex.Message);
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            sifreOlustur sifreSayfa = new sifreOlustur();
            sifreSayfa.Show();
        }

        private void LoginPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}

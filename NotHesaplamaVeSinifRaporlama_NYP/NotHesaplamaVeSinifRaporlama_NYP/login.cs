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
        private readonly MaterialSkinManager materialSkinManager;
        public login()
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
                    if (textBox1.Text == reader["KullaniciAdi"].ToString() && textBox2.Text == reader["Sifre"].ToString())
                    {
                        if (textBox2.Text == "")
                        {
                            MessageBox.Show("Şifre boş olamaz.");
                            return;
                        }
                        if (reader["Rol"].ToString() == "OgrGr")
                        {
                            login = 1;
                            loginUserID = reader["KullaniciAdi"].ToString();
                            ogretmen ogretmenForm = new ogretmen();
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
                        else if (reader["Rol"].ToString() == "admin")
                        {
                            login = 1;
                            loginUserID = reader["KullaniciAdi"].ToString();
                            admin adminForm = new admin();
                            adminForm.Show();
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
    }
}

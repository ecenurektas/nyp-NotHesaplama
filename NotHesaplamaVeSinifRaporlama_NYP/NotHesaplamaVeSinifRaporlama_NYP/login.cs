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
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ogretmen ogretmenForm = new ogretmen();
            ogretmenForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ogrenci ogrenciForm = new ogrenci();
            ogrenciForm.Show();
        }
        static public string loginUserID;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int login = 0;
                SqlCommand cmd = new SqlCommand("SELECT * FROM OgrenciSifreleri", Database.Connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {  
                    if (textBox1.Text == reader["OgrenciID"].ToString() && textBox2.Text == reader["SifreHash"].ToString())
                    {
                        loginUserID = reader["OgrenciID"].ToString();
                        ogrenci ogrenciForm = new ogrenci();
                        ogrenciForm.Show();
                        this.Hide();
                        login = 1;
                    }
                }
                if(login==0)
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı.");
                reader.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Veritabanına baplantı hatası: " + ex.Message);
            }
        }
    }
}

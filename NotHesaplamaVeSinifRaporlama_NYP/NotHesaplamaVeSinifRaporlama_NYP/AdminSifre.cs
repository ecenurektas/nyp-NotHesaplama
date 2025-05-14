using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    admin.adminPassword = textBox2.Text;
                    MessageBox.Show("Şifre başarıyla değiştirildi.");
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

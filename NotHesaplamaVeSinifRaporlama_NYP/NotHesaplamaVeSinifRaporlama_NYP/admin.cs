using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        static public string adminPassword = "admin";
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir işlem seçin.");
                return;
            }
            else
            {
                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Admin Şifre Değiştir":
                        AdminSifre adminSifre = new AdminSifre();
                        adminSifre.Show();
                        break;
                    case "Öğrenci Ekle":
                        
                        break;
                }
            }

        }

        private void admin_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
    }
}

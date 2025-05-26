using MaterialSkin;
using MaterialSkin.Controls;
using System.Drawing;
using System.Windows.Forms;

namespace NotHesaplamaVeSinifRaporlama_NYP
{
    public static class DesignManager
    {
        private static MaterialSkinManager materialSkinManager;

        static DesignManager()
        {
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue800,
                Primary.Blue900,
                Primary.Blue500,
                Accent.LightBlue200,
                TextShade.WHITE
            );
        }

        public static void ApplyTheme(MaterialForm form)
        {
            materialSkinManager.AddFormToManage(form);
        }
        public static void StyleDataGridView(DataGridView grid)
        {
            // Başlıkların kendi Windows temasını kapat, kendi stilimizi uygula
            grid.EnableHeadersVisualStyles = false;

            // Başlık arka plan ve yazı rengi
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);  // Material Blue 500
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Hücre stili
            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(33, 33, 33);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 181, 246);  // Material Light Blue 300
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            // Satır yüksekliği
            grid.RowTemplate.Height = 35;

            // Grid çizgileri ve seçim modu
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.LightGray;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;

            // Alternatif satır rengini aç (opsiyonel)
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            grid.AllowUserToAddRows = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
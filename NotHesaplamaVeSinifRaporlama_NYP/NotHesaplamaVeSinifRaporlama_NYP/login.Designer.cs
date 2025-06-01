namespace NotHesaplamaVeSinifRaporlama_NYP
{
    partial class login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialButton1 = new MaterialSkin.Controls.MaterialButton();
            this.materialButton2 = new MaterialSkin.Controls.MaterialButton();
            this.materialTextBox1 = new MaterialSkin.Controls.MaterialTextBox();
            this.materialTextBox2 = new MaterialSkin.Controls.MaterialTextBox();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.LoginPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSize = false;
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.Location = new System.Drawing.Point(176, 333);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(175, 40);
            this.materialButton1.TabIndex = 8;
            this.materialButton1.Text = "Giriş Yap";
            this.materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.materialButton1_Click);
            // 
            // materialButton2
            // 
            this.materialButton2.AutoSize = false;
            this.materialButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton2.Depth = 0;
            this.materialButton2.HighEmphasis = true;
            this.materialButton2.Icon = null;
            this.materialButton2.Location = new System.Drawing.Point(176, 398);
            this.materialButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialButton2.Name = "materialButton2";
            this.materialButton2.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton2.Size = new System.Drawing.Size(175, 40);
            this.materialButton2.TabIndex = 9;
            this.materialButton2.Text = "Şifre Oluştur";
            this.materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton2.UseAccentColor = false;
            this.materialButton2.UseVisualStyleBackColor = true;
            this.materialButton2.Click += new System.EventHandler(this.materialButton2_Click);
            // 
            // materialTextBox1
            // 
            this.materialTextBox1.AnimateReadOnly = false;
            this.materialTextBox1.BackColor = System.Drawing.Color.White;
            this.materialTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox1.Depth = 0;
            this.materialTextBox1.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox1.LeadingIcon = null;
            this.materialTextBox1.Location = new System.Drawing.Point(176, 155);
            this.materialTextBox1.MaxLength = 50;
            this.materialTextBox1.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox1.Multiline = false;
            this.materialTextBox1.Name = "materialTextBox1";
            this.materialTextBox1.Size = new System.Drawing.Size(175, 36);
            this.materialTextBox1.TabIndex = 11;
            this.materialTextBox1.Text = "";
            this.materialTextBox1.TrailingIcon = null;
            this.materialTextBox1.UseAccent = false;
            this.materialTextBox1.UseTallSize = false;
            // 
            // materialTextBox2
            // 
            this.materialTextBox2.AnimateReadOnly = false;
            this.materialTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.materialTextBox2.Depth = 0;
            this.materialTextBox2.Font = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialTextBox2.LeadingIcon = null;
            this.materialTextBox2.Location = new System.Drawing.Point(176, 254);
            this.materialTextBox2.MaxLength = 50;
            this.materialTextBox2.MouseState = MaterialSkin.MouseState.OUT;
            this.materialTextBox2.Multiline = false;
            this.materialTextBox2.Name = "materialTextBox2";
            this.materialTextBox2.Password = true;
            this.materialTextBox2.Size = new System.Drawing.Size(175, 36);
            this.materialTextBox2.TabIndex = 12;
            this.materialTextBox2.Text = "";
            this.materialTextBox2.TrailingIcon = null;
            this.materialTextBox2.UseAccent = false;
            this.materialTextBox2.UseTallSize = false;
            // 
            // LoginPanel
            // 
            this.LoginPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LoginPanel.Controls.Add(this.materialLabel2);
            this.LoginPanel.Controls.Add(this.materialLabel1);
            this.LoginPanel.Controls.Add(this.materialTextBox2);
            this.LoginPanel.Controls.Add(this.materialButton1);
            this.LoginPanel.Controls.Add(this.materialButton2);
            this.LoginPanel.Controls.Add(this.materialTextBox1);
            this.LoginPanel.Location = new System.Drawing.Point(144, 97);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(519, 503);
            this.LoginPanel.TabIndex = 16;
            this.LoginPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.LoginPanel_Paint);
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel2.Location = new System.Drawing.Point(182, 223);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(38, 19);
            this.materialLabel2.TabIndex = 17;
            this.materialLabel2.Text = "Şifre:";
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.BackColor = System.Drawing.Color.Transparent;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.materialLabel1.Location = new System.Drawing.Point(182, 123);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(93, 19);
            this.materialLabel1.TabIndex = 16;
            this.materialLabel1.Text = "Kullanıcı Adı:";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(819, 652);
            this.Controls.Add(this.LoginPanel);
            this.Name = "login";
            this.Padding = new System.Windows.Forms.Padding(2, 41, 2, 2);
            this.Text = "Giriş Sayfası";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox1;
        private MaterialSkin.Controls.MaterialTextBox materialTextBox2;
        private System.Windows.Forms.Panel LoginPanel;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
    }
}


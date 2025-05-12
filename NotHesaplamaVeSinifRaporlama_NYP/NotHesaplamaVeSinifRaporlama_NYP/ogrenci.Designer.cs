namespace NotHesaplamaVeSinifRaporlama_NYP
{
    partial class ogrenci
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.noTextBox = new System.Windows.Forms.TextBox();
            this.danismanTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ynoTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.donemTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenci Numarası:";
            // 
            // noTextBox
            // 
            this.noTextBox.Location = new System.Drawing.Point(140, 12);
            this.noTextBox.Name = "noTextBox";
            this.noTextBox.ReadOnly = true;
            this.noTextBox.Size = new System.Drawing.Size(121, 22);
            this.noTextBox.TabIndex = 4;
            // 
            // danismanTextBox
            // 
            this.danismanTextBox.Location = new System.Drawing.Point(362, 12);
            this.danismanTextBox.Name = "danismanTextBox";
            this.danismanTextBox.ReadOnly = true;
            this.danismanTextBox.Size = new System.Drawing.Size(138, 22);
            this.danismanTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(285, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Danışman:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(521, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dönem:";
            // 
            // ynoTextBox
            // 
            this.ynoTextBox.Location = new System.Drawing.Point(798, 12);
            this.ynoTextBox.Name = "ynoTextBox";
            this.ynoTextBox.ReadOnly = true;
            this.ynoTextBox.Size = new System.Drawing.Size(154, 22);
            this.ynoTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(754, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "GPA:";
            // 
            // donemTextBox
            // 
            this.donemTextBox.Location = new System.Drawing.Point(581, 12);
            this.donemTextBox.Name = "donemTextBox";
            this.donemTextBox.ReadOnly = true;
            this.donemTextBox.Size = new System.Drawing.Size(138, 22);
            this.donemTextBox.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 66);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1064, 445);
            this.dataGridView1.TabIndex = 12;
            // 
            // ogrenci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 523);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.donemTextBox);
            this.Controls.Add(this.ynoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.danismanTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.noTextBox);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ogrenci";
            this.Text = "Öğrenci";
            this.Load += new System.EventHandler(this.ogrenci_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox noTextBox;
        private System.Windows.Forms.TextBox danismanTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ynoTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox donemTextBox;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}
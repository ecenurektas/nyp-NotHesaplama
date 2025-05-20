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
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(23, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Öğrenci Numarası:";
            // 
            // noTextBox
            // 
            this.noTextBox.Location = new System.Drawing.Point(209, 142);
            this.noTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.noTextBox.Name = "noTextBox";
            this.noTextBox.ReadOnly = true;
            this.noTextBox.Size = new System.Drawing.Size(180, 31);
            this.noTextBox.TabIndex = 4;
            // 
            // danismanTextBox
            // 
            this.danismanTextBox.Location = new System.Drawing.Point(542, 142);
            this.danismanTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.danismanTextBox.Name = "danismanTextBox";
            this.danismanTextBox.ReadOnly = true;
            this.danismanTextBox.Size = new System.Drawing.Size(205, 31);
            this.danismanTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(427, 146);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Danışman:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(781, 146);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Dönem:";
            // 
            // ynoTextBox
            // 
            this.ynoTextBox.Location = new System.Drawing.Point(1196, 142);
            this.ynoTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ynoTextBox.Name = "ynoTextBox";
            this.ynoTextBox.ReadOnly = true;
            this.ynoTextBox.Size = new System.Drawing.Size(229, 31);
            this.ynoTextBox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1130, 146);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "GPA:";
            // 
            // donemTextBox
            // 
            this.donemTextBox.Location = new System.Drawing.Point(871, 142);
            this.donemTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.donemTextBox.Name = "donemTextBox";
            this.donemTextBox.ReadOnly = true;
            this.donemTextBox.Size = new System.Drawing.Size(205, 31);
            this.donemTextBox.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(28, 197);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1398, 601);
            this.dataGridView1.TabIndex = 12;
            // 
            // ogrenci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1492, 813);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.donemTextBox);
            this.Controls.Add(this.ynoTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.danismanTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.noTextBox);
            this.Controls.Add(this.label2);
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
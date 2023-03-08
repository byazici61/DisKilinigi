
namespace DisKilinigi.UI
{
    partial class frmRapor
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
			this.lvTumHastalar = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnAdaGoreFiltrele = new System.Windows.Forms.Button();
			this.txtAranacakAd = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbDoktorlar = new System.Windows.Forms.ComboBox();
			this.btnDoktoraGoreFiltrele = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cmbTedaviDurumu = new System.Windows.Forms.ComboBox();
			this.btnTedaviDurumunaGöreFiltrele = new System.Windows.Forms.Button();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dtp2 = new System.Windows.Forms.DateTimePicker();
			this.dtp1 = new System.Windows.Forms.DateTimePicker();
			this.btnTariheGoreFiltrele = new System.Windows.Forms.Button();
			this.btnFiltelemeyiSifirla = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvTumHastalar
			// 
			this.lvTumHastalar.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader5});
			this.lvTumHastalar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lvTumHastalar.HideSelection = false;
			this.lvTumHastalar.Location = new System.Drawing.Point(0, 260);
			this.lvTumHastalar.Name = "lvTumHastalar";
			this.lvTumHastalar.Size = new System.Drawing.Size(819, 338);
			this.lvTumHastalar.TabIndex = 0;
			this.lvTumHastalar.UseCompatibleStateImageBehavior = false;
			this.lvTumHastalar.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Adı Soyadı";
			this.columnHeader1.Width = 97;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Kimlik Num.";
			this.columnHeader2.Width = 109;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Doğum Tarihi";
			this.columnHeader8.Width = 93;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Doktor";
			this.columnHeader3.Width = 106;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Yapılan İslem";
			this.columnHeader4.Width = 72;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Randevu Tarihi";
			this.columnHeader6.Width = 129;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Tedavi Durumu";
			this.columnHeader7.Width = 93;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Ücret";
			this.columnHeader5.Width = 99;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Transparent;
			this.groupBox1.Controls.Add(this.btnAdaGoreFiltrele);
			this.groupBox1.Controls.Add(this.txtAranacakAd);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(13, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(194, 211);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Ad Soyad Bilgisine Göre Listele";
			// 
			// btnAdaGoreFiltrele
			// 
			this.btnAdaGoreFiltrele.Location = new System.Drawing.Point(113, 182);
			this.btnAdaGoreFiltrele.Name = "btnAdaGoreFiltrele";
			this.btnAdaGoreFiltrele.Size = new System.Drawing.Size(75, 23);
			this.btnAdaGoreFiltrele.TabIndex = 2;
			this.btnAdaGoreFiltrele.Text = "Filtrele";
			this.btnAdaGoreFiltrele.UseVisualStyleBackColor = true;
			this.btnAdaGoreFiltrele.Click += new System.EventHandler(this.btnAdaGoreFiltrele_Click);
			// 
			// txtAranacakAd
			// 
			this.txtAranacakAd.Location = new System.Drawing.Point(10, 55);
			this.txtAranacakAd.Name = "txtAranacakAd";
			this.txtAranacakAd.Size = new System.Drawing.Size(126, 20);
			this.txtAranacakAd.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Hasta Ad Soyad: ";
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Transparent;
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.cmbDoktorlar);
			this.groupBox2.Controls.Add(this.btnDoktoraGoreFiltrele);
			this.groupBox2.Location = new System.Drawing.Point(213, 43);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(194, 211);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Doktor Bilgisine Göre Listele";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(93, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Doktor Ad Soyadı:";
			// 
			// cmbDoktorlar
			// 
			this.cmbDoktorlar.FormattingEnabled = true;
			this.cmbDoktorlar.Location = new System.Drawing.Point(6, 55);
			this.cmbDoktorlar.Name = "cmbDoktorlar";
			this.cmbDoktorlar.Size = new System.Drawing.Size(181, 21);
			this.cmbDoktorlar.TabIndex = 3;
			// 
			// btnDoktoraGoreFiltrele
			// 
			this.btnDoktoraGoreFiltrele.Location = new System.Drawing.Point(113, 182);
			this.btnDoktoraGoreFiltrele.Name = "btnDoktoraGoreFiltrele";
			this.btnDoktoraGoreFiltrele.Size = new System.Drawing.Size(75, 23);
			this.btnDoktoraGoreFiltrele.TabIndex = 2;
			this.btnDoktoraGoreFiltrele.Text = "Filtrele";
			this.btnDoktoraGoreFiltrele.UseVisualStyleBackColor = true;
			this.btnDoktoraGoreFiltrele.Click += new System.EventHandler(this.btnDoktoraGoreFiltrele_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.cmbTedaviDurumu);
			this.groupBox3.Controls.Add(this.btnTedaviDurumunaGöreFiltrele);
			this.groupBox3.Location = new System.Drawing.Point(413, 43);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(194, 211);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tedavi Durumuna Göre Listele";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 28);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(83, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Tedavi Durumu:";
			// 
			// cmbTedaviDurumu
			// 
			this.cmbTedaviDurumu.FormattingEnabled = true;
			this.cmbTedaviDurumu.Items.AddRange(new object[] {
            "Devam Ediyor",
            "Tamamlandı"});
			this.cmbTedaviDurumu.Location = new System.Drawing.Point(5, 55);
			this.cmbTedaviDurumu.Name = "cmbTedaviDurumu";
			this.cmbTedaviDurumu.Size = new System.Drawing.Size(181, 21);
			this.cmbTedaviDurumu.TabIndex = 3;
			// 
			// btnTedaviDurumunaGöreFiltrele
			// 
			this.btnTedaviDurumunaGöreFiltrele.Location = new System.Drawing.Point(113, 182);
			this.btnTedaviDurumunaGöreFiltrele.Name = "btnTedaviDurumunaGöreFiltrele";
			this.btnTedaviDurumunaGöreFiltrele.Size = new System.Drawing.Size(75, 23);
			this.btnTedaviDurumunaGöreFiltrele.TabIndex = 2;
			this.btnTedaviDurumunaGöreFiltrele.Text = "Filtrele";
			this.btnTedaviDurumunaGöreFiltrele.UseVisualStyleBackColor = true;
			this.btnTedaviDurumunaGöreFiltrele.Click += new System.EventHandler(this.btnTedaviDurumunaGöreFiltrele_Click);
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.Color.Transparent;
			this.groupBox4.Controls.Add(this.label1);
			this.groupBox4.Controls.Add(this.dtp2);
			this.groupBox4.Controls.Add(this.dtp1);
			this.groupBox4.Controls.Add(this.btnTariheGoreFiltrele);
			this.groupBox4.Location = new System.Drawing.Point(613, 43);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(194, 211);
			this.groupBox4.TabIndex = 1;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Tarihe Göre Listele";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Tarih Aralığı :";
			// 
			// dtp2
			// 
			this.dtp2.Location = new System.Drawing.Point(7, 97);
			this.dtp2.Name = "dtp2";
			this.dtp2.Size = new System.Drawing.Size(181, 20);
			this.dtp2.TabIndex = 3;
			// 
			// dtp1
			// 
			this.dtp1.Location = new System.Drawing.Point(6, 54);
			this.dtp1.Name = "dtp1";
			this.dtp1.Size = new System.Drawing.Size(181, 20);
			this.dtp1.TabIndex = 3;
			// 
			// btnTariheGoreFiltrele
			// 
			this.btnTariheGoreFiltrele.Location = new System.Drawing.Point(113, 182);
			this.btnTariheGoreFiltrele.Name = "btnTariheGoreFiltrele";
			this.btnTariheGoreFiltrele.Size = new System.Drawing.Size(75, 23);
			this.btnTariheGoreFiltrele.TabIndex = 2;
			this.btnTariheGoreFiltrele.Text = "Filtrele";
			this.btnTariheGoreFiltrele.UseVisualStyleBackColor = true;
			this.btnTariheGoreFiltrele.Click += new System.EventHandler(this.btnTariheGoreFiltrele_Click);
			// 
			// btnFiltelemeyiSifirla
			// 
			this.btnFiltelemeyiSifirla.Location = new System.Drawing.Point(612, 12);
			this.btnFiltelemeyiSifirla.Name = "btnFiltelemeyiSifirla";
			this.btnFiltelemeyiSifirla.Size = new System.Drawing.Size(195, 25);
			this.btnFiltelemeyiSifirla.TabIndex = 2;
			this.btnFiltelemeyiSifirla.Text = "Filtrelemeyi Sıfırla";
			this.btnFiltelemeyiSifirla.UseVisualStyleBackColor = true;
			this.btnFiltelemeyiSifirla.Click += new System.EventHandler(this.btnFiltelemeyiSifirla_Click);
			// 
			// frmRapor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::DisKilinigi.UI.Properties.Resources.EMREIPOR_EFSANE;
			this.ClientSize = new System.Drawing.Size(819, 598);
			this.Controls.Add(this.btnFiltelemeyiSifirla);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.lvTumHastalar);
			this.Name = "frmRapor";
			this.Text = "RAPORLAR";
			this.Load += new System.EventHandler(this.FrmRaporPenceresi_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvTumHastalar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAdaGoreFiltrele;
        private System.Windows.Forms.TextBox txtAranacakAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDoktorlar;
        private System.Windows.Forms.Button btnDoktoraGoreFiltrele;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTedaviDurumu;
        private System.Windows.Forms.Button btnTedaviDurumunaGöreFiltrele;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp2;
        private System.Windows.Forms.DateTimePicker dtp1;
        private System.Windows.Forms.Button btnTariheGoreFiltrele;
        private System.Windows.Forms.Button btnFiltelemeyiSifirla;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }
}
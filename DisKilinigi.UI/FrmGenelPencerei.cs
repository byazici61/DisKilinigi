using DisKilinigi.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DisKilinigi.UI
{
	public partial class FrmGenelPencerei : Form
	{

		List<Hasta> hastaListesi = new List<Hasta>();
		List<Doktor> doktorListesi = new List<Doktor>();
		List<Randevu> randevuListesi = new List<Randevu>();


		public FrmGenelPencerei()
		{
			InitializeComponent();
		}


		private void btnRontgenRandevuOlustur_Click(object sender, EventArgs e)
		{
			Berkay();
		}

		private void btnRandevuOlustur_Click(object sender, EventArgs e)
		{

		}

		private void btnOdemeAl_Click(object sender, EventArgs e)
		{

		}

		private void btnHastaBilgileriİslemGorecekDisleriDuzenle_Click(object sender, EventArgs e)
		{

		}

		private void btnHastaBilgileriKaydet_Click(object sender, EventArgs e)
		{

		}

		private void btnGecmisTümTedaviler_Click(object sender, EventArgs e)
		{

        }
        private void Berkay()
        {
	        doktorListesi.AddRange(new List<Doktor>()
	        {
		        new Doktor() {DoktorAdSoyad="Melike Memiş",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
		        new Doktor() {DoktorAdSoyad="Batuhan Yazıcı",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
		        new Doktor() {DoktorAdSoyad="Berkay Engin",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
		        new Doktor() {DoktorAdSoyad="Ela Güler",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
		        new Doktor() {DoktorAdSoyad="Zahide Uzun",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
		        new Doktor() {DoktorAdSoyad="Yekta Büyükkaya",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
	        });
	        if (Validasyon())
	        {
		        // todo textbox1 => txtEkstraAciklama , Kangrubu textbox atılacak
		        hastaListesi.Add(
			        new Hasta
			        {
				        HastaAdSoyad = txtHastanaIlkMuayeneAdSoyad.Text,
				        KimlikNumarasi = mtxtHastaBilgileriKimlikNumarası.Text,
				        DogumTarihi = mtxtHastanaIlkMuayeneDoğumTarihi.Text,
				        TelefonNumarasi = mtxtHastanaIlkMuayeneTelefonNumarasi.Text,
				        EkstraAciklama = textBox1.Text,
				        KanGrubu = ""
			        });
	        }
	        else
	        {
		        MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Giriniz");
	        }
        }
        private bool Validasyon()
        {
	        throw new NotImplementedException();
        }
		void HastayaYapilacakIslemleriOlustur()
        {
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "Dolgu", Tag = new Islem() { IslemAdi = "Dolgu", IslemUcreti = 100 } });
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "Kanal Tedavisi", Tag = new Islem() { IslemAdi = "Kanal Tedavisi", IslemUcreti = 500 } });
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "Diş Beyazlatma", Tag = new Islem() { IslemAdi = "Diş Beyazlatma", IslemUcreti = 100 } });
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "Diş Taşı Temizliği", Tag = new Islem() { IslemAdi = "Diş Taşı Temizliği", IslemUcreti = 100 } });
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "İmplant", Tag = new Islem() { IslemAdi = "İmplant", IslemUcreti = 100 } });
	        cmboxYapılacakIslem.Controls.Add(new ComboBox() { Text = "Diş Teli", Tag = new Islem() { IslemAdi = "Diş Teli", IslemUcreti = 100 } });
        }
	}

}

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
			doktorListesi.AddRange(new List<Doktor>()
			{ 
				new Doktor() {DoktorAdSoyad="Melike Hoca",MezuniyetUniversitesi="...",UzmanlikAlani="..." },
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
	}
}

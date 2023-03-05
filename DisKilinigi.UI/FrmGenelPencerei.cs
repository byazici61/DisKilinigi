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
		private void FrmGenelPencerei_Load(object sender, EventArgs e)
		{
			DoktorlariDoldur();
		}



		/// <summary>
		/// Doktorları, kotor nesnesi ile Dolduran Fonksiyon
		/// </summary>
        private void DoktorlariDoldur()
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
		}

		/// <summary>
		/// Hastaları hastlar listesine kaydeder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void btnRontgenRandevuOlustur_Click(object sender, EventArgs e)
		{
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
						EkstraAciklama = txtHastaSikayet.Text,
						KanGrubu = ""
					});
			}
			else
			{
				MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz Giriniz");
			}
		}




		private void btnRandevuOlustur_Click(object sender, EventArgs e)
		{
			foreach (CheckBox item in gbSikayetiOlanDisler.Controls)
			{
				if (item.Checked)
				{

					randevuListesi.Add(new Randevu()
					{
						Hasta = cmboxHastaAdi.SelectedItem,
						Doktor = cmboxIlgilenecekDoktor.SelectedItem,
						RandevuTarihi = dtpRandevuTarihi.Value,
						Islemler = cmboxYapılacakIslem.SelectedItem

					});
				}
			}
		}

		private void btnOdemeAl_Click(object sender, EventArgs e)
		{
            foreach (Randevu item in randevuListesi)
            {
                if (!item.RandevuDurumu)
                {
                    ListViewItem li = new ListViewItem();
                    li.SubItems.Add(item.Hasta.HastaAdSoyad);
                    li.SubItems.Add(item.Hasta.KimlikNumarasi);
                    li.SubItems.Add(item.Hasta.DogumTarihi);
                    //li.SubItems.Add(item.Islemler.IslemAdi);
                    //li.SubItems.Add(item.RandevuDurumu);
                    li.Tag = item;
                    lvHastaBilgileri.Items.Add(li);

                    //item.RandevuUcreti += item.Islemler.IslemUcreti;
                    double toplamTutar = item.RandevuUcreti;
                    MessageBox.Show("Ödeme bilgileriniz\n Toplam tutar: " + toplamTutar.ToString());
                }
            }
        }

		private void btnHastaBilgileriİslemGorecekDisleriDuzenle_Click(object sender, EventArgs e)
		{

		}

		private void btnHastaBilgileriKaydet_Click(object sender, EventArgs e)
		{

			foreach (Randevu item in randevuListesi)
			{
				if (item.Hasta.HastaAdSoyad == clboxHastaBilgileri.SelectedItem.ToString())
				{
					item.Hasta.TelefonNumarasi = mtxtHastaBilgileriTelefonNo.Text;
					item.Islemler = cmboxHastaBilgileriGelisSebebi.SelectedItem;
					item.Hasta.EkstraAciklama = txtHastaBilgileriEkstraBilgiler.Text;
					item.RandevuDurumu = cmboxHastaBilgileriTedaviDurumu.SelectedItem;

				}

			}

		}

		private void clboxHastaBilgileri_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (CheckBox item in clboxHastaBilgileri.CheckedItems)
			{
				txtHastaBilgileriHastaAdSoyad.Text = item.Tag.Randevu.Hasta.AdSoyad;
				mtxtHastaBilgileriKimlikNumarası.Text = item.Tag.Randevu.Hasta.KimlikNumarasi;
				mtxtHastaBilgileriDogumTarihi.Text = item.Tag.Randevu.Hasta.DogumTarihi;
				mtxtHastaBilgileriTelefonNo.Text = item.Tag.Randevu.Hasta.TelefonNumarasi;
				cmboxHastaBilgileriKanGrubu.DataSource = item.Tag.Randevu.Hasta.KanGrubu;
				txtHastaBilgileriEkstraBilgiler.Text = item.Tag.Randevu.Hasta.EkstraAciklama;
				cmboxHastaBilgileriGelisSebebi.DataSource = item.Tag.Randevu.Hasta.Islemler;

			}

		}

		private void btnGecmisTümTedaviler_Click(object sender, EventArgs e)
        {

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

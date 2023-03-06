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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace DisKilinigi.UI
{
	public partial class FrmGenelPencerei : Form
	{

		List<Hasta> hastaListesi = new List<Hasta>();
		List<Doktor> doktorListesi = new List<Doktor>();
		List<Randevu> randevuListesi = new List<Randevu>();
		private string islemYapilacakDisAdlari = "";
		double islemUcreti;

		public FrmGenelPencerei()
		{
			InitializeComponent();
		}
		private void FrmGenelPencerei_Load(object sender, EventArgs e)
		{
			pbRontgen.Visible = false;
			DoktorlariOlustur();
			HastayaYapilacakIslemleriOlustur();
		}

		/// <summary>
		/// tablar arasindaki her geciste o taba ait yüklenmesi gereken bilgileri doldurur.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (tabControl1.SelectedIndex == 1)
			{
				cmboxHastaAdi.Items.Clear();
				cmboxIlgilenecekDoktor.Items.Clear();
				gbTedaviAtamasi.Refresh();
				gbTedaviAtamasi.Enabled = true;

				cmboxHastaAdi.Items.AddRange(hastaListesi.ToArray());
				cmboxIlgilenecekDoktor.Items.AddRange(doktorListesi.ToArray());
			}
			if (tabControl1.SelectedIndex == 2)
			{
				lvHastaBilgileri.Items.Clear();
				foreach (Randevu item in randevuListesi)
				{
					if (item.RandevuDurumu)
					{
						ListViewItem li = new ListViewItem(item.Hasta.HastaAdSoyad, 0);
						li.SubItems.Add(item.Hasta.KimlikNumarasi);
						li.SubItems.Add(item.Hasta.DogumTarihi);
						li.SubItems.Add(DiziyiStringeCevir(item.Disler));
						li.SubItems.Add(item.Islem.ToString());
						li.SubItems.Add(item.RandevuTarihi.ToString());
						li.SubItems.Add(item.RandevuUcreti.ToString());

						li.Tag = item;
						lvHastaBilgileri.Items.Add(li);
					}
				}
			}
			if (tabControl1.SelectedIndex == 3)
			{
				flplist.Controls.Clear();
				foreach (Randevu item in randevuListesi)
				{
					if (item.RandevuDurumu)
					{
						flplist.Controls.Add(new CheckBox() { Text = item.Hasta.HastaAdSoyad, Tag = item });
					}
				}

			}

		}


		#region Hasta İlk Kayıt Ekranı

		/// <summary>
		/// Hastaları hastlar listesine kaydeder
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRontgenRandevuOlustur_Click(object sender, EventArgs e)
		{
			
			if (HastaIlkKayitValidasyon())
			{
				pbRontgen.Visible = true;
				hastaListesi.Add(
					new Hasta
					{
						HastaAdSoyad = txtHastanaIlkMuayeneAdSoyad.Text,
						KimlikNumarasi = mtxtHastaKayitKimlikNo.Text,
						DogumTarihi = mtxtHastanaIlkMuayeneDoğumTarihi.Text,
						TelefonNumarasi = mtxtHastanaIlkMuayeneTelefonNumarasi.Text,
						EkstraAciklama = txtHastaSikayet.Text,
						KanGrubu = ""
					});
				MessageBox.Show("Hasta kaydı oluşturuldu. Röntgen bilgisi doktora iletildi!");
			}
			else
			{
				MessageBox.Show("Lütfen Tüm Bilgileri Eksiksiz ve Doğru Formatta Giriniz");
			}
		}

		/// <summary>
		/// yeni hasta kaydi girilmesi icin formu temizler
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnYeniHastaKayit_Click(object sender, EventArgs e)
		{
			foreach (Control item in gbHastaKayitHastaBilgileri.Controls)
			{
				if (item is TextBox || item is MaskedTextBox) item.Text = null;
			}
			pbRontgen.Visible = false;
		}

		#endregion
		
		#region Tedavi Planlaması Ekranı

		/// <summary>
		/// Randevu tipinde nesneler oluşturup randevu istesine atar
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnRandevuOlustur_Click(object sender, EventArgs e)
		{
			foreach (CheckBox item in gbSikayetiOlanDisler.Controls)
			{
				if (item.Checked)
				{
					islemYapilacakDisAdlari += item.Name.Substring(4, item.Name.Length - 4) + " ";
				}
			}
			string[] dizi = islemYapilacakDisAdlari.Split(' ');
			if (islemYapilacakDisAdlari != "" && RandevuOlusturmaValidasyon())
			{
				randevuListesi.Add(new Randevu()
				{

					Hasta = cmboxHastaAdi.SelectedItem as Hasta,
					Doktor = cmboxIlgilenecekDoktor.SelectedItem as Doktor,
					RandevuTarihi = dtpRandevuTarihi.Value,
					Islem = cmboxYapılacakIslem.SelectedItem as Islem,
					RandevuDurumu = true,
					Disler = dizi,
				});
				MessageBox.Show("Randevu başarıyla oluşturuldu!");
				islemYapilacakDisAdlari = "";
			}
			else
			{
				MessageBox.Show("Lütfen tüm bilgileri eksiksiz girdiğinizden emin olunuz!");
			}
			
		}

		/// <summary>
		/// tedavi planlanacak dişlerin tamamını tek seferde secer ve geri alindiginda secimlerin tamamini kaldirir.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void chboxTumunuSec_CheckStateChanged(object sender, EventArgs e)
		{
			if (chboxTumunuSec.Checked)
			{
				foreach (CheckBox item in gbSikayetiOlanDisler.Controls)
				{
					item.Checked = true;
				}
			}
			else
			{
				foreach (CheckBox item in gbSikayetiOlanDisler.Controls)
				{
					item.Checked = false;
				}
			}

		}

		/// <summary>
		/// secilen doktorun fotografini getirir
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmboxIlgilenecekDoktor_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmboxIlgilenecekDoktor.SelectedIndex == 0)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\melike hoca.png");
			}
			if (cmboxIlgilenecekDoktor.SelectedIndex == 1)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\batu.png");
			}
			if (cmboxIlgilenecekDoktor.SelectedIndex == 2)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\berkay.png");
			}
			if (cmboxIlgilenecekDoktor.SelectedIndex == 3)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\ela.png");
			}
			if (cmboxIlgilenecekDoktor.SelectedIndex == 4)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\yekta.png");
			}
			if (cmboxIlgilenecekDoktor.SelectedIndex == 5)
			{
				picbDoktorResmi.Image = Image.FromFile(@"..\..\Resources\zahide.png");
			}

		}


		#endregion

		#region Metotlar

		/// <summary>
		/// Doktorları, kotor nesnesi ile Dolduran Fonksiyon
		/// </summary>
		private void DoktorlariOlustur()
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
		/// textboxlarin ve mtextboxlarin girilen degerlerininin uygunlugunu kontrol eder.
		/// </summary>
		/// <returns></returns>
		private bool HastaIlkKayitValidasyon()
		{
			return txtHastanaIlkMuayeneAdSoyad.Text.StringDegerAdSoyadKontrolu()
			       && ExtensionMethod.StringDegerinNullVeyaBoslukOlupOlmamaDurumu(txtHastaSikayet.Text,
				      mtxtHastanaIlkMuayeneDoğumTarihi.Text,
				       mtxtHastaKayitKimlikNo.Text, mtxtHastanaIlkMuayeneTelefonNumarasi.Text)
			       && mtxtHastaKayitKimlikNo.Text.TCKimlikNoDogruFormattaMi()
			       && mtxtHastanaIlkMuayeneTelefonNumarasi.Text.TelefonNoFormatKontrolu();
		}

		public bool RandevuOlusturmaValidasyon()
		{
			return ExtensionMethod.NullValidasyon(cmboxIlgilenecekDoktor.Text,
				cmboxYapılacakIslem.Text) && cmboxHastaAdi.Text.StringDegerAdSoyadKontrolu();
		}

		/// <summary>
		/// yapılacak işlemler combobaxını doldurur.
		/// </summary>
		public void HastayaYapilacakIslemleriOlustur()
		{
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "Dolgu", IslemUcreti = 100 });
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "Kanal Tedavisi", IslemUcreti = 500 });
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "Diş Beyazlatma", IslemUcreti = 100 });
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "Diş Taşı Temizliği", IslemUcreti = 100 });
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "İmplant", IslemUcreti = 100 });
			cmboxYapılacakIslem.Items.Add(new Islem() { IslemAdi = "Diş Teli", IslemUcreti = 100 });
		}

		/// <summary>
		/// ?TODO
		/// </summary>
		/// <param name="dizi"></param>
		/// <returns></returns>
		private string DiziyiStringeCevir(string[] dizi)
		{
			string disler = "";
			foreach (string item in dizi)
			{
				disler += item + " ";
			}
			return disler;
		}


		#endregion

		#region Ödeme Ekranı

		/// <summary>
		/// Toplam islem ücretine göre ödeme alma fonksiyonu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOdemeAl_Click(object sender, EventArgs e)
		{
			if (listedeSecilenIndis == null)
			{
				MessageBox.Show("Ödeme yapmak için hasta seçmediniz!");
				return;
			}

			DialogResult dg = MessageBox.Show($"{islemUcreti} tutarındaki ödeme alınacak, bu işleme devam etmek istediğinize emin misiniz", "", MessageBoxButtons.YesNoCancel);
			if (dg == DialogResult.Yes)
			{
				MessageBox.Show($"{islemUcreti} tutarındaki ücret alınmıştır.");
				islemUcreti = 0;

				randevuListesi.Find(r => r == listedeSecilenIndis.Tag as Randevu).RandevuDurumu = false ;
				lvHastaBilgileri.Items.Remove(listedeSecilenIndis);
			}
		}

		#endregion

		#region Rapor Ekranı

		ListViewItem listedeSecilenIndis;
		private void lvHastaBilgileri_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lvHastaBilgileri.SelectedItems.Count > 0)
			{
				listedeSecilenIndis = lvHastaBilgileri.SelectedItems[0];
				lblRandevuBİlgileri.Text = listedeSecilenIndis.Tag.ToString();
				islemUcreti = double.Parse(listedeSecilenIndis.SubItems[6].Text);
			}
		}

		#endregion

		#region Hasta  Bilgilerini Detaylı Görme Ekranı

		/// <summary>
		/// hasta bilgilerini günceller. kan grubu ve ekstra eklenmek istenen not kismi degistirilebilir. ad soyad ve diger hasta bilgileri degistirilmez.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnHastaBilgileriKaydet_Click(object sender, EventArgs e)
		{

			randevuListesi[hastaIndis].Hasta.TelefonNumarasi = mtxtHastaBilgileriTelefonNo.Text;
			randevuListesi[hastaIndis].Hasta.EkstraAciklama = txtHastaBilgileriEkstraBilgiler.Text;
			randevuListesi[hastaIndis].Hasta.KanGrubu = cmboxHastaBilgileriKanGrubu.SelectedItem.ToString();
			MessageBox.Show(randevuListesi[hastaIndis].Hasta.TelefonNumarasi + randevuListesi[hastaIndis].Hasta.EkstraAciklama + randevuListesi[hastaIndis].Hasta.KanGrubu);

		}

		/// <summary>
		/// raporlama formuna gecer.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnGecmisTümTedaviler_Click(object sender, EventArgs e)
		{
			frmRapor frmRapor = new frmRapor(randevuListesi, doktorListesi);
			frmRapor.Show();

		}

		int hastaIndis = -1;
		/// <summary>
		/// hasta bilgileri ekraninda listelenen hastalardan, secilenin bilgilerini getirir
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnHastaGetir_Click(object sender, EventArgs e)
		{
			flplist.Enabled = true;
			foreach (CheckBox item in flplist.Controls)
			{
				if (item.Checked)
				{
					foreach (Randevu item1 in randevuListesi)
					{
						txtHastaBilgileriHastaAdSoyad.Text = item1.Hasta.ToString();
						mtxtHastaBilgileriKimlikNumarası.Text = item1.Hasta.KimlikNumarasi;
						mtxtHastaBilgileriDogumTarihi.Text = item1.Hasta.DogumTarihi;
						mtxtHastaBilgileriTelefonNo.Text = item1.Hasta.TelefonNumarasi;
						txtHastaBilgileriEkstraBilgiler.Text = item1.Hasta.EkstraAciklama;
						hastaIndis++;
					}
				}

			}
		}

		#endregion

	}

}

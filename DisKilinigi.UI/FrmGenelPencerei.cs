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

        //List<string> islemYapilacakDisAdlari = new List<string>();
        string islemYapilacakDisAdlari = "";


        public FrmGenelPencerei()
        {
            InitializeComponent();
        }
        private void FrmGenelPencerei_Load(object sender, EventArgs e)
        {
            DoktorlariOlustur();
            HastayaYapilacakIslemleriOlustur();
        }



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
                    islemYapilacakDisAdlari += item.Name.Substring(4, item.Name.Length - 4) +" ";
                }
            }
            string[] dizi = islemYapilacakDisAdlari.Split(' ');
            islemYapilacakDisAdlari = "";

            randevuListesi.Add(new Randevu()
            {

                Hasta = cmboxHastaAdi.SelectedItem as Hasta,
                Doktor = cmboxIlgilenecekDoktor.SelectedItem as Doktor,
                RandevuTarihi = dtpRandevuTarihi.Value,
                Islemler = cmboxYapılacakIslem.SelectedItem as Islem,
                RandevuDurumu = true,
                Disler = dizi


            }) ;
            
        }


        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            foreach (Randevu item in randevuListesi)
            {
               
            }
        }

        private void btnHastaBilgileriİslemGorecekDisleriDuzenle_Click(object sender, EventArgs e)
        {

        }

        private void btnHastaBilgileriKaydet_Click(object sender, EventArgs e)
        {

            //foreach (Randevu item in randevuListesi)
            //{
            //    if (item.Hasta.HastaAdSoyad == clboxHastaBilgileri.SelectedItem.ToString())
            //    {
            //        item.Hasta.TelefonNumarasi = mtxtHastaBilgileriTelefonNo.Text;
            //        item.Islemler = cmboxHastaBilgileriGelisSebebi.SelectedItem;
            //        item.Hasta.EkstraAciklama = txtHastaBilgileriEkstraBilgiler.Text;
            //        item.RandevuDurumu = cmboxHastaBilgileriTedaviDurumu.SelectedItem;

            //    }

            //}

        }

        private void clboxHastaBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
            //foreach (CheckBox item in clboxHastaBilgileri.CheckedItems)
            //{
            //    txtHastaBilgileriHastaAdSoyad.Text = item.Tag.Randevu.Hasta.AdSoyad;
            //    mtxtHastaBilgileriKimlikNumarası.Text = item.Tag.Randevu.Hasta.KimlikNumarasi;
            //    mtxtHastaBilgileriDogumTarihi.Text = item.Tag.Randevu.Hasta.DogumTarihi;
            //    mtxtHastaBilgileriTelefonNo.Text = item.Tag.Randevu.Hasta.TelefonNumarasi;
            //    cmboxHastaBilgileriKanGrubu.DataSource = item.Tag.Randevu.Hasta.KanGrubu;
            //    txtHastaBilgileriEkstraBilgiler.Text = item.Tag.Randevu.Hasta.EkstraAciklama;
            //    cmboxHastaBilgileriGelisSebebi.DataSource = item.Tag.Randevu.Hasta.Islemler;

            //}

        }

        private void btnGecmisTümTedaviler_Click(object sender, EventArgs e)
        {

        }

        private bool Validasyon()
        {
            return true;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                gbTedaviAtamasi.Refresh();
                gbTedaviAtamasi.Enabled = true;

                cmboxHastaAdi.Items.AddRange(hastaListesi.ToArray());
                cmboxIlgilenecekDoktor.Items.AddRange(doktorListesi.ToArray());
            }
            if (tabControl1.SelectedIndex==2)
            {
                foreach (Randevu item in randevuListesi)
                {
                    if (item.RandevuDurumu)
                    {
                        ListViewItem li = new ListViewItem(item.Hasta.HastaAdSoyad, 0);
                        li.SubItems.Add(item.Hasta.KimlikNumarasi);
                        li.SubItems.Add(item.Hasta.DogumTarihi);
                        li.SubItems.Add(DiziyiStringeCevir(item.Disler));
                        li.SubItems.Add(item.Islemler.ToString());
                        li.SubItems.Add(item.RandevuTarihi.ToString());
                       
                        li.Tag = item;
                        lvHastaBilgileri.Items.Add(li);

                        //item.RandevuUcreti += item.Islemler.IslemUcreti;
                    }
                }

            }

        }

        private string DiziyiStringeCevir(string[] dizi)
        {
            string disler="";
            foreach (string item in dizi)
            {
                disler += item + " ";
                    

            }
            return disler;
        }

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

        private void lvHastaBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Randevu item in randevuListesi)
            {
               


            }
        }

        private void lvHastaBilgileri_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (Randevu item in randevuListesi)
            {
                //if (lvHastaBilgileri.Items.che)
                //{

                //}


            }

        }
    }

}

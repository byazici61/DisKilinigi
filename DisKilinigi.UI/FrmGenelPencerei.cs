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

namespace DisKilinigi.UI
{
    public partial class FrmGenelPencerei : Form
    {

        List<Hasta> hastaListesi = new List<Hasta>();
        List<Doktor> doktorListesi = new List<Doktor>();
        List<Randevu> randevuListesi = new List<Randevu>();

        //List<string> islemYapilacakDisAdlari = new List<string>();
        string islemYapilacakDisAdlari = "";
        double islemUcreti;


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
                    islemYapilacakDisAdlari += item.Name.Substring(4, item.Name.Length - 4) + " ";
                }
            }
            string[] dizi = islemYapilacakDisAdlari.Split(' ');
            islemYapilacakDisAdlari = "";

            randevuListesi.Add(new Randevu()
            {

                Hasta = cmboxHastaAdi.SelectedItem as Hasta,
                Doktor = cmboxIlgilenecekDoktor.SelectedItem as Doktor,
                RandevuTarihi = dtpRandevuTarihi.Value,
                Islem = cmboxYapılacakIslem.SelectedItem as Islem,
                RandevuDurumu = true,
                Disler = dizi,
                
               

            });

        }

        /// <summary>
        /// Toplam islem ücretine göre ödeme alma fonksiyonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show($"{islemUcreti} tutarındaki ödeme alınacak, bu işleme devam etmek istediğinize emin misiniz","",MessageBoxButtons.YesNoCancel);
            if (dg==DialogResult.Yes)
            {
                MessageBox.Show($"{islemUcreti} tutarındaki ücret alınmıştır.");
                islemUcreti = 0;
                
                foreach (Randevu item in randevuListesi)
                {
                    if (listedeSecilenIndis.Tag==item)
                    {
                        item.RandevuDurumu = false;

                    }
                }

                lvHastaBilgileri.Items.Remove(listedeSecilenIndis);
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
            gbHastaBilgileriHastaBilgileri.Enabled = true;
            foreach ( CheckBox item1 in clboxHastaBilgileri.CheckedItems)
            {
                Randevu item = item1.Tag as Randevu;
                
                txtHastaBilgileriHastaAdSoyad.Text = item.Hasta.HastaAdSoyad;
                mtxtHastaBilgileriKimlikNumarası.Text = item.Hasta.KimlikNumarasi;
                mtxtHastaBilgileriDogumTarihi.Text = item.Hasta.DogumTarihi;
                mtxtHastaBilgileriTelefonNo.Text = item.Hasta.TelefonNumarasi;
                cmboxHastaBilgileriKanGrubu.DataSource = item.Hasta.KanGrubu;
                txtHastaBilgileriEkstraBilgiler.Text = item.Hasta.EkstraAciklama;
                cmboxHastaBilgileriGelisSebebi.DataSource = item.Islem;

            }

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
            if (tabControl1.SelectedIndex == 2)
            {
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

                        //item.RandevuUcreti += item.Islemler.IslemUcreti;
                    }
                }

            }

            if (tabControl1.SelectedIndex==3)
            {

                foreach (Randevu item in randevuListesi)
                {
                    if (item.RandevuDurumu )
                    {
                        clboxHastaBilgileri.Controls.Add(new CheckBox() { Text = item.Hasta.HastaAdSoyad, Tag = item });


                        //flpHizmetler.Controls.Add(new CheckBox() { Text = "Kola", Tag = new Hizmet() { UrunAdi = "Kola", UrunFiyati = 20 } }
                        

                    }
                }

            }

        }

        private string DiziyiStringeCevir(string[] dizi)
        {
            string disler = "";
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

        ListViewItem listedeSecilenIndis;
        private void lvHastaBilgileri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHastaBilgileri.SelectedItems.Count > 0)
            {
                listedeSecilenIndis  = lvHastaBilgileri.SelectedItems[0];
                lblRandevuBİlgileri.Text = listedeSecilenIndis.Tag.ToString();
                islemUcreti = double.Parse(listedeSecilenIndis.SubItems[6].Text);

            }
        }

	}

}

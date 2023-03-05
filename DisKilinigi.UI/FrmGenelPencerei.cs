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

            foreach (Randevu item in randevuListesi)
            {
                if (item.Hasta.HastaAdSoyad==clboxHastaBilgileri.SelectedItem.ToString())
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

     
    }
}

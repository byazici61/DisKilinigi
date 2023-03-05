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
    public partial class frmRapor : Form
    {
        private List<Randevu> randevuListesi;
        private List<Doktor> doktorListesi;

        public frmRapor()
        {
            InitializeComponent();
        }

        public frmRapor(List<Randevu> randevuListesi, List<Doktor> doktorListesi) : this()
        {
            this.randevuListesi = randevuListesi;
            this.doktorListesi = doktorListesi;
        }

        private void FrmRaporPenceresi_Load(object sender, EventArgs e)
        {
            lvTumHastalar.Items.Clear();
            foreach (Randevu item in randevuListesi)
            {
                btnFiltelemeyiSifirla_Click(sender, e);
            }
            cmbDoktorlar.Items.AddRange(doktorListesi.ToArray());   
        }


        private void btnAdaGoreFiltrele_Click(object sender, EventArgs e)
        {
            string aranilanKelime = txtAranacakAd.Text;

            lvTumHastalar.Items.Clear();

            foreach (Randevu item in randevuListesi)
            {

                if (item.Hasta.HastaAdSoyad.ToLower().Contains(aranilanKelime.ToLower()))
                {
                    TabloyuDoldur(item);
                }

            }

        }

        private void btnDoktoraGoreFiltrele_Click(object sender, EventArgs e)
        {
            lvTumHastalar.Items.Clear();

            foreach (Randevu item in randevuListesi)
            {
                if (cmbDoktorlar.SelectedItem.ToString()==item.Doktor.DoktorAdSoyad)
                {
                    TabloyuDoldur(item);
                }

                

            }
        }

        private void btnTedaviDurumunaGöreFiltrele_Click(object sender, EventArgs e)
        {
            lvTumHastalar.Items.Clear();

            foreach (Randevu item in randevuListesi)
            {
                

                if (cmbTedaviDurumu.SelectedIndex == 0 && item.RandevuDurumu == true)
                {
                    TabloyuDoldur(item);
                }
                else if (cmbTedaviDurumu.SelectedIndex == 1 && item.RandevuDurumu == false)
                {
                    TabloyuDoldur(item);

                }

            }




        }




        private void btnTariheGoreFiltrele_Click(object sender, EventArgs e)
        {
            lvTumHastalar.Items.Clear();

            foreach (Randevu item in randevuListesi)
            {

                if (dtp1.Value <= item.RandevuTarihi && dtp2.Value >= item.RandevuTarihi)
                {
                    TabloyuDoldur(item);
                }
            }

        }

        private void btnFiltelemeyiSifirla_Click(object sender, EventArgs e)
        {
            lvTumHastalar.Items.Clear();
            foreach (Randevu item in randevuListesi)
            {
                TabloyuDoldur(item);
            }

        }




        //private void btnAra_Click(object sender, EventArgs e)
        //{
        //    string aranilanKelime = txtAranacakKelime.Text;

        //    lvTumHastalar.Items.Clear();

        //    foreach (Kullanım item in kullanımlar)
        //    {

        //        if (ExtentionMetods.SayiVarMi(aranilanKelime) && item.Rezervasyon.Musteri.AdSoyad.ToLower().Contains(aranilanKelime.ToLower()))
        //        {
        //            TabloyuDoldurma(item);
        //        }

        //    }
        //}

        ///// <summary>
        ///// Tarihe göre seçilen aralıktaki otelde kalmış kişileri getirir.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnTarihFitrele_Click(object sender, EventArgs e)
        //{

        //    lvTumHastalar.Items.Clear();

        //    foreach (Kullanım item in kullanımlar)
        //    {

        //        if (dtpBirinciTrh.Value <= item.Rezervasyon.GirisTarihi && dtpİkinciTrh.Value >= item.CikisTarihi)
        //        {
        //            TabloyuDoldurma(item);
        //        }
        //    }
        //}

        ///// <summary>
        ///// Tüm müşteriler listesini getiri.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void btnSifirla_Click(object sender, EventArgs e)
        //{
        //    lvTumHastalar.Items.Clear();
        //    foreach (Kullanım item in kullanımlar)
        //    {
        //        TabloyuDoldurma(item);

        //    }
        //}

        /// <summary>
        /// tabloyu dolduran fonksiyon
        /// </summary>
        /// <param name="item"></param>
        public void TabloyuDoldur(Randevu item)
        {
            ListViewItem h1 = new ListViewItem(item.Hasta.HastaAdSoyad, 0);
            h1.SubItems.Add(item.Hasta.KimlikNumarasi);
            h1.SubItems.Add(item.Hasta.DogumTarihi);
            h1.SubItems.Add(item.Doktor.DoktorAdSoyad);
            h1.SubItems.Add(item.Islem.IslemAdi);
            h1.SubItems.Add(item.RandevuTarihi.ToString());
            h1.SubItems.Add(item.RandevuDurumu == false
                ? "Tamamlandı"
                : "Devam Ediyor"
                );
            h1.SubItems.Add(item.RandevuUcreti.ToString());

            lvTumHastalar.Items.AddRange(new ListViewItem[] { h1 });



        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKilinigi.UI.Common
{
    public class Randevu
    {

        public bool RandevuDurumu { get; set; } 
        
        public DateTime RandevuTarihi { get; set; }
        public Doktor Doktor { get; set; }
        
        public double RandevuUcreti { get {

                return (Disler.Length * Islem.IslemUcreti);
            } }

        public Hasta Hasta { get; set; }
        public Islem Islem { get; set; }
        public string[] Disler { get; set; }

        public override string ToString()
        {
            string islemYapilanDisler = "";
            foreach (string item in Disler)
            {
                islemYapilanDisler += item + " ";

            }
            return $"{Hasta.HastaAdSoyad} adlı hastamızın, '{islemYapilanDisler}' dişlerine {Islem.IslemAdi} işlemi yapılmıştır. \nToplam Randevu Ücreti {RandevuUcreti} TL'dir ";
        }

    }
}

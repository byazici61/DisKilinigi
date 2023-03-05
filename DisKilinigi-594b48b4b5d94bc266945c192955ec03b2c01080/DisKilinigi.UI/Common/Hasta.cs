using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKilinigi.UI.Common
{
    public class Hasta
    {
        public string  HastaAdSoyad { get; set; }
        public string DogumTarihi { get; set; }
        public string KimlikNumarasi { get; set; }
        public string TelefonNumarasi { get; set; }
        public string KanGrubu { get; set; }
        public string EkstraAciklama{get; set; }

        public override string ToString()
        {
            return HastaAdSoyad; 
        }

    }
}

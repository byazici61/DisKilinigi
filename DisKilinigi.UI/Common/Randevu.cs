using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKilinigi.UI.Common
{
    class Randevu
    {

        public bool RandevuDurumu { get; set; } 
        
        public DateTime RandevuTarihi { get; set; }
        public Doktor Doktor { get; set; }
        
        public double RandevuUcreti { get; set; }

        public Hasta Hasta { get; set; }
        public List<Islem> Islemler { get; set; } = new List<Islem>();
        
    }
}

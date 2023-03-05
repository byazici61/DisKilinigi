using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKilinigi.UI.Common
{
    class Doktor
    {
        public string DoktorAdSoyad { get; set; }
        public string MezuniyetUniversitesi { get; set; }
        public string UzmanlikAlani { get; set; }

        public override string ToString()
        {
            return DoktorAdSoyad;
        }


    }
}

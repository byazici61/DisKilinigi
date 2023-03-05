using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisKilinigi.UI.Common
{
    public class Islem
    {
        public string IslemAdi { get; set; }
        public double IslemUcreti { get; set; }

        public override string ToString()
        {
            return IslemAdi;
        }
    }
}

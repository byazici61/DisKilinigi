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
    public partial class FrmGirisPenceresi : Form
    {
        public FrmGirisPenceresi()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            FrmGenelPencerei frmGenelPencere = new FrmGenelPencerei();
            frmGenelPencere.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Araçlar
{
    public partial class FrmYabanciSorgulama : Form
    {
        public FrmYabanciSorgulama()
        {
            InitializeComponent();
        }

        private void FrmYoutube_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://tckimlik.nvi.gov.tr/Modul/YabanciKimlikNoSorgula");
        }
    }
}

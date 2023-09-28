using DevExpress.XtraCharts;
using Otelreservation.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Grafikler
{
    public partial class FrmGrafik2 : Form
    {
        public FrmGrafik2()
        {
            InitializeComponent();
        }
        DbOtelEntities db=new DbOtelEntities();
        private void FrmGrafik2_Load(object sender, EventArgs e)
        {
            var durum = db.OdaDurum();
            foreach (var x in durum)
            {
                chartControl1.Series["Odalar"].Points.AddPoint(x.DurumAd, double.Parse(x.Sayı.ToString()));
            }
        }
    }
}

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

namespace Otelreservation.Formlar.Urun
{
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.UrunAd,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.Fiyat,
                                           x.TblBirim.BirimAD,
                                           x.Toplam,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }
    }
}

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
    public partial class FrmUrunCikishareket : Form
    {
        public FrmUrunCikishareket()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmUrunCikishareket_Load(object sender, EventArgs e)
        {

            gridControl1.DataSource = (from x in db.TblUrunHareket
                                       select new
                                       {
                                           x.HareketID,
                                           x.TblUrun.UrunAd,
                                           x.Miktar,
                                           x.Tarih,
                                           x.HareketTuru,
                                           x.TblPersonel.AdSoyad
                                       }).Where(y => y.HareketTuru == "Çıkış").ToList();
        }
    }
}

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
    public partial class FrmUrunGirisHareket : Form
    {
        public FrmUrunGirisHareket()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmUrunGirisHareket_Load(object sender, EventArgs e)
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
                                       }).Where(y => y.HareketTuru == "Giriş").ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunHareketKarti fr=new FrmUrunHareketKarti();
            fr.id=int.Parse(gridView1.GetFocusedRowCellValue("HareketID").ToString());
            fr.Show();
        }
    }
}

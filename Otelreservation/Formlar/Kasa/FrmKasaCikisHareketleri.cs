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

namespace Otelreservation.Formlar.Kasa
{
    public partial class FrmKasaCikisHareketleri : Form
    {
        public FrmKasaCikisHareketleri()
        {
            InitializeComponent();
        }
        DbOtelEntities db=new DbOtelEntities();
        private void FrmKasaCikisHareketleri_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblKasaCikisHareket
                                       select new
                                       {
                                           x.Aciklama,
                                           x.Tarih,
                                           x.Tutar,
                                           x.Personel
                                       }).ToList();
        }
    }
}

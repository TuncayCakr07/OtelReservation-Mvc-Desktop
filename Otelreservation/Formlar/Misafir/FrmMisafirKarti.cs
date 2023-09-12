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

namespace Otelreservation.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();

        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            //Country List

            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke
                                                         select new
                                                         {
                                                             x.UlkeID,
                                                             x.UlkeAD,
                                                         }).ToList();

            //City List

            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                    select new
                                                    {
                                                        Id=x.id,
                                                        Şehir=x.sehir,
                                                    }).ToList();

            //Town List
            lookUpEditİlce.Properties.DataSource = (from x in db.ilceler
                                                     select new
                                                     {
                                                         Id=x.id,
                                                         İlçe=x.ilce,
                                                     }).ToList();
        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen=int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditİlce.Properties.DataSource= (from x in db.ilceler select new
            {
                Id=x.id,
                İlçe=x.ilce,
                Şehir=x.sehir,
            }).Where(y=> y.Şehir==secilen).ToList();
        }
    }
}

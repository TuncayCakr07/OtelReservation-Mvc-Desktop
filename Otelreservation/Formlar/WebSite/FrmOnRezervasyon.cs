using Otelreservation.Entity;
using Otelreservation.Formlar.Rezervasyon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.WebSite
{
    public partial class FrmOnRezervasyon : Form
    {
        public FrmOnRezervasyon()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmOnRezervasyon_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblOnRezervasyon
                                       select new
                                       {
                                           x.ID,
                                           x.AdSoyad,
                                           x.Mail,
                                           x.Telefon,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Tarih
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmOnRezervasyonKarti fr = new FrmOnRezervasyonKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}

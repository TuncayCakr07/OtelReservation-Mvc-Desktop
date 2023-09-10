using DevExpress.XtraEditors;
using Otelreservation.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Tanımlamalar
{
    public partial class FrmKurlar : Form
    {
        public FrmKurlar()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmKurlar_Load(object sender, EventArgs e)
        {
            db.TblKur.Load();
            bindingSource1.DataSource = db.TblKur.Local;

            repositoryItemLookUpEdit1Durum.DataSource = (from x in db.TblDurum
                                                         select new
                                                         {
                                                             x.DurumID,
                                                             x.DurumAd,
                                                         }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            db.SaveChanges();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
            XtraMessageBox.Show("Durum Silindi!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

﻿using DevExpress.XtraEditors;
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
    public partial class FrmTelefon : Form
    {
        public FrmTelefon()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmTelefon_Load(object sender, EventArgs e)
        {
            db.TblTelefon.Load();
            bindingSource1.DataSource = db.TblTelefon.Local;

            repositoryItemLookUpEdit1Durum.DataSource = (from x in db.TblDurum
                                                         select new
                                                         {
                                                             x.DurumID,
                                                             x.DurumAd,
                                                         }).ToList();
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                XtraMessageBox.Show("Bilgiler Kaydedilirken Hata Oluştu!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bindingSource1.RemoveCurrent();
            db.SaveChanges();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

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

namespace Otelreservation.Formlar.Admin
{
    public partial class FrmKullaniciListesi : Form
    {
        public FrmKullaniciListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db=new DbOtelEntities();
        private void FrmKullaniciListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TblAdmin.ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmSifreİslemleri fr=new FrmSifreİslemleri();
            fr.id=int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            fr.Show();
        }
    }
}

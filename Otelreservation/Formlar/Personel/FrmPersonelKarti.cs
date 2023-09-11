using DevExpress.XtraEditors;
using Otelreservation.Entity;
using Otelreservation.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Personel
{
    public partial class FrmPersonelKarti : Form
    {
        public FrmPersonelKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            lookUpEditDepartman.Properties.DataSource = (from x in db.TblDepartman
                                                         select new
                                                         {
                                                             x.DepartmanID,
                                                             x.DepartmanAD,
                                                         }).ToList();

            lookUpEditGorev.Properties.DataSource = (from x in db.TblGorev
                                                         select new
                                                         {
                                                             x.GorevID,
                                                             x.GorevAD,
                                                         }).ToList();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            TxtAciklama.Text=pictureEditKimlikOn.GetLoadedImageLocation();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                Repository<TblPersonel> repo = new Repository<TblPersonel>();
                TblPersonel t = new TblPersonel();
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTcNo.Text;
                t.Adres = TxtAdres.Text;
                t.Telefon = TxtTelefon.Text;
                t.IseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
                t.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
                t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
                t.Aciklama = TxtAciklama.Text;
                t.Durum = 1;
                repo.TAdd(t);
                XtraMessageBox.Show("Personel Sisteme Kaydedildi!","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata Oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

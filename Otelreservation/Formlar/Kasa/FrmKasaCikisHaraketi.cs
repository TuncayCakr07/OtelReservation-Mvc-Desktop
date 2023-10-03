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

namespace Otelreservation.Formlar.Kasa
{
    public partial class FrmKasaCikisHaraketi : Form
    {
        public FrmKasaCikisHaraketi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<TblKasaCikisHareket> repo = new Repository<TblKasaCikisHareket>();
        TblKasaCikisHareket t=new TblKasaCikisHareket();
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                t.Aciklama = TxtAciklama.Text;
                t.Tutar = decimal.Parse(TxtToplam.Text);
                t.Tarih = DateTime.Parse(dateEdit1.Text);
                t.Personel = TxtPersonel.Text;
                repo.TAdd(t);
                XtraMessageBox.Show("Kasa Çıkış Hareketi Sisteme Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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

namespace Otelreservation.Formlar.WebSite
{
    public partial class FrmHakkimizda : Form
    {
        public FrmHakkimizda()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<TblHakkimda> repo = new Repository<TblHakkimda>();
        private void FrmHakkimizda_Load(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            TxtAciklama1.Text = iletisim.Hakkimda1;
            TxtAciklama2.Text = iletisim.Hakkimda2;
            TxtAciklama3.Text = iletisim.Hakkimda3;
            TxtAciklama4.Text = iletisim.Hakkimda4;
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var hakkimda = repo.Find(x => x.ID == 1);
                hakkimda.Hakkimda1 = TxtAciklama1.Text;
                hakkimda.Hakkimda2 = TxtAciklama2.Text;
                hakkimda.Hakkimda3 = TxtAciklama3.Text;
                hakkimda.Hakkimda4 = TxtAciklama4.Text;
                repo.TUpdate(hakkimda);
                XtraMessageBox.Show("Hakkınızdaki Bilgiler Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

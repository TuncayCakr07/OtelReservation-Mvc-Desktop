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
    public partial class FrmAdresKarti : Form
    {
        public FrmAdresKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        Repository<Tbliletisim> repo = new Repository<Tbliletisim>();

        private void FrmAdresKarti_Load(object sender, EventArgs e)
        {
            var iletisim = repo.Find(x => x.ID == 1);
            TxtTelefon.Text = iletisim.Telefon;
            TxtMail.Text = iletisim.Mail;
            TxtKoordinat.Text = iletisim.Koordinat;
            TxtAdres.Text = iletisim.Adres;
            TxtAciklama.Text = iletisim.Aciklama;

        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var iletisim = repo.Find(x => x.ID == 1);
                iletisim.Mail = TxtMail.Text;
                iletisim.Telefon = TxtTelefon.Text;
                iletisim.Aciklama = TxtAciklama.Text;
                iletisim.Koordinat = TxtKoordinat.Text;
                iletisim.Adres = TxtAdres.Text;
                repo.TUpdate(iletisim);
                XtraMessageBox.Show("İletişim Bilgileri Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

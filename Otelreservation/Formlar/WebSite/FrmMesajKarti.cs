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
    public partial class FrmMesajKarti : Form
    {
        public FrmMesajKarti()
        {
            InitializeComponent();
        }
        public int id;
        public int id2;

        DbOtelEntities db = new DbOtelEntities();
        Repository<TblMesajGuest> repo = new Repository<TblMesajGuest>();
        Repository<TblMesaj> repoiletisim = new Repository<TblMesaj>();
        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMesajKarti_Load(object sender, EventArgs e)
        {

            if (id != 0)
            {
                var mesaj = repo.Find(x => x.MesajID == id);
                TxtMail.Text = mesaj.Gonderen;
                TxtKonu.Text= mesaj.Konu;
                TxtMesaj.Text= mesaj.Mesaj;
                TxtTarih.Text=mesaj.Tarih.ToString();

                var kisi=db.TblYeniKayit.Where(x=> x.Mail==mesaj.Gonderen).Select(x=>x.AdSoyad).FirstOrDefault();
                if (kisi!=null)
                {
                    TxtAdSoyad.Text = kisi.ToString();
                }
                else
                {
                    TxtAdSoyad.Text="Admin";
                }
            }

            if (id2 != 0)
            {
                var mesaj = repoiletisim.Find(x => x.MesajID == id2);
                TxtMail.Text = mesaj.Gonderen;
                TxtKonu.Text = mesaj.Konu;
                TxtMesaj.Text = mesaj.Mesaj;
                TxtAdSoyad.Text = mesaj.Gonderen;

            }
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                TblMesajGuest t = new TblMesajGuest();
                t.Gonderen = "Admin";
                t.Alici = TxtMail.Text;
                t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                t.Konu = TxtKonu.Text;
                t.Mesaj = TxtMesaj.Text;
                repo.TAdd(t);
                XtraMessageBox.Show("Mesaj başarıyla gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

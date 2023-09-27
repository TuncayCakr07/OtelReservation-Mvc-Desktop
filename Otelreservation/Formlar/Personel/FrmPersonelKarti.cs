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
        
        public int id;
        Repository<TblPersonel> repo = new Repository<TblPersonel>();
        private void FrmPersonelKarti_Load(object sender, EventArgs e)
        {
            string resim1, resim2;
            this.Text = id.ToString();
            if (id!=0)
            {
                var personel = repo.Find(x => x.PersonelID == id);
                TxtAdSoyad.Text=personel.AdSoyad;
                TxtTcNo.Text = personel.TC;
                TxtAdres.Text = personel.Adres;
                TxtTelefon.Text = personel.Telefon;
                TxtMail.Text = personel.Mail;
                dateEditGiris.Text = personel.İseGirisTarihi.ToString();
                dateEditCikis.Text = personel.İstenCikisTarihi.ToString();
                TxtAciklama.Text=personel.Aciklama;
                TxtSifre.Text = personel.Sifre; 
                labelControl12.Text=personel.KimlikOn;
                labelControl13.Text=personel.KimlikArka;
                resim1 = personel.KimlikOn;
                resim2 = personel.KimlikArka;
                lookUpEditDepartman.EditValue = personel.Departman;
                lookUpEditGorev.EditValue = personel.Gorev;

                pictureEditKimlikOn.LoadAsync(personel.KimlikOn);
                pictureEditKimlikArka.LoadAsync(personel.KimlikArka);

            }
       



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
          this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
         
                TblPersonel t = new TblPersonel();
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTcNo.Text;
                t.Adres = TxtAdres.Text;
                t.Telefon = TxtTelefon.Text;
                t.Mail = TxtMail.Text;
                t.İseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
                t.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
                t.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
                t.Aciklama = TxtAciklama.Text;
                t.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
                t.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();
                t.Sifre = TxtSifre.Text;
                t.Durum = 1;
                repo.TAdd(t);
                XtraMessageBox.Show("Personel Sisteme Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var deger = repo.Find(x => x.PersonelID == id);
            deger.AdSoyad = TxtAdSoyad.Text;
            deger.TC = TxtTcNo.Text;
            deger.Adres = TxtAdres.Text;
            deger.Telefon = TxtTelefon.Text;
            deger.Mail = TxtMail.Text;
            deger.İseGirisTarihi = DateTime.Parse(dateEditGiris.Text);
            deger.Departman = int.Parse(lookUpEditDepartman.EditValue.ToString());
            deger.Gorev = int.Parse(lookUpEditGorev.EditValue.ToString());
            deger.Aciklama = TxtAciklama.Text;
            deger.KimlikOn = pictureEditKimlikOn.GetLoadedImageLocation();
            deger.KimlikArka = pictureEditKimlikArka.GetLoadedImageLocation();
            deger.Sifre = TxtSifre.Text;
            repo.TUpdate(deger);
            XtraMessageBox.Show("Personel Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            labelControl12.Text =pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            labelControl13.Text = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }
    }
}

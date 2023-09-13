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

namespace Otelreservation.Formlar.Misafir
{
    public partial class FrmMisafirKarti : Form
    {
        public FrmMisafirKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        Repository<TblMisafir> repo = new Repository<TblMisafir>();
        TblMisafir t = new TblMisafir();
        string resim1, resim2;
        public int id;

        private void FrmMisafirKarti_Load(object sender, EventArgs e)
        {
            //Kart Guncelleme
            if (id != 0)
            {
                var misafir = repo.Find(x => x.MisafirID == id);
                TxtAdSoyad.Text = misafir.AdSoyad;
                TxtTcNo.Text = misafir.TC;
                TxtAdres.Text = misafir.Adres;
                TxtTelefon.Text = misafir.Telefon;
                TxtMail.Text = misafir.Mail;
                TxtAciklama.Text = misafir.Aciklama;
                resim1 = misafir.KimlikFoto1;
                resim2 = misafir.KimlikFoto2;
                lookUpEditSehir.EditValue = misafir.sehir;
                lookUpEditUlke.EditValue = misafir.Ulke;
                lookUpEditİlce.EditValue = misafir.ilce;

            }


            //Country List

            lookUpEditUlke.Properties.DataSource = (from x in db.TblUlke
                                                         select new
                                                         {
                                                             x.UlkeID,
                                                             x.UlkeAD,
                                                         }).ToList();

            //City List

            lookUpEditSehir.Properties.DataSource = (from x in db.iller
                                                    select new
                                                    {
                                                        Id=x.id,
                                                        Şehir=x.sehir,
                                                    }).ToList();

            //Town List
            lookUpEditİlce.Properties.DataSource = (from x in db.ilceler
                                                     select new
                                                     {
                                                         Id=x.id,
                                                         İlçe=x.ilce,
                                                     }).ToList();
        }

        private void lookUpEditSehir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen = int.Parse(lookUpEditSehir.EditValue.ToString());
            lookUpEditİlce.Properties.DataSource = (from x in db.ilceler
                                                    select new
                                                    {
                                                         Id = x.id,
                                                        İlçe = x.ilce,
                                                        Şehir = x.sehir,
                                                    }).Where(y => y.Şehir == secilen).ToList();
        }
      

        private void pictureEditKimlikOn_EditValueChanged(object sender, EventArgs e)
        {
            resim1=pictureEditKimlikOn.GetLoadedImageLocation().ToString();
        }

        private void pictureEditKimlikArka_EditValueChanged(object sender, EventArgs e)
        {
            resim2 = pictureEditKimlikArka.GetLoadedImageLocation().ToString();
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var deger = repo.Find(x => x.MisafirID == id);
                deger.AdSoyad = TxtAdSoyad.Text;
                deger.TC = TxtTcNo.Text;
                deger.Telefon = TxtTelefon.Text;
                deger.Mail = TxtMail.Text;
                deger.Adres = TxtAdres.Text;
                deger.Aciklama = TxtAciklama.Text;
                deger.KimlikFoto1 = resim1;
                deger.KimlikFoto2 = resim2;
                deger.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                deger.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                deger.ilce = int.Parse(lookUpEditİlce.EditValue.ToString());
                deger.Durum = 1;
                repo.TUpdate(deger);
                XtraMessageBox.Show("Misafir Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException ex)
            {
                // Girilen değerleri uygun bir formatta dönüştürme hatası
                XtraMessageBox.Show("Geçersiz bir değer girdiniz: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer genel hata durumları için
                XtraMessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                t.AdSoyad = TxtAdSoyad.Text;
                t.TC = TxtTcNo.Text;
                t.Telefon = TxtTelefon.Text;
                t.Mail = TxtMail.Text;
                t.Adres = TxtAdres.Text;
                t.Aciklama = TxtAciklama.Text;
                t.Durum = 1;
                t.sehir = int.Parse(lookUpEditSehir.EditValue.ToString());
                t.ilce = int.Parse(lookUpEditİlce.EditValue.ToString());
                t.Ulke = int.Parse(lookUpEditUlke.EditValue.ToString());
                t.KimlikFoto1 = resim1;
                t.KimlikFoto2 = resim2;
                repo.TAdd(t);
                XtraMessageBox.Show("Misafir Sisteme Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (FormatException ex)
            {
                // Girilen değerleri uygun bir formatta dönüştürme hatası
                XtraMessageBox.Show("Geçersiz bir değer girdiniz: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Diğer genel hata durumları için
                XtraMessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}

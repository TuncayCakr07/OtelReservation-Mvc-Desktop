using DevExpress.Data.WcfLinq.Helpers;
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

namespace Otelreservation.Formlar.Rezervasyon
{
    public partial class FrmRezervasyonKarti : Form
    {
        public FrmRezervasyonKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        public int id;
        Repository<TblRezervasyon> repo = new Repository<TblRezervasyon>();
        TblRezervasyon t = new TblRezervasyon();
        private void FrmRezervasyonKarti_Load(object sender, EventArgs e)
        {
            // Guest Group List1
            lookUpEditMisafir.Properties.DataSource = (from x in db.TblMisafir
                                                        select new
                                                        {
                                                            x.MisafirID,
                                                            x.AdSoyad,
                                                        }).ToList();

            // Guest Group List2
            lookUpEditKisi1.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad,
                                                       }).ToList();
            // Guest Group List3
            lookUpEditKisi2.Properties.DataSource = (from x in db.TblMisafir
                                                       select new
                                                       {
                                                           x.MisafirID,
                                                           x.AdSoyad,
                                                       }).ToList();

            // Guest Group List4
            lookUpEditKisi3.Properties.DataSource = (from x in db.TblMisafir
                                                     select new
                                                     {
                                                         x.MisafirID,
                                                         x.AdSoyad
                                                     }).ToList();

            // Room Group List
            lookUpEditOda.Properties.DataSource = (from x in db.TblOda
                                                        select new
                                                        {
                                                            x.OdaID,
                                                            x.OdaNo,
                                                            x.TblDurum.DurumAd
                                                        }).Where(y=> y.DurumAd=="Aktif").ToList();

            // Status Group List
            lookUpEditRezDurum.Properties.DataSource = (from x in db.TblDurum
                                                   select new
                                                   {
                                                       x.DurumID,
                                                       x.DurumAd
                                                   }).ToList();
            if (id != 0)
            {
                var reservation = repo.Find(x => x.RezervasyonID == id);
                lookUpEditMisafir.EditValue = reservation.Misafir;
                dateEditGirisTarih.Text = reservation.GirisTarih.ToString();
                dateEditCikisTarih.Text = reservation.CikisTarih.ToString();
                numericUpDownKisi.Value = decimal.Parse(reservation.Kisi.ToString());
                lookUpEditOda.EditValue = reservation.Oda;
                TxtTelefon.Text = reservation.Telefon.ToString();
                lookUpEditRezDurum.EditValue = reservation.Durum;
                TxtAciklama.Text = reservation.Aciklama;
                lookUpEditKisi1.EditValue = reservation.Kisi1;
                lookUpEditKisi2.EditValue = reservation.Kisi2;
                lookUpEditKisi3.EditValue = reservation.Kisi3;
                TxtToplam.Text = reservation.Tutar.ToString();
                TxtOdaNo.Text = reservation.TblOda.OdaNo;

            }


        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblRezervasyon t=new TblRezervasyon();
            try
            {
                if (numericUpDownKisi.Value==1)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                }
                if (numericUpDownKisi.Value==2)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                }
                if (numericUpDownKisi.Value == 3)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                    t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                else if (numericUpDownKisi.Value == 4)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    t.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                    t.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    t.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                }
                t.GirisTarih = DateTime.Parse(dateEditGirisTarih.Text);
                t.CikisTarih = DateTime.Parse(dateEditCikisTarih.Text);
                t.Kisi=numericUpDownKisi.Value.ToString();
                t.Oda=int.Parse(lookUpEditOda.EditValue.ToString());
                //t.RezervasyonAdSoyad=TxtRezervasyonAd.Text;
                t.Telefon=TxtTelefon.Text;
                t.Aciklama=TxtAciklama.Text;
                t.Durum=int.Parse(lookUpEditRezDurum.EditValue.ToString());
                t.Tutar=decimal.Parse(TxtToplam.Text);
                repo.TAdd(t);

                XtraMessageBox.Show("Rezervasyon Başarıyla Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (FormatException ex)
            {
                XtraMessageBox.Show("Geçersiz bir değer girdiniz: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lookUpEditMisafir_EditValueChanged(object sender, EventArgs e)
        {
            int secilen;
            secilen=int.Parse(lookUpEditMisafir.EditValue.ToString());
            var telefon = db.TblMisafir.Where(x => x.MisafirID == secilen).Select(y => y.Telefon).FirstOrDefault();
            TxtTelefon.Text = telefon.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
         
            var rezervasyon = repo.Find(x => x.RezervasyonID == id);
            try
            {
                if (lookUpEditRezDurum.Text=="Çıkış Yapıldı")
                {
                    Repository<TblOda> repo2 = new Repository<TblOda>();
                    var odadurum = repo2.Find(x => x.OdaID == rezervasyon.Oda);
                    odadurum.Durum = 3;
                    repo2.TUpdate(odadurum);
                    rezervasyon.KasayaAktar = true;
                    repo.TUpdate(rezervasyon);

                    //Kasaya Aktarma İşlemi
                    TblKasaHareket tkasa=new TblKasaHareket();
                    Repository<TblKasaHareket> repokasa = new Repository<TblKasaHareket>();
                    tkasa.Misafir = lookUpEditMisafir.Text;
                    tkasa.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
                    tkasa.Tutar = decimal.Parse(TxtToplam.Text);
                    repokasa.TAdd(tkasa);
                }
                rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                rezervasyon.GirisTarih = DateTime.Parse(dateEditGirisTarih.Text);
                rezervasyon.CikisTarih = DateTime.Parse(dateEditCikisTarih.Text);
                rezervasyon.Kisi=numericUpDownKisi.Value.ToString();
                rezervasyon.Oda = int.Parse(lookUpEditOda.EditValue.ToString());
                rezervasyon.Telefon = TxtTelefon.Text;
                rezervasyon.Durum = int.Parse(lookUpEditRezDurum.EditValue.ToString());

                if (numericUpDownKisi.Value == 1)
                {
                    rezervasyon.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                }
                if (numericUpDownKisi.Value == 2)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                }
                if (numericUpDownKisi.Value == 3)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                    rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                }
                else if (numericUpDownKisi.Value == 4)
                {
                    t.Misafir = int.Parse(lookUpEditMisafir.EditValue.ToString());
                    rezervasyon.Kisi1 = int.Parse(lookUpEditKisi1.EditValue.ToString());
                    rezervasyon.Kisi2 = int.Parse(lookUpEditKisi2.EditValue.ToString());
                    rezervasyon.Kisi3 = int.Parse(lookUpEditKisi3.EditValue.ToString());
                }
                rezervasyon.Aciklama = TxtAciklama.Text;
               rezervasyon.Tutar = decimal.Parse(TxtToplam.Text);
                repo.TUpdate(rezervasyon);
                XtraMessageBox.Show("Rezervasyon Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

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

namespace Otelreservation.Formlar.Urun
{
    public partial class FrmUrunKarti : Form
    {
        public FrmUrunKarti()
        {
            InitializeComponent();
        }

        DbOtelEntities db = new DbOtelEntities();
        public int id;
        Repository<TblUrun> repo = new Repository<TblUrun>();
        TblUrun t = new TblUrun();
        private void FrmUrunKarti_Load(object sender, EventArgs e)
        {
            // Product Group List
            lookUpEditUrunGrup.Properties.DataSource = (from x in db.TblUrunGrup
                                                    select new
                                                    {
                                                        x.UrunGrupID,
                                                        x.UrunGrupAd,
                                                    }).ToList();
            //Unit List

            lookUpEditBirim.Properties.DataSource = (from x in db.TblBirim
                                                    select new
                                                    {
                                                        x.BirimID,
                                                        x.BirimAD,
                                                    }).ToList();
            //Product List 

            lookUpEditDurum.Properties.DataSource = (from x in db.TblDurum
                                                    select new
                                                    {
                                                        x.DurumID,
                                                        x.DurumAd,
                                                    }).ToList();

            //Product Upgrade 
            if (id!=0)
            {
                var urun=repo.Find(x=> x.UrunID==id);
                TxtUrunAdi.Text = urun.UrunAd;
                lookUpEditUrunGrup.EditValue = urun.UrunGrup;
                lookUpEditBirim.EditValue = urun.Birim;
                TxtFiyat.Text=urun.Fiyat.ToString();
                TxtToplam.Text=urun.Toplam.ToString();
                TxtKdv.Text=urun.Kdv.ToString();
                lookUpEditDurum.EditValue = urun.Durum;
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                t.UrunAd=TxtUrunAdi.Text;
                t.UrunGrup=int.Parse(lookUpEditUrunGrup.EditValue.ToString());
                t.Birim=int.Parse(lookUpEditBirim.EditValue.ToString());
                t.Durum=int.Parse(lookUpEditDurum.EditValue.ToString());
                t.Fiyat = decimal.Parse(TxtFiyat.Text);
                t.Toplam=decimal.Parse(TxtToplam.Text);
                t.Kdv=byte.Parse(TxtKdv.Text);
                repo.TAdd(t);
                XtraMessageBox.Show("Ürün Sisteme Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = repo.Find(x => x.UrunID == id);
            try
            {
               urun.UrunAd = TxtUrunAdi.Text;
                urun.UrunGrup = int.Parse(lookUpEditUrunGrup.EditValue.ToString());
                urun.Birim = int.Parse(lookUpEditBirim.EditValue.ToString());
                urun.Durum = int.Parse(lookUpEditDurum.EditValue.ToString());
                urun.Fiyat = decimal.Parse(TxtFiyat.Text);
                urun.Toplam = decimal.Parse(TxtToplam.Text);
                urun.Kdv = byte.Parse(TxtKdv.Text);
                repo.TUpdate(urun);
                XtraMessageBox.Show("Ürün Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            TxtKdv.Text = "1";
        }

        private void rdb8_CheckedChanged(object sender, EventArgs e)
        {
            TxtKdv.Text = "8";
        }

        private void rdb10_CheckedChanged(object sender, EventArgs e)
        {
            TxtKdv.Text = "10";
        }

        private void rdb20_CheckedChanged(object sender, EventArgs e)
        {
            TxtKdv.Text = "20";
        }
    }
}

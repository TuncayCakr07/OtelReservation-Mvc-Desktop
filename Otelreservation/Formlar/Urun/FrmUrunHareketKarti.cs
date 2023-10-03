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
    public partial class FrmUrunHareketKarti : Form
    {
        public FrmUrunHareketKarti()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        public int id;
        Repository<TblUrunHareket> repo = new Repository<TblUrunHareket>();
        TblUrunHareket t = new TblUrunHareket();
        private void FrmUrunHareketKarti_Load(object sender, EventArgs e)
        {
            //id values
            TxtID.Text =id.ToString();
            TxtID.Enabled = false; 
           
            lookUpEditUrun.Properties.DataSource = (from x in db.TblUrun
                                                        select new
                                                        {
                                                            x.UrunID,
                                                            x.UrunAd,
                                                        }).ToList();

            lookUpEditPersonel.Properties.DataSource = (from x in db.TblPersonel
                                                    select new
                                                    {
                                                        x.PersonelID,
                                                        x.AdSoyad,
                                                    }).ToList();
            //data's Reload
            if (id!=0)
            {
                var urun = repo.Find(x => x.HareketID == id);
                lookUpEditUrun.EditValue=urun.Urun;
                TxtMiktar.Text = urun.Miktar.ToString();
                TxtAciklama.Text = urun.Aciklama;
                comboBox1.Text = urun.HareketTuru;
                dateEdit1.Text = urun.Tarih.ToString();
                lookUpEditPersonel.EditValue = urun.Personel;
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
                t.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
                t.Tarih = DateTime.Parse(dateEdit1.Text);
                t.HareketTuru = comboBox1.Text;
                t.Miktar = decimal.Parse(TxtMiktar.Text);
                t.Aciklama = TxtAciklama.Text;
                t.Personel = int.Parse(lookUpEditPersonel.EditValue.ToString());

                if (comboBox1.Text=="Giriş")
                {
                    t.BirimFiyat = decimal.Parse(TxtBirimFiyat.Text);
                    t.ToplamFiyat = decimal.Parse(TxttoplamFiyat.Text);
                }
                repo.TAdd(t);
                XtraMessageBox.Show("Ürün Hareketi Başarıyla Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            var urun = repo.Find(x => x.HareketID == id);
            try
            {
                urun.Urun = int.Parse(lookUpEditUrun.EditValue.ToString());
                urun.Tarih = DateTime.Parse(dateEdit1.Text);
                urun.HareketTuru = comboBox1.Text;
                urun.Miktar = decimal.Parse(TxtMiktar.Text);
                urun.Aciklama = TxtAciklama.Text;
                urun.Personel = int.Parse(lookUpEditPersonel.EditValue.ToString());
                repo.TUpdate(urun);
                XtraMessageBox.Show("Ürün Hareketi Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void TxtMiktar_ValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text=="Giriş")
            {
                double miktar, birimfiyat, toplam;
                miktar = Convert.ToDouble(TxtMiktar.Value);
                birimfiyat = Convert.ToDouble(TxtBirimFiyat.Text);
                toplam = miktar * birimfiyat;
                TxttoplamFiyat.Text = toplam.ToString();
            }

        }
    }
}

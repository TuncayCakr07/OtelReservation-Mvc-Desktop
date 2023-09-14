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
                t.Personel = int.Parse(lookUpEditUrun.EditValue.ToString());
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
    }
}

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
            // Guest Group List
            lookUpEditMisafir.Properties.DataSource = (from x in db.TblMisafir
                                                        select new
                                                        {
                                                            x.MisafirID,
                                                            x.AdSoyad,
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
                t.Misafir=int.Parse(lookUpEditMisafir.EditValue.ToString());
                t.GirisTarih = DateTime.Parse(dateEditGirisTarih.Text);
                t.CikisTarih = DateTime.Parse(dateEditCikisTarih.Text);
                t.Kisi=numericUpDownKisi.Value.ToString();
                t.Oda=int.Parse(lookUpEditOda.EditValue.ToString());
                t.RezervasyonAdSoyad=TxtRezervasyonAd.Text;
                t.Telefon=TxtTelefon.Text;
                t.Aciklama=TxtAciklama.Text;
                t.Durum=int.Parse(lookUpEditRezDurum.EditValue.ToString());
                repo.TAdd(t);

                XtraMessageBox.Show("Rezervasyon Başarıyla Oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

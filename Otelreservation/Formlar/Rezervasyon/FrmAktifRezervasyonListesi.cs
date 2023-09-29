using Otelreservation.Entity;
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
    public partial class FrmAktifRezervasyonListesi : Form
    {
        public FrmAktifRezervasyonListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmAktifRezervasyonListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblRezervasyon
                                       select new
                                       {
                                           x.RezervasyonID,
                                           x.TblMisafir.AdSoyad,
                                           x.GirisTarih,
                                           x.CikisTarih,
                                           x.Kisi,
                                           x.TblOda.OdaNo,
                                           x.Telefon,
                                           x.TblDurum.DurumAd
                                       }).Where(y=> y.DurumAd=="Aktif").ToList();
        }
        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Seçilen rezervasyonun ID'sini alın
                int rezervasyonID = int.Parse(gridView1.GetFocusedRowCellValue("RezervasyonID").ToString());

                // Silme işlemi
                SilRezervasyon(rezervasyonID);

                // Grid'i güncelleme veya yeniden yükleme işlemi
                FrmAktifRezervasyonListesi_Load(sender, e);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Geçersiz bir değer girdiniz: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SilRezervasyon(int rezervasyonID)
        {
            try
            {
                // Rezervasyonu bul ve sil
                var rezervasyon = db.TblRezervasyon.FirstOrDefault(x => x.RezervasyonID == rezervasyonID);
                if (rezervasyon != null)
                {
                    db.TblRezervasyon.Remove(rezervasyon);
                    db.SaveChanges();
                    MessageBox.Show("Rezervasyon başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Rezervasyon bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

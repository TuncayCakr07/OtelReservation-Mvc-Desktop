using DevExpress.ClipboardSource.SpreadsheetML;
using Otelreservation.Entity;
using Otelreservation.Formlar.Personel;
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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = (from x in db.TblUrun
                                       select new
                                       {
                                           x.UrunID,
                                           x.UrunAd,
                                           x.TblUrunGrup.UrunGrupAd,
                                           x.Fiyat,
                                           x.TblBirim.BirimAD,
                                           x.Toplam,
                                           x.TblDurum.DurumAd
                                       }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmUrunKarti fr= new FrmUrunKarti();
            fr.id=int.Parse(gridView1.GetFocusedRowCellValue("UrunID").ToString());
            fr.Show();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Ürünü silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    int urunID = int.Parse(gridView1.GetFocusedRowCellValue("UrunID").ToString());
                    SilUrun(urunID);
                    FrmUrunListesi_Load(sender, e);
                }
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


        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUrunKarti fr = new FrmUrunKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("UrunID").ToString());
            fr.Show();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SilUrun(int urunID)
        {
            try
            {
                var urun = db.TblUrun.FirstOrDefault(x => x.UrunID == urunID);
                if (urun != null)
                {
                    db.TblUrun.Remove(urun);
                    var hareketler = db.TblUrunHareket.Where(x => x.Urun == urunID);
                    db.TblUrunHareket.RemoveRange(hareketler);

                    db.SaveChanges();
                    MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ürün bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

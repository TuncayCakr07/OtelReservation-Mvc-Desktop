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

namespace Otelreservation.Formlar.Personel
{
    public partial class FrmPersonelListesi : Form
    {
        public FrmPersonelListesi()
        {
            InitializeComponent();
        }
        DbOtelEntities db=new DbOtelEntities();
        private void FrmPersonelListesi_Load(object sender, EventArgs e)
        {
           gridControl1.DataSource = (from x in db.TblPersonel
                            select new
                            {
                                x.PersonelID,
                                x.AdSoyad,
                                x.TC,
                                x.Telefon,
                                x.Mail,
                                x.TblDepartman.DepartmanAD,
                                x.TblGorev.GorevAD,
                                x.TblDurum.DurumAd
                            }).ToList();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmPersonelKarti fr =new FrmPersonelKarti();
            fr.id=int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());
            fr.Show();
        }

        private void vazgeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Personeli silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                int personelID = int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());
                SilPersoneli(personelID);
                FrmPersonelListesi_Load(sender, e);
            }
        }

        private void SilPersoneli(int personelID)
        {
            try
            {
                var personel = db.TblPersonel.FirstOrDefault(x => x.PersonelID == personelID);
                if (personel != null)
                {
                    db.TblPersonel.Remove(personel);
                    db.SaveChanges();
                    MessageBox.Show("Personel başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Personel bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPersonelKarti fr = new FrmPersonelKarti();
            fr.id = int.Parse(gridView1.GetFocusedRowCellValue("PersonelID").ToString());
            fr.Show();
        }
    }
}

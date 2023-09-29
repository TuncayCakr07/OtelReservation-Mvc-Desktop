using Otelreservation.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Admin
{
    public partial class FrmSifreİslemleri : Form
    {
        public FrmSifreİslemleri()
        {
            InitializeComponent();
        }
        DbOtelEntities db = new DbOtelEntities();
        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxTYeniSifre.Text==TxtYeniSifreTekrar.Text)
                {
                    TblAdmin t = new TblAdmin();
                    t.Kullanici = TxtKullaniciAdi.Text;
                    t.Sifre = TxTYeniSifre.Text;
                    db.TblAdmin.Add(t);
                    db.SaveChanges();
                    MessageBox.Show("Yeni kullanıcı başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bir hata oluştu: Şifreler Uyuşmuyor! Şifreleri Kontrol Ediniz!", "Uyarı!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("Veritabanına kaydetme hatası: " + ex.InnerException.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "HATA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

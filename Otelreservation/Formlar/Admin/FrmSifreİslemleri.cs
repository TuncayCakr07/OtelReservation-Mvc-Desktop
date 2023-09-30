using DevExpress.XtraEditors;
using Otelreservation.Entity;
using Otelreservation.Repositories;
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
        public int id;
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
        Repository<TblAdmin> repo= new Repository<TblAdmin>();
        private void FrmSifreİslemleri_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var admin = repo.Find(x => x.ID == id);
                TxtKullaniciAdi.Text = admin.Kullanici;
                TxtMevcutSifre.Text = admin.Sifre;
                txtRol.Text = admin.Rol;
        
            }
        }
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxTYeniSifre.Text==TxtYeniSifreTekrar.Text)  
                {
                var deger = repo.Find(x => x.ID == id);
                deger.Kullanici = TxtKullaniciAdi.Text;
                deger.Sifre = TxTYeniSifre.Text;
                deger.Rol = txtRol.Text;
                repo.TUpdate(deger);
                XtraMessageBox.Show("Admin Bilgileri Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Şifreler Uyuşmamaktadır! Şifreleri Kontrol Ediniz!","HATA!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
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


        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmKullaniciListesi fr=new FrmKullaniciListesi();
            fr.Show();
            this.Hide();
        }
    }
}

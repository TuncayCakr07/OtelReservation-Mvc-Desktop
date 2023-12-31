﻿using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraPrinting;
using Otelreservation.Entity;
using Otelreservation.Formlar.Misafir;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnDurum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDurum fr = new Formlar.Tanımlamalar.FrmDurum();
            fr.Show();
        }

        private void BtnBirimTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmBirim fr = new Formlar.Tanımlamalar.FrmBirim();
            fr.Show();
        }

        private void BtnDepartmanTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmDepartman fr = new Formlar.Tanımlamalar.FrmDepartman();
            fr.Show();
        }

        private void BtnGorevTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmGorev fr = new Formlar.Tanımlamalar.FrmGorev();
            fr.Show();
        }

        private void BtnKasaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa fr = new Formlar.Tanımlamalar.FrmKasa();
            fr.Show();
        }

        private void BtnKurTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKurlar fr = new Formlar.Tanımlamalar.FrmKurlar();
            fr.Show();
        }

        private void BtnOdaTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmOda fr = new Formlar.Tanımlamalar.FrmOda();
            fr.Show();
        }

        private void BtnTelefonTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmTelefon fr = new Formlar.Tanımlamalar.FrmTelefon();
            fr.Show();
        }

        private void BtnUlkeTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUlke fr = new Formlar.Tanımlamalar.FrmUlke();
            fr.Show();
        }

        private void BtnUrunGrupTanimlari_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmUrunGrup fr = new Formlar.Tanımlamalar.FrmUrunGrup();
            fr.Show();
        }

        private void BtnPersonelKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelKarti fr = new Formlar.Personel.FrmPersonelKarti();
            fr.Show();
        }

        private void BtnPersonelListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Personel.FrmPersonelListesi fr = new Formlar.Personel.FrmPersonelListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BnMisafirKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirKarti fr = new Formlar.Misafir.FrmMisafirKarti();
            fr.Show();
        }

        private void BtnMisafirListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Misafir.FrmMisafirListesi fr = new Formlar.Misafir.FrmMisafirListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnUrunListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunListesi fr = new Formlar.Urun.FrmUrunListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunKarti fr = new Formlar.Urun.FrmUrunKarti();
            fr.Show();
        }

        private void BtnUrunGirisHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunGirisHareket fr = new Formlar.Urun.FrmUrunGirisHareket();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnUrunCikisHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Formlar.Urun.FrmUrunCikishareket fr = new Formlar.Urun.FrmUrunCikishareket();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniUrunHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Urun.FrmUrunHareketKarti fr = new Formlar.Urun.FrmUrunHareketKarti();
            fr.Show();
        }

        private void BtnYeniRezervasyonKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmRezervasyonKarti fr = new Formlar.Rezervasyon.FrmRezervasyonKarti();
            fr.Show();
        }

        private void BtnButunRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmButunRezervasyonlar fr = new Formlar.Rezervasyon.FrmButunRezervasyonlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnAktifRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmAktifRezervasyonListesi fr = new Formlar.Rezervasyon.FrmAktifRezervasyonListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnİptalEdilenRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmİptalEdilenRezervasyonlar fr = new Formlar.Rezervasyon.FrmİptalEdilenRezervasyonlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGecmisRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmGecmisRezervasyonlar fr = new Formlar.Rezervasyon.FrmGecmisRezervasyonlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGelecekRezervasyonlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Rezervasyon.FrmGelecekRezervasyonlarListesi fr = new Formlar.Rezervasyon.FrmGelecekRezervasyonlarListesi();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void BtnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void BtnHesapmakinesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BtnKurlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araçlar.FrmKurlar fr = new Formlar.Araçlar.FrmKurlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGoogle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araçlar.FrmGoogle fr = new Formlar.Araçlar.FrmGoogle();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araçlar.FrmYabanciSorgulama fr = new Formlar.Araçlar.FrmYabanciSorgulama();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniKayıtlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmYeniKayit fr = new Formlar.WebSite.FrmYeniKayit();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmOnRezervasyon fr = new Formlar.WebSite.FrmOnRezervasyon();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGelenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmGelenMesajlar fr = new Formlar.WebSite.FrmGelenMesajlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniMesaj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmMesajKarti fr = new Formlar.WebSite.FrmMesajKarti();
            fr.Show();
        }

        private void BtnGidenMesajlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmGidenMesajlar fr = new Formlar.WebSite.FrmGidenMesajlar();
            fr.MdiParent = this;
            fr.Show();
        }

        private void Btnİletisim_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.Frmİletisim fr = new Formlar.WebSite.Frmİletisim();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnAdresKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmAdresKarti fr = new Formlar.WebSite.FrmAdresKarti();
            fr.Show();
        }

        private void BtnHakkimdaKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.WebSite.FrmHakkimizda fr = new Formlar.WebSite.FrmHakkimizda();
            fr.Show();
        }

        private void BtnHizliBakis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.AnaForm.FrmAnaForm fr = new Formlar.AnaForm.FrmAnaForm();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnGrafik1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Grafikler.FrmGrafik2 fr = new Formlar.Grafikler.FrmGrafik2();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnUrunStokGrafigi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Grafikler.FrmGrafik1 fr = new Formlar.Grafikler.FrmGrafik1();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnSifre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Admin.FrmSifreİslemleri fr = new Formlar.Admin.FrmSifreİslemleri();
            fr.Show();
        }
        public string kullanicirolu;
        private void Form1_Load(object sender, EventArgs e)
        {
            if (kullanicirolu == "S")
            {

                ribbonPage6.Visible = true;

            }
            else
            {
                ribbonPage6.Visible = false;
            }

            Formlar.AnaForm.FrmAnaForm fr = new Formlar.AnaForm.FrmAnaForm();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYetkiler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Admin.FrmSifreİslemleri fr = new Formlar.Admin.FrmSifreİslemleri();
            fr.Show();
        }

        private void BtnYedekleme_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Veri yedek dosyası|*.bak";
            save.FileName = "Sonic_OtelRezervasyon_DataBaseBackup_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".bak";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    if (File.Exists(save.FileName))
                    {
                        File.Delete(save.FileName);
                    }
                    var dbHedef = save.FileName;
                    string dbKaynak = "Data Source=DESKTOP-2BCQ69S\\MSİ;Initial Catalog=DbOtel;Integrated Security=True";
                    // SqlConnection kullanarak veritabanı yedeğini oluşturun
                    using (SqlConnection sqlCon = new SqlConnection(dbKaynak))
                    {
                        sqlCon.Open();
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "BACKUP DATABASE [" + sqlCon.Database + "] TO DISK='" + dbHedef + "'";
                        cmd.Connection = sqlCon;
                        cmd.ExecuteNonQuery();
                        sqlCon.Close();
                    }

                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Yedekleme İşlemi Tamamlandı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Yedekleme işlemi sırasında hata oluştu: " + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnYardım_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Araclar.FrmYardimTalebi fr = new Formlar.Araclar.FrmYardimTalebi();
            fr.Show();
        }

        private void BtnResepsiyonHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Kasa.FrmResepsiyonHareket fr = new Formlar.Kasa.FrmResepsiyonHareket();
            fr.MdiParent = this;
            fr.Show();
        }

        private void BtnYeniKasaKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Tanımlamalar.FrmKasa fr = new Formlar.Tanımlamalar.FrmKasa();
            fr.Show();
        }

        private void BtnKasaCikisKarti_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Kasa.FrmKasaCikisHaraketi fr = new Formlar.Kasa.FrmKasaCikisHaraketi();
            fr.Show();
        }

        private void BtnKasaCikisHareketleri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Kasa.FrmKasaCikisHareketleri fr = new Formlar.Kasa.FrmKasaCikisHareketleri();
            fr.MdiParent = this;
            fr.Show();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.Raporlar.RaporFormu fr = new Formlar.Raporlar.RaporFormu();
            fr.Show();
        }
    }
}

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

namespace Otelreservation.Formlar.WebSite
{
    public partial class FrmOnRezervasyonKarti : Form
    {
        public FrmOnRezervasyonKarti()
        {
            InitializeComponent();
        }
    
        DbOtelEntities db=new DbOtelEntities();
        Repository<TblOnRezervasyon> repo = new Repository<TblOnRezervasyon>();
        public int id;
        private void FrmOnRezervasyonKarti_Load(object sender, EventArgs e)
        {
            if (id != 0)
            {
                var reservation = repo.Find(x => x.ID == id);
                dateEditGirisTarih.Text = reservation.GirisTarih.ToString();
                dateEditCikisTarih.Text = reservation.CikisTarih.ToString();
                dateEditRezTarih.Text = reservation.Tarih.ToString();
                numericUpDownKisi.Value = decimal.Parse(reservation.Kisi.ToString());
                TxtTelefon.Text = reservation.Telefon.ToString();
                TxtAdSoyad.Text = reservation.AdSoyad;
                TxtAciklama.Text = reservation.Aciklama;
                TxtMail.Text = reservation.Mail;

            }
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

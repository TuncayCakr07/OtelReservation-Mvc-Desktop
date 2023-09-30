using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otelreservation.Formlar.Araclar
{
    public partial class FrmYardimTalebi : Form
    {
        public FrmYardimTalebi()
        {
            InitializeComponent();
        }

        private void FrmYardimTalebi_Load(object sender, EventArgs e)
        {
            TxtKonu.Text = "Destek Ve Yardım Talebi";
            TxtAlici.Text = "info@softcakir.com";
        }

        private void BtnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mm = new MailMessage();
                string frommail = "adminotelrezervasyon@softcakir.com";
                string sifre = "123456789a";
                string receiver = TxtAlici.Text;
                string subject = TxtKonu.Text;
                string content = richTextBox1.Text.ToString();
                mm.From = (new MailAddress(frommail));
                mm.To.Add(receiver);
                mm.Subject = subject;
                mm.Body = content;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient("mail.softcakir.com");
                smtp.Port = 587;
                //string appPassword = "voaxjcghtayqzljj";
                smtp.Credentials = new NetworkCredential(frommail, sifre);
                smtp.EnableSsl = false;
                smtp.Send(mm);
                MessageBox.Show("Mail Başarıyla Gönderildi.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mail gönderme işlemi sırasında hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

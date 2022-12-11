using KullaniciArayuzu.DAL.ORM.Context;
using KullaniciArayuzu.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KullaniciArayuzu
{
    public partial class KullaniciOlusturma : Form
    {
        Form1 mainform;
        ProjeContext db = new ProjeContext();
        public KullaniciOlusturma(Form1 f1)
        {
            mainform= f1;
            InitializeComponent();
        }

        private void KullaniciOlusturma_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text==txtSifreKontrol.Text)
            {
                AppUser user = new AppUser();
                user.Name = txtAd.Text;
                user.LastName = txtSoyad.Text;
                user.UserName = txtKullaniciAdi.Text;
                user.Password = txtSifre.Text;
                user.BirthDate = dtpDogumTarihi.Value;
                user.Added_Time = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Kullanıcı ekleme başarılı giriş yapma sayfasına yönlendiriliyorsunuz..");
                mainform.Show();
                this.Hide();
               
            }
            else
            {
                MessageBox.Show("Lütfen şifre alanlarını kontrol ediniz..");
            }
            

        }
    }
}

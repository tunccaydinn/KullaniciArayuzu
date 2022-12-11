using KullaniciArayuzu.DAL.ORM.Context;
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
 
    public partial class KullaniciAyar : Form
    {
           Form1 mainform;
       
        ProjeContext db = new ProjeContext();
        public KullaniciAyar()
        {
         //   mainform = f1;
            InitializeComponent();
        }
        string kadi = Form1.username;
        
        private void KullaniciAyar_Load(object sender, EventArgs e)
        {


            //  var Id = 5; // ornegin (primary key) Id'si 5 olan kayit


            var sorgu = db.Users.SingleOrDefault(r => r.UserName == kadi);
            if (sorgu != null)
            {
                txtAd.Text = sorgu.Name;
                txtSoyad.Text = sorgu.LastName;
                txtSifre.Text = sorgu.Password;
                txtKullaniciAdi.Text = sorgu.UserName;
                dtpDogumTarihi.Value = sorgu.BirthDate;
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var guncellenecek = db.Users.SingleOrDefault(x => x.UserName == kadi);
            if (guncellenecek!=null)
            {
                guncellenecek.Name = txtAd.Text;
                guncellenecek.LastName = txtSoyad.Text;
                guncellenecek.Password = txtSifre.Text;
                guncellenecek.UserName = txtKullaniciAdi.Text;
                db.SaveChanges();
                MessageBox.Show("Bilgiler güncellenmiştir lütfen tekrar giriş yapınız");

                Form1 frm = new Form1();
                frm.Show();
                this.Hide();


            }
        }

        private void KullaniciAyar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form2 frm2 = new Form2(mainform);
            frm2.Show();



        }
    }
}

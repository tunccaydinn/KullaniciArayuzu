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
    public partial class Form1 : Form
    {
        ProjeContext db = new ProjeContext();
        public Form1()
        {
            InitializeComponent();
        }
        public static string  username;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            GirisKontrol(txtKullaniciAdi.Text, txtPassword.Text);
        }

        public void GirisKontrol(string kadi,string sifre)

        {
            if (db.Users.Any(X=>X.UserName==kadi&&X.Password==sifre))
            {
                username = kadi;
                Form2 frm2 = new Form2(this);
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı!!");
            }
        }

        private void btnKullaniciOlustur_Click(object sender, EventArgs e)
        {
            KullaniciOlusturma olusturma = new KullaniciOlusturma(this);
            olusturma.Show();
            this.Hide();
        }
    }
}

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
    public partial class Form2 : Form
    {
        ProjeContext db = new ProjeContext();
        Form1 mainform;
        public Form2(Form1 f1)
        {
            mainform = f1;
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainform.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        //    this.Text = mainform.Text;
            UrunListesi();
        }

        public void UrunListesi()
        {
            lstUrunler.Items.Clear();

            foreach (Product item in db.Products.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.Id.ToString();
                lvi.SubItems.Add(item.Name);
                lvi.SubItems.Add(item.UnitPrice.ToString());
                lvi.SubItems.Add(item.UnitInStock.ToString());
                lvi.SubItems.Add(item.QuantityUnit.ToString());
                lvi.Tag = item;
                lstUrunler.Items.Add(lvi);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product urun = new Product();

            if (txtUrunAdi.Text!=""&&txtBirim.Text!=""&&txtFiyat.Text!=""&&txtStok.Text!="")
            {
                urun.Name = txtUrunAdi.Text;
                urun.UnitPrice = Convert.ToDecimal(txtFiyat.Text);
                urun.UnitInStock = Convert.ToInt16(txtStok.Text);
                urun.QuantityUnit = txtBirim.Text;
                db.Products.Add(urun);
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!!");
            }

            UrunListesi();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            KullaniciAyar ayar = new KullaniciAyar();
            ayar.Show();
            this.Hide();
        }
        public void KullaniciBilgileri()
        {

        }
        Product guncellenecek;
        private void lstUrunler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lstUrunler.SelectedItems.Count <= 0) return;

            guncellenecek = lstUrunler.SelectedItems[0].Tag as Product;
            txtUrunAdi.Text = guncellenecek.Name;
            txtStok.Text = guncellenecek.UnitInStock.ToString();
            txtFiyat.Text = guncellenecek.UnitPrice.ToString();
            txtBirim.Text = guncellenecek.QuantityUnit.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncellenecek.Name = txtUrunAdi.Text;
            guncellenecek.QuantityUnit = txtBirim.Text;
            guncellenecek.UnitInStock = Convert.ToInt16(txtStok.Text);
            guncellenecek.UnitPrice =Convert.ToDecimal(txtFiyat.Text);
            db.SaveChanges();
            MessageBox.Show(guncellenecek.Name+" Ürünü başarılı bir şekilde güncellenmiştir.");
            UrunListesi();
            Temizle();


        }

        void Temizle()
        {
            txtBirim.Clear();
            txtFiyat.Clear();
            txtStok.Clear();
            txtUrunAdi.Clear();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id=((Product)lstUrunler.SelectedItems[0].Tag).Id;
            Product silinecek = db.Products.Find(id);
            db.Products.Remove(silinecek);
            db.SaveChanges();
            UrunListesi();

        }
    }
}

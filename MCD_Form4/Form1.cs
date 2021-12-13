using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCD_Form4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            DialogResult resultEnum = MessageBox.Show("Form içerisinde bulunan değerleri silmek istediğinizden emin misiniz?", "Form temizleme işlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultEnum == DialogResult.Yes)
            {
                formTemizle();
                formElemanIndexTemizle();
            }
            else
            {
                // işlem iptal edildi...

            }
        }
        private void formTemizle()
        {
            foreach (Control item in this.Controls)
            {
                if (item is TextBox) // item.control == TextBox
                {
                    TextBox T = (TextBox)item;
                    T.Text = string.Empty;
                }
            }
        }
        private void formElemanIndexTemizle()
        {
            ((TextBox)this.Controls["txtIsim"]).Text = string.Empty;
            ((TextBox)this.Controls["txtSoyisim"]).Text = string.Empty;
            ((TextBox)this.Controls["txtEmailAdres"]).Text = string.Empty;
            ((TextBox)this.Controls["txtTelefon"]).Text = string.Empty;
        }

        private void btnOnizlemeYap_Click(object sender, EventArgs e)
        {
            FrmOnizlemeKayit onizlemeKayit = new FrmOnizlemeKayit();
            ((TextBox)onizlemeKayit.Controls["txtIsim"]).Text = txtIsim.Text;
            ((TextBox)onizlemeKayit.Controls["txtSoyisim"]).Text = txtSoyisim.Text;
            ((TextBox)onizlemeKayit.Controls["txtEmailAdres"]).Text = txtEmailAdres.Text;
            ((TextBox)onizlemeKayit.Controls["txtTelefon"]).Text = txtTelefon.Text;
            onizlemeKayit.ShowDialog();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // sanaldatabase içerisine kayıt işlemi olacak
            //formTemizle();
            yeniMusteriEkle(new Musteri()
            {
                Isim = txtIsim.Text,
                Soyisim = txtSoyisim.Text,
                EmailAdres = txtEmailAdres.Text,
                Telefon = txtTelefon.Text,
                
            });
            MessageBox.Show("Yeni Kayıt Oluşturuldu.", "Başarılı", MessageBoxButtons.OK);


        }

        private int yeniMusteriEkle(Musteri musteri)
        {
            SanalDatabase.musteriler.Add(musteri);
            return 1;
        }
    }
}

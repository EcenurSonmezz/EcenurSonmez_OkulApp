using OkulApp.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OkulApp.BLL;

namespace OkulAppSube2BIL
{
    public partial class frmOgrKayit : Form
    {
        public int Ogrenciid { get; set; }
        public frmOgrKayit()
        {
            InitializeComponent();
            btnSil.Enabled = false;
            btnGuncelle.Enabled = false;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                bool sonuc = obl.OgrenciKaydet(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() });
                MessageBox.Show(sonuc ? "Ekleme Başarılı" : "Ekleme Başarısız!!");
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 2627:
                        MessageBox.Show("Bu numara daha önce kaydedilmiş");
                        break;
                    default:
                        MessageBox.Show("Veritabanı Hatası!");
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
                MessageBox.Show("Bilinmeyen Hata!!");
            }
        }
        private void btnBul_Click(object sender, EventArgs e)
        {
            txtAd.Text = string.Empty;
            txtSoyad.Text = string.Empty;
            txtNumara.Text = string.Empty;

            try
            {
                var frm = new frmOgrBul(this);
                frm.Show();
            }
            catch (Exception ex) 
            { throw new Exception("UYARI! Hata: " + ex.Message); }
            
           

        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciSil(Ogrenciid) ? "Silme Başarılı" : "Başarısız!");
            }
            catch (Exception ex) { throw new Exception("UYARI! Hata: " + ex.Message); }
           
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var obl = new OgrenciBL();
                MessageBox.Show(obl.OgrenciGuncelle(new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim(), Ogrenciid = Ogrenciid }) ? "Güncelleme Başarılı" : "Güncelleme Başarısız!");

            }
            catch (Exception ex) { throw new Exception("UYARI! Hata: " + ex.Message); }
        }
    }


    class Transfer : ITransferIslemleri
    {
        public int Eft(string gondereniban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }

        public int Havale(string gondereniban, string aliciiban, double tutar)
        {
            throw new NotImplementedException();
        }
    }


    interface ITransferIslemleri
    {
        int Eft(string gondereniban, string aliciiban, double tutar);
        int Havale(string gondereniban, string aliciiban, double tutar);
    }
}

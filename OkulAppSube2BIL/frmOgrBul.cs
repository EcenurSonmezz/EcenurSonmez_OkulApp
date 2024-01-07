using OkulApp.BLL;
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

namespace OkulAppSube2BIL
{
    public partial class frmOgrBul : Form
    {
        frmOgrKayit frm;
        public frmOgrBul(frmOgrKayit frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            OgrenciBL obl = new OgrenciBL();
            Ogrenci ogr = obl.OgrenciBul(txtNumara.Text.Trim());
            if (ogr != null)
            {
                frm.txtAd.Text = ogr.Ad;
                frm.txtSoyad.Text = ogr.Soyad;
                frm.txtNumara.Text = ogr.Numara;
                frm.Ogrenciid = ogr.Ogrenciid;

                frm.btnSil.Enabled = true;
                frm.btnGuncelle.Enabled = true;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Öğrenci bulunamadı!!");
            }
        }
    }
}

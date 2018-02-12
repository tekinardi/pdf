using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pdf
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtSifre.Text == "*123#")
            {
                try
                {
                    StreamWriter writetext = new StreamWriter(Application.StartupPath + "\\program.dll");
                    writetext.WriteLine(sifreleyici.sifreleme(txtdomain.Text.ToUpper()));
                    writetext.Close();
                    lblmsj.Text = "Güncelleme Başarılı";
                    btnYeniBaslat.Visible = true;
                    
                }
                catch (Exception)
                {
                    lblmsj.Text = "Hata Oluştu";
                }

            }
            else
            {
                lblmsj.Text = "Şifre Yanlış";

            }
        }

        private void btnYeniBaslat_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

    }
}

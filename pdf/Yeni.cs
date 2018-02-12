using PdfSharp.Pdf;
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
    public partial class Yeni : Form
    {
        public Yeni()
        {
            InitializeComponent();
        }

        PdfDocument gelen;






        private void button4_Click(object sender, EventArgs e)
        {
            lblSonuc.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gelen = yapici.PdfAc(ofd.FileName);// PdfReader.Open(ofd.FileName, PdfDocumentOpenMode.Import);
                // lblSNo.Text = "Pdf Sayfa Sayısı : " + gelen.PageCount.ToString();
                string BelgeAdi = ofd.FileName.ToString().Split('\\')[ofd.FileName.ToString().Split('\\').Length - 1].ToString();




                sinif pdfdsy = null;
                for (int i = 0; i < gelen.PageCount; i++)
                {
                    pdfdsy = new sinif();
                    pdfdsy.tamadres = ofd.FileName;
                    pdfdsy.belgeadi = BelgeAdi;
                    pdfdsy.sayfano = (i + 1);
                    if (chkGelenler.Items.Count > 0)
                    {
                        pdfdsy.sirano = chkGelenler.Items.Count + 1;
                    }
                    else
                    {
                        pdfdsy.sirano = i;
                    }

                    chkGelenler.Items.Add(pdfdsy);

                    //BelgeAdi + " - " + i.ToString() + ". Sayfa");
                }




            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var selectedItems = chkGelenler.CheckedItems.Cast<sinif>().ToList();
            foreach (var item in selectedItems)
            {
                lstBirlesecekler.Items.Add(item);
                chkGelenler.Items.Remove(item);

            }


            //foreach (var item in chkGelenler.CheckedItems)
            //{
            //    sinif s = item as sinif;
            //    lstBirlesecekler.Items.Add(s);
            //    //chkGelenler.Items.RemoveAt(s.sirano);


            //}



        }

        private void button6_Click(object sender, EventArgs e)
        {

            var selectedItems = lstBirlesecekler.SelectedItems.Cast<sinif>().ToList();
            foreach (var item in selectedItems)
            {
                lstBirlesecekler.Items.Remove(item);
                chkGelenler.Items.Add(item);
            }

            var list = chkGelenler.Items.Cast<sinif>().OrderBy(item => item.sirano).ToList();
            chkGelenler.Items.Clear();
            foreach (sinif listItem in list)
            {
                chkGelenler.Items.Add(listItem);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            List<sinif> gelensayfalar = new List<sinif>();

            foreach (var item in lstBirlesecekler.Items)
            {
                gelensayfalar.Add(item as sinif);

            }

            yapici.PdfKaydet(gelensayfalar).Save(label7.Text);

            label6.Text = "Kayıt Edildi.";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            label6.Text = "";



            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files|*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                label7.Text = sfd.FileName.ToString();// +".pdf";
            }

        }





        // tab 1 kodları

        private void button1_Click(object sender, EventArgs e)
        {
            lblSonuc.Text = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF Files|*.pdf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                gelen = yapici.PdfAc(ofd.FileName);// PdfReader.Open(ofd.FileName, PdfDocumentOpenMode.Import);
                lblSNo.Text = "Pdf Sayfa Sayısı : " + gelen.PageCount.ToString();
                lblbelgead.Text = "Belge Adı : " + ofd.FileName.ToString().Split('\\')[ofd.FileName.ToString().Split('\\').Length - 1].ToString();
            }
        }

        void belgeac(string belgeyolu, string belgeadi)
        {
            gelen = yapici.PdfAc(belgeyolu);
            lblSNo.Text = "Pdf Sayfa Sayısı : " + gelen.PageCount.ToString();
            lblbelgead.Text = "Belge Adı : " + belgeadi;//gelen.FullPath.ToString().Split('\\')[gelen.FullPath.ToString().Split('\\').Length - 1].ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            lblSonuc.Text = "";

            if (checkBox1.Checked)
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    lblKayit.Text = fbd.SelectedPath;
                }
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files|*.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    lblKayit.Text = sfd.FileName.ToString();// +".pdf";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            List<int> sayfalar = new List<int>();
            // = textBox1.Text.Split('-').ToList<string>();

            if (checkBox1.Checked)
            {

                for (int i = 0; i < gelen.Pages.Count; i++)
                {
                    //PdfDocument kayit = new PdfDocument();
                    //kayit.AddPage(gelen.Pages[i]);
                    try
                    {
                        //  kayit.Save(lblKayit.Text.Split('.')[0] + " sayfa " + (i + 1).ToString() + ".pdf");
                        yapici.PdfKaydet(gelen, new List<int> { i + 1 }).Save(lblKayit.Text + "\\" + lblbelgead.Text.Split(':')[1].Replace(".pdf", "") + " sayfa " + (i + 1).ToString() + ".pdf");
                        lblSonuc.Text = "Kayıt Edildi.";
                    }
                    catch (Exception)
                    {
                        lblSonuc.Text = "Hata Oluştu.";
                        break;
                    }
                }
            }
            if (checkBox2.Checked)
            {
                if (textBox1.Text.Contains(','))
                {
                    textBox1.BackColor = Color.White;
                    sayfalar = yapici.sayitamamla(Convert.ToInt16(textBox1.Text.Split(',')[0]), Convert.ToInt16(textBox1.Text.Split(',')[1]));
                }
                else if (textBox1.Text.Contains('-'))
                {
                    textBox1.BackColor = Color.White;
                    sayfalar = yapici.donensayilar(textBox1.Text);
                }
                else if (textBox1.Text.Contains(',') && textBox1.Text.Contains('-'))
                {
                    textBox1.BackColor = Color.White;
                }
                else
                {
                    textBox1.BackColor = Color.White;
                    sayfalar.Add(Convert.ToInt16(textBox1.Text));
                }

                if (sayfalar.Count > 0)
                {
                    textBox1.BackColor = Color.White;

                    //PdfDocument kayit = new PdfDocument();


                    //for (int i = 0; i < sayfalar.Count; i++)
                    //{
                    //    kayit.AddPage(gelen.Pages[sayfalar[i] - 1]);
                    //}
                    try
                    {
                        yapici.PdfKaydet(gelen, sayfalar).Save(lblKayit.Text);
                        // kayit.Save(lblKayit.Text);
                        lblSonuc.Text = "Kayıt Edildi.";
                    }
                    catch (Exception)
                    {

                        lblSonuc.Text = "Hata Oluştu.";
                    }
                }
            }

            else if (!checkBox1.Checked && !checkBox2.Checked)
            {
                textBox1.BackColor = Color.Red;
            }




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lblSonuc.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Enabled = false;
                checkBox2.Checked = false;

            }
            if (!checkBox1.Checked)
            {
                textBox1.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.Enabled = true;
                checkBox1.Checked = false;

            }
            if (!checkBox2.Checked)
            {
                textBox1.Enabled = false;
            }
        }

        private void button1_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.').Length - 1].ToString() == "pdf")
            // if ((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.')[1] == "pdf")
            {
                belgeac((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString(), (e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1]);
            }
            else
            {
                MessageBox.Show("PDF dosyası değil");
            }



        }

        private void button1_DragOver(object sender, DragEventArgs e)
        {

            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void button4_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.').Length - 1].ToString() == "pdf")
            // if ((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1].Split('.')[1] == "pdf")
            {
                //   belgeac();

                gelen = yapici.PdfAc((e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString());// PdfReader.Open(ofd.FileName, PdfDocumentOpenMode.Import);
                // lblSNo.Text = "Pdf Sayfa Sayısı : " + gelen.PageCount.ToString();
                string BelgeAdi = gelen.FullPath.ToString().Split('\\')[gelen.FullPath.ToString().Split('\\').Length - 1].ToString();

                sinif pdfdsy = null;
                for (int i = 0; i < gelen.PageCount; i++)
                {
                    pdfdsy = new sinif();
                    pdfdsy.tamadres = gelen.FullPath.ToString();
                    pdfdsy.belgeadi = (e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\')[(e.Data.GetData(DataFormats.FileDrop) as System.Array).GetValue(0).ToString().Split('\\').Length - 1];
                    pdfdsy.sayfano = i + 1;
                    if (chkGelenler.Items.Count > 0)
                    {
                        pdfdsy.sirano = chkGelenler.Items.Count + 1;
                    }
                    else
                    {
                        pdfdsy.sirano = i;
                    }
                    chkGelenler.Items.Add(pdfdsy);

                    //BelgeAdi + " - " + i.ToString() + ". Sayfa");
                }

            }
            else
            {
                MessageBox.Show("PDF dosyası değil");
            }
        }

        private void button4_DragOver(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void btnTekle_Click(object sender, EventArgs e)
        {

            var bb = chkGelenler.Items.Cast<sinif>().ToList();

            foreach (sinif item in bb)
            {
                lstBirlesecekler.Items.Add(item);
                chkGelenler.Items.Remove(item);

            }


        }

        private void btnTCikar_Click(object sender, EventArgs e)
        {


            var selectedItems = lstBirlesecekler.Items.Cast<sinif>().ToList();
            foreach (var item in selectedItems)
            {
                lstBirlesecekler.Items.Remove(item);
                chkGelenler.Items.Add(item);
            }

            var ss = chkGelenler.Items.Cast<sinif>().OrderBy(item => item.sirano).ToList();
            chkGelenler.Items.Clear();
            foreach (var item in ss)
            {
                chkGelenler.Items.Add((item as sinif));
            }

        }

        private void Yeni_FormClosing(object sender, FormClosingEventArgs e)
        {
            string[] s = System.IO.Directory.GetFiles(System.IO.Path.GetTempPath());

            //C:\Users\Tekin\AppData\Local\Temp\58b00bf2-ac53-440d-b260-9cc4f1548f73.pdf

            //gelen.FullPath.ToString().Split('\\')[gelen.FullPath.ToString().Split('\\').Length - 1].ToString();

            foreach (string item in s)
            {
                if (item.Contains("pdf"))
                {
                    System.IO.File.Delete(item);
                }
            }

        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();

        }

        private void Yeni_Load(object sender, EventArgs e)
        {
            String str = Environment.UserName.ToUpper();


            if (File.Exists(Application.StartupPath + "\\program.dll"))
            {
                StreamReader readtext = new StreamReader(Application.StartupPath + "\\program.dll");
                string readmetext = readtext.ReadLine();

                readtext.Close();

                if (str != sifreleyici.SifreCozme(readmetext))
                {
                    Admin a = new Admin();
                    a.ShowDialog();
                }

            }
            else
            {
                File.Create(Application.StartupPath + "\\program.dll");
                Admin a = new Admin();
                a.ShowDialog();
            }






        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

            //string[] s = System.IO.Directory.GetFiles(System.IO.Path.GetTempPath());

            ////C:\Users\Tekin\AppData\Local\Temp\58b00bf2-ac53-440d-b260-9cc4f1548f73.pdf

            ////gelen.FullPath.ToString().Split('\\')[gelen.FullPath.ToString().Split('\\').Length - 1].ToString();

            //foreach (string item in s)
            //{
            //    if (item.Contains("pdf"))
            //    {
            //        System.IO.File.Delete(item);
            //    }
            //}
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void menuStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                dragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }


        }

        private void menuStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging && e.Button == MouseButtons.Left)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));

            }
        }

        private void menuStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void lstBirlesecekler_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstBirlesecekler.SelectedItem == null)
            {
                return;
            }
            else
            {
                lstBirlesecekler.DoDragDrop(lstBirlesecekler.SelectedItem, DragDropEffects.Move);
            }
        }

        private void lstBirlesecekler_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Scroll;
        }

        private void lstBirlesecekler_DragDrop(object sender, DragEventArgs e)
        {

            Point point = lstBirlesecekler.PointToClient(new Point(e.X, e.Y));
            int index = lstBirlesecekler.IndexFromPoint(point);
            if (index < 0) index = lstBirlesecekler.Items.Count - 1;
            object data = e.Data.GetData(typeof(sinif));

            lstBirlesecekler.Items.Remove(data);
            lstBirlesecekler.Items.Insert(index, data);




        }





    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using iTextSharp;
using System.IO;
using itextsharp;

namespace pdf
{
    public static class yapici
    {

        public static PdfDocument PdfAc(string belgeyolu)
        {

            PdfDocument reader = new PdfDocument();

            try
            {
                reader = PdfReader.Open(belgeyolu, PdfDocumentOpenMode.Import);
            }
            catch (PdfSharp.Pdf.IO.PdfReaderException)
            {
                //workaround if pdfsharp doesnt dupport this pdf
                string newName = WriteCompatiblePdf(belgeyolu);
                reader = PdfReader.Open(newName, PdfDocumentOpenMode.Import);
            }

            return reader;
        }


        static List<string> sNewPdfs = new List<string>();
        static private string WriteCompatiblePdf(string sFilename)
        {
           // string s = System.IO.Path.GetTempPath();
            string sNewPdf = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".pdf";

           sNewPdfs.Add(sNewPdf);

            iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(sFilename);

            // we retrieve the total number of pages
            int n = reader.NumberOfPages;
            // step 1: creation of a document-object
            iTextSharp.text.Document document = new iTextSharp.text.Document(reader.GetPageSizeWithRotation(1));
            // step 2: we create a writer that listens to the document
            iTextSharp.text.pdf.PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(sNewPdf, FileMode.Create));
            //write pdf that pdfsharp can understand
            writer.SetPdfVersion(iTextSharp.text.pdf.PdfWriter.PDF_VERSION_1_4);
            // step 3: we open the document
            document.Open();
            iTextSharp.text.pdf.PdfContentByte cb = writer.DirectContent;
            iTextSharp.text.pdf.PdfImportedPage page;

            int rotation;

            int i = 0;
            while (i < n)
            {
                i++;
                document.SetPageSize(reader.GetPageSizeWithRotation(i));
                document.NewPage();
                page = writer.GetImportedPage(reader, i);
                rotation = reader.GetPageRotation(i);
                if (rotation == 90 || rotation == 270)
                {
                    cb.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(i).Height);
                }
                else
                {
                    cb.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);
                }
            }
            // step 5: we close the document
            document.Close();

         

            return sNewPdf;
        }

        
        public static List<int> sayitamamla(int ilksayi, int sonsayi)
        {
            List<int> sayilar = new List<int>();
            sayilar.Add(ilksayi);
            for (int i = ilksayi + 1; i < sonsayi; i++)
            {
                if (i == sonsayi)
                {

                    break;
                }
                else
                {
                    sayilar.Add(i);
                }

            }
            sayilar.Add(sonsayi);
            return sayilar;

        }

        public static List<int> donensayilar(string sayilar)
        {
            List<int> dsayilar = new List<int>();
            List<string> sylar = sayilar.Split('-').ToList<string>();
            for (int i = 0; i < sylar.Count; i++)
            {
                dsayilar.Add(Convert.ToInt16(sylar[i]));

            }
            return dsayilar;



        }

        public static PdfDocument PdfKaydet(PdfDocument ParcalanacakPDF, List<int> sayfalar)
        {
            PdfDocument yeniPDF = new PdfDocument();

            for (int i = 0; i < sayfalar.Count; i++)
            {
                yeniPDF.AddPage(ParcalanacakPDF.Pages[sayfalar[i] - 1]);
            }
            try
            {

             
               
                return yeniPDF;

            }
            catch (Exception)
            {
                return null;
            }


        }

        public static PdfDocument PdfKaydet(List<pdf.sinif> gelenler)
        {
            PdfDocument yeniPDF = new PdfDocument();

            foreach (sinif item in gelenler)
            {
                PdfDocument g = PdfAc(item.tamadres);
                yeniPDF.AddPage(g.Pages[item.sayfano-1]);
            }


            //for (int i = 0; i < sayfalar.Count; i++)
            //{
            //    yeniPDF.AddPage(ParcalanacakPDF.Pages[sayfalar[i] - 1]);
            //}

            try
            {
               
                return yeniPDF;

            }
            catch (Exception)
            {
                return null;
            }


        }

    }
}

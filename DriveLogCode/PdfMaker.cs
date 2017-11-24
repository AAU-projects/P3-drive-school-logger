using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf;
using Spire.Pdf.General.Render.Font.OpenTypeFile;
using Spire.Pdf.Graphics;

namespace DriveLogCode
{
    public class PdfMaker
    {
        public PdfMaker()
        {
            
        }

        public void MakeDriveLog()
        {
            // Create the empty document
            PdfDocument doc = new PdfDocument();

            // Get the front page of the drive log
            MakeFrontPage(doc);

            // Save the pdf file
            doc.SaveToFile("test.pdf");
            doc.Close();

            PDFDocumentViewer("test.pdf");
        }

        private void MakeFrontPage(PdfDocument document)
        {
            float y = 15;
            string text = "LEKTIONSPLAN";

            // Add a page to our document
            PdfPageBase page = document.Pages.Add();
            float pageWidth = page.Canvas.ClientSize.Width;

            // Add a header
            AddHeader(page);

            // Add title

            page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfTitleFont, DesignSchemes.ColorScheme.PdfBlackText, 
                x: pageWidth / 2, y: y, format: new PdfStringFormat(PdfTextAlignment.Center));

            SizeF size = DesignSchemes.FontScheme.PdfTitleFont.MeasureString(text);
            y += size.Height + 1;

            // Add subtitle
            text = "For Køreundervisning til kat. B (alm. bil)";
            page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfSubTitleFont, DesignSchemes.ColorScheme.PdfBlackText,
                x: pageWidth / 2, y: y, format: new PdfStringFormat(PdfTextAlignment.Center));

            // Insert the logo

            size = DesignSchemes.FontScheme.PdfSubTitleFont.MeasureString(text);
            y += size.Height + 30;
            DrawLogo(page, ref y);

            // Add information
            text = "Park Alle 3, 8000 Århus C\nTlf./SMS: 40456669\nwww.city-ks.dk - post@city-ks.dk";
            y += 100;
            page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfBigTextFont, DesignSchemes.ColorScheme.PdfBlackText,
                x: pageWidth / 2, y: y, format: new PdfStringFormat(PdfTextAlignment.Center));
        }

        private void AddHeader(PdfPageBase page)
        {
            float pageWidth = page.Canvas.ClientSize.Width;

            // Page header
            PdfPen pen1 = new PdfPen(Color.LightGray);
            PdfStringFormat rightAligenment = new PdfStringFormat(PdfTextAlignment.Right);
            string headerText = "City Køreskolen Århus";
            page.Canvas.DrawString(headerText, DesignSchemes.FontScheme.PdfHeaderFont, DesignSchemes.ColorScheme.PdfLightGrayText, pageWidth, 0, rightAligenment);
            SizeF textSize = DesignSchemes.FontScheme.PdfHeaderFont.MeasureString(headerText, rightAligenment);
            page.Canvas.DrawLine(pen1, 0, textSize.Height + 1, pageWidth, textSize.Height + 1);
        }

        private void DrawLogo(PdfPageBase page,  ref float y)
        {
            PdfImage logo = PdfImage.FromFile("Resources/CityLogo.png");

            float width = logo.Width * 0.75f;
            float height = logo.Height * 0.75f;

            float x = (page.Canvas.ClientSize.Width - width) / 2;
            page.Canvas.DrawImage(logo, x, y, width, height);

            y += height;
        }

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}

using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DriveLogCode.Objects;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using Spire.Pdf.Grid;

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

            // Get the schools instructors
            CreateInstructorsInfo(doc);

            // Get the lessons from the predefined templates
            AddLessons(doc);

            // Save the pdf file
            string fileName = SaveFile("test.pdf", doc);
            doc.Close();

            PDFDocumentViewer(fileName);
        }

        private string SaveFile(string filename, PdfDocument document)
        {
            int i = 0;

            string[] fileNameAndExt = filename.Split('.');

            while (File.Exists(filename))
            {
                i++;
            }

            if (i != 0) fileNameAndExt[0] += i;

            document.SaveToFile($"{fileNameAndExt[0]}.{fileNameAndExt[1]}");

            return $"{fileNameAndExt[0]}.{fileNameAndExt[1]}";
        }

        private void MakeFrontPage(PdfDocument document)
        {
            float y = 15;
            string text = "LEKTIONSPLAN";

            // Add a page to our document
            PdfPageBase page = document.Pages.Add(PdfPageSize.A4);
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

            size = DesignSchemes.FontScheme.PdfBigTextFont.MeasureString(text);
            y += size.Height + 50;

            CreateStudentInfo(Session.LoggedInUser, page, ref y);
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

        private void CreateStudentInfo(User owner , PdfPageBase page , ref float y)
        {
            string[] data =
            {
                $"Navn: {owner.Fullname}",
                $"Adresse: {owner.Address}",
                $"Post nr.: {owner.Zip}",
                $"By: {owner.City}",
                $"CPR nr.: {owner.Cpr}",
                $"Mobil: {owner.Phone}",
                $"Mail: {owner.Email}"
            };

            // Make two row, full size
            PdfGrid grid = new PdfGrid();
            grid.Style.CellPadding = new PdfPaddings(1,1,1,1);
            grid.Columns.Add(1);
            grid.Columns[0].Width = page.Canvas.ClientSize.Width;

            for (int i = 0; i < 2; i++)
            {
                PdfGridRow row = grid.Rows.Add();
                row.Style.Font = DesignSchemes.FontScheme.PdfBigTextFont;

                row.Cells[0].Value = data[i];
            }

            // Make two rows, half size
            PdfGrid grid1 = new PdfGrid();
            grid1.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);
            grid1.Columns.Add(2);
            grid1.Columns[0].Width = page.Canvas.ClientSize.Width / 2;
            grid1.Columns[1].Width = page.Canvas.ClientSize.Width / 2;

            for (int i = 2; i < 6; i++)
            {
                PdfGridRow row = grid1.Rows.Add();
                row.Style.Font = DesignSchemes.FontScheme.PdfBigTextFont;

                row.Cells[0].Value = data[i++];
                row.Cells[1].Value = data[i];
            }

            // Single row, full size
            PdfGrid grid2 = new PdfGrid();
            grid2.Style.CellPadding = new PdfPaddings(1, 1, 1, 1);
            grid2.Columns.Add(1);
            grid2.Columns[0].Width = page.Canvas.ClientSize.Width;

            PdfGridRow mailRow = grid2.Rows.Add();
            mailRow.Style.Font = DesignSchemes.FontScheme.PdfBigTextFont;
            mailRow.Cells[0].Value = data[6];

            // Draw the grid on the page
            PdfLayoutResult result = grid.Draw(page, 0, y);
            y += result.Bounds.Height;
            result = grid1.Draw(page, 0, y);
            y += result.Bounds.Height;
            result = grid2.Draw(page, 0, y);
            y += result.Bounds.Height;

        }

        private void CreateInstructorsInfo(PdfDocument document)
        {
            PdfPageBase page = document.Pages.Add(PdfPageSize.A4);
            AddHeader(page);

            DataTable instructorsTable = DataAccess.MySql.GetAllInstrutors();
            float y = 10;
            
            // draw title
            string title = "Kørelærere";
            page.Canvas.DrawString(title, DesignSchemes.FontScheme.PdfTitleFont, DesignSchemes.ColorScheme.PdfBlackText,
                x: page.Canvas.ClientSize.Width / 2, y: y, format: new PdfStringFormat(PdfTextAlignment.Center));

            SizeF size = DesignSchemes.FontScheme.PdfTitleFont.MeasureString(title);
            y += size.Height + 10;

            // make 3 columns
            PdfGrid grid = new PdfGrid {Style = {CellPadding = new PdfPaddings(1, 1, 1, 1)}};
            grid.Columns.Add(3);
            grid.Columns[0].Width = page.Canvas.ClientSize.Width * 0.30f;
            grid.Columns[1].Width = page.Canvas.ClientSize.Width * 0.40f;
            grid.Columns[2].Width = page.Canvas.ClientSize.Width * 0.30f;

            for (int i = 0; i < instructorsTable.Rows.Count; i++)
            {
                PdfGridRow row = grid.Rows.Add();
                row.Style.Font = DesignSchemes.FontScheme.PdfBigTextFont;

                row.Cells[0].Value = $"{(string)instructorsTable.Rows[i][0]} {(string)instructorsTable.Rows[i][1]}";
                row.Cells[1].Value = "";
                row.Cells[2].Value = $"{(string)instructorsTable.Rows[i][2]}";

            }

            PdfLayoutResult result = grid.Draw(page, 0, y);
            y += result.Bounds.Height + 10;

            // make boxes for other teachers or tracks, 2 boxes, 1 line

            title = "Andre undervisere/baner:";
            page.Canvas.DrawString(title, DesignSchemes.FontScheme.PdfSubTitleFont, DesignSchemes.ColorScheme.PdfBlackText,
                x: page.Canvas.ClientSize.Width / 2, y: y, format: new PdfStringFormat(PdfTextAlignment.Center));

            size = DesignSchemes.FontScheme.PdfTitleFont.MeasureString(title);
            y += size.Height + 10;

            grid = new PdfGrid { Style = { CellPadding = new PdfPaddings(1, 1, 1, 1) } };
            grid.Columns.Add(1);
            grid.Columns[0].Width = page.Canvas.ClientSize.Width * 0.47f;

            PdfGridRow topRow = grid.Rows.Add();
            PdfGridRow botRow = grid.Rows.Add();

            topRow.Style.Font = DesignSchemes.FontScheme.PdfTextFont;
            botRow.Style.Font = DesignSchemes.FontScheme.PdfTextFont;


            topRow.Cells[0].Value = "Stempel/Navn\n\n\n\n\n\n\n";
            botRow.Cells[0].Value = "Underskrift\n\n\n";

            for (int i = 0; i < 2; i++)
            {
                grid.Draw(page, 0, y);
                result = grid.Draw(page, grid.Columns[0].Width + 30, y);

                y += result.Bounds.Height + 10;
            }

            y += result.Bounds.Height + 10;

        }

        private void AddLessons(PdfDocument document)
        {
            List<LessonTemplate> templates = DataAccess.DatabaseParser.GetTemplatesList();
            float y = 10;
            SizeF size;
            PdfPageBase page = CreatePage(document);

            page.Canvas.DrawString("OBS!", DesignSchemes.FontScheme.PdfOBSTitleFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

            y += DesignSchemes.FontScheme.PdfOBSTitleFont.MeasureString("OBS!").Height;

            string text = "For at komme op til teoriprøve skal dine papirer (ansøgningsskema, \r\n lægeerklæring og førstehjælps bevis) være afleveret til kørelæreren. " +
                          "\r\nLægeerklæringen, SKAL være fra egen læge, og må MAX være 3 måneden gammel!" +
                          "\r\nFørstehjælps kurset MAX 1 år gammel!\r\n";

            page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

            y += DesignSchemes.FontScheme.PdfOBSTextFont.MeasureString(text).Height;

            foreach (LessonTemplate template in templates)
            {
                if (y >= page.Canvas.ClientSize.Height - 250)
                {
                    page = CreatePage(document);
                    y = 10;
                }

                if (templates.IndexOf(template) == 8)
                {
                    page.Canvas.DrawString("OBS!", DesignSchemes.FontScheme.PdfOBSTitleFont, DesignSchemes.ColorScheme.PdfBlackText,0,y);

                    y += DesignSchemes.FontScheme.PdfOBSTitleFont.MeasureString("OBS").Height;

                    text = "Nu er det på tide at tænke på at bestille teoriprøve!\r\nHvis du kan nå lektionerne til og med Teorilektion 7, inden for de næste ca. 2 uger,\r\n kan du bestille teoriprøve via din kørelærer!\r\n";
                    page.Canvas.DrawString(text,DesignSchemes.FontScheme.PdfOBSTextFont,DesignSchemes.ColorScheme.PdfBlackText,0,y);

                    y += DesignSchemes.FontScheme.PdfOBSTextFont.MeasureString(text).Height;

                    text = "Men kun hvis du HAR afleveret papirerne, ellers er det på høje tid at få dem afleveret!!!";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextUnderlineFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTextUnderlineFont.MeasureString(text).Height;

                    text = "Husk også at få betalt det gebyr til prøverne, som du har fået via E-Boks";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextUnderlineFatFont, DesignSchemes.ColorScheme.PdfBlackText, page.Canvas.ClientSize.Width/2, y, new PdfStringFormat(PdfTextAlignment.Center));
                    
                    y += DesignSchemes.FontScheme.PdfOBSTextUnderlineFatFont.MeasureString(text).Height;

                } else if (templates.IndexOf(template) == 11)
                {
                    page.Canvas.DrawString("OBS", DesignSchemes.FontScheme.PdfOBSTitleFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTitleFont.MeasureString("OBS!").Height;

                    text = "Medbring dit ansøgningsskema, og få det underskrevet af kørelæreren i teorilektion 7!";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTextFont.MeasureString(text).Height;
                } else if (template.Title == "KØRETEKNISK KURUS")
                {
                    page.Canvas.DrawString("OBS! Lektionerne hertil skal gennemføres inden teoriprøven.", DesignSchemes.FontScheme.PdfOBSTitleFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTitleFont.MeasureString("OBS").Height;

                    text = "Dit ansøgningsskema skal underskrives af teorilæreren i teorilektion 7 + af din \r\nkørelærer i skolevognen, inden du kan komme til teoriprøve!";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextUnderlineFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTextUnderlineFont.MeasureString(text).Height;

                    text = "Husk pas, lektionsplan og ansøgningsskema til både teori- og køreprøve.";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextFont, DesignSchemes.ColorScheme.PdfBlackText, 0, y);

                    y += DesignSchemes.FontScheme.PdfOBSTextFont.MeasureString(text).Height;

                    text = "De efterfølgende lektioner behøver ikke nødvendigvis at være i rækkefølge!";
                    page.Canvas.DrawString(text, DesignSchemes.FontScheme.PdfOBSTextUnderlineFont, DesignSchemes.ColorScheme.PdfBlackText, page.Canvas.ClientSize.Width / 2, y, new PdfStringFormat(PdfTextAlignment.Center));

                    y += DesignSchemes.FontScheme.PdfOBSTextUnderlineFont.MeasureString(text).Height;
                }

                page.Canvas.DrawString(template.Title, DesignSchemes.FontScheme.PdfTitleFont, DesignSchemes.ColorScheme.PdfBlackText,
                    x: 0, y: y);

                size = DesignSchemes.FontScheme.PdfTitleFont.MeasureString(template.Title);
                y += size.Height;

                page.Canvas.DrawString(template.Reading, DesignSchemes.FontScheme.PdfHeaderFont, DesignSchemes.ColorScheme.PdfBlackText,
                    x: size.Width + 5, y: y - 20);

                PdfStringFormat format = new PdfStringFormat(PdfTextAlignment.Left);
                format.LineSpacing = 20f;

                PdfStringLayouter stringLayout = new PdfStringLayouter();
                PdfStringLayoutResult description = stringLayout.Layout(template.Description, DesignSchemes.FontScheme.PdfTextFont, format, new SizeF(page.GetClientSize().Width, 0));

                foreach (LineInfo line in description.Lines)
                {
                    page.Canvas.DrawString(line.Text, DesignSchemes.FontScheme.PdfTextFont, DesignSchemes.ColorScheme.PdfBlackText,0,y,format);
                    y += description.LineHeight;
                }
                y += 10;

                PdfGrid grid = new PdfGrid { Style = { CellPadding = new PdfPaddings(1, 1, 1, 1) } };
                grid.Columns.Add(2);
                grid.Columns[0].Width = page.Canvas.ClientSize.Width * 0.20f;
                grid.Columns[1].Width = page.Canvas.ClientSize.Width * 0.80f;

                List<string> data = new List<string>()
                {
                    $" Dato:;Tidsforbug:\t\t\t{template.Time} x 45 min.",
                    " Elev underskrift:; ",
                    " Kørelære underskrift:\t\t\t\t+ banens stempel; "
                };

                foreach (string s in data)
                {
                    string[] cols = s.Split(';');
                    PdfGridRow row = grid.Rows.Add();

                    row.Style.Font = DesignSchemes.FontScheme.PdfTextFont;
                    

                    for (int i = 0; i < 2; i++)
                    {
                        row.Cells[i].Value = cols[i];

                        if (data.IndexOf(s) > 0)
                        {
                            row.Height += 10;
                        }
                    }
                }

                PdfLayoutResult result = grid.Draw(page, 0, y);
                y += result.Bounds.Height + 10;
            }
        }

        private PdfPageBase CreatePage(PdfDocument document)
        {
            PdfPageBase page = document.Pages.Add(PdfPageSize.A4);
            AddHeader(page);

            return page;
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

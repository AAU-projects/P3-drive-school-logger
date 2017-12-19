using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spire.Pdf.Graphics;

namespace DriveLogCode.DesignSchemes
{
    static class FontScheme
    {
        public static PdfTrueTypeFont PdfTitleFont = new PdfTrueTypeFont(new Font("Calibri",48f,FontStyle.Bold));
        public static PdfTrueTypeFont PdfSubTitleFont = new PdfTrueTypeFont(new Font("Calibri", 20f, FontStyle.Bold));
        public static PdfTrueTypeFont PdfHeaderFont = new PdfTrueTypeFont(new Font("Calibri Light", 8f, FontStyle.Bold));
        public static PdfTrueTypeFont PdfBigTextFont = new PdfTrueTypeFont(new Font("Calibri Light", 20f, FontStyle.Regular));
        public static PdfTrueTypeFont PdfTextFont = new PdfTrueTypeFont(new Font("Calibri Light", 12f, FontStyle.Regular));
        public static PdfTrueTypeFont PdfOBSTitleFont = new PdfTrueTypeFont(new Font("Calibri", 22f, FontStyle.Bold | FontStyle.Underline));
        public static PdfTrueTypeFont PdfOBSTextFont = new PdfTrueTypeFont(new Font("Calibri Light", 15f, FontStyle.Regular));
        public static PdfTrueTypeFont PdfOBSTextUnderlineFont = new PdfTrueTypeFont(new Font("Calibri Light", 15f, FontStyle.Regular | FontStyle.Underline | FontStyle.Italic));
        public static PdfTrueTypeFont PdfOBSTextUnderlineFatFont = new PdfTrueTypeFont(new Font("Calibri Light", 15f, FontStyle.Bold | FontStyle.Underline | FontStyle.Italic));
    }
}

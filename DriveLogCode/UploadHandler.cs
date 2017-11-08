using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace DriveLogCode
{
    public class UploadHandler : IUploadHandler
    {
        public bool UploadDoctorsNote(string title, string fileLocation, string url)
        {
            return UploadFile(title, Session.TypeDoctorsNote, fileLocation, url);
        }

        public bool UploadFirstAid(string title, string fileLocation, string url)
        {
            return UploadFile(title, Session.TypeFirstAid, fileLocation, url);
        }

        private bool UploadFile(string title, string type, string fileLocation, string url)
        {
            FileInfo file = new FileInfo(fileLocation);

            if (!file.Exists) return false;

            if (file.Extension != ".pdf")
            {
                PdfDocument doc = new PdfDocument();
                doc.Pages.Add(new PdfPage());
                XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[0]);
                XImage img = XImage.FromFile(fileLocation);

                xgr.DrawImage(img, 0, 0);
                fileLocation = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
                doc.Save(fileLocation);
                doc.Close();
            }
            
            string fileUrl = SendToServer(fileLocation, url);

            if (fileUrl == "null") return false;

            if (!MySql.UploadDocument(title, type, DateTime.Today, Session.LoggedInUser.Id, fileUrl)) return false;

            return true;
        }

        public string SaveProfilePicture(Image image, string url)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
            
            if (image == null) return null;
            image.Save(tempFile,ImageFormat.Png);

            return SendToServer(tempFile, url);
        }

        private string SendToServer(string imageLocation, string url)
        {
            System.Net.WebClient Client = new System.Net.WebClient();

            Client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            byte[] result = Client.UploadFile(url, "POST", imageLocation);

            return Encoding.UTF8.GetString(result, 0, result.Length);
        }
    }
 }


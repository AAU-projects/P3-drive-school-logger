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
using Spire.Pdf.Graphics;

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
            Spire.Pdf.PdfDocument document = new Spire.Pdf.PdfDocument();
            FileInfo file = new FileInfo(fileLocation);

            if (!file.Exists) return false;

            if (file.Extension != ".pdf")
            {
                Spire.Pdf.PdfPageBase page = document.Pages.Add();

                PdfImage image = PdfImage.FromFile(fileLocation);
                fileLocation = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.pdf");
                
                float widthFitRate = image.PhysicalDimension.Width / page.Canvas.ClientSize.Width;
                float heightFitRate = image.PhysicalDimension.Height / page.Canvas.ClientSize.Height;
                float fitRate = Math.Max(widthFitRate, heightFitRate);
                float fitWidth = image.PhysicalDimension.Width / fitRate;
                float fitHeight = image.PhysicalDimension.Height / fitRate;
                page.Canvas.DrawImage(image, 30, 30, fitWidth, fitHeight);

                document.DocumentInformation.Title = $"{Session.LoggedInUser.Fullname} - {type}";
                document.DocumentInformation.Author = Session.LoggedInUser.Fullname;
                document.DocumentInformation.CreationDate = DateTime.Now;

                document.SaveToFile(fileLocation);
                document.Close();

            }
            else
            {
                document.LoadFromFile(fileLocation);
                document.DocumentInformation.Title = $"{Session.LoggedInUser.Fullname} - {type}";
                document.DocumentInformation.Author = Session.LoggedInUser.Fullname;
                document.DocumentInformation.CreationDate = DateTime.Now;

                document.SaveToFile(fileLocation);
                document.Close();
            }

            document.Dispose();
            
            string fileUrl = SendToServer(fileLocation, url);

            if (fileUrl == "null") return false;

            if (!MySql.UploadDocument(title, type, DateTime.Today, Session.LoggedInUser.Id, fileUrl)) return false;

            return true;
        }

        public string SaveProfilePicture(Image image, string url)
        {
            return SavePicture(image, url);
        }

        public string SavePicture(Image image, string url)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");

            if (image == null) return null;
            image.Save(tempFile, ImageFormat.Png);

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


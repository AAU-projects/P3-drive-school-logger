using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using DriveLogCode.Objects;
using Spire.Pdf.Graphics;

namespace DriveLogCode.DataAccess
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

        /// <summary>
        /// Uploads a file to the webserver.
        /// </summary>
        /// <param name="title">The title for the file, to be used in the Database.</param>
        /// <param name="type">What type of file is uploaded. Example: 'FirstAid' or 'DoctorsNote'.</param>
        /// <param name="fileLocation">The local filepath to the document.</param>
        /// <param name="url">The url of the server, where the file will be uploaded.</param>
        /// <returns>Returns a bool wether the operation was completed or not.</returns>
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

        /// <summary>
        /// Upload profile picture to the webserver
        /// </summary>
        /// <param name="image">the image to uplaod</param>
        /// <param name="url">the </param>
        /// <returns>wether it was uploaded or not</returns>
        public string SaveProfilePicture(Image image, string url)
        {
            return SavePicture(image, url);
        }

        /// <summary>
        /// Upload picture to the webserver
        /// </summary>
        /// <param name="image">the image to uplaod</param>
        /// <param name="url">the </param>
        /// <returns>wether it was uploaded or not</returns>
        public string SavePicture(Image image, string url)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");

            if (image == null) return null;
            image.Save(tempFile, ImageFormat.Png);

            return SendToServer(tempFile, url);
        }

        /// <summary>
        /// uploads the file to the web server
        /// </summary>
        /// <param name="imageLocation">the local path to the file</param>
        /// <param name="url">the remote upload path</param>
        /// <returns>the url to the uploaded file</returns>
        private string SendToServer(string imageLocation, string url)
        {
            System.Net.WebClient Client = new System.Net.WebClient();

            Client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            byte[] result = Client.UploadFile(url, "POST", imageLocation);

            return Encoding.UTF8.GetString(result, 0, result.Length);
        }
    }
 }


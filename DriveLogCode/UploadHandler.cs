using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class UploadHandler : IUploadHandler
    {
        public bool UploadFile(string user, string fileLocation)
        {
            throw new NotImplementedException();
        }

        public string SaveProfilePicture(Image image, string url)
        {
            string tempFile = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid()}.png");
            
            if (image == null) return null;
            image.Save(tempFile,ImageFormat.Png);

            System.Net.WebClient Client = new System.Net.WebClient();

            Client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            byte[] result = Client.UploadFile(url, "POST", tempFile);

            return Encoding.UTF8.GetString(result, 0, result.Length);
        }
    }
 }


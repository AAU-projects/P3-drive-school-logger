using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public interface IUploadHandler
    {
        bool UploadFile(string title, string fileLocation, string url);
        string SaveProfilePicture(Image image, string url);
    }
}

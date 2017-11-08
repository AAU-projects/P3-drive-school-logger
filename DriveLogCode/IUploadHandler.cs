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
        bool UploadFirstAid(string title, string fileLocation, string url);
        bool UploadDoctorsNote(string title, string fileLocation, string url);
        string SaveProfilePicture(Image image, string url);
    }
}

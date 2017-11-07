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
        bool UploadFile(string user, string fileLocation);
        string SaveProfilePicture(Image image);
    }
}

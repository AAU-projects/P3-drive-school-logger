using System;
using System.Collections.Generic;
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

        public string UploadProfilePicture(string imageLocation)
        {
            if (File.Exists(imageLocation))
            {
                File.Copy(imageLocation, $@"C:\Users\Lukas\Desktop\test.png",true);
                return "bob";
            }
            return null;
        }
    }
}

using System.Drawing;

namespace DriveLogCode.DataAccess
{
    public interface IUploadHandler
    {
        bool UploadFirstAid(string title, string fileLocation, string url);
        bool UploadDoctorsNote(string title, string fileLocation, string url);
        string SaveProfilePicture(Image image, string url);
        string SavePicture(Image image, string url);
    }
}

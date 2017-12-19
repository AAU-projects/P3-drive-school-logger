using System.Drawing;

namespace DriveLogCode.DataAccess
{
    public interface IUploadHandler
    {
        /// <summary>
        /// Upload first aid to remote location
        /// </summary>
        /// <param name="title">The title of the docment</param>
        /// <param name="fileLocation">The local location</param>
        /// <param name="url">The remote location</param>
        /// <returns>wether it was uploaded or not</returns>
        bool UploadFirstAid(string title, string fileLocation, string url);

        /// <summary>
        /// Upload Doctors Note to remote location
        /// </summary>
        /// <param name="title">The title of the docment</param>
        /// <param name="fileLocation">The local location</param>
        /// <param name="url">The remote location</param>
        /// <returns>wether it was uploaded or not</returns>
        bool UploadDoctorsNote(string title, string fileLocation, string url);

        /// <summary>
        /// Upload profile picture to remote location
        /// </summary>
        /// <param name="image">the image to uplaod</param>
        /// <param name="url">the remote location</param>
        /// <returns>wether it was uploaded or not</returns>
        string SaveProfilePicture(Image image, string url);

        /// <summary>
        /// Upload picture to remote location
        /// </summary>
        /// <param name="image">the image to uplaod</param>
        /// <param name="url">the remote location</param>
        /// <returns>wether it was uploaded or not</returns>
        string SavePicture(Image image, string url);
    }
}

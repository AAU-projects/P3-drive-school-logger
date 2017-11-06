using System;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class ProfileTab : UserControl
    {
        public ProfileTab()
        {
            InitializeComponent();
            UpdateInfo();
        }

        /// <summary>
        /// Updates the user information with data from session class
        /// </summary>
        private void UpdateInfo()
        {
            User user = Session.LoggedInUser;

            profileHeaderLabel.Text = "Profile: " + user.Username;
            nameOutputLabel.Text = user.Fullname;
            phoneOutputLabel.Text = user.Phone;
            cprOutputLabel.Text = user.Cpr;
            emailOutputLabel.Text = user.Email;
            addressOutputLabel.Text = user.Address;
            cityOutputLabel.Text = $"{user.City}, {user.Zip}";

            if (user.PicturePath != null)
            {
                ProfilePicture.Load(user.PicturePath);
            }
        }
    }
}

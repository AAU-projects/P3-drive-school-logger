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

            if (!string.IsNullOrEmpty(user.PicturePath) || user.PicturePath != "")
            {
                ProfilePicture.Load(user.PicturePath);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditUserInfoForm editForm = new EditUserInfoForm();

            editForm.ShowDialog(this);
            UpdateInfo();
        }
    }
}

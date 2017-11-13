using System;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class ProfileTab : UserControl
    {
        private User _user;
        private bool _search;
        public ProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;
            UpdateLayout();
            UpdateInfo();
        }

        private void UpdateLayout()
        {
            if(_search)
            {
                backButton.Enabled = true;
                backButton.Visible = true;
                logoutButton.Enabled = false;
                logoutButton.Visible = false;
            }
        }

        /// <summary>
        /// Updates the user information with data from session class
        /// </summary>
        private void UpdateInfo()
        {

            profileHeaderLabel.Text = "Profile: " + _user.Username;
            nameOutputLabel.Text = _user.Fullname;
            phoneOutputLabel.Text = _user.Phone;
            cprOutputLabel.Text = _user.Cpr;
            emailOutputLabel.Text = _user.Email;
            addressOutputLabel.Text = _user.Address;
            cityOutputLabel.Text = $"{_user.City}, {_user.Zip}";

            if (!string.IsNullOrEmpty(_user.PicturePath) || _user.PicturePath != "")
            {
                ProfilePicture.Load(_user.PicturePath);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditUserInfoForm editForm = new EditUserInfoForm(_user);

            editForm.ShowDialog(this);
            UpdateInfo();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Find("userSearchTab", false)[0].Show();
            this.Dispose();
        }
    }
}

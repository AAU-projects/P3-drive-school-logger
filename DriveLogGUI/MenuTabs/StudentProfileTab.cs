using System;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class StudentProfileTab : ProfileTab
    {
        private User _user;
        private bool _search;
        internal virtual event SubPageNotification SubPageCreated;
        public StudentProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;
            UpdateLayout();
            UpdateInfo();

            foreach (Control c in progressBarPanel.Controls)
            {
                c.MouseClick += progressBarPanel_Click;

                foreach (Control childControl in c.Controls)
                    childControl.MouseClick += progressBarPanel_Click;
            }
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
        public void UpdateInfo()
        {
            profileHeaderLabel.Text = "Profile: " + Session.LoggedInUser.Username;
            nameOutputLabel.Text = Session.LoggedInUser.Fullname;
            phoneOutputLabel.Text = Session.LoggedInUser.Phone;
            cprOutputLabel.Text = Session.LoggedInUser.Cpr;
            emailOutputLabel.Text = Session.LoggedInUser.Email;
            addressOutputLabel.Text = Session.LoggedInUser.Address;
            cityOutputLabel.Text = $"{Session.LoggedInUser.City}, {Session.LoggedInUser.Zip}";
            theoreticalStatus.Text = Session.LoggedInUser.TheoreticalProgress + "/24";
            practicalStatus.Text = Session.LoggedInUser.PracticalProgress + "/14";

            theoreticalProgressFill.Size = new Size((theoreticalBar.Width / 24) * Session.LoggedInUser.TheoreticalProgress, theoreticalBar.Height);
            practicalProgressFill.Size = new Size((practicalBar.Width / 14) * Session.LoggedInUser.PracticalProgress, practicalBar.Height);

            if (!string.IsNullOrEmpty(Session.LoggedInUser.PicturePath) || Session.LoggedInUser.PicturePath != "")
            {
                ProfilePicture.Load(Session.LoggedInUser.PicturePath);
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

        private void progressBarPanel_Click(object sender, EventArgs e)
        {
            if (!_search)
            {
                SubPageCreated?.Invoke(this);
            }
            else
            {
                this.Hide();
                DriveLogTab studentFoundDriveLogTab = new DriveLogTab(_user, true);
                studentFoundDriveLogTab.Location = this.Location;
                studentFoundDriveLogTab.Parent = this;
                this.Parent.Controls.Add(studentFoundDriveLogTab);
                studentFoundDriveLogTab.Show();
            }
        }
    }
}

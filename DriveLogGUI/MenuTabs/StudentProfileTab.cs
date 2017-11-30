using System;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class StudentProfileTab : ProfileTab
    {
        private User _user;
        private bool _search;
        internal virtual event SubPageNotification SubPageCreated;
        internal override event EventHandler IconPictureButtonClickEvent;

        // Pictures for check icons
        private Bitmap incompleteImage = DriveLogGUI.Properties.Resources.crossIncomplete;
        private Bitmap incompleteHoverImage = DriveLogGUI.Properties.Resources.crossHover;
        private Bitmap completedImage = DriveLogGUI.Properties.Resources.checkCompleted;
        private Bitmap completedHoverImage = DriveLogGUI.Properties.Resources.checkHover;

        public StudentProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;

            UpdateLayout();
            UpdateInfo();
            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
            FirstCheckIfUploaded(firstAidPictureButton);

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
        private void UpdateInfo()
        {
            profileHeaderLabel.Text = "Profile: " + _user.Username;
            nameOutputLabel.Text = _user.Fullname;
            phoneOutputLabel.Text = _user.Phone;
            cprOutputLabel.Text = _user.Cpr;
            emailOutputLabel.Text = _user.Email;
            addressOutputLabel.Text = _user.Address;
            cityOutputLabel.Text = $"{_user.City}, {_user.Zip}";
            theoreticalStatus.Text = _user.TheoreticalProgress + "/24";
            practicalStatus.Text = _user.PracticalProgress + "/14";

            theoreticalProgressFill.Size = new Size((theoreticalBar.Width / 24) * _user.TheoreticalProgress, theoreticalBar.Height);
            practicalProgressFill.Size = new Size((practicalBar.Width / 14) * _user.PracticalProgress, practicalBar.Height);

            if (!string.IsNullOrEmpty(_user.PicturePath) || _user.PicturePath != "")
            {
                ProfilePicture.Load(_user.PicturePath);
            }

            // Update icons
            if (_user.TheoreticalTestDone)
                theroraticalPictureButton.Image = completedImage;
            if (_user.PracticalTestDone)
                praticalTestPictureButton.Image = completedImage;
            if (_user.FeePaid)
                feePictureBox.Image = completedImage;

            foreach (Lesson lesson in _user.LessonsList)
            {
                if (lesson.LessonTemplate.Id == 1 && lesson.Completed)
                    maneuverTrackPictureButton.Image = completedImage;
                if (lesson.LessonTemplate.Id == 18 && lesson.Completed)
                    slippertTrackPictureButton.Image = completedImage;
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

        private void doctorsNotePictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(doctorsNotePictureButton, e);
        }

        private void firstAidPictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(firstAidPictureButton, e);
        }

        private void ProgressButtonMouseEnter(PictureBox button)
        {
            if (button.Image == incompleteImage)
                button.Image = incompleteHoverImage;
            else if (button.Image == completedImage)
                button.Image = completedHoverImage;
        }

        private void DoctorsNoteCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistDoctorsNote(Session.LoggedInUser))
                button.Image = completedImage;
        }

        private void FirstCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistFirstAid(Session.LoggedInUser))
                button.Image = completedImage;
        }

        private void firstAidPictureButton_MouseLeave(object sender, EventArgs e)
        {
            FirstCheckIfUploaded(firstAidPictureButton);
        }

        private void firstAidPictureButton_MouseEnter(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(firstAidPictureButton);
        }

        private void doctorsNotePictureButton_MouseLeave(object sender, EventArgs e)
        {
            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
        }

        private void doctorsNotePictureButton_MouseEnter(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(doctorsNotePictureButton);
        }

        private void theroraticalPictureButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;
            ProgressButtonMouseEnter(theroraticalPictureButton);
        }

        private void praticalTestPictureButton_MouseEnter(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;
            ProgressButtonMouseEnter(praticalTestPictureButton);
        }

        private void feePictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;
            ProgressButtonMouseEnter(feePictureBox);
        }

        private void theroraticalPictureButton_MouseLeave(object sender, EventArgs e)
        {
            if(!Session.LoggedInUser.Sysmin) return;

            PictureBox pBox = sender as PictureBox;
            pBox.Image = _user.TheoreticalTestDone ? completedImage : incompleteImage;
        }

        private void praticalTestPictureButton_MouseLeave(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;

            PictureBox pBox = sender as PictureBox;
            pBox.Image = _user.PracticalTestDone ? completedImage : incompleteImage;
        }

        private void feePictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;

            PictureBox pBox = sender as PictureBox;
            pBox.Image = _user.FeePaid ? completedImage : incompleteImage;
        }

        private void theroraticalPictureButton_DoubleClick(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;

            PictureBox icon = sender as PictureBox;

            DialogResult confirmamtionBox = CustomMsgBox.ShowYesNo($"Are you sure {_user.Fullname} has completed a {theoraticalTestLabel.Text.ToLower()}", "Confirm", CustomMsgBoxIcon.Warrning);

            if (confirmamtionBox == DialogResult.Yes)
            {
                DatabaseParser.SetUserTheoreticalTestDone(_user.Id, true);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = completedImage;
            }
            else if (confirmamtionBox == DialogResult.No)
            {
                DatabaseParser.SetUserTheoreticalTestDone(_user.Id, false);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = incompleteImage;
            }
        }

        private void praticalTestPictureButton_DoubleClick(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;

            PictureBox icon = sender as PictureBox;

            DialogResult confirmamtionBox = CustomMsgBox.ShowYesNo($"Are you sure {_user.Fullname} has completed a {practicalTestLabel.Text.ToLower()}", "Confirm", CustomMsgBoxIcon.Warrning);

            if (confirmamtionBox == DialogResult.Yes)
            {
                DatabaseParser.SetUserTheoreticalTestDone(_user.Id, true);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = completedImage;
            }
            else if (confirmamtionBox == DialogResult.No)
            {
                DatabaseParser.SetUserPracticalTestDone(_user.Id, false);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = incompleteImage;
            }
        }

        private void feePictureBox_DoubleClick(object sender, EventArgs e)
        {
            if (!Session.LoggedInUser.Sysmin) return;

            PictureBox icon = sender as PictureBox;

            DialogResult confirmamtionBox = CustomMsgBox.ShowYesNo($"Are you sure {_user.Fullname} has paid goverment {feeLabel.Text.ToLower()}s", "Confirm", CustomMsgBoxIcon.Warrning);

            if (confirmamtionBox == DialogResult.Yes)
            {
                DatabaseParser.SetUserFeePaid(_user.Id, true);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = completedImage;
            }
            else if (confirmamtionBox == DialogResult.No)
            {
                DatabaseParser.SetUserFeePaid(_user.Id, false);
                _user = DatabaseParser.GetUserById(_user.Id);
                icon.Image = incompleteImage;
            }
        }
    }
}

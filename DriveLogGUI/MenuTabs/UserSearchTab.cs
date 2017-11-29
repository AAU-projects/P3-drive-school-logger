using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;

namespace DriveLogGUI.MenuTabs
{
    public partial class UserSearchTab : UserControl
    {
        public UserSearchTab()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
            userCollectionMenu.SelectedIndex = 0;
        }

        public virtual event EventHandler LogOutButtonClick;

        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }

        private List<User> _usersFoundList = new List<User>();
        private List<Panel> _userPanelList = new List<Panel>();

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ExecuteSearch();
            Cursor = Cursors.Arrow;
        }

        private void ExecuteSearch()
        {
            Cursor = Cursors.AppStarting;
            if (searchBox.Text.Contains("'")) return;
            _usersFoundList = DatabaseParser.UserSearchList(searchBox.Text);

            _userPanelList.Clear();
            resultsPanel.Controls.Clear();
            int idx = 0;

            if (_usersFoundList.Count == 0)
            {
                errorLabel.Text = "No Users Found";
                return;
            }

            for (int i = 0; i < _usersFoundList.Count; i++)
            {
                if (userCollectionMenu.Text == "Students Only" && _usersFoundList[i].Sysmin == true) continue;
                if (userCollectionMenu.Text == "Instructors Only" && _usersFoundList[i].Sysmin == false) continue;

                GenerateUserPanel(_usersFoundList[i], idx);
                idx++;
            }

            foreach (Panel panel in _userPanelList)
            {
                resultsPanel.Controls.Add(panel);
            }
        }

        private void GenerateUserPanel(User user, int index)
        {
            Panel tempPanel = new Panel();
            tempPanel.Size = new Size(397, 74);
            tempPanel.BackColor = Color.White;
            tempPanel.BorderStyle = BorderStyle.FixedSingle;

            if (index % 2 == 0)
                tempPanel.Location = new Point(22, 13 + (13 + tempPanel.Height) * (index / 2));
            else
                tempPanel.Location = new Point(454, 13 + (13 + tempPanel.Height) * (index / 2));

            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Location = new Point(5, 5);
            profilePictureBox.Size = new Size(64, 64);
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tempPanel.Controls.Add(profilePictureBox);

            if (!String.IsNullOrEmpty(user.PicturePath))
                profilePictureBox.Load(user.PicturePath);
            else
                profilePictureBox.Image = Properties.Resources.avataricon;

            int labelWidth = 160;
            int labelHeight = 14;

            Label nameLabel = new Label();
            nameLabel.Location = new Point(70, 4);
            nameLabel.Size = new Size(labelWidth, labelHeight);
            nameLabel.Text = "Name: " + user.Fullname;
            tempPanel.Controls.Add(nameLabel);

            Label emailLabel = new Label();
            emailLabel.Location = new Point(70, 20);
            emailLabel.Size = new Size(labelWidth, labelHeight);
            emailLabel.Text = "Email: " + user.Email;
            tempPanel.Controls.Add(emailLabel);

            Label addressLabel = new Label();
            addressLabel.Location = new Point(70, 36);
            addressLabel.Size = new Size(labelWidth, labelHeight);
            addressLabel.Text = "Address: " + user.Address;
            tempPanel.Controls.Add(addressLabel);

            Label phoneLabel = new Label();
            phoneLabel.Location = new Point(70, 52);
            phoneLabel.Size = new Size(labelWidth, labelHeight);
            phoneLabel.Text = "Phone: " + user.Phone;
            tempPanel.Controls.Add(phoneLabel);

            Label usernameLabel = new Label();
            usernameLabel.Location = new Point(240, 4);
            usernameLabel.Size = new Size(labelWidth, labelHeight);
            usernameLabel.Text = "Username: " + user.Username;
            tempPanel.Controls.Add(usernameLabel);

            Label teamLabel = new Label();
            teamLabel.Location = new Point(240, 20);
            teamLabel.Size = new Size(labelWidth, labelHeight);
            teamLabel.Text = "Class: " + "N/A";
            tempPanel.Controls.Add(teamLabel);

            Label progressLabel = new Label();
            progressLabel.Location = new Point(240, 36);
            progressLabel.Size = new Size(labelWidth, labelHeight);
            progressLabel.Text = $"Theo/Prac: {user.TheoreticalProgress}/24 - {user.PracticalProgress}/14";
            tempPanel.Controls.Add(progressLabel);

            Label roleLabel = new Label();
            roleLabel.Location = new Point(240, 52);
            roleLabel.Size = new Size(labelWidth, labelHeight);
            roleLabel.Text = "Role: " + (user.Sysmin ? "Instructor" : "Student");
            tempPanel.Controls.Add(roleLabel);

            foreach (Control c in tempPanel.Controls)
            {
                c.Click += (sender, e) => OnTempPanelClick(sender, e, user);
                c.MouseEnter += OnTempPanelEnter;
                c.MouseLeave += OnTempPanelLeave;
            }

            tempPanel.MouseEnter += OnTempPanelEnter;
            tempPanel.MouseLeave += OnTempPanelLeave;
            tempPanel.Click += (sender, e) => OnTempPanelClick(sender, e, user);

            _userPanelList.Add(tempPanel);
        }

        private void OnTempPanelClick(object sender, EventArgs e, User user)
        {
            OnTempPanelLeave(sender, e);
            this.Hide();
            StudentProfileTab foundUserProfile = new StudentProfileTab(user, true);
            foundUserProfile.Location = this.Location;
            foundUserProfile.Parent = this;
            this.Parent.Controls.Add(foundUserProfile);
            foundUserProfile.Show();
        }

        private void OnTempPanelEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
            if (sender is Panel)
            {
                Panel panel = sender as Panel;
                panel.BackColor = Color.FromArgb(229, 243, 255);
            }
            else
            {
                Control control = sender as Control;
                control.Parent.BackColor = Color.FromArgb(229, 243, 255);
            }
        }

        private void OnTempPanelLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
            if (sender is Panel)
            {
                Panel panel = sender as Panel;
                panel.BackColor = Color.White;
            }
            else
            {
                Control control = sender as Control;
                control.Parent.BackColor = Color.White;
            }
        }

        private void pictureSearchButton_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
            Cursor = Cursors.Arrow;
        }

        private void pictureSearchButton_MouseEnter(object sender, EventArgs e)
        {
            pictureSearchButton.BackColor = Color.FromArgb(230, 230, 230);
        }

        private void pictureSearchButton_MouseLeave(object sender, EventArgs e)
        {
            pictureSearchButton.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}

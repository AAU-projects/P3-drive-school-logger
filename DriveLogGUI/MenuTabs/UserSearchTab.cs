using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class UserSearchTab : UserControl
    {
        /// <summary>
        /// Class constructor. Initializes component and sets start index
        /// </summary>
        public UserSearchTab()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
            userCollectionMenu.SelectedIndex = 0;
        }

        public virtual event EventHandler LogOutButtonClick;

        /// <summary>
        /// Invokes the log out event
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventARgs</param>
        public virtual void logoutButton_Click(object sender, EventArgs e)
        {
            LogOutButtonClick?.Invoke(this, e);
        }

        private List<User> _usersFoundList = new List<User>();
        private List<Panel> _userPanelList = new List<Panel>();

        /// <summary>
        /// Executes the search once enter is pressed
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventARgs</param>
        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            ExecuteSearch();
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Executes the serach by sending a query through the database parser
        /// </summary>
        private void ExecuteSearch()
        {
            Cursor = Cursors.AppStarting;
            if (searchBox.Text.Contains("'")) return;
            if (searchBox.Text.Length != 0 && searchBox.Text.Length < 3 && searchBox.Text != "%")
            {
                Cursor = Cursors.Arrow;
                CustomMsgBox.ShowOk("Please input at least 3 characters", "Search Too Short", CustomMsgBoxIcon.Warrning);
                return;
            }
            // Get all results in a list of users
            _usersFoundList = DatabaseParser.UserSearchList(searchBox.Text);

            // Clear previous search
            _userPanelList.Clear();
            resultsPanel.Controls.Clear();
            int idx = 0;

            // Return if no results
            if (_usersFoundList.Count == 0)
            {
                errorLabel.Text = "No Users Found";
                return;
            }

            // Loop the result list and skip results not meeting criterias. Then call GenerateUserPanel
            for (int i = 0; i < _usersFoundList.Count; i++)
            {
                if (activeCheckBox.Checked && !_usersFoundList[i].Active) continue;
                if (userCollectionMenu.Text == "Students Only" && _usersFoundList[i].Sysmin) continue;
                if (userCollectionMenu.Text == "Instructors Only" && !_usersFoundList[i].Sysmin) continue;

                if (_usersFoundList[i].Sysmin)
                {
                    _usersFoundList[i].GetInstructorLessons();
                }
                else
                {
                    _usersFoundList[i].CalculateProgress();
                }

                GenerateUserPanel(_usersFoundList[i], idx);
                idx++;
            }

            // Add all Panels in userPanelList to resultPanel controls list to make them appear
            foreach (Panel panel in _userPanelList)
            {
                resultsPanel.Controls.Add(panel);
            }
        }

        private void GenerateUserPanel(User user, int index)
        {
            // Instantiate a new Panel which will be used throughout this method
            Panel tempPanel = new Panel();
            tempPanel.Size = new Size(397, 74);
            tempPanel.BackColor = Color.White;
            tempPanel.BorderStyle = BorderStyle.FixedSingle;

            // Calculate position for the Panel
            if (index % 2 == 0)
                tempPanel.Location = new Point(22, 13 + (13 + tempPanel.Height) * (index / 2));
            else
                tempPanel.Location = new Point(454, 13 + (13 + tempPanel.Height) * (index / 2));

            // Add visual objects like Labels and Picture...
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

        /// <summary>
        /// Goes to the user profile when Panel is clicked
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        /// <param name="user">The User on the Panel</param>
        private void OnTempPanelClick(object sender, EventArgs e, User user)
        {
            OnTempPanelLeave(sender, e);
            this.Hide();
            ProfileTab foundUserProfile;
            if (user.Sysmin)
                foundUserProfile = new InstructorProfileTab(user, true);
            else
                foundUserProfile = new StudentProfileTab(user, true);
            foundUserProfile.BackButtonClicked += ExecuteSearch;
            foundUserProfile.Location = this.Location;
            foundUserProfile.Parent = this;
            this.Parent.Controls.Add(foundUserProfile);
            foundUserProfile.Show();
        }

        /// <summary>
        /// Changes cursor and color on mouse enter
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
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

        /// <summary>
        /// Changes cursor and color on mouse leave
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
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

        /// <summary>
        /// Executes the search when search button clicked
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void pictureSearchButton_Click(object sender, EventArgs e)
        {
            ExecuteSearch();
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Changes color of pictureSearchButton on mouse enter
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void pictureSearchButton_MouseEnter(object sender, EventArgs e)
        {
            pictureSearchButton.BackColor = Color.FromArgb(230, 230, 230);
        }

        /// <summary>
        /// Changes color of pictureSearchButton on mouse leave
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void pictureSearchButton_MouseLeave(object sender, EventArgs e)
        {
            pictureSearchButton.BackColor = Color.FromArgb(255, 255, 255);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class UserSearchTab : UserControl
    {
        public UserSearchTab()
        {
            InitializeComponent();
            errorLabel.Text = string.Empty;
        }

        private List<User> _usersFoundList = new List<User>();
        private List<Panel> _userPanelList = new List<Panel>();

        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            _usersFoundList = DatabaseParser.UserSearchList(searchBox.Text);

            _userPanelList.Clear();
            resultsPanel.Controls.Clear();

            if (_usersFoundList.Count == 0)
            {
                errorLabel.Text = "No Users Found";
                return;
            }

            for (int i = 0; i < _usersFoundList.Count; i++)
            {
               GenerateUserPanel(_usersFoundList[i], i);
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
                tempPanel.Location = new Point(22, 13 + (13 + tempPanel.Height * (index / 2)) * (index / 2));
            else
                tempPanel.Location = new Point(454, 13 + (13 + tempPanel.Height * (index / 2)) * (index / 2));

            PictureBox profilePictureBox = new PictureBox();
            profilePictureBox.Load(user.PicturePath);
            profilePictureBox.Location = new Point(5, 5);
            profilePictureBox.Size = new Size(64, 64);
            profilePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            tempPanel.Controls.Add(profilePictureBox);

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

            profilePictureBox.Click += (sender, e) => OnTempPanelClick(sender, e, user);
            nameLabel.Click += (sender, e) => OnTempPanelClick(sender, e, user);
            emailLabel.Click += (sender, e) => OnTempPanelClick(sender, e, user);
            addressLabel.Click += (sender, e) => OnTempPanelClick(sender, e, user);
            phoneLabel.Click += (sender, e) => OnTempPanelClick(sender, e, user);
            tempPanel.Click += (sender, e) => OnTempPanelClick(sender, e, user);

            _userPanelList.Add(tempPanel);
        }

        private void OnTempPanelClick(object sender, EventArgs e, User user)
        {
            this.Hide();
            ProfileTab foundUserProfile = new ProfileTab(user, true);
            foundUserProfile.Location = this.Location;
            foundUserProfile.Parent = this;
            this.Parent.Controls.Add(foundUserProfile);
            foundUserProfile.Show();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class MainWindowTab : Form
    {
        public MainWindowTab()
        {
            InitializeComponent();
            MoveButtonSpaces(OverviewButton, 8);
            MoveButtonSpaces(ProfileButton, 8);
            MoveButtonSpaces(bookingButton, 8);
            MoveButtonSpaces(settingsButton, 8);
            OverviewButton.Controls.Add(pictureHomeTab);
            ProfileButton.Controls.Add(pictureProfileTab);
            bookingButton.Controls.Add(pictureBookingTab);
            settingsButton.Controls.Add(pictureSettingsTab);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {

            if (!panelForProfile.Visible)
            {
                //placing the panel at the correct location
                panelForProfile.Location = new Point(ProfileButton.Location.X, ProfileButton.Location.Y + ProfileButton.Height);
                panelForProfile.Show();
                //moving objects below
                bookingButton.Location = MoveLocation(bookingButton.Location, panelForProfile.Height);
                settingsButton.Location = MoveLocation(settingsButton.Location, panelForProfile.Height);
            }
            else
            {
                //move objects back
                bookingButton.Location = MoveLocation(bookingButton.Location, -panelForProfile.Height);
                settingsButton.Location = MoveLocation(settingsButton.Location, -panelForProfile.Height);
                panelForProfile.Hide();
            }

        }

        private void MoveButtonSpaces(Button button, int spaces)
        {
            string spacesString = null;
            //moves the buttons in tab to make space for a icon
            for (int i = 0; i < spaces; i++)
            {
                spacesString += " ";
            }
            button.Text = $@"{spacesString}{button.Text}";
        }
        private Point MoveLocation(Point location, int moveLocation)
        {
            return new Point(location.X, location.Y + moveLocation);
        }
    }
}
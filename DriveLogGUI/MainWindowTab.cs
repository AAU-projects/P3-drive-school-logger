using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class MainWindowTab : Form
    {
<<<<<<< HEAD
        private Point lastClick;
        private Point pageStartPoint;
        private UserControl lastPage;
=======
        private Point _lastClick;
        private UserControl _lastPage;
        private bool _isOpen;
>>>>>>> master

        private OverviewTab overviewTab;
        private ProfileTab profileTab;
        private DocumentViewer documentViewer;

        public MainWindowTab()
        {
            // Initializing
            overviewTab = new OverviewTab();
            profileTab = new ProfileTab();
            documentViewer = new DocumentViewer();

            InitializeComponent();
            MoveButtonSpaces(OverviewButton, 8);
            MoveButtonSpaces(ProfileButton, 8);
            MoveButtonSpaces(bookingButton, 8);
            MoveButtonSpaces(settingsButton, 8);
            OverviewButton.Controls.Add(pictureHomeTab);
            ProfileButton.Controls.Add(pictureProfileTab);
            bookingButton.Controls.Add(pictureBookingTab);
            settingsButton.Controls.Add(pictureSettingsTab);
            overviewTab.LogOutButtonClick += new EventHandler(logoutButton_Click);
            overviewTab.DoctorsNotePictureButtonClick += new EventHandler(doctorsNoteButton_Click);

            //createing the start point for all pages.
            pageStartPoint = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);

            // setting their location
            overviewTab.Location = pageStartPoint;
            profileTab.Location = pageStartPoint;
            documentViewer.Location = pageStartPoint;

            // adding them as control panels
            this.Controls.Add(overviewTab);
            this.Controls.Add(profileTab);
            this.Controls.Add(documentViewer);

            // opening starting page after login
            OpenPage(overviewTab);
        }

        private void doctorsNoteButton_Click(object sender, EventArgs e)
        {
            OpenPage(doctorsNoteTab);

            ProfileSubmenuControl(true);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            OpenPage(profileTab);

            ProfileSubmenuControl(true);
        }

        private void ProfileSubmenuControl(bool isProfileClick)
        {
            if (!panelForProfile.Visible && isProfileClick)
            {
                //placing the panel at the correct location
                panelForProfile.Location = new Point(ProfileButton.Location.X, ProfileButton.Location.Y + ProfileButton.Height);
                panelForProfile.Show();
                //moving objects below
                bookingButton.Location = MoveLocation(bookingButton.Location, panelForProfile.Height);
                settingsButton.Location = MoveLocation(settingsButton.Location, panelForProfile.Height);
                _isOpen = true;
            }
            else if (_isOpen)
            {
                //move objects back
                bookingButton.Location = MoveLocation(bookingButton.Location, -panelForProfile.Height);
                settingsButton.Location = MoveLocation(settingsButton.Location, -panelForProfile.Height);
                panelForProfile.Hide();
                _isOpen = false;
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

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            //To add a page create a usercontrol and send it as paramater in use OpenPage
            OpenPage(overviewTab);

            ProfileSubmenuControl(false);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            _lastClick = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - _lastClick.X;
                this.Top += e.Y - _lastClick.Y;
            }
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainWindowTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Owner.Visible) {
                this.Dispose();
            } else if (!Owner.Visible) {
                Application.Exit();
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void OpenPage(UserControl page)
        {
            if (_lastPage != page) 
            {
                CloseLastPage();
                _lastPage = page;
                page.Show();
            }
        }

        private void CloseLastPage()
        {
            if (_lastPage != null)
            {
                _lastPage.Hide();
            }
        }

<<<<<<< HEAD
        private void firstAidButton_Click(object sender, EventArgs e)
        {
            if (DatabaseParser.ExistFirstAid(Session.LoggedInUser))
            {
                OpenPage(documentViewer);
                documentViewer.LoadFirstAid(Session.LoggedInUser);
            }
            else
            {
                documentViewer.Clear();
                OpenPage(documentViewer);
            }
=======
        private void bookingButton_Click(object sender, EventArgs e)
        {
            ProfileSubmenuControl(false);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            ProfileSubmenuControl(false);
>>>>>>> master
        }
    }
}

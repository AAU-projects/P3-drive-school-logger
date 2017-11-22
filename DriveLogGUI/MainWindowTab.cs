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
        public Point pageStartPoint { get; set; }
        private Point _lastClick;
        public UserControl _lastPage;
        private Button _lastButton;
        private bool _isOpen;

        private OverviewTab overviewTab;
        private ProfileTab profileTab;
        private DocumentViewer documentViewer;
        private DoctorsNote doctorsNoteTab;
        private UserSearchTab userSearchTab;
        private CalendarTabG calendarTab;
        private SettingsTab settingsTab;
        private DriveLogTab driveLogTab;


        public MainWindowTab()
        {
            InitializeComponent();
            InitializeMenuTabs();


            overviewTab.LogOutButtonClick += new EventHandler(logoutButton_Click);
            overviewTab.DoctorsNotePictureButtonClick += new EventHandler(doctorsNoteButton_Click);

            //createing the start point for all pages.
            pageStartPoint = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);

            // setting their location
            overviewTab.Location = pageStartPoint;
            profileTab.Location = pageStartPoint;
            driveLogTab.Location = pageStartPoint;
            documentViewer.Location = pageStartPoint;
            doctorsNoteTab.Location = pageStartPoint;
            userSearchTab.Location = pageStartPoint;
            calendarTab.Location = pageStartPoint;
            settingsTab.Location = pageStartPoint;

            // adding them as control panels
            this.Controls.Add(overviewTab);
            this.Controls.Add(profileTab);
            this.Controls.Add(driveLogTab);
            this.Controls.Add(documentViewer);
            this.Controls.Add(doctorsNoteTab);
            this.Controls.Add(userSearchTab);
            this.Controls.Add(calendarTab);
            this.Controls.Add(settingsTab);
            
            if (Session.LoggedInUser.Sysmin)
            {
                this.Controls.Add(userSearchTab);

                userSearchButton.Enabled = true;
                userSearchButton.Visible = true;
                pictureSearchTab.Enabled = true;
                pictureSearchTab.Visible = true;
                driveLogButton.Visible = false;
                driveLogButton.Enabled = false;

                settingsButton.Location = new Point(0, 138);
            }

            overviewTab.SubPageCreated += OpenPageEvent;
            profileTab.SubPageCreated += OpenPageEvent;

            // opening starting page after login
            _lastButton = OverviewButton;
            OpenPage(OverviewButton, overviewTab);
        }

        private void InitializeMenuTabs()
        {
            overviewTab = new OverviewTab();
            profileTab = new ProfileTab(Session.LoggedInUser);
            documentViewer = new DocumentViewer();
            doctorsNoteTab = new DoctorsNote();
            userSearchTab = new UserSearchTab();
            calendarTab = new CalendarTabG(overviewTab, this);
            settingsTab = new SettingsTab();
            driveLogTab = new DriveLogTab(Session.LoggedInUser);

            overviewTab.Hide();
            profileTab.Hide();
            driveLogTab.Hide();
            documentViewer.Hide();
            doctorsNoteTab.Hide();
            userSearchTab.Hide();
            calendarTab.Hide();
            settingsTab.Hide();

            MoveButtonSpaces(OverviewButton, 8);
            MoveButtonSpaces(ProfileButton, 8);
            MoveButtonSpaces(bookingButton, 8);
            MoveButtonSpaces(settingsButton, 8);
            MoveButtonSpaces(userSearchButton, 8);
            OverviewButton.Controls.Add(pictureHomeTab);
            ProfileButton.Controls.Add(pictureProfileTab);
            bookingButton.Controls.Add(pictureBookingTab);
            settingsButton.Controls.Add(pictureSettingsTab);
            userSearchButton.Controls.Add(pictureSearchTab);
        }

        private void doctorsNoteButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, doctorsNoteTab);

            ProfileSubmenuControl(true);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, profileTab);

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
                userSearchButton.Location = MoveLocation(userSearchButton.Location, panelForProfile.Height);
                _isOpen = true;
            }
            else if (_isOpen)
            {
                //move objects back
                bookingButton.Location = MoveLocation(bookingButton.Location, -panelForProfile.Height);
                settingsButton.Location = MoveLocation(settingsButton.Location, -panelForProfile.Height);
                userSearchButton.Location = MoveLocation(userSearchButton.Location, -panelForProfile.Height);
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
            OpenPage(sender, overviewTab);

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
            this.documentViewer.DisposePdf();
            this.Close();
        }

        private void MainWindowTab_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Owner.Visible)
                this.Dispose();
            else if (!Owner.Visible)
                Application.Exit();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Owner.Show();
            this.Close();
        }

        private void OpenPage(object sender, UserControl page)
        {
            if (_lastPage != page) 
            {
                CloseLastPage();
                _lastPage = page;
                
                page.Show();

                HighlightCurrentButton((Button)sender, _lastButton);
                _lastButton = (Button)sender;
            }
        }

        private void HighlightCurrentButton(Button sender, Button lastButton)
        {
            _lastButton.BackColor = Color.FromArgb(81, 108, 112);
            sender.BackColor = Color.FromArgb(148, 197, 204);
        }
        
        private void OpenPageEvent(UserControl page)
        {
            if (Session.LoggedInUser.Sysmin) return;
            if (page is OverviewTab || page is ProfileTab)
            {
                OpenPage(driveLogTab);
            }
        }

        private void CloseLastPage()
        {
            if (_lastPage != null)
            {
                _lastPage.Hide();
                foreach (Control lastPageControl in _lastPage.Controls)
                {
                    if (lastPageControl is UserControl)
                        lastPageControl.Dispose();
                }
            }
        }

        private void firstAidButton_Click(object sender, EventArgs e)
        {
            if (DatabaseParser.ExistFirstAid(Session.LoggedInUser))
            {
                OpenPage(sender, documentViewer);
                documentViewer.LoadFirstAid(Session.LoggedInUser);
            }
            else
            {
                OpenPage(sender, documentViewer);
                documentViewer.SetType(Session.TypeFirstAid);
            }
        }

        private void bookingButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, calendarTab);
            ProfileSubmenuControl(false);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, settingsTab);
            ProfileSubmenuControl(false);
        }

        private void userSearchButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, userSearchTab);
            ProfileSubmenuControl(false);
        }
        
        private void doctorsNoteButton_Click_1(object sender, EventArgs e)
        {
            if (DatabaseParser.ExistDoctorsNote(Session.LoggedInUser))
            {
                OpenPage(sender, documentViewer);
                documentViewer.LoadDoctorsNote(Session.LoggedInUser);
            }
            else
            {
                OpenPage(sender, documentViewer);
                documentViewer.SetType(Session.TypeDoctorsNote);
            }
        }

        internal void driveLogButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, driveLogTab);
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

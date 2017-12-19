using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.MenuTabs;
using DriveLogGUI.Windows;
using System.Threading;

namespace DriveLogGUI
{
    public partial class MainWindow : Form
    {
        public Point pageStartPoint { get; set; }
        private Point _lastClick;
        public UserControl _lastPage;
        private Button _lastButton;
        private bool _isOpen;

        private OverviewTab overviewTab;
        private ProfileTab profileTab;
        private DocumentViewer documentViewer;
        private UserSearchTab userSearchTab;
        private CalendarTabG calendarTab;
        private DriveLogTab driveLogTab;
        private TemplateCreator _lessonCreator;

        /// <summary>
        /// The constructor makes sure that all the buttons are added to the correct controls aswell as making sure everything is setup correctly
        /// </summary>
        public MainWindow()
        {
            Thread loadingThread = new Thread(new ThreadStart(LoadingScreenStart));
            loadingThread.Start();

            InitializeComponent();
            InitializeMenuTabs();

            loadingThread.Abort();
            
            // Add logout events for pages containing a logout button.
            overviewTab.LogOutButtonClick += LogOut;
            profileTab.LogOutButtonClick += LogOut;
            userSearchTab.LogOutButtonClick += LogOut;
            driveLogTab.LogOutButtonClick += LogOut;

            //createing the start point for all pages.
            pageStartPoint = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);

            // setting their location
            overviewTab.Location = pageStartPoint;
            profileTab.Location = pageStartPoint;
            driveLogTab.Location = pageStartPoint;
            documentViewer.Location = pageStartPoint;
            userSearchTab.Location = pageStartPoint;
            calendarTab.Location = pageStartPoint;
            _lessonCreator.Location = pageStartPoint;

            // adding them as control panels
            this.Controls.Add(overviewTab);
            this.Controls.Add(profileTab);
            this.Controls.Add(driveLogTab);
            this.Controls.Add(documentViewer);
            this.Controls.Add(userSearchTab);
            this.Controls.Add(calendarTab);
            this.Controls.Add(_lessonCreator);


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

            overviewTab.IconPictureButtonClickEvent += OnIconClick;
            profileTab.IconPictureButtonClickEvent += OnIconClick;
            overviewTab.SubPageCreated += OpenPageEvent;
            profileTab.SubPageCreated += OpenPageEvent;

            // opening starting page after login
            _lastButton = OverviewButton;
            OpenPage(OverviewButton, overviewTab);

            SettingsAdminSubMenu();
            SettingsSubMenu(false);
        }

        /// <summary>
        /// A loading screen that is showed while everything is intializing
        /// </summary>
        public void LoadingScreenStart()
        {
            Application.Run(new LoadingScreen());
        }

        /// <summary>
        /// Method that can be called to logout
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void LogOut(object sender, EventArgs e)
        {
            Owner.Show();
            this.Hide();
        }

        /// <summary>
        /// The intilizaing of menu tabs creates the correct pages depending on if a user is a instructor or student. 
        /// </summary>
        private void InitializeMenuTabs()
        {
            if (Session.LoggedInUser.Sysmin)
            {
                overviewTab = new InstructorOverviewTab();
                profileTab = new InstructorProfileTab(Session.LoggedInUser);
                }
            else
            {
                overviewTab = new StudentOverviewTab();
                profileTab = new StudentProfileTab(Session.LoggedInUser);
            }

            documentViewer = new DocumentViewer();
            userSearchTab = new UserSearchTab();
            calendarTab = new CalendarTabG(overviewTab, this);
            driveLogTab = new DriveLogTab(Session.LoggedInUser);
            _lessonCreator = new TemplateCreator();


            overviewTab.Hide();
            profileTab.Hide();
            driveLogTab.Hide();
            documentViewer.Hide();
            userSearchTab.Hide();
            calendarTab.Hide();
            _lessonCreator.Hide();
            
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

        /// <summary>
        /// Method used to show the submenus
        /// </summary>
        /// <param name="profileSubMenu">If true the profile submenu is shown</param>
        /// <param name="settingsSubMenu">If true the settings submenu is shown</param>
        private void SubMenus(bool profileSubMenu = false, bool settingsSubMenu = false)
        {
            ProfileSubmenuControl(profileSubMenu);
            SettingsSubMenu(settingsSubMenu);
        }

        /// <summary>
        /// Method used to show the settings menu
        /// </summary>
        /// <param name="visabilty"></param>
        private void SettingsSubMenu(bool visabilty = true)
        {
            string[] adminSettingsBtnNames = {"templateBtn"};
            string[] normalSettingsbtnNames = { };
            IEnumerable<string> settingsbtnNames = normalSettingsbtnNames;

            if (Session.LoggedInUser.Sysmin)
            {
                settingsbtnNames = normalSettingsbtnNames.Union(adminSettingsBtnNames);
            }

            if (visabilty)
            {
                foreach (string btnName in settingsbtnNames)
                {
                    panel4.Controls.Find(btnName,false)[0].Show();
                }
            }
            else
            {
                foreach (string btnName in settingsbtnNames)
                {
                    panel4.Controls.Find(btnName, false)[0].Hide();
                }
            }
        }

        /// <summary>
        /// Method used to show the settings menu for an instructor
        /// </summary>
        private void SettingsAdminSubMenu()
        {
            Button templateBtn = new Button
            {
                Name = "templateBtn",
                Text = "Templates",
                Size = new Size(108, 32),
                Location = new Point(
                    settingsButton.Location.X + 24,
                    settingsButton.Location.Y + settingsButton.Height
                    ),
                BackColor = Color.Transparent,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.FromArgb(109, 144, 150)
                },
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft
            };

            templateBtn.Click += TemplateBtn_Click;
            templateBtn.Hide();
            panel4.Controls.Add(templateBtn);
        }

        private void TemplateBtn_Click(object sender, EventArgs e)
        {
            OpenPage(sender, _lessonCreator);
        }

        /// <summary>
        /// When button is clicked the profile submenu is shown
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void ProfileButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            if (!Session.LoggedInUser.Sysmin)
                ProfileSubmenuControl(true);
            profileTab.UpdateInfo();
            OpenPage(sender, profileTab);
        }

        /// <summary>
        /// Method used to close and open the profile sub menu
        /// </summary>
        /// <param name="isProfileClick"></param>
        private void ProfileSubmenuControl(bool isProfileClick)
        {
            if (!panelForProfile.Visible && isProfileClick)
            {
                //placing the panel at the correct location
                panelForProfile.Location = new Point(ProfileButton.Location.X, ProfileButton.Location.Y + ProfileButton.Height);
                //moving objects below
                bookingButton.Location = MoveLocationY(bookingButton.Location, panelForProfile.Height);
                settingsButton.Location = MoveLocationY(settingsButton.Location, panelForProfile.Height);
                userSearchButton.Location = MoveLocationY(userSearchButton.Location, panelForProfile.Height);
                _isOpen = true;
                panelForProfile.Show();
            }
            else if (_isOpen && !isProfileClick)
            {
                //move objects back
                bookingButton.Location = MoveLocationY(bookingButton.Location, -panelForProfile.Height);
                settingsButton.Location = MoveLocationY(settingsButton.Location, -panelForProfile.Height);
                userSearchButton.Location = MoveLocationY(userSearchButton.Location, -panelForProfile.Height);
                panelForProfile.Hide();
                _isOpen = false;
            }
        }

        /// <summary>
        ///  Method used to move a button around
        /// </summary>
        /// <param name="button">The button Control that should be moved</param>
        /// <param name="spaces">How many spaces it should be moved to the right</param>
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

        /// <summary>
        /// Method used to caculate a new location that should be on the y-axis
        /// </summary>
        /// <param name="location">The current location of the control</param>
        /// <param name="moveLocation">How many pixels it should be moved on the y a-axis</param>
        /// <returns>Returns a new point that is the moved location</returns>
        private Point MoveLocationY(Point location, int moveLocation)
        {
            return new Point(location.X, location.Y + moveLocation);
        }

        /// <summary>
        /// Method for when the overview button is clicked
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void OverviewButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
            //To add a page create a usercontrol and send it as paramater in use OpenPage
            overviewTab.UpdateInfo();
            OpenPage(sender, overviewTab);
            
            SubMenus();
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

        /// <summary>
        /// Method for opening a usercontrol page, this makes sure that the last page is closed and the new usercontrol is shown
        /// </summary>
        /// <param name="sender">The Object sender</param>
        /// <param name="page">The page that should be shown</param>
        private void OpenPage(object sender, UserControl page)
        {
            if (_lastPage != page) 
            {
                CloseLastPage();
                _lastPage = page;
                
                page.Show();

                HighlightCurrentButton((Button)sender);
                Cursor = Cursors.Arrow;
            } 
            
            else if (_lastPage is DocumentViewer && page is DocumentViewer)
            {
                HighlightCurrentButton((Button)sender);
            }
        }


        /// <summary>
        /// Method for highlighing a button
        /// </summary>
        /// <param name="sender">This button will be highlighted</param>
        public void HighlightCurrentButton(Button sender)
        {
            _lastButton.BackColor = Color.FromArgb(81, 108, 112);
            sender.BackColor = Color.FromArgb(148, 197, 204);
            _lastButton = sender;
        }

        /// <summary>
        /// Method that makes sure that the submenus can only be open if the user is a student 
        /// </summary>
        /// <param name="page">The page that should be shown</param>
        private void OpenPageEvent(UserControl page)
        {
            if (Session.LoggedInUser.Sysmin) return;
            if (page is StudentOverviewTab || page is StudentProfileTab)
            {
                SubMenus(true);
                OpenPage(driveLogButton, driveLogTab);
            }
        }

        /// <summary>
        /// Method to close the last usercontrol page
        /// </summary>
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

        /// <summary>
        /// Method for when the first aid button is clciked, opens the exisitng first aid or empty one
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void firstAidButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
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
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Method to open the calendar page
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void bookingButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, calendarTab);
            SubMenus();
        }

        /// <summary>
        /// Method to open the settings page
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void settingsButton_Click(object sender, EventArgs e)
        {
            //OpenPage(sender, ??);
            SubMenus(settingsSubMenu: true);
        }

        /// <summary>
        /// Method to go to the user search if a previous usercontrol is not open
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void userSearchButton_Click(object sender, EventArgs e)
        {
            UserControl finalpage = userSearchTab;
            bool usersearchfound = false;
            foreach (Control c in this.Controls)
            {
                if (c is UserSearchTab)
                { 
                    usersearchfound = true;
                    continue;
                }

                if (!usersearchfound)
                    continue;

                if (c is DriveLogTab)
                    finalpage =  c as DriveLogTab;
                else if (c is DocumentViewer)
                    finalpage = c as DocumentViewer;
                else if (c is ProfileTab)
                    finalpage = c as ProfileTab;
            }

            OpenPage(sender, finalpage);
            SubMenus();
        }

        /// <summary>
        /// Method for doctors note this opens the already existing doctors note or an empty one
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void doctorsNoteButton_Click_1(object sender, EventArgs e)
        {
            Cursor = Cursors.AppStarting;
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
            Cursor = Cursors.Arrow;
        }

        /// <summary>
        /// Method for going to pages that match the icon that have been clicked
        /// </summary>
        /// <param name="sender">The Object Sender</param>
        /// <param name="e">The EventArgs</param>
        private void OnIconClick(object sender, EventArgs e)
        {
            SubMenus(true);

            PictureBox pBox = sender as PictureBox;

            if (pBox.Name == "doctorsNotePictureButton")
            {
                OpenPage(doctorsNoteButton, documentViewer);
                documentViewer.LoadDoctorsNote(Session.LoggedInUser);
            }

            else if (pBox.Name == "firstAidPictureButton")
            {
                OpenPage(firstAidButton, documentViewer);
                documentViewer.LoadFirstAid(Session.LoggedInUser);
            }

        }

        internal void driveLogButton_Click(object sender, EventArgs e)
        {
            OpenPage(sender, driveLogTab);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

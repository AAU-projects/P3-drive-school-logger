using System;
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
        private Point lastClick;
        private UserControl lastPage;

        private OverviewTab overviewTab;
        private ProfileTab profileTab;
        private DoctorsNote doctorsNoteTab;

        public MainWindowTab()
        {
            // asdasd
            overviewTab = new OverviewTab();
            this.Controls.Add(overviewTab);
            profileTab = new ProfileTab();
            doctorsNoteTab = new DoctorsNote();

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

            overviewTab.Location = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);
            profileTab.Location = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);
            doctorsNoteTab.Location = new Point(leftSidePanel.Size.Width, topPanel.Size.Height);

            OpenPage(overviewTab);
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            OpenPage(profileTab);

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

        private void OverviewButton_Click(object sender, EventArgs e)
        {
            //To add a page create a usercontrol and send it as paramater in use OpenPage
            OpenPage(overviewTab);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastClick = e.Location;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastClick.X;
                this.Top += e.Y - lastClick.Y;
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

        private void button7_Click(object sender, EventArgs e)
        {
            OpenPage(doctorsNoteTab);
        }

        private void OpenPage(UserControl page)
        {
            if (lastPage != page) 
            {
                CloseLastPage();
                lastPage = page;
                page.Show();
            }
        }

        private void CloseLastPage()
        {
            if (lastPage != null)
            {
                lastPage.Hide();
            }
        }
    }
}

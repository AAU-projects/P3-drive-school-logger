using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class InstructorProfileTab : ProfileTab
    {
        private User _user;
        private bool _search;
        internal event SubPageNotification SubPageCreated;
        internal override event NoParametersEvent BackButtonClicked;

        List<AppointmentStructure> instructorAppointments = new List<AppointmentStructure>();

        public InstructorProfileTab(User user, bool search = false)
        {
            InitializeComponent();
            _user = user;
            _search = search;
            UpdateLayout();
            UpdateInfo();

            FormatAppointmentInformationPanel();

            foreach (Control c in upcommingTestsBackPanel.Controls)
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

            if (!string.IsNullOrEmpty(_user.PicturePath) || _user.PicturePath != "")
            {
                ProfilePicture.Load(_user.PicturePath);
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
            BackButtonClicked?.Invoke();
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

        private void FormatAppointmentInformationPanel()
        {
            // Create overlay panel, for when the user clicks on an appointment.
            appointmentInformationPanel.Width = upcommingLessonsBackPanel.Width;
            appointmentInformationPanel.Height = upcommingLessonsBackPanel.Height;
            appointmentInformationPanel.Location = new Point(0, 0);

            upcommingLessonsBackPanel.Controls.Add(appointmentInformationPanel);

            // Create subpanels and labels for the overlay panel.

            // Create back button.
            Button informationPanelBackButton = new Button
            {
                Text = "Back",
                ForeColor = Color.White,
                BackColor = ColorScheme.MainThemeColorLighter,
                Width = 80,
                Height = 40,
                Left = appointmentInformationPanel.Width - 92,
                Top = appointmentInformationPanel.Height - 50,
                FlatStyle = FlatStyle.Flat
            };
            informationPanelBackButton.Click += (s, e) => appointmentInformationPanel.Hide();
            appointmentInformationPanel.Controls.Add(informationPanelBackButton);

            appointmentInformationPanel.BringToFront();
            appointmentInformationPanel.Hide();
        }

        private void panelContainingUpcomingLessons_Paint(object sender, PaintEventArgs e)
        {
            int widthForEachDay = panelContainingUpcomingLessons.Width / 4;
            int heightForEachDay = panelContainingUpcomingLessons.Height / 10;
            int locationForRow = 0;

            // Get appointments for the instructor, and take 10 if the count is above 10.
            instructorAppointments = Session.LoggedInUser.InstructorAppointments.Count > 10 ? Session.LoggedInUser.InstructorAppointments.Take(10).ToList() : Session.LoggedInUser.InstructorAppointments;


            foreach (AppointmentStructure appointment in instructorAppointments)
            {
                Panel appointmentPanel = new Panel
                {
                    Width = panelContainingUpcomingLessons.Width,
                    Height = heightForEachDay,
                    Location = new Point(0, locationForRow),
                    Cursor = Cursors.Hand
                };

                Label dateLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay + 30,
                    Left = 0
                };

                Label timeLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay / 2,
                    Left = widthForEachDay + 30
                };

                Label typeLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay,
                    Left = timeLabel.Left + timeLabel.Width + 10
                };

                Label statusLabel = new Label
                {
                    AutoSize = false,
                    Font = new Font("Calibri Light", 10F, FontStyle.Regular),
                    ForeColor = ColorScheme.MainFontColor,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = widthForEachDay,
                    Left = typeLabel.Left + widthForEachDay + 10
                };

                locationForRow += heightForEachDay;

                // Add Controls.
                appointmentPanel.Controls.Add(statusLabel);
                appointmentPanel.Controls.Add(typeLabel);
                appointmentPanel.Controls.Add(timeLabel);
                appointmentPanel.Controls.Add(dateLabel);

                panelContainingUpcomingLessons.Controls.Add(appointmentPanel);

                // Set values of labels.
                dateLabel.Text = $@"{appointment.StartTime.Date:dd/MM} {appointment.StartTime.DayOfWeek}";
                timeLabel.Text = $@"{appointment.StartTime:HH:mm}";
                typeLabel.Text = $@"{appointment.LessonType}";
                

                // Get amount of booked students.
                List<Lesson> listOfLessonsForCurrentAppointment = Session.LoggedInUser.InstructorLessons
                    .Where(l => l.AppointmentID == appointment.Id).GroupBy(x => x.StudentId).Select(y => y.First()).ToList();
                statusLabel.Text = $@"{listOfLessonsForCurrentAppointment.Count} / 24";

                // Panel hover.
                foreach (Label label in appointmentPanel.Controls)
                {
                    label.MouseClick += (s, eventArgs) => appointmentInformationPanel.Show();
                    label.MouseEnter += (s, eventArgs) => OnAppointmentPanelEnter(appointmentPanel);
                    label.MouseLeave += (s, eventArgs) => OnAppointmentPanelLeave(appointmentPanel);
                }
            }
        }

        private void OnAppointmentPanelEnter(Panel appointmentPanel)
        {
            appointmentPanel.BackColor = ColorScheme.MainThemeColorLighter;
            foreach (Label label in appointmentPanel.Controls)
                label.ForeColor = Color.White;
        }

        private void OnAppointmentPanelLeave(Panel appointmentPanel)
        {
            appointmentPanel.BackColor = Color.White;
            foreach (Label label in appointmentPanel.Controls)
                label.ForeColor = ColorScheme.MainFontColor;
        }
    }
}

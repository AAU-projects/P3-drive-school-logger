using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;

namespace DriveLogGUI.MenuTabs
{
    public partial class StudentOverviewTab : OverviewTab
    {
        public event EventHandler LogOutButtonClick;
        internal override event SubPageNotification SubPageCreated;
        internal override event EventHandler IconPictureButtonClickEvent;
        private DateTime selectedMonth;
        private DateTime formatDateTime;

        // Pictures for overview buttons.
        private Bitmap incompleteImage = DriveLogGUI.Properties.Resources.crossIncomplete;
        private Bitmap incompleteHoverImage = DriveLogGUI.Properties.Resources.crossHover;
        private Bitmap completedImage = DriveLogGUI.Properties.Resources.checkCompleted;
        private Bitmap completedHoverImage = DriveLogGUI.Properties.Resources.checkHover;

        /// <summary>
        /// Class constructor. Initializes component, layout and information
        /// </summary>
        public StudentOverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = $"Welcome {Session.LoggedInUser.Firstname}";
            if (!Session.LoggedInUser.Active)
                welcomeUserLabel.Text = welcomeUserLabel.Text + " (Inactive)";
            selectedMonth = DateTime.Now;
            
            overviewUpdateTodaysNote.Hide();
            if (Session.LoggedInUser.Sysmin)
            {
                overviewUpdateTodaysNote.Show();
            }
            todaysNoteTextbox.Text = DatabaseParser.GetLatestTodaysNote();

            DrawCalendar();
            UpdateInfo();
        }

        /// <summary>
        /// Updates all the defined information
        /// </summary>
        public override void UpdateInfo()
        {
            // Update icons
            if (Session.LoggedInUser.TheoreticalTestDone)
                theroraticalPictureButton.Image = completedImage;
            if (Session.LoggedInUser.PracticalTestDone)
                praticalTestPictureButton.Image = completedImage;
            if (Session.LoggedInUser.FeePaid)
                feePictureBox.Image = completedImage;

            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
            FirstCheckIfUploaded(firstAidPictureButton);

            foreach (Lesson lesson in Session.LoggedInUser.LessonsList)
            {
                if (lesson.LessonTemplate.Id == 1 && lesson.Completed)
                    maneuverTrackPictureButton.Image = completedImage;
                if (lesson.LessonTemplate.Id == 18 && lesson.Completed)
                    slippertTrackPictureButton.Image = completedImage;
            }

            UpdateProgress();
        }

        /// <summary>
        /// Updates the users progress based on completed lessons
        /// </summary>
        private void UpdateProgress()
        {
            theoreticalStatus.Text = Session.LoggedInUser.TheoreticalProgress + "/24";
            practicalStatus.Text = Session.LoggedInUser.PracticalProgress + "/14";

            theoreticalProgressFill.Size = new Size((theoreticalBar.Width / 24) * Session.LoggedInUser.TheoreticalProgress, theoreticalBar.Height);
            practicalProgressFill.Size = new Size((practicalBar.Width / 14) * Session.LoggedInUser.PracticalProgress, practicalBar.Height);
        }

        /// <summary>
        /// Invokes click event when clicking doctors note icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The event args</param>
        private void doctorsNotePictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(doctorsNotePictureButton, e);
        }

        /// <summary>
        /// Draws the calendar with the correct information
        /// </summary>
        private void DrawCalendar()
        {
            int widthForEachDay = daysForCalendar.Width / 7;
            int heightForEachDay = daysForCalendar.Height / 6;

            formatDateTime = WhereDoWeStart();

            int locationForRow = 0;
            int locationForColumn = 0;

            for (var i = 0; i < 42; i++) // 42 is number of days in our calendar, therefor static.
            {
                // Instantiates a new calendar day
                CalendarData calendarDay = new CalendarData(new Panel(), new Label(), formatDateTime, new Panel());
                calendarDay.LabelForDate.MouseEnter += (s, e) =>
                    LabelForDateMouseEnter(calendarDay.LabelForDate, calendarDay.PanelForCalendarDay, calendarDay.Date);

                // Assign mouse leave event
                calendarDay.LabelForDate.MouseLeave +=
                    (s, e) => LabelForDateMouseLeave(calendarDay.PanelForCalendarDay, calendarDay.Date);

                // Add the day to the list of days
                listOfDays.Add(calendarDay);

                // Set the size for the Panel
                calendarDay.PanelForCalendarDay.Width = widthForEachDay;
                calendarDay.PanelForCalendarDay.Height = heightForEachDay;
                
                if (locationForRow == 336)
                {
                    locationForRow = 0;
                    locationForColumn += heightForEachDay;
                }

                // Set the location of Panel
                calendarDay.PanelForCalendarDay.Location = new Point(locationForRow, locationForColumn);
                locationForRow += widthForEachDay;

                // Format the data
                FormatPanelForDays(calendarDay, ref formatDateTime);
                daysForCalendar.Controls.Add(calendarDay.PanelForCalendarDay);
            }
        }

        /// <summary>
        /// Changes cursor and Panel back color on mouse enter
        /// </summary>
        /// <param name="label">The Label</param>
        /// <param name="panel">The Panel</param>
        /// <param name="panelDate">The Date</param>
        private void LabelForDateMouseEnter(Label label, Panel panel, DateTime panelDate)
        {
            label.Cursor = Cursors.Hand;
            if (panelDate != DateTime.Today)
                panel.BackColor = Color.FromArgb(229, 243, 255);
        }

        /// <summary>
        /// Changes Panel back color on mouse leave
        /// </summary>
        /// <param name="panel">The Panel</param>
        /// <param name="panelDate">The Date</param>
        private void LabelForDateMouseLeave(Panel panel, DateTime panelDate)
        {
            if (panelDate != DateTime.Today)
                panel.BackColor = Color.FromArgb(251, 251, 251);
        }

        /// <summary>
        /// Updates the calendar with data from listOfDays
        /// </summary>
        private void UpdateCalender()
        {
            foreach (CalendarData day in listOfDays)
            {
                Panel p = day.PanelForCalendarDay;
                Label l = day.LabelForDate;
                FormatPanelForDays(day, ref formatDateTime);
            }
        }

        /// <summary>
        /// Calculates the start date
        /// </summary>
        /// <returns>The start date</returns>
        private DateTime WhereDoWeStart()
        {
            int day;
            DateTime date = selectedMonth;
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            date = startDate;

            if (date.DayOfWeek == DayOfWeek.Sunday)
            {
                day = 6;
            }
            else
            {
                day = (int)date.DayOfWeek - 1;
            }
            DateTime endDate = date.AddDays(-day);
            date = endDate;

            return date;
        }

        /// <summary>
        /// Formats the Panels in the calendar
        /// </summary>
        /// <param name="data">the data to use in the calendar</param>
        /// <param name="currentDateTime">Current date and time</param>
        private void FormatPanelForDays(CalendarData data, ref DateTime currentDateTime)
        {
            calendarMonth.Text = selectedMonth.ToString("MMMM").ToUpper();

            data.PanelForCalendarDay.BackColor = Color.FromArgb(251, 251, 251);
            data.LabelForDate.ForeColor = Color.Black;
            data.LabelForDate.Font = new Font(data.LabelForDate.Font, FontStyle.Regular);
            data.LabelForDate.Text = currentDateTime.Day.ToString();
            data.LabelForDate.AutoSize = false;
            data.LabelForDate.Dock = DockStyle.Fill;
            data.LabelForDate.TextAlign = ContentAlignment.MiddleCenter;
            data.DayNotification.Height = 2;
            data.DayNotification.Width = 2;
            data.DayNotification.Location = new Point(data.PanelForCalendarDay.Width / 2 - data.DayNotification.Width / 2, data.PanelForCalendarDay.Height / 2 + 12);

            CheckIfUserHasAppointment(data.DayNotification, currentDateTime);
            
            if (currentDateTime.Month != selectedMonth.Month)
            {
                data.LabelForDate.ForeColor = Color.FromArgb(203, 203, 203);
            }
            else if (currentDateTime == DateTime.Today)
            {
                data.PanelForCalendarDay.BackColor = Color.FromArgb(148, 197, 204);
                data.LabelForDate.ForeColor = Color.FromArgb(251, 251, 251);
                data.LabelForDate.Font = new Font(data.LabelForDate.Font, FontStyle.Bold);
            }

            data.PanelForCalendarDay.Controls.Add(data.LabelForDate);
            data.Date = currentDateTime;

            currentDateTime = currentDateTime.AddDays(1);
        }

        /// <summary>
        /// Sets the color of the dayNotification Panel if the day and time mathces the lesson
        /// </summary>
        /// <param name="dayNotification">The Panel</param>
        /// <param name="currentDateTime">The current time and date</param>
        private void CheckIfUserHasAppointment(Panel dayNotification, DateTime currentDateTime)
        {
            foreach (Lesson lesson in Session.LoggedInUser.LessonsList)
            {
                if (lesson.EndDate.Date == currentDateTime.Date)
                {
                    dayNotification.BackColor = Color.FromArgb(0, 132, 144);
                }
                else
                {
                    dayNotification.BackColor = Color.FromArgb(251, 251, 251);
                }
            }

        }

        /// <summary>
        /// Event method raised when clicking the Right Arrow
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void calendarRightArrow_Click(object sender, EventArgs e)
        {
            selectedMonth = selectedMonth.AddMonths(1);
            formatDateTime = WhereDoWeStart();
            UpdateCalender();
        }

        /// <summary>
        /// Event method raised when clicking the Left Arrow
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void calendarLeftArrow_Click(object sender, EventArgs e)
        {
            selectedMonth = selectedMonth.AddMonths(-1);
            formatDateTime = WhereDoWeStart();
            UpdateCalender();
        }

        /// <summary>
        /// Event method raised when hovering the doctors note icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void doctorsNotePictureButton_Hover(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(doctorsNotePictureButton);
        }

        /// <summary>
        /// Event method raised when the cursor leaves the dictors note icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void doctorsNotePictureButton_Leave(object sender, EventArgs e)
        {
            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
        }

        /// <summary>
        /// Changes image on mouse enter
        /// </summary>
        /// <param name="button">The icon to change</param>
        private void ProgressButtonMouseEnter(PictureBox button)
        {
            if (button.Image == incompleteImage)
                button.Image = incompleteHoverImage;
            else if (button.Image == completedImage)
                button.Image = completedHoverImage;
        }

        /// <summary>
        /// Checks if the user has a doctors note and changes icon
        /// </summary>
        /// <param name="button">The icon to change</param>
        private void DoctorsNoteCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistDoctorsNote(Session.LoggedInUser))
                button.Image = completedImage;
        }

        /// <summary>
        /// Checks if the user has a first aid certificate and changes icon
        /// </summary>
        /// <param name="button">The icon to change</param>
        private void FirstCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistFirstAid(Session.LoggedInUser))
                button.Image = completedImage;
        }

        /// <summary>
        /// Event method raised when cursor enters the first aid icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void firstAidPictureButton_Enter(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(firstAidPictureButton);
        }

        /// <summary>
        /// Event method raised when cursor leaves the first aid icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void firstAidPictureButton_Leave(object sender, EventArgs e)
        {
            FirstCheckIfUploaded(firstAidPictureButton);
        }

        /// <summary>
        /// Event method raised when clicking the message edit
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void overviewUpdateTodaysNote_Click(object sender, EventArgs e)
        {
            if (todaysNoteTextbox.Enabled)
            {
                todaysNoteTextbox.Enabled = false;
                DatabaseParser.AddTodaysNote(Session.LoggedInUser, todaysNoteTextbox.Text);
            }
            else
            {
                todaysNoteTextbox.Enabled = true;
            }
        }

        /// <summary>
        /// Event method raised when clicking the first aid icon
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void firstAidPictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(firstAidPictureButton, e);
        }

        /// <summary>
        /// Invoke SubPageCreated event when clikcing the Drive log button
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void driveLogButton_Click(object sender, EventArgs e)
        {
            SubPageCreated?.Invoke(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class InstructorOverviewTab : OverviewTab
    {
        private DateTime selectedMonth;
        private DateTime formatDateTime;
        private List<Lesson> _lessonsToCompleteList = new List<Lesson>();

        // Pictures for overview buttons.
        private Bitmap incompleteImage = DriveLogGUI.Properties.Resources.crossIncomplete;
        private Bitmap incompleteHoverImage = DriveLogGUI.Properties.Resources.crossHover;
        private Bitmap completedImage = DriveLogGUI.Properties.Resources.checkCompleted;
        private Bitmap completedHoverImage = DriveLogGUI.Properties.Resources.checkHover;

        /// <summary>
        /// Class constructor. Initializes component, layout and information
        /// </summary>
        public InstructorOverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = "Welcome " + Session.LoggedInUser.Firstname;
            selectedMonth = DateTime.Now;
            
            overviewUpdateTodaysNote.Hide();
            if (Session.LoggedInUser.Sysmin)
            {
                overviewUpdateTodaysNote.Show();
            }
            todaysNoteTextbox.Text = DatabaseParser.GetLatestTodaysNote();
            activeUsersLabel.Text = "Active Users: " + DatabaseParser.GetActiveUserCount();
            DrawCalendar();
            UpdateInfo();
        }

        /// <summary>
        /// Updates all the defined information
        /// </summary>
        public override void UpdateInfo()
        {
            UpdateLessonsToCompleteList();
        }

        /// <summary>
        /// Updates the listview containing all the lessons an instructor needs to complete
        /// </summary>
        private void UpdateLessonsToCompleteList()
        {
            _lessonsToCompleteList.Clear();
            completeLessonsList.Items.Clear();

            // Retrieve all lessons by instructor
            List<Lesson> lessonsFoundList = DatabaseParser.GetLessonsToCompleteList(Session.LoggedInUser);
            int scheduledCount = 0;
            int studentCount = 1;

            foreach (Lesson lesson in lessonsFoundList)
            {
                // Skip lessons of the future and increment scheduledCount
                if (lesson.EndDate > DateTime.Now)
                {
                    scheduledCount++;
                    continue;
                }

                // Count how many students attended the same time slot and add lesson to the listview
                if (_lessonsToCompleteList.Count != 0 && lesson.StartDate == _lessonsToCompleteList.Last().StartDate)
                {
                    studentCount++;
                }
                else if (_lessonsToCompleteList.Count != 0)
                {
                    string[] subItems = {_lessonsToCompleteList.Last().LessonTemplate.Type, studentCount > 1 ? studentCount.ToString() : DatabaseParser.GetUserById(_lessonsToCompleteList.Last().StudentId).Fullname};
                    completeLessonsList.Items.Add(_lessonsToCompleteList.Last().StartDate.ToString("dd/MM - HH:mm") + " to " + _lessonsToCompleteList.Last().EndDate.ToString("HH:mm")).SubItems.AddRange(subItems);
                    studentCount = 1;
                }

                _lessonsToCompleteList.Add(lesson);
            }

            scheduledAppointmentsLabel.Text = "Scheduled Appointments: " + scheduledCount;
            freeAppointmentsLabel.Text = "Free Appointments: " +
                                         (DatabaseParser.GetAppointmentsByInstructorIdCount(Session.LoggedInUser.Id) -
                                         scheduledCount);
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
        /// Event method raised when clicking the message edit button
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
        /// Event method raised when activating an item in the listview
        /// </summary>
        /// <param name="sender">The object sender</param>
        /// <param name="e">The EventArgs</param>
        private void completeLessonsList_ItemActivate(object sender, EventArgs e)
        {
            if (!(sender is ListView item)) return;
            List<Lesson> tempLessonList = new List<Lesson>();

            // Add all lessons which match the StartTime of the selected item to tempLessonList
            foreach (Lesson l in _lessonsToCompleteList)
            {
                string lessontime = l.StartDate.ToString("dd/MM - HH:mm");
                string listtime = item.SelectedItems[0].Text.Substring(0, 13);
                if (lessontime == listtime)
                    tempLessonList.Add(l);
            }
            
            // Instantiates a new ConfirmLessonForm
            ConfirmLessonForm confirmbox = new ConfirmLessonForm(tempLessonList);

            // Shows the ConfirmLessonForm and assigns result
            DialogResult result = confirmbox.ShowDialog();

            // Call the update method if result is Yes
            if(result == DialogResult.Yes)
                UpdateLessonsToCompleteList();
        }
    }
}

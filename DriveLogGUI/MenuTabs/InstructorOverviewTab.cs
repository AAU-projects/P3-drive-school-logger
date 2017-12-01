using System;
using System.Collections.Generic;
using System.Drawing;
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

            DrawCalendar();
            UpdateLessonsToCompleteList();
            UpdateStatistics();
        }

        private void UpdateStatistics()
        {
            activeUsersLabel.Text = "Active Users: " + DatabaseParser.GetActiveUserCount();
        }

        private void UpdateLessonsToCompleteList()
        {
            _lessonsToCompleteList.Clear();
            completeLessonsList.Items.Clear();
            List<Lesson> lessonsFoundList = DatabaseParser.GetLessonsToCompleteList(Session.LoggedInUser);
            int scheduledCount = 0;

            foreach (Lesson lesson in lessonsFoundList)
            {
                if (lesson.EndDate > DateTime.Now)
                {
                    scheduledCount++;
                    continue;
                }

                _lessonsToCompleteList.Add(lesson);

                string[] subItems = {lesson.LessonTemplate.Title, DatabaseParser.GetUserById(lesson.StudentId).Fullname};
                completeLessonsList.Items.Add(lesson.StartDate.ToString("dd/MM - HH:mm") + " to " + lesson.EndDate.ToString("HH:mm")).SubItems.AddRange(subItems);
            }

            scheduledAppointmentsLabel.Text = "Scheduled Appointments: " + scheduledCount;
            freeAppointmentsLabel.Text = "Free Appointments: " +
                                         (DatabaseParser.GetAppointmentsByInstructorIdCount(Session.LoggedInUser.Id) -
                                         scheduledCount);
        }

        public DateTime GetPanelDate(int position)
        {
            return listOfDays[position].Date;
        }

        private void DrawCalendar()
        {
            int widthForEachDay = daysForCalendar.Width / 7;
            int heightForEachDay = daysForCalendar.Height / 6;

            formatDateTime = WhereDoWeStart();

            int locationForRow = 0;
            int locationForColumn = 0;

            for (var i = 0; i < 42; i++) // 42 is number of days in our calendar, therefor static.
            {
                CalendarData calendarDay = new CalendarData(new Panel(), new Label(), formatDateTime, new Panel());
                calendarDay.LabelForDate.MouseEnter += (s, e) =>
                    LabelForDateMouseEnter(calendarDay.LabelForDate, calendarDay.PanelForCalendarDay, calendarDay.Date);

                calendarDay.LabelForDate.MouseLeave +=
                    (s, e) => LabelForDateMouseLeave(calendarDay.PanelForCalendarDay, calendarDay.Date);

                listOfDays.Add(calendarDay);
                
                calendarDay.PanelForCalendarDay.Width = widthForEachDay;
                calendarDay.PanelForCalendarDay.Height = heightForEachDay;
                
                if (locationForRow == 336)
                {
                    locationForRow = 0;
                    locationForColumn += heightForEachDay;
                }

                calendarDay.PanelForCalendarDay.Location = new Point(locationForRow, locationForColumn);
                locationForRow += widthForEachDay;

                FormatPanelForDays(calendarDay, ref formatDateTime);
                daysForCalendar.Controls.Add(calendarDay.PanelForCalendarDay);
            }
        }

        private void LabelForDateMouseEnter(Label label, Panel panel, DateTime panelDate)
        {
            label.Cursor = Cursors.Hand;
            if (panelDate != DateTime.Today)
                panel.BackColor = Color.FromArgb(229, 243, 255);
        }

        private void LabelForDateMouseLeave(Panel panel, DateTime panelDate)
        {
            if (panelDate != DateTime.Today)
                panel.BackColor = Color.FromArgb(251, 251, 251);
        }

        private void UpdateCalender()
        {
            foreach (CalendarData day in listOfDays)
            {
                Panel p = day.PanelForCalendarDay;
                Label l = day.LabelForDate;
                FormatPanelForDays(day, ref formatDateTime);
            }
        }

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

        private void CheckIfUserHasAppointment(Panel dayNotification, DateTime currentDateTime)
        {
            foreach (Lesson lesson in Session.LoggedInUser.LessonsList) //TODO Lookup after session class appointment is done
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

        private void calendarRightArrow_Click(object sender, EventArgs e)
        {
            selectedMonth = selectedMonth.AddMonths(1);
            formatDateTime = WhereDoWeStart();
            UpdateCalender();
        }

        private void calendarLeftArrow_Click(object sender, EventArgs e)
        {
            selectedMonth = selectedMonth.AddMonths(-1);
            formatDateTime = WhereDoWeStart();
            UpdateCalender();
        }

        private void overviewUpdateTodaysNote_Click(object sender, EventArgs e)
        {
            if (todaysNoteTextbox.Enabled)
            {
                todaysNoteTextbox.Enabled = false;
                MySql.AddTodaysNote(Session.LoggedInUser, todaysNoteTextbox.Text);
            }
            else
            {
                todaysNoteTextbox.Enabled = true;
            }
        }

        private void completeLessonsList_ItemActivate(object sender, EventArgs e)
        {
            if (!(sender is ListView item)) return;
            List<Lesson> tempLessonList = new List<Lesson>();

            foreach (Lesson l in _lessonsToCompleteList)
            {
                if(l.EndDate == _lessonsToCompleteList[item.SelectedItems[0].Index].EndDate)
                    tempLessonList.Add(l);
            }
            ConfirmLessonForm confirmbox = new ConfirmLessonForm(tempLessonList);

            DialogResult result = confirmbox.ShowDialog();

            if(result == DialogResult.Yes)
                UpdateLessonsToCompleteList();
        }
    }
}

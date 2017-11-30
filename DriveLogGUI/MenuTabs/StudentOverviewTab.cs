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
        internal event SubPageNotification SubPageCreated;
        internal override event EventHandler IconPictureButtonClickEvent;
        private DateTime selectedMonth;
        private DateTime formatDateTime;

        // Pictures for overview buttons.
        private Bitmap incompleteImage = DriveLogGUI.Properties.Resources.crossIncomplete;
        private Bitmap incompleteHoverImage = DriveLogGUI.Properties.Resources.crossHover;
        private Bitmap completedImage = DriveLogGUI.Properties.Resources.checkCompleted;
        private Bitmap completedHoverImage = DriveLogGUI.Properties.Resources.checkHover;

        public StudentOverviewTab()
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
            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
            FirstCheckIfUploaded(firstAidPictureButton);

            foreach (Control control in progressBarPanel.Controls)
            {
                control.MouseClick += progressBarPanel_Click;

                foreach (Control childControl in control.Controls)
                    childControl.MouseClick += progressBarPanel_Click;
            }

            // Update icons
            if (Session.LoggedInUser.TheoreticalTestDone)
                theroraticalPictureButton.Image = completedImage;
            if (Session.LoggedInUser.PracticalTestDone)
                praticalTestPictureButton.Image = completedImage;
            if (Session.LoggedInUser.FeePaid)
                feePictureBox.Image = completedImage;

            foreach (Lesson lesson in Session.LoggedInUser.LessonsList)
            {
                if (lesson.LessonTemplate.Id == 1 && lesson.Completed)
                    maneuverTrackPictureButton.Image = completedImage;
                if (lesson.LessonTemplate.Id == 18 && lesson.Completed)
                    slippertTrackPictureButton.Image = completedImage;
            }

            UpdateProgress();
        }

        private void UpdateProgress()
        {
            theoreticalStatus.Text = Session.LoggedInUser.TheoreticalProgress + "/24";
            practicalStatus.Text = Session.LoggedInUser.PracticalProgress + "/14";

            theoreticalProgressFill.Size = new Size((theoreticalBar.Width / 24) * Session.LoggedInUser.TheoreticalProgress, theoreticalBar.Height);
            practicalProgressFill.Size = new Size((practicalBar.Width / 14) * Session.LoggedInUser.PracticalProgress, practicalBar.Height);
        }

        /*public void logoutButton_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.LogOutButtonClick != null)
                this.LogOutButtonClick(this, e);
        }*/

        private void doctorsNotePictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(doctorsNotePictureButton, e);
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
            foreach (Lesson lesson in Session.LessonsUser) //TODO Lookup after session class appointment is done
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

        private void doctorsNotePictureButton_Hover(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(doctorsNotePictureButton);
        }

        private void doctorsNotePictureButton_Leave(object sender, EventArgs e)
        {
            DoctorsNoteCheckIfUploaded(doctorsNotePictureButton);
        }

        private void ProgressButtonMouseEnter(PictureBox button)
        {
            if (button.Image == incompleteImage)
                button.Image = incompleteHoverImage;
            else if (button.Image == completedImage)
                button.Image = completedHoverImage;
        }

        private void DoctorsNoteCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistDoctorsNote(Session.LoggedInUser))
                button.Image = completedImage;
        }

        private void FirstCheckIfUploaded(PictureBox button)
        {
            if (DatabaseParser.ExistFirstAid(Session.LoggedInUser))
                button.Image = completedImage;
        }

        private void firstAidPictureButton_Enter(object sender, EventArgs e)
        {
            ProgressButtonMouseEnter(firstAidPictureButton);
        }

        private void firstAidPictureButton_Leave(object sender, EventArgs e)
        {
            FirstCheckIfUploaded(firstAidPictureButton);
        }

        private void progressBarPanel_Click(object sender, EventArgs e)
        {
            SubPageCreated?.Invoke(this);
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

        private void todaysNoteTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void todaysNoteLabel_Click(object sender, EventArgs e)
        {

        }

        private void firstAidPictureButton_Click(object sender, EventArgs e)
        {
            IconPictureButtonClickEvent?.Invoke(firstAidPictureButton, e);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public partial class OverviewTab : UserControl
    {
        public event EventHandler LogOutButtonClick;
        public event EventHandler DoctorsNotePictureButtonClick;

        private DateTime selectedMonth;
        private DateTime formatDateTime;
        public List<CalendarData> listOfDays = new List<CalendarData>();

        public OverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = "Welcome " + Session.LoggedInUser.Firstname;
            selectedMonth = DateTime.Now;

            DrawCalendar();

        }

        public void logoutButton_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.LogOutButtonClick != null)
                this.LogOutButtonClick(this, e);
        }

        private void doctorsNotePictureButton_Click(object sender, EventArgs e)
        {
            DoctorsNotePictureButtonClick?.Invoke(this, e);
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
                CalendarData calendarDay = new CalendarData(new Panel(), new Label(), formatDateTime);
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
            if (panelDate != DateTime.Today)
            {
                label.Cursor = Cursors.Hand;
                panel.BackColor = Color.FromArgb(229, 243, 255);
            }
        }

        private void LabelForDateMouseLeave(Panel panel, DateTime panelDate)
        {
            if (panelDate != DateTime.Today)
                panel.BackColor = Color.White;
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
    }
}

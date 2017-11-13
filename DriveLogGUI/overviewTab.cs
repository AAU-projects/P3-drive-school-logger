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
    public delegate DateTime OnDateClick(DateTime labelDate);

    public partial class OverviewTab : UserControl
    {
        public event EventHandler LogOutButtonClick;
        public event EventHandler DoctorsNotePictureButtonClick;
        public event EventHandler ClickOnDate;

        private DateTime selectedMonth;
        private DateTime formatDateTime;
        private List<CalendarData> listOfDays = new List<CalendarData>();

        public OverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = "Welcome " + Session.LoggedInUser.Firstname;
            selectedMonth = DateTime.Now;
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

        private void panel_Click(object sender, EventArgs e)
        {
            ClickOnDate?.Invoke(this, e);
        }

        private void daysForCalendar_Paint(object sender, PaintEventArgs e)
        {
            DrawCalendar();
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
                calendarDay.Panel.Click += new EventHandler(panel_Click);
                calendarDay.Label.MouseEnter += (s, e) => calendarDay.Label.Cursor = Cursors.Hand;

                listOfDays.Add(calendarDay);
                
                calendarDay.Panel.Width = widthForEachDay;
                calendarDay.Panel.Height = heightForEachDay;
                
                if (locationForRow == 336)
                {
                    locationForRow = 0;
                    locationForColumn += heightForEachDay;
                }

                calendarDay.Panel.Location = new Point(locationForRow, locationForColumn);
                locationForRow += widthForEachDay;

                FormatPanelForDays(calendarDay.Panel, calendarDay.Label, ref formatDateTime);
                daysForCalendar.Controls.Add(calendarDay.Panel);
            }
        }

        private void UpdateCalender()
        {
            foreach (CalendarData day in listOfDays)
            {
                Panel p = day.Panel;
                Label l = day.Label;
                FormatPanelForDays(p, l, ref formatDateTime);
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

        private void FormatPanelForDays(Panel panel, Label dayNumber, ref DateTime currentDateTime)
        {
            calendarMonth.Text = selectedMonth.ToString("MMMM").ToUpper();
            
            panel.BackColor = Color.FromArgb(251, 251, 251);
            dayNumber.ForeColor = Color.Black;
            dayNumber.Font = new Font(dayNumber.Font, FontStyle.Regular);
            dayNumber.Text = currentDateTime.Day.ToString();
            dayNumber.AutoSize = false;
            dayNumber.Dock = DockStyle.Fill;
            dayNumber.TextAlign = ContentAlignment.MiddleCenter;

            if (currentDateTime.Month != selectedMonth.Month)
            {
                dayNumber.ForeColor = Color.FromArgb(203, 203, 203);
            }
            else if (currentDateTime == DateTime.Today)
            {
                panel.BackColor = Color.FromArgb(148, 197, 204);
                dayNumber.ForeColor = Color.FromArgb(251, 251, 251);
                dayNumber.Font = new Font(dayNumber.Font, FontStyle.Bold);
            }

            panel.Controls.Add(dayNumber);
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

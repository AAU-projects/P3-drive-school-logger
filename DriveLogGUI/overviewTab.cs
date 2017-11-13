using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
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

        private void daysForCalendar_Paint(object sender, PaintEventArgs e)
        {
            DrawCalendar();
        }

        private void DrawCalendar()
        {
            int widthForEachDay = daysForCalendar.Width / 7;
            int heightForEachDay = daysForCalendar.Height / 5;

            DateTime currentDateTime = WhereDoWeStart();

            int locationForRow = 0;
            int locationForColumn = 0;

            for (var i = 0; i < 35; i++)
            {
                Panel day = new Panel();
                Label dayNumber = new Label();
                listOfDays.Add(new CalendarData(day, dayNumber));
                
                day.Width = widthForEachDay;
                day.Height = heightForEachDay;

                if (locationForRow == 336)
                {
                    locationForRow = 0;
                    locationForColumn += heightForEachDay;
                }

                day.Location = new Point(locationForRow, locationForColumn);
                locationForRow += widthForEachDay;

                FormatPanelForDays(ref day, ref dayNumber, ref currentDateTime);
                daysForCalendar.Controls.Add(day);
            }
        }

        private void UpdateCalender()
        {
            foreach (CalendarData day in listOfDays)
            {
                Panel p = day.Panel;
                Label l = day.Label;
                FormatPanelForDays(ref p, ref l, ref formatDateTime);
            }
        }

        private DateTime WhereDoWeStart()
        {
            DateTime date = selectedMonth;
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            date = startDate;

            int day = (int)date.DayOfWeek - 1;
            DateTime endDate = date.AddDays(-day);
            date = endDate;

            return date;
        }

        private void FormatPanelForDays(ref Panel panel, ref Label dayNumber, ref DateTime currentDateTime)
        {
            calendarMonth.Text = selectedMonth.ToString("MMMM").ToUpper();
            
            panel.BackColor = Color.FromArgb(251, 251, 251);
            dayNumber.Text = currentDateTime.Day.ToString();
            dayNumber.AutoSize = false;
            dayNumber.Dock = DockStyle.Fill;
            dayNumber.TextAlign = ContentAlignment.MiddleCenter;

            if (currentDateTime.Month != selectedMonth.Month)
            {
                dayNumber.ForeColor = Color.FromArgb(203, 203, 203);
            }
            else if (currentDateTime == DateTime.Now)
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

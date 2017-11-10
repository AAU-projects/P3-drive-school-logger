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

        public OverviewTab()
        {
            InitializeComponent();
            welcomeUserLabel.Text = "Welcome " + Session.LoggedInUser.Firstname;
            calendarMonth.Text = DateTime.Now.ToString("MMMM").ToUpper();
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
            int widthForEachDay = daysForCalendar.Width / 7;
            int heightForEachDay = daysForCalendar.Height / 5;

            DateTime currentDateTime = WhereDoWeStart();

            int locationForRow = 0;
            int locationForColumn = 0;

            for (var i = 0; i < 35; i++)
            {
                Panel day = new Panel();
                day.Width = widthForEachDay;
                day.Height = heightForEachDay;

                if (locationForRow == 336)
                {
                    locationForRow = 0;
                    locationForColumn += heightForEachDay;
                }

                day.Location = new Point(locationForRow, locationForColumn);
                locationForRow += widthForEachDay;

                FormatPanelForDays(ref day, ref currentDateTime);

                daysForCalendar.Controls.Add(day);
            }
        }

        private DateTime WhereDoWeStart()
        {
            DateTime date;

            date = DateTime.Now;
            DateTime startDate = new DateTime(date.Year, date.Month, 1);
            date = startDate;

            int day = (int)date.DayOfWeek - 1;
            DateTime endDate = date.AddDays(-day);
            date = endDate;

            return date;
        }

        private void FormatPanelForDays(ref Panel panel, ref DateTime currentDateTime)
        {
            panel.BackColor = Color.FromArgb(251, 251, 251);
            Label dayNumber = new Label();

            dayNumber.Text = currentDateTime.Day.ToString();
            dayNumber.AutoSize = false;
            dayNumber.Dock = DockStyle.Fill;
            dayNumber.TextAlign = ContentAlignment.MiddleCenter;

            panel.Controls.Add(dayNumber);
            currentDateTime = currentDateTime.AddDays(1);
        }
    }
}

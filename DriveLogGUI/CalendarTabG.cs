using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public partial class CalendarTabG : UserControl
    {
        private const int WEEKDAYS = 7;
        private DateTime dayNow;
        private DateTime lastWeek = DateTime.Now;
        private List<CalendarData> calendarData = new List<CalendarData>();
        private List<Appointment> appointments = new List<Appointment>();
        private MainWindowTab mainWindow;

        private OverviewTab overviewTab;

        Random test = new Random();

        public CalendarTabG(OverviewTab overviewTab, MainWindowTab mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.overviewTab = overviewTab;
            SubscribeToAllClickPanels(overviewTab.listOfDays);

            TestAppointments();
            SubscribeToAllClickAppointments(appointments);
        }

        private void SubscribeToAllClickAppointments(List<Appointment> appointments)
        {
            foreach (var appointment in appointments)
            {
                appointment.ClickOnAppointmentTriggered += UpdateInformation;
            }
        }

        private void UpdateInformation(object sender, ApppointmentEventArgs e)
        {
            informationLabel.Text = e.LabelAppointment.Text;
            dateInformationLabel.Text = e.Date;
            timeInformationLabel.Text = e.Time;
            contextInformationLabel.Text = e.Context;
            contextTitleInformationLabel.Text = e.LabelAppointment.Text;
            contextInformationLabel.Text = e.Context;
            instructorInformationLabel.Text = e.Instructor;

        }

        private void SubscribeToAllClickPanels(List<CalendarData> listOfDays)
        {
            foreach (var day in listOfDays)
            {
                day.ClickOnDateTriggered += OverviewTabOnClickOnDate;
            }
        }

        public void OverviewTabOnClickOnDate(object sender, DateClickEventArgs dateEvent)
        {
            this.mainWindow._lastPage = this;
            overviewTab.Hide();
            this.Show();
            UpdateCalendar(dateEvent.Date);
        }

        private void GenerateWeeklyCalendar()
        {
            //sets the first day to monday
            UpdateDateMonday();
            // width of each calendar, so there is space for 7 TODO something with 3 maybe 2
            int WidthOfWeeklyCalendar = (panelForCalendar.Width - 3) / WEEKDAYS;
            int locationOfCalendar = 0;

            for (var i = 0; i < WEEKDAYS; i++)
            {
                // generates each panel for dates
                Panel newDay = new Panel();
                newDay.Size = new Size(WidthOfWeeklyCalendar, panelForCalendar.Height);
                newDay.Location = new Point(locationOfCalendar, 0);
                newDay.BackColor = Color.White;
                locationOfCalendar += WidthOfWeeklyCalendar + 1;

                // generates label for each day
                GenerateDayLabel(ref newDay);

                //adds each panel to calendarPanel
                panelForCalendar.Controls.Add(newDay);

                //Updates calendar to current date, update calendar can be called with a int 1 for week forward and -1 for past week
                UpdateCalendar(0);
            }
            panelForCalendar.Controls.Add(backPanel);

        }

        private void GenerateDayLabel(ref Panel newDay)
        {
            Panel dayPanel = new Panel() { Size = new Size(newDay.Width, newDay.Height / 7), Location = new Point(0, 0) };

            Label dayNumber = new Label();
            dayNumber.Font = new Font(new FontFamily("Calibri Light"), 18f, FontStyle.Bold, dayNumber.Font.Unit);
            dayNumber.ForeColor = Color.FromArgb(128, 132, 144);
            dayNumber.Location = new Point(0, dayPanel.Height/2-dayNumber.Height);
            dayNumber.TextAlign = ContentAlignment.MiddleCenter;

            Label weekDay = new Label();
            weekDay.Font = new Font(new FontFamily("Calibri Light"), 10, FontStyle.Regular, weekDay.Font.Unit);
            weekDay.Location = new Point(0, dayPanel.Height/2);
            weekDay.ForeColor = Color.FromArgb(128, 132, 144);

            weekDay.TextAlign = ContentAlignment.MiddleCenter;

            dayPanel.Controls.Add(dayNumber);
            dayPanel.Controls.Add(weekDay);
            newDay.Controls.Add(dayPanel);

            calendarData.Add(new CalendarData(dayPanel, newDay, dayNumber, weekDay, dayNow));

        }

        private void panelForCalendar_Paint(object sender, PaintEventArgs e)
        {
            GenerateWeeklyCalendar();
            DrawLineBelowDates();  
        }

        private void DrawLineBelowDates()
        {
            //drawing a line below dates
            foreach (var data in calendarData) {
                var test = data.PanelForCalendarDay;
                using (Graphics g = test.CreateGraphics()) {
                    var p = new Pen(Color.FromArgb(128, 132, 144), 5);
                    g.DrawLine(p, test.Location.X + 15, test.Height - 10, test.Width - 15, test.Height - 10);
                }
            }
        }

        private string GetShortWeekday(string weekday)
        {
            switch (weekday.ToLower())
            {
                case "monday": return "mon";
                case "tuesday": return "tue";
                case "wednesday": return "wed";
                case "thursday": return "thu";
                case "friday": return "fri";
                case "saturday": return "sat";
                case "sunday": return "sun";
                default: return "error";

            }
        }



        private void UpdateCalendar(int weeks)
        {
            lastWeek = lastWeek.AddDays(weeks * 7);
            UpdateDates();
        }

        private void UpdateCalendar(DateTime day)
        {
            lastWeek = day;
            UpdateDateMonday();
            UpdateDates();
        }

        private void UpdateDates()
        {
            dayNow = lastWeek;
            datesInWeek.Text = GetDatesInWeek(dayNow);
            weekNumber.Text = GetWeekNumber(dayNow);

            foreach (var day in calendarData) 
            {
                day.LabelForDate.Text = dayNow.Day.ToString();
                day.LabelForWeekday.Text = GetShortWeekday(dayNow.DayOfWeek.ToString()).ToUpper();
                day.Date = dayNow;
                dayNow = dayNow.AddDays(1);
            }

            AddAllElements();
        }


        private void RemoveAllElements()
        {
            if (appointments != null)
            {
                foreach (var element in appointments)
                {
                    element.LabelAppointment.Hide();
                }
            }
        }

        private string GetDatesInWeek(DateTime now)
        {
            return $"{now.Day}  - {now.AddDays(6).Day} {now.ToString("MMMM")} {now.Year}";
        }

        private string GetWeekNumber(DateTime dateTime)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dateTime);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday) {
                dateTime = dateTime.AddDays(3);
            }

            int weekNumber =
                CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek,
                    DayOfWeek.Monday);
            return $"week {weekNumber}";
        }


        private void AddAppointment(DateTime fromDate, DateTime toDate, string text, Color color)
        {
            Label labelAppointment = new Label();
            labelAppointment.Text = text;
            labelAppointment.BackColor = color;
            labelAppointment.TextAlign = ContentAlignment.MiddleCenter;
            labelAppointment.Font = new Font(new FontFamily("Calibri Light"), 9f, FontStyle.Regular, labelAppointment.Font.Unit);

            //this is just for testing purp
            Appointment test = new Appointment(fromDate, toDate, labelAppointment);
            test.Instructor = "Karl";
            test.Context =
                "Had denoting properly jointure you occasion directly raillery. In said to of poor full be post face snug. Introduced imprudence see say unpleasing devonshire acceptance son. Exeter longer wisdom gay nor design age. Am weather to entered norland no in showing service. Nor repeated speaking shy appetite. Excited it hastily an pasture it observe. Snug hand how dare here too. ";


            appointments.Add(test);
        }

        private void AddAllElements()
        {
            RemoveAllElements();

            foreach (var day in calendarData)
            {
                int prevLocation = 0;

                foreach (var appointment in appointments)
                {
                    if (day.Date.ToShortDateString() == appointment.FromDate.ToShortDateString()) 
                    {
                        appointment.LabelAppointment.Show();
                        appointment.LabelAppointment.Location = new Point(0, day.PanelForCalendarDay.Height + prevLocation);
                        prevLocation += appointment.LabelAppointment.Height + 5;
                        day.BottomPanelForCalendar.Controls.Add(appointment.LabelAppointment);
                    }
                }
            }
        }

        private void UpdateDateMonday()
        {
            while (lastWeek.DayOfWeek.ToString().ToLower() != "monday") {
                lastWeek = lastWeek.AddDays(-1);
            }
        }

        private Color RandomColor()
        {
            int lol = test.Next(0, 5);
            if (lol == 0) {
                return Color.GreenYellow;
            } else if (lol == 1) {
                return Color.Aqua;
            } else if (lol == 2) {
                return Color.Red;
            } else if (lol == 3) {
                return Color.BurlyWood;
            } else if (lol == 4) {
                return Color.SlateBlue;
            } else if (lol == 5) {
                return Color.CadetBlue;
            }
            return Color.Aquamarine;
        }

        private void buttonLeftWeek_Click(object sender, EventArgs e)
        {
            UpdateCalendar(-1);
        }

        private void buttonRightWeek_Click(object sender, EventArgs e)
        {
            UpdateCalendar(1);
        }

        private void gotoTodayButton_Click(object sender, EventArgs e)
        {
            lastWeek = DateTime.Now;
            UpdateDateMonday();
            UpdateCalendar(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAppointment(DateTime.Now, DateTime.Now.AddHours(4), "fuck you", Color.Gold);
        }

        private void TestAppointments()
        {
            AddAppointment(DateTime.Now, DateTime.Now.AddHours(4), "fuck you", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), "fuck you", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), "fuck you", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "hmmmm", Color.Green);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "hmmmm", Color.Green);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "hmmmm", Color.Green);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "hmmmm", Color.Green);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "hmmmm", Color.Green);
            AddAppointment(DateTime.Now.AddDays(1), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(4), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(0), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "wildcard", RandomColor());
            AddAppointment(DateTime.Now.AddDays(4), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(4), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(4), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "goya", Color.OrangeRed);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "die", Color.Green);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "die", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "die", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "die", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(2), DateTime.Now.AddHours(4), "die", Color.Gold);
            AddAppointment(DateTime.Now.AddDays(-1), DateTime.Now.AddHours(4), "idk", Color.Red);
            AddAppointment(DateTime.Now.AddDays(-2), DateTime.Now.AddHours(4), "idk", Color.Red);
            AddAppointment(DateTime.Now.AddDays(5), DateTime.Now.AddHours(4), "idk", Color.Red);
            AddAppointment(DateTime.Now.AddDays(3), DateTime.Now.AddHours(4), "idk", Color.Red);
            AddAppointment(DateTime.Now.AddDays(6), DateTime.Now.AddHours(4), "idk", Color.Red);
        }
    }
}

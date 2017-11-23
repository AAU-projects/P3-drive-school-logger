using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DriveLogCode;

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

        private Color ColorRed = Color.FromArgb(229, 187, 191);
        private Color ColorBlue = Color.FromArgb(148, 197, 204);
        private Color ColorGreen = Color.FromArgb(175, 212, 167);
        private Color ColorYellow = Color.FromArgb(246, 228, 125);

        private OverviewTab overviewTab;

        Random test = new Random();

        public CalendarTabG(OverviewTab overviewTab, MainWindowTab mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.overviewTab = overviewTab;
            SubscribeToAllClickPanels(overviewTab.listOfDays);
            GetAppointsments();
            SubscribeToAllClickAppointments(appointments);

            if (Session.LoggedInUser.Sysmin)
                bookingInformationButton.Hide();
        }

        private void GetAppointsments()
        {
            foreach (var appointment in DatabaseParser.AppointmentsList())
            {
                AddAppointment(appointment);
            }
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
            informationLabel.Text = e.Appointment.LabelAppointment.Text;
            dateInformationLabel.Text = e.Date;
            timeInformationLabel.Text = e.Time;
            contextInformationTextbox.Text = e.Appointment.Context;
            contextTitleInformationLabel.Text = e.Appointment.LabelAppointment.Text;
            instructorInformationLabel.Text = e.Appointment.InstructorName;
            

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
            if (Session.LoggedInUser.Sysmin)
            {
                DrawAddAppointmentButtons();
            }
        }

        private void DrawAddAppointmentButtons()
        {
            //drawing buttons to add appointments
            foreach (var data in calendarData)
            {
                Button addAppointmentButton = new Button();
                addAppointmentButton.FlatStyle = FlatStyle.Flat;
                addAppointmentButton.BackgroundImage = Image.FromFile("Resources/addlessongrey.png");
                addAppointmentButton.Size = new Size(26, 26);
                addAppointmentButton.Location = new Point(data.BottomPanelForCalendar.Width/2 - 13, data.BottomPanelForCalendar.Height - 50);
                addAppointmentButton.FlatAppearance.BorderSize = 0;
                addAppointmentButton.Click += (s, e) => OpenAppointment(new DateClickEventArgs(data.Date));

                data.BottomPanelForCalendar.Controls.Add(addAppointmentButton);

            }
            
        }

        private void OpenAppointment(DateClickEventArgs e)
        {
            AddAppointmentWindow addAppointmentWindow = new AddAppointmentWindow(e.Date, MousePosition, appointments);
            addAppointmentWindow.ShowDialog();
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
            weekNumberLabel.Text = $"week {GetWeekNumber(dayNow)}";

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
            return $"{weekNumber}";
        }

        private DateTime GetDateFromWeek(int weekOfYear)
        {
            int year = lastWeek.Year;
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(daysOffset);
            var cal = CultureInfo.CurrentCulture.Calendar;
            int firstWeek = cal.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            var weekNum = weekOfYear;
            if (firstWeek <= 1) {
                weekNum -= 1;
            }
            var result = firstThursday.AddDays(weekNum * 7);
            return result.AddDays(-3);
        }


        private void AddAppointment(AppointmentStructure appointment)
        {
            Lesson progress = null;
            if (appointment.LessonType == "Practical")
            {
                progress = Session.LastPracticalLesson;
            }
            if (appointment.LessonType == "Theoretical") 
            {
                progress = Session.LastTheoraticalLesson;
            } 

            Appointment newAppointment = new Appointment(appointment, progress);

            newAppointment.LabelAppointment = GenerateLabel(appointment);
            newAppointment.UpdateLabel();
            newAppointment.SubscribeToEvent();
            appointments.Add(newAppointment);
        }

        private Label GenerateLabel(AppointmentStructure appointment)
        {
            Label newLabel = new Label();
            newLabel.Text = "no?";
            newLabel.BackColor = GetColorForLabel(appointment.LessonType);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            newLabel.Font = new Font(new FontFamily("Calibri Light"), 9f, FontStyle.Regular, newLabel.Font.Unit);

            return newLabel;
        }

        private Color GetColorForLabel(string appointmentLessonType)
        {
            if (appointmentLessonType.ToLower() == "theoretical")
            {
                return ColorBlue;
            }
            if (appointmentLessonType.ToLower() == "practical") {
                return ColorGreen;
            }
            if (appointmentLessonType.ToLower() == "manoeuvre") {
                return ColorYellow;
            }
            if (appointmentLessonType.ToLower() == "slippery") {
                return ColorYellow;
            }
            if (appointmentLessonType.ToLower() == "other") {
                return ColorYellow;
            }

            return ColorRed;

        }

        private void AddAllElements()
        {
            RemoveAllElements();

            foreach (var day in calendarData)
            {
                int prevLocation = 0;

                foreach (var appointment in appointments)
                {
                    if (day.Date.ToShortDateString() == appointment.ToTime.ToShortDateString()) 
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
            int lol = test.Next(0, 3);
            if (lol == 0) {
                return Color.FromArgb(255, 229, 187, 191);
            } else if (lol == 1) {
                return Color.FromArgb(255, 148, 197, 204);
            } else if (lol == 2) {
                return Color.FromArgb(255, 175, 212, 167);
            } else if (lol == 3) {
                return Color.FromArgb(255, 246, 228, 125);
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

        private void TestAppointments()
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void weekNumberTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            int weekNumber = Convert.ToInt32(weekNumberTextbox.Text);

            if (weekNumber <= 52)
            {
                UpdateCalendar(GetDateFromWeek(weekNumber));
            }
        }

        private void weekSelectButton_Click(object sender, EventArgs e)
        {
            if (!weekNumberTextbox.Visible)
            {
                weekNumberTextbox.Show();
                weekNumberTextbox.Text = GetWeekNumber(lastWeek);
                this.ActiveControl = weekNumberTextbox;
            }
            else
            {
                weekNumberTextbox.Hide();
            }
        }

        private void weekNumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }
    }
}

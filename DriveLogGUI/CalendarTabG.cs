﻿using System;
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
        private Appointment selectedAppointment;

        private MainWindowTab mainWindow;

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
            selectedAppointment = e.Appointment;
            informationLabel.Text = selectedAppointment.LabelAppointment.Text;
            dateInformationLabel.Text = selectedAppointment.Date;
            timeInformationLabel.Text = selectedAppointment.Time;
            contextInformationTextbox.Text = selectedAppointment.lessonTemplate.Description;
            contextTitleInformationLabel.Text = selectedAppointment.LabelAppointment.Text;
            instructorInformationLabel.Text = selectedAppointment.InstructorName;
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
                using (Graphics g = data.PanelForCalendarDay.CreateGraphics()) {
                    var p = new Pen(Color.FromArgb(128, 132, 144), 5);
                    g.DrawLine(p, data.PanelForCalendarDay.Location.X + 15, data.PanelForCalendarDay.Height - 10, data.PanelForCalendarDay.Width - 15, data.PanelForCalendarDay.Height - 10);
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
            Appointment newAppointment;
            Lesson progress = new Lesson("Your first theory lesson :)", "idk", 1, 1, DateTime.Now, false, new LessonTemplate());

            if (!Session.LoggedInUser.Sysmin)
            {
                // if no lessons user gets the first lesson :)
                if (appointment.LessonType == "Practical" && Session.LastPracticalLesson != null) {
                    progress = Session.LastPracticalLesson;
                } else if (appointment.LessonType == "Practical") {
                    progress = new Lesson("Your first driving lesson :)", "idk", 4, 1, DateTime.Now, false, new LessonTemplate());
                }

                if (appointment.LessonType == "Theoretical" && Session.LastTheoraticalLesson != null) {
                    progress = Session.LastTheoraticalLesson;
                } else if (appointment.LessonType == "Theoretical") {
                    progress = new Lesson("Your first theory lesson :)", "idk", 1, 1, DateTime.Now, false, new LessonTemplate());
                }


                newAppointment = new Appointment(appointment, progress);
            }
            else
            {
                newAppointment = new Appointment(appointment);
            }
            
            appointments.Add(newAppointment);
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


        private void weekNumberTextbox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            int weekNumber = Convert.ToInt32(weekNumberTextbox.Text);

            if (weekNumber <= 52)
            {
                UpdateCalendar(GetDateFromWeek(weekNumber));
                weekNumberTextbox.Hide();
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

        private void bookingInformationButton_Click(object sender, EventArgs e)
        {
            if (selectedAppointment.lessonTemplate.Type == "Practical")
            {
                
            }


            //TODO let a user select their own lesson if the user already have completed all lessons
            LessonTemplate lessonTemplate = DatabaseParser.GetNextLessonTemplateFromID(selectedAppointment.lessonTemplate.Id, selectedAppointment.LessonType);
            foreach (var appointment in appointments)
            {
                if (appointment.LessonType == selectedAppointment.LessonType)
                {
                    appointment.UpdateTemplate(lessonTemplate);
                }
            }
        }
    }
}

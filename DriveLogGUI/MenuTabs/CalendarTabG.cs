﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
 using System.Text;
 using System.Windows.Forms;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.CustomEventArgs;
using DriveLogGUI.Windows;

namespace DriveLogGUI.MenuTabs
{
    public partial class CalendarTabG : UserControl
    {
        private const int WEEKDAYS = 7;
        private DateTime dayNow;
        private DateTime lastWeek = DateTime.Now;
        private List<CalendarData> calendarData = new List<CalendarData>();
        private List<Appointment> appointments = new List<Appointment>();
        private Appointment selectedAppointment;
        private Appointment lastSelectedAppointment;

        private MainWindow mainWindow;
        private OverviewTab overviewTab;

        private string BookingText = "BOOK";
        private string CancelBookingText = "CANCEL BOOKING";
        private string UnavaiableBookingText = "UNAVAILABLE";

        public CalendarTabG(OverviewTab overviewTab, MainWindow mainWindow)
        {
            InitializeComponent();
            DrawCalendar();

            this.mainWindow = mainWindow;
            this.overviewTab = overviewTab;

            SubscribeToAllClickPanels(overviewTab.listOfDays);
            GetAppointsments();
           
            SubscribeToAllClickAppointments(appointments);

            if (Session.LoggedInUser.Sysmin)
                GetInstructorData();

            UpdateCalendar(0);
        }

        /// <summary>
        /// A method that should be used to change the programs calendar from a student calendar to instrucotr calendar. 
        /// </summary>
        private void GetInstructorData()
        {
            bookingInformationButton.Text = CancelBookingText;
            notAvailableDot.Image = Properties.Resources.bookableDot;
            notAvailableLabel.Text = "Bookable";
            NotAvaiableLabel.Text = "Fully booked";
            instructorTitleInformationLabel.Text = "Students attending";

            bookedDot.Hide();
            bookedDotLabel.Hide();
            completedDot.Hide();
            completedDotLabel.Hide();
            warningInformationTextbox.Size = new Size(141, 118);
            warningInformationTextbox.Location = new Point(13, 141);
            warningInformationTextbox.ScrollBars = ScrollBars.Vertical;

        }

        /// <summary>
        /// Draws the calendar and adds buttons for a instructor
        /// </summary>
        private void DrawCalendar()
        {
            GenerateWeeklyCalendar();

            if (Session.LoggedInUser.Sysmin) {
                DrawAddAppointmentButtons();
            }
        }

        /// <summary>
        /// Get all appointments from the database and adds it to the calendar
        /// </summary>
        private void GetAppointsments()
        {
            foreach (var appointment in DatabaseParser.AppointmentsList())
            {
                AddAppointment(appointment);
            }
        }

        /// <summary>
        /// Subscribes to all appointments that when clicked that it should call UpdateInformation Method
        /// </summary>
        /// <param name="appointments">Appointments that should be subscribed</param>
        private void SubscribeToAllClickAppointments(List<Appointment> appointments)
        {
            foreach (var appointment in appointments)
            {
                appointment.ClickOnAppointmentTriggered += UpdateInformation;
            }
        }

        /// <summary>
        /// An event that should be called to update data shown to a user in the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">An appointment event with all the data about the appointment</param>
        private void UpdateInformation(object sender, ApppointmentEventArgs e)
        {
            if (panelHideInfo.Visible)
            {
                panelHideInfo.Hide();
            }
            lastSelectedAppointment = selectedAppointment;
            selectedAppointment = e.Appointment;

            HighLightSelectedAppointment();

            informationLabel.Text = selectedAppointment.LabelAppointment.Text;
            dateInformationLabel.Text = selectedAppointment.DateFormat;
            timeInformationLabel.Text = selectedAppointment.TimeFormat;
            instructorInformationLabel.Text = selectedAppointment.InstructorName;
            warningInformationTextbox.Hide();
            warningTitleLabel.Hide();

            List<User> usersOnAppointment = DatabaseParser.GetUsersOnAppointmentID(selectedAppointment.Id);

            CheckIfUserCanBookLesson(usersOnAppointment);
            bookInformationLabel.Text = BookInformation(usersOnAppointment);
        }

        /// <summary>
        /// Highlights the selected appointment
        /// </summary>
        private void HighLightSelectedAppointment()
        {
            selectedAppointment.LabelAppointment.BackColor = Color.FromArgb(selectedAppointment.LabelAppointment.BackColor.A, Color.LightBlue);
            if (lastSelectedAppointment != null)
            {
                lastSelectedAppointment.LabelAppointment.BackColor = Color.FromArgb(lastSelectedAppointment.LabelAppointment.BackColor.A, ColorScheme.MainCalendarColor);
            }
        }

        /// <summary>
        /// Shows the correct number of avaiable bookings on the selected appointment
        /// </summary>
        /// <param name="usersOnAppointment">Requires a list of all the users that are on the appointment</param>
        /// <returns>Returns a string that can be displayed</returns>
        private string BookInformation(List<User> usersOnAppointment)
        {
            if (selectedAppointment.LessonType == LessonTypes.Theoretical)
            {
                return $"Booking status {usersOnAppointment.Count}/24";
            }
            if (selectedAppointment.LessonType == LessonTypes.Practical)
            {
                return $"Booking status {usersOnAppointment.Count}/1";
            }
            return $"Booking status {usersOnAppointment.Count}/8";

        }
        /// <summary>
        /// Checks if the user should be able to book the appointment and displays specific data for an instructor
        /// </summary>
        /// <param name="usersOnAppointment"></param>
        private void CheckIfUserCanBookLesson(List<User> usersOnAppointment)
        {
            if (Session.LoggedInUser.Sysmin)
            {
                ShowAttendingStudents(usersOnAppointment);
            }
            else if (selectedAppointment.ShowWarning)
            {
                ShowBookingWarrning(selectedAppointment.WarningText);
                if (selectedAppointment.BookedByUser)
                {
                    ShowBookingCancel();
                }
            }
            else
            {
                BookingAvailable();
            }
        }

        /// <summary>
        /// Generates a string that displays all the users that are given in the variable
        /// </summary>
        /// <param name="usersOnAppointment">List of users attending</param>
        private void ShowAttendingStudents(List<User> usersOnAppointment)
        {
            StringBuilder attendingString = new StringBuilder();

            foreach (var user in usersOnAppointment)
            {
                attendingString.AppendLine(user.Fullname);
            }

            ShowBookingWarrning(attendingString.ToString());
        }

        /// <summary>
        /// Change the button state to cancel
        /// </summary>
        private void ShowBookingCancel()
        {
            bookingInformationButton.Text = CancelBookingText;
        }

        /// <summary>
        /// Change the button state to available
        /// </summary>
        private void BookingAvailable()
        {
            bookingInformationButton.Text = BookingText;
        }
        /// <summary>
        /// When given a type of theoretical or practical the opposite type is given returned.
        /// </summary>
        /// <param name="type">Given type</param>
        /// <returns>Returns the oppsoite type</returns>
        private string GetReverseType(string type)
        {
            if (type == LessonTypes.Theoretical)
            {
                return LessonTypes.Practical.ToLower();
            }
            if (type == LessonTypes.Practical) 
            {
                return LessonTypes.Theoretical.ToLower();
            }
            return null;
        }

        /// <summary>
        /// Display a messeage to the user in the calendar
        /// </summary>
        /// <param name="errorMsg">Given messeage</param>
        private void ShowBookingWarrning(string errorMsg)
        {
            if (!Session.LoggedInUser.Sysmin)
                bookingInformationButton.Text = UnavaiableBookingText;
            warningInformationTextbox.Text = errorMsg;

            warningTitleLabel.Show();
            warningInformationTextbox.Show();
        }
        /// <summary>
        /// Subscribes to all the days given and when clicked they go to that date in the calendar
        /// </summary>
        /// <param name="listOfDays">A list of the days that should be subscribed to</param>
        private void SubscribeToAllClickPanels(List<CalendarData> listOfDays)
        {
            foreach (var day in listOfDays)
            {
                day.ClickOnDateTriggered += OverviewTabOnClickOnDate;
            }
        }

        /// <summary>
        /// An event that goes to the date in the calendar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="dateEvent">Requires a DateClickEventArgs with data for the date</param>
        public void OverviewTabOnClickOnDate(object sender, DateClickEventArgs dateEvent)
        {
            this.mainWindow.HighlightCurrentButton(mainWindow.bookingButton);
            this.mainWindow._lastPage = this;
            overviewTab.Hide();
            this.Show();
            UpdateCalendar(dateEvent.Date);
        }

        /// <summary>
        /// Generates the weekly calendar creating the panels needed for the GUI
        /// </summary>
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
            }

            //Updates calendar to current date, update calendar can be called with a int 1 for week forward and -1 for past week
            UpdateCalendar(0);

            panelForCalendar.Controls.Add(backPanel);

        }

        /// <summary>
        /// Generates the data for each day needed for the GUI
        /// </summary>
        /// <param name="newDay">The panel for a day that should hold all the data</param>
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

        /// <summary>
        /// Method used to draw buttons below each day that can be used to add an appointment
        /// </summary>
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

        /// <summary>
        /// Method used for to open an add appointment window 
        /// </summary>
        /// <param name="e">Data for the date is required</param>
        private void OpenAppointment(DateClickEventArgs e)
        {
            AddAppointmentWindow addAppointmentWindow = new AddAppointmentWindow(e.Date, MousePosition, appointments);
            addAppointmentWindow.ShowDialog();
            UpdateCalendar(0);
        }
        /// <summary>
        /// Draws a line below each day in a week
        /// </summary>
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

        /// <summary>
        /// When the calendar is painted a method for drawing lines is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelForCalendar_Paint(object sender, PaintEventArgs e)
        {
            DrawLineBelowDates();
        }
        /// <summary>
        /// A method used to transform a weekday into a shorter weekday
        /// </summary>
        /// <param name="weekday">Then given weekday</param>
        /// <returns>A shorter weekday</returns>
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

        /// <summary>
        /// Changes the calendar from the current week to a previous or forward week
        /// </summary>
        /// <param name="weeks">How many weeks the calendar should update previous or forward</param>
        private void UpdateCalendar(int weeks)
        {
            lastWeek = lastWeek.AddDays(weeks * 7);
            UpdateDates();
        }

        /// <summary>
        /// Changes the calendar to a specfic date 
        /// </summary>
        /// <param name="day">The specifc date</param>
        private void UpdateCalendar(DateTime day)
        {
            lastWeek = day;
            UpdateDateMonday();
            UpdateDates();
        }

        /// <summary>
        /// Updates all the dates in the calendar to the correct dates
        /// </summary>
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

                if (day.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    day.LabelForWeekday.BackColor = Color.FromArgb(100, ColorScheme.MainThemeColorLight);
                    day.LabelForDate.BackColor = Color.FromArgb(100, ColorScheme.MainThemeColorLight);
                }
                else
                {
                    day.LabelForWeekday.BackColor = Color.White;
                    day.LabelForDate.BackColor = Color.White;

                }

                dayNow = dayNow.AddDays(1);
            }

            if (Session.LoggedInUser.Active)
            {
                AddAllElements();
            }
        }


        /// <summary>
        /// Removes all the appointments that have been added to the calendar
        /// </summary>
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

        /// <summary>
        /// Deletes an appointment from all the appointments
        /// </summary>
        /// <param name="appointment"></param>
        private void DeleteAppointment(Appointment appointment)
        {
            appointment.LabelAppointment.Hide();
            appointments.Remove(appointments.Single(x => x.Id == appointment.Id));
        }

        /// <summary>
        /// Method used to display the current week that is shown
        /// </summary>
        /// <param name="now">The given datetime</param>
        /// <returns>Returns a string with the the current date and a week forward that can be displayed</returns>
        private string GetDatesInWeek(DateTime now)
        {
            return $"{now.Day}  - {now.AddDays(6).Day} {now.ToString("MMMM")} {now.Year}";
        }

        /// <summary>
        /// Method used to get a weeknumber from datetime
        /// </summary>
        /// <param name="dateTime">A datetime you want a weeknumber from</param>
        /// <returns>Returns the week number the datetime is in</returns>
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

        /// <summary>
        /// Method used to get a date from a weeknumber
        /// </summary>
        /// <param name="weekOfYear">Week number that have to be translated into a date</param>
        /// <returns>Returns a datetime</returns>
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

        /// <summary>
        /// Adds an appointment to all appoinments
        /// </summary>
        /// <param name="appointment">Appointment that should be added</param>
        private void AddAppointment(AppointmentStructure appointment)
        {
            Appointment newAppointment = new Appointment(appointment);
            appointments.Add(newAppointment);
        }

        /// <summary>
        /// Displays all appointments on the current dates in the week
        /// </summary>
        private void AddAllElements()
        {
            RemoveAllElements();

            foreach (var day in calendarData)
            {
                int prevLocation = 0;


                List<Appointment> appointmentsOnDay = appointments.Where(x => x.ToTime.ToShortDateString() == day.Date.ToShortDateString()).ToList();

                foreach (var appointment in appointmentsOnDay) {
                    appointment.LabelAppointment.Show();
                    appointment.LabelAppointment.Location = new Point(0, day.PanelForCalendarDay.Height + prevLocation);
                    prevLocation += appointment.LabelAppointment.Height + 5;
                    day.BottomPanelForCalendar.Controls.Add(appointment.LabelAppointment);

                    if (!Session.LoggedInUser.Sysmin)
                    {
                        AppointmentDataForUser(appointment);
                    }
                    else
                    {
                        AppointmentDataForInstructor(appointment);
                    }

                }
            }
        }

        /// <summary>
        /// Checks if an appointment should be expired
        /// </summary>
        /// <param name="appointment">Given appointment to check</param>
        /// <returns>Returns true if the appointment is expired</returns>
        private bool CheckIfAppointmentIsExpired(Appointment appointment)
        {
            if (DateTime.Now > appointment.ToTime)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Analyzes the apppointment data for an instructor
        /// </summary>
        /// <param name="appointment">Appointment data</param>
        private void AppointmentDataForInstructor(Appointment appointment)
        {
            bool appointmentInPreviousTime = CheckIfAppointmentIsExpired(appointment);

            if (appointment.FullyBooked)  // if the appointment is fullybooked
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarNoSlotsAvailable);
                appointment.ShowWarning = true;
                appointment.WarningText = "This appointment is fully booked";
            }
            else if (appointmentInPreviousTime)
            {
                appointment.LabelAppointmentUnavailable();
            }
            else
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarBookable);
                appointment.LabelAppointmentAvailable();
            }
        }

        /// <summary>
        ///  Analyzes the apppointment appointment data for a student
        /// </summary>
        /// <param name="appointment">Appointment data</param>
        private void AppointmentDataForUser(Appointment appointment)
        {
            bool appointmentBookedInPreviousTime = CheckForPreviousBookedLessons(appointment);
            bool appointmentInPreviousTime = CheckIfAppointmentIsExpired(appointment);


            if (appointment.FullyBooked)  // if the appointment is fullybooked
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarRed);
                appointment.ShowWarning = true;
                appointment.WarningText = "This appointment is fully booked";
            } else if (appointmentBookedInPreviousTime)
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarNoSlotsAvailable);
                appointment.ShowWarning = true;
                appointment.WarningText = "You can not book a lesson in a previous time than your lastly booked lesson";
            }
            else if (appointmentInPreviousTime)
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarNoSlotsAvailable);
                appointment.ShowWarning = true;
                appointment.WarningText = "You can not book a lesson in the past";
                appointment.LabelAppointmentUnavailable();
            }

            if (Session.LoggedInUser.LessonsList.Count == 0) // if 0 there is nothing to do for the user with highlights
            {
                if (appointment.LessonType != LessonTypes.Theoretical)
                {
                    appointment.AppointmentHighlight(Color.BlueViolet);
                    appointment.ShowWarning = true;
                    appointment.WarningText = "Please book theoretical lessons before booking a practical lesson";
                    appointment.LabelAppointmentUnavailable();
                }
                else
                {
                    appointment.LabelAppointmentAvailable();
                }
            } else if (appointment.bookedLessons.Find(x => x.Completed) != null) // if one lesson is completed assigned to that appointment
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarCompleted);
                appointment.ShowWarning = true;
                appointment.WarningText = "You have already completed your lessons on this appointment";
                appointment.LabelAppointmentUnavailable();
            } else if (appointment.bookedLessons.Find(x => x.UserID == Session.LoggedInUser.Id) != null) // if the user have booked the appointment
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarBooked);
                appointment.BookedByUser = true;
                appointment.ShowWarning = true;
                appointment.WarningText = "You already have a booking on this appointment";
            } else if (appointmentInPreviousTime) {
                appointment.AppointmentHighlight(ColorScheme.CalendarNoSlotsAvailable);
                appointment.ShowWarning = true;
                appointment.WarningText = "You can not book a lesson in the past";
                appointment.LabelAppointmentUnavailable();
            } else if (appointmentBookedInPreviousTime)
            {
                appointment.AppointmentHighlight(ColorScheme.CalendarNoSlotsAvailable);
                appointment.ShowWarning = true;
                appointment.WarningText = "You can not book a lesson in a previous time than your lastly booked lesson";
                appointment.LabelAppointmentUnavailable();
            } else if (Session.NextLesson.LessonTemplate.Type != appointment.LessonType)
            {
                appointment.AppointmentHighlight(Color.BlueViolet);
                appointment.ShowWarning = true;
                appointment.WarningText = $"You need to book more {GetReverseType(appointment.LessonType)} lessons before booking a {appointment.LessonType}";
                appointment.LabelAppointmentUnavailable();
            } else
            {
                appointment.LabelAppointmentAvailable();
                appointment.AppointmentHighlightHide();
                appointment.ShowWarning = false;
                appointment.WarningText = $"";
            }
        }

        /// <summary>
        /// Method used to check if a appointment have been booked in a preivous time of the appointment given
        /// </summary>
        /// <param name="appointment">Given appointment to check</param>
        /// <returns>Returns true the given appointment is in a previous time of the lastly booked appointment</returns>
        private bool CheckForPreviousBookedLessons(Appointment appointment)
        {
            if (appointment.ToTime <= Session.CurrentLesson.EndDate) // if the user is trying to book a lesson earlier than their lastly booked lesson
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Updates the calendar to show the first day as monday
        /// </summary>
        private void UpdateDateMonday()
        {
            while (lastWeek.DayOfWeek.ToString().ToLower() != "monday") {
                lastWeek = lastWeek.AddDays(-1);
            }
        }
        /// <summary>
        /// Method used to go a week backwrads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLeftWeek_Click(object sender, EventArgs e)
        {
            UpdateCalendar(-1);
        }

        /// <summary>
        /// Method used to go a week forward
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRightWeek_Click(object sender, EventArgs e)
        {
            UpdateCalendar(1);
        }

        /// <summary>
        /// Method used to go to the current todays date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gotoTodayButton_Click(object sender, EventArgs e)
        {
            lastWeek = DateTime.Now;
            UpdateDateMonday();
            UpdateCalendar(0);
        }

        /// <summary>
        /// Method used to go to a specific week 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Toogle for displaying the textbox for the user to go to a specific week
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Method used to vertificate that the user input is only numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void weekNumberTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
           if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Method used when the calendar button is clicked opening a window depending on the button text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bookingInformationButton_Click(object sender, EventArgs e)
        {
            if (bookingInformationButton.Text == BookingText)
            {
                BookAppointmentWindow bookingWindow = new BookAppointmentWindow(selectedAppointment, MousePosition);
                bookingWindow.ShowDialog();
                Session.GetProgress();
                UpdateCalendar(0);
            }
            else if (bookingInformationButton.Text == CancelBookingText)
            {
                if (Session.LoggedInUser.Sysmin)
                {
                    List<Lesson> cancelTheseLessons = new List<Lesson>();
                    List<Lesson> usersOnAppointment = DatabaseParser.GetUsersAndLessonsOnAppointmentID(selectedAppointment.Id);
                    foreach (Lesson lessonToCancel in usersOnAppointment)
                    {
                        cancelTheseLessons.AddRange(DatabaseParser.CancelLesson(lessonToCancel.TemplateID, lessonToCancel.Progress, lessonToCancel.UserID));
                    }
                    DialogResult result = CustomMsgBox.ShowYesNoInstructor("", "Cancel lesson", cancelTheseLessons, CustomMsgBoxIcon.Warrning);
                    if (result == DialogResult.Yes)
                    {
                        DatabaseParser.DeleteLessons(cancelTheseLessons);
                        DatabaseParser.DeleteAppointment(selectedAppointment.Id);
                        DeleteAppointment(selectedAppointment);
                        Session.LoggedInUser.GetLessonList();
                        Session.GetProgress();
                        UpdateCalendar(0);
                    }
                }
                else
                {
                    List<Lesson> cancelTheseLessons = DatabaseParser.CancelLesson(selectedAppointment.bookedLessons.First().TemplateID, selectedAppointment.bookedLessons.First().Progress, Session.LoggedInUser.Id);

                    DialogResult result = CustomMsgBox.ShowYesNo("", "Cancel lesson", cancelTheseLessons, CustomMsgBoxIcon.Warrning);
                    if (result == DialogResult.Yes)
                    {
                        DatabaseParser.DeleteLessons(cancelTheseLessons);
                        Session.LoggedInUser.GetLessonList();
                        Session.GetProgress();
                        UpdateCalendar(0);
                    }
                }
            }
        }
        /// <summary>
        /// Method used to help a user with the calendar, shows a window that gives a short summary of all functions.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InformationPictureBox_Click(object sender, EventArgs e)
        {
            CalendarInformationWindow informationWindow = new CalendarInformationWindow();
            informationWindow.ShowDialog();
        }
    }
}


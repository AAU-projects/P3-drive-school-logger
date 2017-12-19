using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;
using DriveLogCode.Objects;
using DriveLogGUI.CustomEventArgs;

namespace DriveLogGUI
{
    public class Appointment : AppointmentStructure
    {
        public event EventHandler<ApppointmentEventArgs> ClickOnAppointmentTriggered;
        public Label LabelAppointment;
        public Panel BookedPanelOnLabel;
        public List<Lesson> bookedLessons => Session.LoggedInUser.LessonsList.FindAll(x => x.AppointmentID == Id);
        public DateTime ToTime => StartTime.AddMinutes(AvailableTime * 45);
        public string TimeFormat => GetTime();
        public string DateFormat => GetDate();
        public bool BookedByUser;
        public bool ShowWarning;
        public string WarningText;

        public Appointment(AppointmentStructure appointmentStructure) : base(appointmentStructure)
        {
            GenerateLabel();

            if (Session.LoggedInUser.Sysmin)
            {
                InstructorLabelData();
            } else 
            {
                UserLabelData();
            }

            SubscribeToEvent();
        }

        /// <summary>
        /// Method used to display appointment label text for instructor
        /// </summary>
        private void InstructorLabelData()
        {
            LabelAppointment.Text = $"{InstructorName}\n{LessonType}\n{FromTimeToTime()}";
        }

        /// <summary>
        /// Genereates the labels used to display a appointment
        /// </summary>
        private void GenerateLabel()
        {
            LabelAppointment = new Label();
            LabelAppointment.Text = "no?";
            LabelAppointment.BackColor = GetColorForLabel(this.LessonType);
            LabelAppointment.TextAlign = ContentAlignment.MiddleCenter;
            LabelAppointment.Font = new Font(new FontFamily("Calibri Light"), 9f, FontStyle.Regular, LabelAppointment.Font.Unit);
            LabelAppointment.ForeColor = ColorScheme.MainFontColor;
            LabelAppointment.Size = new Size(LabelAppointment.Width, LabelAppointment.Height * 2);

            LabelAppointment.ForeColor = ColorScheme.CalendarRed;
            BookedPanelOnLabel = new Panel();
            BookedPanelOnLabel.Height = LabelAppointment.Height;
            BookedPanelOnLabel.Width = LabelAppointment.Width / 10;
            BookedPanelOnLabel.Location = new Point(0, 0);
            BookedPanelOnLabel.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(this));
            BookedPanelOnLabel.BackColor = ColorScheme.MainBackgroundColor;
            BookedPanelOnLabel.Hide();

            LabelAppointment.ForeColor = Color.Black;
            LabelAppointment.Controls.Add(BookedPanelOnLabel);
        }

        /// <summary>
        /// The color of the appointment depending on the type
        /// </summary>
        /// <param name="appointmentLessonType">Lesson type</param>
        /// <returns>Returns a color depending on the type</returns>
        private Color GetColorForLabel(string appointmentLessonType)
        {
            if (appointmentLessonType == LessonTypes.Theoretical) {
                return ColorScheme.MainCalendarColor;
            }
            if (appointmentLessonType == LessonTypes.Practical) {
                return ColorScheme.MainCalendarColor;
            }
            if (appointmentLessonType == LessonTypes.Manoeuvre) {
                return ColorScheme.MainCalendarColor;
            }
            if (appointmentLessonType == LessonTypes.Slippery) {
                return ColorScheme.MainCalendarColor;
            }
            if (appointmentLessonType == LessonTypes.Other) {
                return ColorScheme.MainCalendarColor;
            }

            return ColorScheme.CalendarRed;

        }

        /// <summary>
        /// Show a marker next to an appointment
        /// </summary>
        /// <param name="color"></param>
        public void AppointmentHighlight(Color color)
        {
            BookedPanelOnLabel.Show();
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, color);
        }

        /// <summary>
        /// Hide a marker next to an appointment
        /// </summary>
        public void AppointmentHighlightHide()
        {
            BookedPanelOnLabel.Hide();
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, Color.White);
        }

        /// <summary>
        /// Greys out a appointment
        /// </summary>
        public void LabelAppointmentUnavailable()
        {
            BookedPanelOnLabel.BackColor = Color.FromArgb(50, BookedPanelOnLabel.BackColor);
            LabelAppointment.BackColor = Color.FromArgb(100, ColorScheme.MainCalendarColor);
            LabelAppointment.ForeColor = Color.FromArgb(255, ColorScheme.MainFontColor);
        }

        /// <summary>
        /// Removes the effect of a greyed out appointment
        /// </summary>
        public void LabelAppointmentAvailable()
        {
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, BookedPanelOnLabel.BackColor);
            LabelAppointment.BackColor = ColorScheme.MainCalendarColor;
            LabelAppointment.ForeColor = Color.Black;
        }

        /// <summary>
        /// Method used to display appointment label text for a student
        /// </summary>
        public void UserLabelData()
        {
            LabelAppointment.Text = $"{LessonType}\n {FromTimeToTime()}";
        }

        /// <summary>
        /// Subscribes to events as mouse changes state when entering an appointment aswell as a click event to display data when clicked
        /// </summary>
        public void SubscribeToEvent()
        {
            LabelAppointment.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(this));
            LabelAppointment.MouseEnter += (s, e) => LabelAppointment.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Invoking all events when clicked if any is subscribed
        /// </summary>
        /// <param name="e"></param>
        private void label_Clicked(ApppointmentEventArgs e)
        {
            ClickOnAppointmentTriggered?.Invoke(this, e);
        }

        /// <summary>
        /// Method used to create a time string to display
        /// </summary>
        /// <returns>Returns a string that shows the time for the appointment</returns>
        private string GetTime()
        {
            return $"Time: {FromTimeToTime()}";
        }

        /// <summary>
        /// A method used to create a string with appointment start time to end time
        /// </summary>
        /// <returns>Returns a string with a from to time in the format 16:00 - 20:00</returns>
        public string FromTimeToTime()
        {
            return
                $"{AddZeroToDates(StartTime.Hour)}:{AddZeroToDates(StartTime.Minute)} - {AddZeroToDates(ToTime.Hour)}:{AddZeroToDates(ToTime.Minute)}";
        }

        /// <summary>
        /// Method used to create a date string to display
        /// </summary>
        /// <returns>Returns a string that shows the date for the appointment</returns>
        private string GetDate()
        {
            return $"Date: {DateShortFormat()}";
        }

        /// <summary>
        /// Method used to create a short date string
        /// </summary>
        /// <returns>Returns the end date in the format 12-24-2017</returns>
        public string DateShortFormat()
        {
            return $"{ToTime.ToShortDateString().Replace('/', '-')}";
        }

        /// <summary>
        /// Method used to make sure that the time format is correctly displayed
        /// </summary>
        /// <param name="checkString">A time string could be 9</param>
        /// <returns>Returns a string that is correclt formatted, if input is 9 it would return 09</returns>
        private string AddZeroToDates(int checkString)
        {
            string fixedString;

            if (checkString < 10) {
                fixedString = $"0{checkString}";
                return fixedString;
            }
            return checkString.ToString();
        }
    }
}

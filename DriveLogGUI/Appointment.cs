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
        private void InstructorLabelData()
        {
            LabelAppointment.Text = $"{InstructorName}\n{LessonType}\n{FromTimeToTime()}";
        }


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

        public void AppointmentHighlight(Color color)
        {
            BookedPanelOnLabel.Show();
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, color);
        }

        public void AppointmentHighlightHide()
        {
            BookedPanelOnLabel.Hide();
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, Color.White);
        }

        public void LabelAppointmentUnavailable()
        {
            BookedPanelOnLabel.BackColor = Color.FromArgb(50, BookedPanelOnLabel.BackColor);
            LabelAppointment.BackColor = Color.FromArgb(100, ColorScheme.MainCalendarColor);
            LabelAppointment.ForeColor = Color.FromArgb(255, ColorScheme.MainFontColor);
        }

        public void LabelAppointmentAvailable()
        {
            BookedPanelOnLabel.BackColor = Color.FromArgb(255, BookedPanelOnLabel.BackColor);
            LabelAppointment.BackColor = ColorScheme.MainCalendarColor;
            LabelAppointment.ForeColor = Color.Black;
        }

        public void UserLabelData()
        {
            LabelAppointment.Text = $"{LessonType}\n {FromTimeToTime()}";
        }

        public event EventHandler<ApppointmentEventArgs> ClickOnAppointmentTriggered;

        public void SubscribeToEvent()
        {
            LabelAppointment.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(this));
            LabelAppointment.MouseEnter += (s, e) => LabelAppointment.Cursor = Cursors.Hand;
        }

        private void label_Clicked(ApppointmentEventArgs e)
        {
            ClickOnAppointmentTriggered?.Invoke(this, e);
        }
        private string GetTime()
        {
            return $"Time: {FromTimeToTime()}";
        }

        public string FromTimeToTime()
        {
            return
                $"{AddZeroToDates(StartTime.Hour)}:{AddZeroToDates(StartTime.Minute)} - {AddZeroToDates(ToTime.Hour)}:{AddZeroToDates(ToTime.Minute)}";
        }

        private string GetDate()
        {
            return $"Date: {DateShortFormat()}";
        }

        public string DateShortFormat()
        {
            return $"{ToTime.ToShortDateString().Replace('/', '-')}";
        }
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

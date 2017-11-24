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
        public DateTime ToTime => StartTime.AddMinutes(AvailableTime * 45);
        public string TimeFormat => GetTime();
        public string DateFormat => GetDate();

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
            LabelAppointment.Text = InstructorName;
        }


        private void GenerateLabel()
        {
            LabelAppointment = new Label();
            LabelAppointment.Text = "no?";
            LabelAppointment.BackColor = GetColorForLabel(this.LessonType);
            LabelAppointment.TextAlign = ContentAlignment.MiddleCenter;
            LabelAppointment.Font = new Font(new FontFamily("Calibri Light"), 9f, FontStyle.Regular, LabelAppointment.Font.Unit);
        }

        private Color GetColorForLabel(string appointmentLessonType)
        {
            if (appointmentLessonType == LessonTypes.Theoretical) {
                return ColorScheme.CalendarBlue;
            }
            if (appointmentLessonType == LessonTypes.Practical) {
                return ColorScheme.CalendarGreen;
            }
            if (appointmentLessonType == LessonTypes.Manoeuvre) {
                return ColorScheme.CalendarYellow;
            }
            if (appointmentLessonType == LessonTypes.Slippery) {
                return ColorScheme.CalendarYellow;
            }
            if (appointmentLessonType == LessonTypes.Other) {
                return ColorScheme.CalendarYellow;
            }

            return ColorScheme.CalendarRed;

        }
        public void UserLabelData()
        {
            LabelAppointment.Text = LessonType;
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

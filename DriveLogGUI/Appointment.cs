using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    public class Appointment : AppointmentStructure
    {
        public Label LabelAppointment;
        public DateTime ToTime => GetToTime();
        public LessonTemplate lessonTemplate = new LessonTemplate();

        public Appointment(AppointmentStructure appointment, Lesson lesson)
        {
            this.Id = appointment.Id;
            this.InstructorID = appointment.InstructorID;
            this.StartTime = appointment.StartTime;
            this.AvailableTime = appointment.AvailableTime;
            this.LessonType = appointment.LessonType;
            this.FullyBooked = appointment.FullyBooked;
            this.InstructorName = appointment.InstructorName;
            this.lessonTemplate = GetLessonTemplate(lesson);

            GenerateLabel();
            UpdateLabel();
            SubscribeToEvent();
        }

        public Appointment(AppointmentStructure appointment)
        {
            this.Id = appointment.Id;
            this.InstructorID = appointment.InstructorID;
            this.StartTime = appointment.StartTime;
            this.AvailableTime = appointment.AvailableTime;
            this.LessonType = appointment.LessonType;
            this.FullyBooked = appointment.FullyBooked;
            this.InstructorName = appointment.InstructorName;

            GenerateLabel();
            InstructorData();
            SubscribeToEvent();
        }

        private void InstructorData()
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
            if (appointmentLessonType.ToLower() == "theoretical") {
                return ColorScheme.ColorBlue;
            }
            if (appointmentLessonType.ToLower() == "practical") {
                return ColorScheme.ColorGreen;
            }
            if (appointmentLessonType.ToLower() == "manoeuvre") {
                return ColorScheme.ColorYellow;
            }
            if (appointmentLessonType.ToLower() == "slippery") {
                return ColorScheme.ColorYellow;
            }
            if (appointmentLessonType.ToLower() == "other") {
                return ColorScheme.ColorYellow;
            }

            return ColorScheme.ColorRed;

        }
        public void UpdateLabel()
        {
            LabelAppointment.Text = lessonTemplate.Title;
        }

        private LessonTemplate GetLessonTemplate(Lesson lesson)
        {
            return DatabaseParser.GetLessonTemplateFromID(lesson.TemplateID);
        }

        private DateTime GetToTime()
        {
            return StartTime.AddMinutes(AvailableTime * 45);
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
    }
}

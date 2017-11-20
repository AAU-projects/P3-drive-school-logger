using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode;

namespace DriveLogGUI
{
    class Appointment : AppointmentStructure
    {
        public Label LabelAppointment;
        public string Title => GetTitle();
        public string Context => GetContext();
        public DateTime ToTime => GetToTime();
        private LessonTemplate lessonTemplate;

        public Appointment(int id, int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked)
            : base(id, instructorID, startTime, availableTime, lessonType, fullyBooked)
        {

        }

        public Appointment(AppointmentStructure appointment, Lesson lesson)
        {
            this.Id = appointment.Id;
            this.InstructorID = appointment.InstructorID;
            this.StartTime = appointment.StartTime;
            this.AvailableTime = appointment.AvailableTime;
            this.LessonType = appointment.LessonType;
            this.FullyBooked = appointment.FullyBooked;
            this.lessonTemplate = GetLessonTemplate(lesson);
        }

        public void UpdateLabel()
        {
            LabelAppointment.Text = Title;
        }

        private LessonTemplate GetLessonTemplate(Lesson lesson)
        {
            return DatabaseParser.GetLessonTemplateFromID(lesson.TemplateID);
        }

        private string GetContext()
        {
            return lessonTemplate.Description;
        }

        private DateTime GetToTime()
        {
            return StartTime.AddMinutes(AvailableTime * 45);
        }

        private string GetTitle()
        {
            return lessonTemplate.Title;
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

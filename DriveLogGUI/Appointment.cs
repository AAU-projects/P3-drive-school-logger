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

        public Appointment(int id, int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked)
            : base(id, instructorID, startTime, availableTime, lessonType, fullyBooked)
        {

        }

        public Appointment(AppointmentStructure appointment)
        {
            this.Id = appointment.Id;
            this.InstructorID = appointment.InstructorID;
            this.StartTime = appointment.StartTime;
            this.AvailableTime = appointment.AvailableTime;
            this.LessonType = appointment.LessonType;
            this.FullyBooked = appointment.FullyBooked;
        }

        private string GetContext()
        {
            throw new NotImplementedException();
        }

        private DateTime GetToTime()
        {
            return StartTime.AddMinutes(AvailableTime * 45);
        }

        private string GetTitle()
        {
            throw new NotImplementedException();
        }


        public event EventHandler<ApppointmentEventArgs> ClickOnAppointmentTriggered;

        public void SubscribeToEvent()
        {
            LabelAppointment.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(LabelAppointment, StartTime, ToTime, Instructor));
            LabelAppointment.MouseEnter += (s, e) => LabelAppointment.Cursor = Cursors.Hand;
        }

        private void label_Clicked(ApppointmentEventArgs e)
        {
            ClickOnAppointmentTriggered?.Invoke(this, e);
        }

 
    }
}

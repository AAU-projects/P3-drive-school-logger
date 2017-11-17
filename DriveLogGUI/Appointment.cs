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

        public DateTime ToTime => GetToTime();

        private DateTime GetToTime()
        {
            return StartTime.AddMinutes(AvailableTime * 45);
        }

        public event EventHandler<ApppointmentEventArgs> ClickOnAppointmentTriggered;

        public Appointment(int id, int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked) 
            : base(id, instructorID, startTime, availableTime, lessonType, fullyBooked)
        {
            
        }

        public void SubscribeToEvents()
        {
            LabelAppointment.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(LabelAppointment, StartTime, ToTime, Context, Instructor));
            LabelAppointment.MouseEnter += (s, e) => LabelAppointment.Cursor = Cursors.Hand;
        }

        private void label_Clicked(ApppointmentEventArgs e)
        {
            ClickOnAppointmentTriggered?.Invoke(this, e);
        }

 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    class Appointment
    {
        public Label LabelAppointment;
        public DateTime FromDate;
        public DateTime ToDate;
        public string Context;
        public string Instructor;

        public event EventHandler<ApppointmentEventArgs> ClickOnAppointmentTriggered;

        public Appointment(DateTime fromDate, DateTime toDate, Label labelAppointment)
        {
            FromDate = fromDate;
            ToDate = toDate;
            LabelAppointment = labelAppointment;

            SubscribeToEvents();
        }

        public Appointment(Label labelAppointment, DateTime fromDate, DateTime toDate, string context, string instructor)
        {
            LabelAppointment = labelAppointment;
            FromDate = fromDate;
            ToDate = toDate;
            Context = context;
            Instructor = instructor;

            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            LabelAppointment.Click += (s, e) => label_Clicked(new ApppointmentEventArgs(LabelAppointment, FromDate, ToDate, Context, Instructor));
            LabelAppointment.MouseEnter += (s, e) => LabelAppointment.Cursor = Cursors.Hand;
        }

        private void label_Clicked(ApppointmentEventArgs e)
        {
            ClickOnAppointmentTriggered?.Invoke(this, e);
        }
    }
}

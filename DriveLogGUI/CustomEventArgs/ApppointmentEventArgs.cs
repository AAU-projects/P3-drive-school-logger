namespace DriveLogGUI.CustomEventArgs
{
    public class ApppointmentEventArgs : System.EventArgs
    {
        public Appointment Appointment;

        public ApppointmentEventArgs(Appointment appointment)
        {
            this.Appointment = appointment;
        }
    }
}

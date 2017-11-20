using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    class ApppointmentEventArgs : EventArgs
    {
        public Appointment Appointment;
        private DateTime EndDate => GetEndDate();


        public string Time => GetTime();
        public string Date => GetDate();

        public ApppointmentEventArgs(Appointment appointment)
        {
            this.Appointment = appointment;
        }

        private string GetTime()
        {
            return $"Time: {AddZeroToDates(Appointment.StartTime.Hour)}:{AddZeroToDates(Appointment.StartTime.Minute)} - {AddZeroToDates(EndDate.Hour)}:{AddZeroToDates(EndDate.Minute)}";
        }

        private string GetDate()
        {
            return $"Date: {EndDate.ToShortDateString().Replace('/', '-')}";
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

        private DateTime GetEndDate()
        {
            return EndDate.AddMinutes(45 * Appointment.AvailableTime);
        }
    }
}

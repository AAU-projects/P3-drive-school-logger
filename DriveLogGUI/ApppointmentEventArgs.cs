using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    public class ApppointmentEventArgs : EventArgs
    {
        public Appointment Appointment;

        public ApppointmentEventArgs(Appointment appointment)
        {
            this.Appointment = appointment;
        }
    }
}

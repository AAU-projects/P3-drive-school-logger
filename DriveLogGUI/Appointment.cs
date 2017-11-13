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
        public DateTime date;
        public Label label;

        public Appointment(DateTime date, Label label)
        {
            this.date = date;
            this.label = label;
        }
    }
}

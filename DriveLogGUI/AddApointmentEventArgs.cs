using System;
using System.Drawing;
using System.Windows.Forms;

namespace DriveLogGUI
{
    class AddApointmentEventArgs
    {
        public DateTime Date;

        public AddApointmentEventArgs(DateTime date)
        {
            Date = date;
        }
    }
}

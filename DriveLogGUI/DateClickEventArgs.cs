using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogGUI
{
    public class DateClickEventArgs : EventArgs
    {
        public DateTime Date;

        public DateClickEventArgs(DateTime date)
        {
            Date = date;
        }
    }
}

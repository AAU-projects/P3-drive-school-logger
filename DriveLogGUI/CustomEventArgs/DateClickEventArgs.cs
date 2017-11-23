using System;

namespace DriveLogGUI.CustomEventArgs
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

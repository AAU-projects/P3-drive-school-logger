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
        public Label LabelAppointment;
        public DateTime FromDate;
        public DateTime ToDate;
        public string Context;

        public string Instructor;

        public string Time => GetTime();
        public string Date => GetDate();


        public ApppointmentEventArgs(Label labelAppointment, DateTime fromDate, DateTime toDate, string instructor)
        {
            LabelAppointment = labelAppointment;
            FromDate = fromDate;
            ToDate = toDate;
            Instructor = instructor;
        }

        private string GetTime()
        {
            return $"Time: {AddZeroToDates(FromDate.Hour)}:{AddZeroToDates(FromDate.Minute)} - {AddZeroToDates(ToDate.Hour)}:{AddZeroToDates(ToDate.Minute)}";
        }

        private string GetDate()
        {
            return $"Date: {FromDate.ToShortDateString().Replace('/', '-')}";
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

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{
    class CalendarData
    {
        public Panel TopPanelForCalendar;
        public Panel BottomPanelForCalendar;
        public Label LabelForDate;
        public Label LabelForWeekday;
        public DateTime date;

        public CalendarData(Panel topPanelForCalendar, Panel bottomPanelForCalendar, Label labelForDate,
            Label labelForWeekday, DateTime date)
        {
            TopPanelForCalendar = topPanelForCalendar;
            BottomPanelForCalendar = bottomPanelForCalendar;
            LabelForDate = labelForDate;
            LabelForWeekday = labelForWeekday;
            this.date = date;
        }
    }
}

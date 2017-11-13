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
        public Panel PanelForCalendarDay;
        public Panel BottomPanelForCalendar;
        public Label LabelForDate;
        public Label LabelForWeekday;
        public DateTime Date;

        public CalendarData(Panel topPanelForCalendar, Panel bottomPanelForCalendar, Label labelForDate,
            Label labelForWeekday, DateTime date)
        {
            PanelForCalendarDay = topPanelForCalendar;
            BottomPanelForCalendar = bottomPanelForCalendar;
            LabelForDate = labelForDate;
            LabelForWeekday = labelForWeekday;
            Date = date;
        }

        public CalendarData(Panel inputPanel, Label inputLabel, DateTime inputDate)
        {
            PanelForCalendarDay = inputPanel;
            LabelForDate = inputLabel;
            Date = inputDate;
        }
    }

}

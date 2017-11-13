using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DriveLogGUI
{

    public class CalendarData
    {
        public Panel PanelForCalendarDay;
        public Panel BottomPanelForCalendar;
        public Label LabelForDate;
        public Label LabelForWeekday;
        public DateTime Date;

        public event EventHandler<DateClickEventArgs> ClickOnDateTriggered;


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

            LabelForDate.Click += (s, e) => panel_Click(new DateClickEventArgs(Date));

        }

        private void panel_Click(DateClickEventArgs e)
        {
            ClickOnDateTriggered?.Invoke(this, e);
        }
    }

}

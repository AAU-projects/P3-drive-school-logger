using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DriveLogCode.Objects;
using DriveLogGUI.CustomEventArgs;

namespace DriveLogGUI
{

    public class CalendarData
    {
        public Panel PanelForCalendarDay;
        public Panel BottomPanelForCalendar;
        public Panel DayNotification;
        public Label LabelForDate;
        public Label LabelForWeekday;
        public DateTime Date;

        public Label LabelLessonInformation;
        public Label LabelLessonTitleAndPart;
        public Lesson Lesson;

        public event EventHandler<DateClickEventArgs> ClickOnDateTriggered;
        public event EventHandler<LessonClickEventArgs> ClickOnUpcomingLessonTriggered;

        /// <summary>
        /// A constructor used to storage some different controls
        /// </summary>
        /// <param name="topPanelForCalendar"></param>
        /// <param name="bottomPanelForCalendar"></param>
        /// <param name="labelForDate"></param>
        /// <param name="labelForWeekday"></param>
        /// <param name="date"></param>
        public CalendarData(Panel topPanelForCalendar, Panel bottomPanelForCalendar, Label labelForDate,
            Label labelForWeekday, DateTime date)
        {
            PanelForCalendarDay = topPanelForCalendar;
            BottomPanelForCalendar = bottomPanelForCalendar;
            LabelForDate = labelForDate;
            LabelForWeekday = labelForWeekday;
            Date = date;
        }

        /// <summary>
        /// A constructor used to storage some different controls
        /// </summary>
        /// <param name="topPanelForCalendar"></param>
        /// <param name="bottomPanelForCalendar"></param>
        /// <param name="labelForDate"></param>
        /// <param name="labelForWeekday"></param>
        /// <param name="date"></param>
        public CalendarData(Panel inputPanel, Label inputLabel, DateTime inputDate, Panel dayNotification)
        {
            PanelForCalendarDay = inputPanel;
            LabelForDate = inputLabel;
            Date = inputDate;
            DayNotification = dayNotification;
            inputPanel.Controls.Add(DayNotification);
            
            LabelForDate.Click += (s, e) => panel_Click(new DateClickEventArgs(Date));
        }

        /// <summary>
        /// A constructor used to storage some different controls
        /// </summary>
        /// <param name="topPanelForCalendar"></param>
        /// <param name="bottomPanelForCalendar"></param>
        /// <param name="labelForDate"></param>
        /// <param name="labelForWeekday"></param>
        /// <param name="date"></param>
        public CalendarData(Panel inputPanel, Label date, Label lessonInformation, Label lessonTitleAndPart, Lesson lesson)
        {
            PanelForCalendarDay = inputPanel;
            LabelForDate = date;
            LabelLessonInformation = lessonInformation;
            LabelLessonTitleAndPart = lessonTitleAndPart;
            Lesson = lesson;

            PanelForCalendarDay.Click += (s, e) => panelUpcomingLesson_click(new LessonClickEventArgs(lesson));
            LabelForDate.Click += (s, e) => panelUpcomingLesson_click(new LessonClickEventArgs(lesson));
            LabelLessonInformation.Click += (s, e) => panelUpcomingLesson_click(new LessonClickEventArgs(lesson));
            LabelLessonTitleAndPart.Click += (s, e) => panelUpcomingLesson_click(new LessonClickEventArgs(lesson));
        }


        private void panel_Click(DateClickEventArgs e)
        {
            ClickOnDateTriggered?.Invoke(this, e);
        }

        public void panelUpcomingLesson_click(LessonClickEventArgs e)
        {
            ClickOnUpcomingLessonTriggered?.Invoke(this, e);
        }
    }

}

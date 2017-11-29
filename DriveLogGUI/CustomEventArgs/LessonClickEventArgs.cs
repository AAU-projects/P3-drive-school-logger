using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveLogCode.Objects;

namespace DriveLogGUI.CustomEventArgs
{
    public class LessonClickEventArgs : EventArgs
    {
        public Lesson Lesson;

        public LessonClickEventArgs(Lesson lesson)
        {
            Lesson = lesson;
        }
    }
}


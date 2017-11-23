using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class LessonTemplate
    {
        public int Id { get; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Type { get; }

        public int Time { get; }

        public string Reading { get; }

        public LessonTemplate(int id, string title, string description, string type, int time, string reading)
        {
            Id = id;
            Title = title;
            Description = description;
            Type = type;
            Time = time;
            Reading = reading;
        }

        public LessonTemplate()
        {
            Id = 0;
            Title = null;
            Description = null;
            Type = null;
            Time = 0;
            Reading = null;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}

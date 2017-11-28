using System;
using System.Data;

namespace DriveLogCode.Objects
{
    public class Lesson
    {
        public string InstructorFirstname { get; }

        public string InstructorLastname { get; }

        public string InstructorSignaturePath { get; }

        public int TemplateID { get; set; }

        public int Progress { get; set; }

        public DateTime EndDate { get; }
        public DateTime StartDate { get; }

        public bool Completed { get; }

        public LessonTemplate LessonTemplate { get; set;}

        public string InstructorFullname => InstructorFirstname + " " + InstructorLastname;

        public Lesson(string instructorFirstname, string instructorLastname, int templateId, int progress, DateTime startDate, DateTime endDate, bool completed, LessonTemplate lessonTemplate, string instructorSignaturePath)
        {
            InstructorFirstname = instructorFirstname;
            InstructorLastname = instructorLastname;
            TemplateID = templateId;
            Progress = progress;
            StartDate = startDate;
            EndDate = endDate;
            Completed = completed;
            this.LessonTemplate = lessonTemplate;
            InstructorSignaturePath = instructorSignaturePath;
        }
    }
}

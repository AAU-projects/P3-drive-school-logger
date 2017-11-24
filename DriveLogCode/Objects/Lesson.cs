﻿using System;

namespace DriveLogCode.Objects
{
    public class Lesson
    {
        public string InstructorFirstname { get; }

        public string InstructorLastname { get; }

        public string InstructorSignaturePath { get; }

        public int TemplateID { get; }

        public int Progress { get; }

        public DateTime EndDate { get; }

        public bool Completed { get; }

        public LessonTemplate LessonTemplate { get; }

        public int StudentId { get; }

        public string InstructorFullname => InstructorFirstname + " " + InstructorLastname;

        public Lesson(string instructorFirstname, string instructorLastname, int templateId, int progress, DateTime endDate, bool completed,
            LessonTemplate lessonTemplate, string instructorSignaturePath, int studentId)
        {
            InstructorFirstname = instructorFirstname;
            InstructorLastname = instructorLastname;
            TemplateID = templateId;
            Progress = progress;
            EndDate = endDate;
            Completed = completed;
            this.LessonTemplate = lessonTemplate;
            InstructorSignaturePath = instructorSignaturePath;
            StudentId = studentId;
        }
    }
}

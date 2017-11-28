﻿using System;
using System.Data;

namespace DriveLogCode.Objects
{
    public class Lesson
    {
        public int Id { get; }
        public int UserID { get; }
        public string InstructorFirstname { get; }

        public string InstructorLastname { get; }

        public string InstructorSignaturePath { get; }
        public int AppointmentID { get; }
        public int TemplateID { get; set; }

        public int Progress { get; set; }

        public DateTime EndDate { get; }
        public DateTime StartDate { get; }

        public bool Completed { get; }

        public LessonTemplate LessonTemplate { get; set;}

        public int StudentId { get; }

        public string InstructorFullname => InstructorFirstname + " " + InstructorLastname;

        public Lesson(string instructorFirstname, string instructorLastname, int appointmentID, int templateId, int progress, DateTime startDate, DateTime endDate, bool completed, LessonTemplate lessonTemplate, string instructorSignaturePath, int studentId)
        {
            InstructorFirstname = instructorFirstname;
            InstructorLastname = instructorLastname;
            AppointmentID = appointmentID;
            TemplateID = templateId;
            Progress = progress;
            StartDate = startDate;
            EndDate = endDate;
            Completed = completed;
            this.LessonTemplate = lessonTemplate;
            InstructorSignaturePath = instructorSignaturePath;
            StudentId = studentId;
        }

        public Lesson(int id, int userid, int appointmentid, int lessonid, int lessonpart, DateTime startdate,
            DateTime enddate, bool completed)
        {
            this.Id = id;
            this.UserID = userid;
            this.AppointmentID = appointmentid;
            this.TemplateID = lessonid;
            this.Progress = lessonpart;
            this.StartDate = startdate;
            this.EndDate = enddate;
            this.Completed = completed;
        }

        public Lesson()
        {
            this.StartDate = DateTime.MinValue;;
        }
    }
}


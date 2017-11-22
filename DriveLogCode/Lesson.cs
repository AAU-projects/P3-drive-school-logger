﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class Lesson
    {
        public string InstructorFirstname { get; }

        public string InstructorLastname { get; }

        public int TemplateID { get; }

        public int Progress { get; }

        public DateTime EndDate { get; }

        public bool Completed { get; }

        public string InstructorFullname => InstructorFirstname + " " + InstructorLastname;

        public Lesson(string instructorFirstname, string instructorLastname, int templateId, int progress, DateTime endDate, bool completed)
        {
            InstructorFirstname = instructorFirstname;
            InstructorLastname = instructorLastname;
            TemplateID = templateId;
            Progress = progress;
            EndDate = endDate;
            Completed = completed;
        }
    }
}
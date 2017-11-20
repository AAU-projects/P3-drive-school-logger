using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public class AppointmentStructure
    {
        public int Id;
        public int InstructorID;
        public DateTime StartTime;
        public int AvailableTime;
        public string LessonType;
        public bool FullyBooked;

        public string Instructor => GetInstructorByID(InstructorID);


        private string GetInstructorByID(int instructorID)
        {
            //TODO :)
            return null;
        }

        public AppointmentStructure(int id, int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked)
        {
            Id = id;
            InstructorID = instructorID;
            StartTime = startTime;
            AvailableTime = availableTime;
            LessonType = lessonType;
            FullyBooked = fullyBooked;
        }

        public AppointmentStructure()
        {
        }
    }
}

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
        public string InstructorName;

        public AppointmentStructure(int id, int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked, string instructorName)
        {
            Id = id;
            InstructorID = instructorID;
            StartTime = startTime;
            AvailableTime = availableTime;
            LessonType = lessonType;
            FullyBooked = fullyBooked;
            InstructorName = instructorName;
        }

        public AppointmentStructure()
        {
        }
    }
}

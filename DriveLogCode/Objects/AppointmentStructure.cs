using System;

namespace DriveLogCode.Objects
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

        // Used to create appointments to show on the instructor profile.
        public AppointmentStructure(int instructorID, DateTime startTime, int availableTime, string lessonType, bool fullyBooked)
        {
            InstructorID = instructorID;
            StartTime = startTime;
            AvailableTime = availableTime;
            LessonType = lessonType;
            FullyBooked = fullyBooked;
        }

        public AppointmentStructure(AppointmentStructure appointmentStructure)
        {
            Id = appointmentStructure.Id;
            InstructorID = appointmentStructure.InstructorID;
            StartTime = appointmentStructure.StartTime;
            AvailableTime = appointmentStructure.AvailableTime;
            LessonType = appointmentStructure.LessonType;
            FullyBooked = appointmentStructure.FullyBooked;
            InstructorName = appointmentStructure.InstructorName;
        }
    }
}

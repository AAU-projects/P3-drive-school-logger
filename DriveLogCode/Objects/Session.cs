﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DriveLogCode.DataAccess;
using DriveLogCode.DesignSchemes;

namespace DriveLogCode.Objects
{
    public static class Session
    {
        public static User LoggedInUser;
        public static Dictionary<int, List<Lesson>> LessonsUserDictionary = new Dictionary<int, List<Lesson>>();
        public static List<Lesson> LessonsUser;
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static Lesson LastTheoraticalLesson;
        public static Lesson LastPracticalLesson;
        public static Lesson CurrentLesson;

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User(userTable);

            GetProgress();
        }

        public static void GetProgress()
        {
            LessonsUserDictionary.Clear();
            LessonsUser = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(LoggedInUser.Id);

            for (int i = 1; i < 10; i++)
            {
                List<Lesson> lessonAppointment = LessonsUser.Where(x => x.AppointmentID == i).ToList();

                if (LessonsUserDictionary.ContainsKey(i))
                {
                    
                    LessonsUserDictionary[i].AddRange(lessonAppointment);
                }
                LessonsUserDictionary.Add(i, lessonAppointment);
            }


            if (LessonsUser.Count != 0)
            {
                CurrentLesson = LessonsUser
                    .OrderByDescending(x => x.TemplateID)
                    .ThenByDescending(x => x.Progress)
                    .FirstOrDefault();

                try
                {
                    LastTheoraticalLesson = LessonsUser
                        .Where(x => x.LessonTemplate.Type == LessonTypes.Theoretical)
                        .OrderByDescending(x => x.TemplateID)
                        .ThenByDescending(x => x.Progress)
                        .First();
                }
                catch (Exception e)
                {
                    Console.WriteLine("No Theoretical lessons for user");
                }
                try
                {
                    LastPracticalLesson = LessonsUser
                        .Where(x => x.LessonTemplate.Type == LessonTypes.Practical)
                        .OrderByDescending(x => x.TemplateID)
                        .ThenByDescending(x => x.Progress)
                        .First();
                }
                catch (Exception e)
                {
                    Console.WriteLine("No practical lessons for user");
                }
            }

            if (CurrentLesson == null) // if the user have no current lessons he will be able to book any date
            {
                CurrentLesson = new Lesson();
            }
        }

        public static Lesson GetLastLessonFromType(string lessonType)
        {
            if (lessonType == "Practical")
            {
                return LastPracticalLesson;
            }
            if (lessonType == "Theoretical")
            {
                return LastTheoraticalLesson;
            }

            return null;
        }
    }
}


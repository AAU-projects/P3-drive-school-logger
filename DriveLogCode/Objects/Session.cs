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
        public static List<Lesson> LessonsUser;
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static Lesson LastTheoraticalLesson;
        public static Lesson LastPracticalLesson;
        public static Lesson CurrentLesson;

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User(userTable);

            GetLessonsFromDatabase();
            GetProgress();
        }

        public static void GetLessonsFromDatabase()
        {
            LessonsUser = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(LoggedInUser.Id);
        }

        public static void GetProgress()
        {
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


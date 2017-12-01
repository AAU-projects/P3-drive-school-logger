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
        public static List<LessonTemplate> LessonTemplates;
        public static List<Lesson> LessonsUser;
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static Lesson LastTheoraticalLesson;
        public static Lesson LastPracticalLesson;
        public static Lesson CurrentLesson;
        public static Lesson NextLesson => GetNextLesson();

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User(userTable);

            GetLessonsDataFromDatabase();
            GetLessonTemplateDataFromDatabase();
            GetProgress();
            GetNextLesson();

        }

        public static void GetLessonsDataFromDatabase()
        {
            LessonsUser = DatabaseParser.GetScheduledAndCompletedLessonsByUserIdList(LoggedInUser.Id);
        }

        public static void GetLessonTemplateDataFromDatabase()
        {
            LessonTemplates = DatabaseParser.GetTemplatesList();
        }

        private static Lesson GetNextLesson()
        {
            if (CurrentLesson.LessonTemplate != null)
            {
                int progress = CurrentLesson.Progress;
                int templateID = CurrentLesson.TemplateID;
                LessonTemplate lessonTemplate = CurrentLesson.LessonTemplate;

                if (CurrentLesson.Progress == CurrentLesson.LessonTemplate.Time) {
                    templateID += 1;
                    progress = 1;
                    lessonTemplate = LessonTemplates.Find(x => x.Id == templateID);

                } else {
                    progress += 1;
                }

                Lesson newLesson = new Lesson(CurrentLesson.UserID, 0, templateID, progress, lessonTemplate, CurrentLesson.StartDate, CurrentLesson.EndDate, false);

                return newLesson;
            }
            return new Lesson(CurrentLesson.UserID, 0, 2, 1, new LessonTemplate(), CurrentLesson.StartDate, CurrentLesson.EndDate, false);

        }

        public static void GetProgress()
        {
            if (LessonsUser.Count != 0)
            {
                UpdateCurrentLesson();

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

        public static void UpdateCurrentLesson()
        {
            CurrentLesson = LessonsUser
                .OrderByDescending(x => x.TemplateID)
                .ThenByDescending(x => x.Progress)
                .FirstOrDefault();
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


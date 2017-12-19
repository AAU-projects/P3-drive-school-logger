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
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static Lesson LastTheoraticalLesson;
        public static Lesson LastPracticalLesson;
        public static Lesson CurrentLesson;
        public static Lesson NextLesson => GetNextLesson();

        /// <summary>
        /// Loads an user from an User object.
        /// </summary>
        /// <param name="user">The User object to load.</param>
        public static void LoadUser(User user)
        {
            GetTemplateList();
            LoggedInUser = user;
            LoggedInUser.GetLessonList();

            if (LoggedInUser.Sysmin)
            {
               LoggedInUser.GetInstructorLessons();
            }
            else
            {
                LoggedInUser.CalculateProgress();
            }

            GetProgress();
        }

        /// <summary>
        /// Loads an user from a DataTable
        /// </summary>
        /// <param name="userTable">The DataTable to load a user from.</param>
        public static void LoadUserFromDataTable(DataTable userTable)
        {
            GetTemplateList();
            LoggedInUser = new User(userTable);
            LoggedInUser.GetLessonList();

            if (LoggedInUser.Sysmin)
            {
                LoggedInUser.GetInstructorLessons();
            }
            else
            {
                LoggedInUser.CalculateProgress();
            }

            GetProgress();

        }

        /// <summary>
        /// Gets the templatelist from the database
        /// </summary>
        private static void GetTemplateList()
        {
            LessonTemplates = DatabaseParser.GetTemplatesList();
        }

        /// <summary>
        /// Removes the data from the session
        /// </summary>
        public static void LogOut()
        {
            CurrentLesson = null;
            LastPracticalLesson = null;
            LastTheoraticalLesson = null;

        }

        /// <summary>
        /// Method used to get the next lesson for the logged in user
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method used to get the current lesson, last theoretical and last practical lesson for the logged in user
        /// </summary>
        public static void GetProgress()
        {
            if (LoggedInUser.LessonsList.Count != 0)
            {
                UpdateCurrentLesson();

                try
                {
                    LastTheoraticalLesson = LoggedInUser.LessonsList
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
                    LastPracticalLesson = LoggedInUser.LessonsList
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

        /// <summary>
        /// Updates the current lesson from the lessonlist
        /// </summary>
        public static void UpdateCurrentLesson()
        {
            CurrentLesson = LoggedInUser.LessonsList
                .OrderByDescending(x => x.TemplateID)
                .ThenByDescending(x => x.Progress)
                .FirstOrDefault();
        }

        /// <summary>
        /// Method used to get a the last lesson of a type
        /// </summary>
        /// <param name="lessonType">Lesson type</param>
        /// <returns>Returns a lesson matching the lesson type given</returns>
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


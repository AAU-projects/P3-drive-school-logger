﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
 using System.Linq;
 using System.Net;
using DriveLogCode.Exceptions;
using System.Net;
 using System.Text;
 using DriveLogCode.Exceptions;
using DriveLogCode.Objects;

namespace DriveLogCode.DataAccess
{
    public static class DatabaseParser
    {
        public static bool AddTodaysNote(User user, string todayNoteText)
        {
            return MySql.AddTodaysNote(user, todayNoteText);
        }

        public static bool UpdateUser(string cpr, string firstname, string lastname, string phone, string mail,
            string address,
            string zip, string city, string username, string password, string picture = null, string signature = "",
            string sysmin = "false")
        {
            return MySql.UpdateUser(cpr, firstname, lastname, phone, mail, address, zip, city, username, password,
                picture, signature, sysmin);
        }

        public static bool AddUser(string firstname, string lastname, string phone, string mail, string cpr,
            string address,
            string zip, string city, string username, string password, string picture = null, string signature = "",
            string sysmin = "false", string classname = "")
        {
            return MySql.AddUser(firstname, lastname, phone, mail, cpr, address, zip, city, username, password, picture,
                signature, sysmin, classname);
        }

        public static User GetUserByUsername(string username)
        {
            DataTable user = MySql.GetUserByName(username);

            return user == null ? null : new User(user);
        }

        public static void DeleteTemplate(int id)
        {
            MySql.DeleteTemplate(id);
        }

        public static bool UploadTemplate(string id, string title, string description, string type, string time,
            string reading)
        {
            return MySql.UploadLessonTemplate(id, title, description, type, time, reading);
        }

        /// <summary>
        /// Gets all lessons and associated instructor from database for userid param.
        /// </summary>
        /// <param name="userid">userid param</param>
        /// <returns></returns>
        public static List<Lesson> GetScheduledAndCompletedLessonsByUserIdList(int userid)
        {
            DataTable results = MySql.GetLessonsAndAttachedAppointmentByUserId(userid);
            List<Lesson> lessonsList = new List<Lesson>();

            foreach (DataRow row in results.Rows)
            {
                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[3]), (string)row[8], (string)row[9], (string)row[10], Convert.ToInt32(row[11]), (string)row[12]);
                lessonsList.Add(new Lesson((string)row[0], (string)row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), (DateTime)row[5], (DateTime)row[6], Convert.ToBoolean(row[7]), newTemplate, (string)row[13], userid));
            }

            return lessonsList;
        }

        public static List<Lesson> GetLessonsToCompleteList(User instructor)
        {
            DataTable results = MySql.GetLessonsToComplete(instructor.Id);
            List<Lesson> lessonsFoundList = new List<Lesson>();

            foreach (DataRow row in results.Rows)
            {
                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[0]), (string)row[6], (string)row[7], (string)row[8], Convert.ToInt32(row[9]), (string)row[10]);
                lessonsFoundList.Add(new Lesson(instructor.Firstname, instructor.Lastname, Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), (DateTime)row[3], (DateTime)row[4], Convert.ToBoolean(row[5]), newTemplate, instructor.SignaturePath, Convert.ToInt32(row[11])));
            }

            return lessonsFoundList;
        }

        public static bool SetLessonToComplete(int studentId, int appointmentId, int progress, bool status)
        {
            return MySql.SetLessonToComplete(studentId, appointmentId, progress, true);
        }

        public static bool DeleteLesson(int studentId, int appointmentId, int progress)
        {
            return MySql.DeleteLesson(studentId, appointmentId, progress);
        }

        public static bool DeleteLessons(List<Lesson> cancelTheseLessons)
        {
            StringBuilder idsToDelete = new StringBuilder();


            for (int i = 0; i < cancelTheseLessons.Count; i++)
            {
                if (i != cancelTheseLessons.Count - 1)
                {
                    idsToDelete.Append($"{cancelTheseLessons[i].Id}, ");
                }
                else
                {
                    idsToDelete.Append($"{cancelTheseLessons[i].Id}");
                }
            }

            return MySql.DeleteLessons(idsToDelete.ToString());
        }

        public static bool SetUserTheoreticalTestDone(int userid, bool value)
        {
            return MySql.UpdateUserEnum(userid, "theotestdone", value);
        }

        public static bool SetUserPracticalTestDone(int userid, bool value)
        {
            return MySql.UpdateUserEnum(userid, "practestdone", value);
        }

        public static bool SetUserFeePaid(int userid, bool value)
        {
            return MySql.UpdateUserEnum(userid, "feepaid", value);
        }

        public static bool SetUserActive(int userid, bool value)
        {
            return MySql.UpdateUserEnum(userid, "active", value);
        }

        public static User GetUserById(int userId)
        {
            return new User(MySql.GetUserByID(userId));
        }

        public static Dictionary<string, string> GetTemplate(string templateName)
        {
            DataTable lessonInfo = MySql.GetLessonData(templateName);

            return GetDict(lessonInfo);
        }

        public static bool AddLessonToUserID(Lesson lesson)
        {
            return MySql.AddLesson(lesson.UserID, lesson.AppointmentID, lesson.TemplateID, lesson.Progress,
                lesson.StartDate.ToString("G", CultureInfo.CreateSpecificCulture("zh-CN")),
                lesson.EndDate.ToString("G", CultureInfo.CreateSpecificCulture("zh-CN")), lesson.Completed);
        }

        public static User GetInstructorByID(int id)
        {
            DataTable result = MySql.GetInstructorByID(id);
            return new User(result);
        }

        private static Dictionary<string, string> GetDict(DataTable dt)
        {
            Dictionary<string, string> TempDict = new Dictionary<string, string>();

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn column in dt.Columns)
                {
                    TempDict.Add(column.ColumnName, row[column].ToString());
                }
            }

            return TempDict;
        }

        public static List<LessonTemplate> GetTemplatesList()
        {
            DataTable results = MySql.GetAllRows("lessonTemplates");
            List<LessonTemplate> templateslist = new List<LessonTemplate>();

            foreach (DataRow row in results.Rows)
            {
                templateslist.Add(new LessonTemplate(Convert.ToInt32(row[0]), (string)row[1], (string)row[2], (string)row[3], Convert.ToInt32(row[4]), (string)row[5]));
            }

            return templateslist;
        }

        public static List<string> GetLessonTemplates()
        {
            List<string> results = new List<string>();
            DataTable DatabaseResults = MySql.GetCreatedLessonNames();

            foreach (DataRow row in DatabaseResults.Rows)
            {
                results.Add((string) row[0]);
            }

            return results;
        }

        public static bool ExistDoctorsNote(User user)
        {
            return ExistDocument(user, Session.TypeDoctorsNote);
        }

        public static bool ExistFirstAid(User user)
        {
            return ExistDocument(user, Session.TypeFirstAid);
        }

        private static bool ExistDocument(User user, string type)
        {
            return MySql.ExistDocument(user.Id, type);
        }

        public static string GetDoctorsNote(User user)
        {
            return GetUserDocumentFromDatabase(user, Session.TypeDoctorsNote);
        }
        public static string GetFirstAid(User user)
        {
            return GetUserDocumentFromDatabase(user, Session.TypeFirstAid);
        }

        private static string GetUserDocumentFromDatabase(User user, string type)
        {
            try
            {
                DataTable fileInfo = MySql.GetDocument(type, user.Id);
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"{fileInfo.Rows[0][1].ToString().Replace(' ','-')}.pdf");

                using (var client = new WebClient())
                {
                    client.DownloadFile(fileInfo.Rows[0][5].ToString(), tempFilePath);
                }

                return tempFilePath;

            }
            catch (EmptyDataTableException)
            {
                return string.Empty;
            }
        }

        public static bool AddAppointment(string type, DateTime startTime, int availableTime, string instructor)
        {
            return MySql.AddAppointment(instructor, startTime.ToString("G",
                CultureInfo.CreateSpecificCulture("zh-CN")), availableTime, type);
        }

        public static List<AppointmentStructure> AppointmentsList()
        {
            List<AppointmentStructure> appointments = new List<AppointmentStructure>();
            DataTable queryInfo = MySql.GetAllAppointments();

            foreach (DataRow appointment in queryInfo.Rows)
            {
                string instructorName = $"{(string) appointment[6]} {(string) appointment[7]}";
                appointments.Add(new AppointmentStructure((int) appointment[0], (int) appointment[1], (DateTime) appointment[2], (int) appointment[3], (string) appointment[4], Convert.ToBoolean(appointment[5]), instructorName));
            }

            return appointments;
        }

        public static List<User> UserSearchList(string searchInput)
        {
            DataTable queryInfo = MySql.UserSearch(searchInput);
            List<User> usersFound = new List<User>();

            for (int i = 0; i < queryInfo.Rows.Count; i++)
            {
                usersFound.Add(new User(queryInfo, i));   
            }

            return usersFound;
        }

        public static int GetActiveUserCount()
        {
            return MySql.GetAllRows("users").Rows.Count;
        }

        public static int GetAppointmentsByInstructorIdCount(int instructorId)
        {
            DataTable results = MySql.GetAllAppointmentsByInstructorId(instructorId);
            int count = 0;

            foreach (DataRow resultsRow in results.Rows)
            {
                count += Convert.ToInt32(resultsRow[3]);
            }

            return count;
        }

        public static string GetLatestTodaysNote()
        {
            DataTable queryInfo = MySql.GetLatestTodaysNote();

            string todaysNote = (string) queryInfo.Rows[0][3];

            return todaysNote;
        }

        public static LessonTemplate GetLessonTemplateFromID(int lessonId)
        {
            DataTable DatabaseResults = MySql.GetLessonTemplateByID(lessonId);

            LessonTemplate lessonTemplate = new LessonTemplate(
                Convert.ToInt32(DatabaseResults.Rows[0][0]), 
                DatabaseResults.Rows[0][1].ToString(), 
                DatabaseResults.Rows[0][2].ToString(),
                DatabaseResults.Rows[0][3].ToString(), 
                Convert.ToInt32(DatabaseResults.Rows[0][4]), 
                DatabaseResults.Rows[0][5].ToString());

            return lessonTemplate;
        }

        public static LessonTemplate GetNextLessonTemplateFromID(int lessonTemplateId, string lessonType)
        {
            DataTable DatabaseResults = MySql.GetNextLessonTemplateByID(lessonTemplateId, lessonType);

            LessonTemplate lessonTemplate = new LessonTemplate(
                Convert.ToInt32(DatabaseResults.Rows[0][0]),
                DatabaseResults.Rows[0][1].ToString(),
                DatabaseResults.Rows[0][2].ToString(),
                DatabaseResults.Rows[0][3].ToString(),
                Convert.ToInt32(DatabaseResults.Rows[0][4]),
                DatabaseResults.Rows[0][5].ToString());

            return lessonTemplate;
        }

        public static List<User> GetUsersOnAppointmentID(int appointmentid)
        {
            DataTable queryInfo = MySql.GetUsersFromAppointmentID(appointmentid);
            List<User> usersOnAppointment = new List<User>();

            for (int i = 0; i < queryInfo.Rows.Count; i++)
            {
                usersOnAppointment.Add(new User(queryInfo, i));
            }

            return usersOnAppointment;
        }

        public static List<Lesson> GetAllLessonsFromAppointmentID(int id)
        {
            DataTable result = MySql.GetAllLessonsFromAppointmentID(id);

            List<Lesson> lessonsAppointment = new List<Lesson>();

            foreach (DataRow lesson in result.Rows)
            {
                lessonsAppointment.Add(new Lesson(
                    Convert.ToInt32(lesson[0]), 
                    Convert.ToInt32(lesson[1]), 
                    Convert.ToInt32(lesson[2]), 
                    Convert.ToInt32(lesson[3]), 
                    Convert.ToInt32(lesson[4]), 
                    (DateTime)lesson[5], 
                    (DateTime)lesson[6], 
                    Convert.ToBoolean(lesson[7])));
            }

            return lessonsAppointment;
        }

        public static List<Lesson> GetAllLessonsFromMultipleAppointmentIds(List<AppointmentStructure> appointments)
        {
            List<int> appointmentIDs = appointments.Select(a => a.Id).ToList();
            string appointmentIdString = string.Join(",", appointmentIDs);

            DataTable result = MySql.GetAllLessonsFromMultipleAppointmentIds(appointmentIdString);
            List<Lesson> InstructorLessons = new List<Lesson>();

            foreach (DataRow lesson in result.Rows)
            {
                LessonTemplate templateToAdd = Session.LessonTemplates.Find(x => Convert.ToInt32(lesson[3]) == x.Id);
                Lesson lessonToAdd = new Lesson(
                    Convert.ToInt32(lesson[0]),
                    Convert.ToInt32(lesson[1]),
                    Convert.ToInt32(lesson[2]),
                    Convert.ToInt32(lesson[3]),
                    Convert.ToInt32(lesson[4]),
                    templateToAdd,
                    Convert.ToDateTime(lesson[5]),
                    Convert.ToDateTime(lesson[6]),
                    Convert.ToBoolean(lesson[7])
                    );

                InstructorLessons.Add(lessonToAdd);
            }

            return InstructorLessons;
        }

        public static List<User> GetAllUsersFromMultipleUserIds(List<int> userIds)
        {
            List<User> locatedUsers = new List<User>();
            string userIdsString = string.Join(",", userIds);

            DataTable result = MySql.GetAllUsersFromMultipleUserIds(userIdsString);

            foreach (DataRow user in result.Rows)
            {
                User foundUser = new User(
                    Convert.ToInt32(user[0]),
                    Convert.ToString(user[1]),
                    Convert.ToString(user[2]),
                    Convert.ToString(user[3]),
                    Convert.ToString(user[4]),
                    Convert.ToString(user[5]),
                    Convert.ToString(user[6]),
                    Convert.ToString(user[7]),
                    Convert.ToString(user[8]),
                    Convert.ToString(user[9]),
                    Convert.ToString(user[10]),
                    Convert.ToString(user[11]),
                    Convert.ToString(user[12]),
                    Convert.ToBoolean(user[13]),
                    string.Empty,
                    Convert.ToBoolean(user[15]),
                    Convert.ToBoolean(user[16]),
                    Convert.ToBoolean(user[17]),
                    Convert.ToBoolean(user[18])
                );

                locatedUsers.Add(foundUser);
            }

            return locatedUsers;
        }

        public static List<AppointmentStructure> GetAppointmentsByInstructorId(int id)
        {
            DataTable result = MySql.GetAllAppointmentsByInstructorId(id);

            List<AppointmentStructure> instructorAppointments = new List<AppointmentStructure>();

            foreach (DataRow appointment in result.Rows)
            {
                AppointmentStructure appointmentToAdd = new AppointmentStructure(
                    Convert.ToInt32(appointment[0]),
                    Convert.ToInt32(appointment[1]),
                    Convert.ToDateTime(appointment[2]),
                    Convert.ToInt32(appointment[3]),
                    appointment[4].ToString(),
                    Convert.ToBoolean(appointment[5])
                    );

                instructorAppointments.Add(appointmentToAdd);
            }

            return instructorAppointments;
        }

        public static List<Lesson> CancelLesson(int templateID, int progressID, int userID)
        {
            List<Lesson> lessonsAppointment = new List<Lesson>();

            int lessonID = MySql.GetLessonIDFromUserIDProgressIDTemplateID(templateID, progressID, userID);

            DataTable result = MySql.GetAllLessonsAfterLessonID(lessonID, userID);

            foreach (DataRow row in result.Rows) {

                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[8]), (string) row[9], (string) row[10], (string) row[11], Convert.ToInt32(row[12]), (string) row[13] );

                lessonsAppointment.Add(new Lesson(
                    Convert.ToInt32(row[0]),
                    Convert.ToInt32(row[1]),
                    Convert.ToInt32(row[2]),
                    Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]),
                    newTemplate,
                    (DateTime)row[5],
                    (DateTime)row[6],
                    Convert.ToBoolean(row[7])));
            }

            return lessonsAppointment;
        }


    }
}


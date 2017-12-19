﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
 using System.Linq;
 using System.Net;
using DriveLogCode.Exceptions;
 using System.Text;
using DriveLogCode.Objects;

namespace DriveLogCode.DataAccess
{
    public static class DatabaseParser
    {

        private const string UserTable = "users";
        private const string DocumnentTable = "documents";
        private const string LessonTemplateTable = "lessonTemplates";
        private const string AppointmentTable = "appointments";
        private const string LessonTable = "lessons";
        private const string TodaysNoteTable = "todaysNoteTable";
        
        /// <summary>
        /// Update the note table with a new active note
        /// </summary>
        /// <param name="user">The User adding the note</param>
        /// <param name="todayNoteText">The note to be added</param>
        /// <param name="todaysNoteTable">Optional* Specify which table to update</param>
        /// <returns>boolean, wether the db executed the command or not</returns>
        public static bool AddTodaysNote(User user, string todayNoteText, string todaysNoteTable = TodaysNoteTable)
        {
            return MySql.AddTodaysNote(user, todayNoteText, todaysNoteTable);
        }

        /// <summary>
        /// Updates the user specified by cpr, all values are needed also for changes to a single value. 
        /// </summary>
        /// <param name="cpr">The users CPR number.</param>
        /// <param name="firstname">The users firstname</param>
        /// <param name="lastname">The users lastname</param>
        /// <param name="phone">The users phone</param>
        /// <param name="mail">The users mail</param>
        /// <param name="address">The users address</param>
        /// <param name="zip">The users zip code</param>
        /// <param name="city">The users city</param>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <param name="picture">The url to the users picture</param>
        /// <param name="signature">The url to the users signature</param>
        /// <param name="sysmin">wether the user is a sysmin or not</param>
        /// <param name="usertable">Optional* the table to change the user in</param>
        /// <returns>boolean, wether the db executed the command or not</returns>
        public static bool UpdateUser(string cpr, string firstname, string lastname, string phone, string mail,
            string address,
            string zip, string city, string username, string password, string picture = null, string signature = "",
            string sysmin = "false", string usertable = UserTable)
        {
            return MySql.UpdateUser(cpr, firstname, lastname, phone, mail, address, zip, city, username, password,
                picture, signature, sysmin, usertable);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="firstname">The users firstname</param>
        /// <param name="lastname">The users lastname</param>
        /// <param name="phone">The users phone</param>
        /// <param name="mail">The users mail</param>
        /// <param name="cpr">The users CPR number.</param>
        /// <param name="address">The users address</param>
        /// <param name="zip">The users zip code</param>
        /// <param name="city">The users city</param>
        /// <param name="username">The users username</param>
        /// <param name="password">The users password</param>
        /// <param name="picture">The url to the users picture</param>
        /// <param name="signature">The url to the users signature</param>
        /// <param name="sysmin">wether the user is a sysmin or not</param>
        /// <param name="classname">An optional class the user is enrolled in</param>
        /// <param name="usertable">Optional* the table to change the user in</param>
        /// <returns>boolean, wether the db executed the command or not</returns>
        public static bool AddUser(string firstname, string lastname, string phone, string mail, string cpr,
            string address,
            string zip, string city, string username, string password, string picture = null, string signature = "",
            string sysmin = "false", string classname = "", string usertable = UserTable)
        {
            return MySql.AddUser(firstname, lastname, phone, mail, cpr, address, zip, city, username, password, picture,
                signature, sysmin, classname, usertable);
        }

        /// <summary>
        /// Find a user from the username
        /// </summary>
        /// <param name="username">Username of the user to find</param>
        /// <param name="usertable">Optional* the table to look for the user in</param>
        /// <returns>The user found by the database</returns>
        public static User GetUserByUsername(string username, string usertable = UserTable)
        {
            DataTable user = MySql.GetUserByName(username, usertable);

            return user == null ? null : new User(user);
        }

        /// <summary>
        /// Delete a lesson template
        /// </summary>
        /// <param name="id">The id of the template to delete</param>
        /// <param name="lessonTable">Optional* the table to execute on</param>
        public static void DeleteTemplate(int id, string lessonTable = LessonTemplateTable)
        {
            MySql.DeleteTemplate(id, lessonTable);
        }

        /// <summary>
        /// update an exsiting lesson template in the database
        /// </summary>
        /// <param name="id">the id of the template to change</param>
        /// <param name="title">the template title</param>
        /// <param name="description">the template description</param>
        /// <param name="type">the template type</param>
        /// <param name="time">the template time requrement</param>
        /// <param name="reading">the templates needed reading</param>
        /// <param name="lessonTable">Optional* the table to execute on</param>
        /// <returns></returns>
        public static bool UploadTemplate(string id, string title, string description, string type, string time,
            string reading, string lessonTable = LessonTemplateTable)
        {
            return MySql.UploadLessonTemplate(id, title, description, type, time, reading, lessonTable);
        }

        /// <summary>
        /// Gets all lessons and associated instructor from database for userid param.
        /// </summary>
        /// <param name="userid">userid param</param>
        /// <returns>boolean, wether the db executed the command or not</returns>
        public static List<Lesson> GetScheduledAndCompletedLessonsByUserIdList(int userid, string lessonTable = LessonTable, string appointmentTable = AppointmentTable, string userTable = UserTable, string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable results = MySql.GetLessonsAndAttachedAppointmentByUserId(userid, lessonTable, appointmentTable, userTable, lessonTemplateTable);
            List<Lesson> lessonsList = new List<Lesson>();

            foreach (DataRow row in results.Rows)
            {
                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[3]), (string)row[8], (string)row[9], (string)row[10], Convert.ToInt32(row[11]), (string)row[12]);
                lessonsList.Add(new Lesson((string)row[0], (string)row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), Convert.ToInt32(row[4]), (DateTime)row[5], (DateTime)row[6], Convert.ToBoolean(row[7]), newTemplate, (string)row[13], userid));
            }

            return lessonsList;
        }

        /// <summary>
        /// Finds all lessons assosiated with a given instructor
        /// </summary>
        /// <param name="instructor">The instructor to find lessons for</param>
        /// <param name="lessonTable">Optional* the table in the db where lessons are stored</param>
        /// <param name="appointmentTable">Optional* the table in the db where appointments are stored</param>
        /// <param name="lessonTemplateTable">Optional* the table in the db where templates are stores</param>
        /// <returns>a list containing all lessons associated with the given instructor</returns>
        public static List<Lesson> GetLessonsToCompleteList(User instructor, string lessonTable = LessonTable, string appointmentTable = AppointmentTable, string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable results = MySql.GetLessonsToComplete(instructor.Id, lessonTable, appointmentTable, lessonTemplateTable);
            List<Lesson> lessonsFoundList = new List<Lesson>();

            foreach (DataRow row in results.Rows)
            {
                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[0]), (string)row[6], (string)row[7], (string)row[8], Convert.ToInt32(row[9]), (string)row[10]);
                lessonsFoundList.Add(new Lesson(instructor.Firstname, instructor.Lastname, Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), Convert.ToInt32(row[2]), (DateTime)row[3], (DateTime)row[4], Convert.ToBoolean(row[5]), newTemplate, instructor.SignaturePath, Convert.ToInt32(row[11])));
            }

            return lessonsFoundList;
        }

        /// <summary>
        /// Complete a lesson
        /// </summary>
        /// <param name="studentId">the id of the studen who completed</param>
        /// <param name="appointmentId">the appointment that was completed</param>
        /// <param name="progress">which part of the lesson that was completed</param>
        /// <param name="status">True/False</param>
        /// <param name="lessonTable">Optional* the table to execute on</param>
        /// <returns>bool</returns>
        public static bool SetLessonToStatus(int studentId, int appointmentId, int progress, bool status, string lessonTable = LessonTable)
        {
            return MySql.SetLessonToComplete(studentId, appointmentId, progress, status, lessonTable);
        }

        /// <summary>
        /// Delete a lesson
        /// </summary>
        /// <param name="studentId">the id of the student on the lesson</param>
        /// <param name="appointmentId">the appointment it belong too</param>
        /// <param name="progress">which part of the lesson to be deleted</param>
        /// <param name="lessonTable">Optional* the table to execute on</param>
        /// <returns>bool</returns>
        public static bool DeleteLesson(int studentId, int appointmentId, int progress, string lessonTable = LessonTable)
        {
            return MySql.DeleteLesson(studentId, appointmentId, progress, lessonTable);
        }

        /// <summary>
        /// Delete multiply lessons
        /// </summary>
        /// <param name="cancelTheseLessons">list of lessons to cancel</param>
        /// <param name="lessonTable">Optional* the table to execute on</param>
        /// <returns>bool</returns>
        public static bool DeleteLessons(List<Lesson> cancelTheseLessons, string lessonTable = LessonTable)
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

            return MySql.DeleteLessons(idsToDelete.ToString(), lessonTable);
        }

        /// <summary>
        /// set a users theoratical test to completed
        /// </summary>
        /// <param name="userid">the users id</param>
        /// <param name="value">completed or not</param>
        /// <param name="userTable">Optional* the table to execute on</param>
        /// <returns>bool</returns>
        public static bool SetUserTheoreticalTestDone(int userid, bool value, string userTable = UserTable)
        {
            return MySql.UpdateUserEnum(userid, "theotestdone", value, userTable);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid">the users id</param>
        /// <param name="value">completed or not</param>
        /// <param name="userTable">Optional* the table to execute on</param>
        /// <returns>bool</returns>
        public static bool SetUserPracticalTestDone(int userid, bool value, string userTable = UserTable)
        {
            return MySql.UpdateUserEnum(userid, "practestdone", value, userTable);
        }

        public static bool SetUserFeePaid(int userid, bool value, string userTable = UserTable)
        {
            return MySql.UpdateUserEnum(userid, "feepaid", value, userTable);
        }

        public static bool SetUserActive(int userid, bool value, string userTable = UserTable)
        {
            return MySql.UpdateUserEnum(userid, "active", value, userTable);
        }

        public static User GetUserById(int userId, string userTable = UserTable)
        {
            return new User(MySql.GetUserByID(userId, userTable));
        }

        public static Dictionary<string, string> GetTemplate(string templateName, string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable lessonInfo = MySql.GetLessonData(templateName, lessonTemplateTable);

            return GetDict(lessonInfo);
        }

        public static bool AddLessonToUserID(Lesson lesson, string lessonTable = LessonTable)
        {
            return MySql.AddLesson(lesson.UserID, lesson.AppointmentID, lesson.TemplateID, lesson.Progress,
                lesson.StartDate.ToString("G", CultureInfo.CreateSpecificCulture("zh-CN")),
                lesson.EndDate.ToString("G", CultureInfo.CreateSpecificCulture("zh-CN")), lesson.Completed, lessonTable);
        }

        public static User GetInstructorByID(int id, string userTable = UserTable)
        {
            DataTable result = MySql.GetInstructorByID(id, userTable);
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

        public static List<LessonTemplate> GetTemplatesList(string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable results = MySql.GetAllRows(lessonTemplateTable);
            List<LessonTemplate> templateslist = new List<LessonTemplate>();

            foreach (DataRow row in results.Rows)
            {
                templateslist.Add(new LessonTemplate(Convert.ToInt32(row[0]), (string)row[1], (string)row[2], (string)row[3], Convert.ToInt32(row[4]), (string)row[5]));
            }

            return templateslist;
        }

        public static List<string> GetLessonTemplates(string lessonTemplateTable = LessonTemplateTable)
        {
            List<string> results = new List<string>();
            DataTable DatabaseResults = MySql.GetCreatedLessonNames(lessonTemplateTable);

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

        private static bool ExistDocument(User user, string type, string documentTable = DocumnentTable)
        {
            return MySql.ExistDocument(user.Id, type, documentTable);
        }

        public static string GetDoctorsNote(User user)
        {
            return GetUserDocumentFromDatabase(user, Session.TypeDoctorsNote);
        }

        public static string GetFirstAid(User user)
        {
            return GetUserDocumentFromDatabase(user, Session.TypeFirstAid);
        }

        private static string GetUserDocumentFromDatabase(User user, string type, string documentTable = DocumnentTable)
        {
            try
            {
                DataTable fileInfo = MySql.GetDocument(type, user.Id, documentTable);
                string tempFilePath = Path.Combine(Path.GetTempPath(),
                    $"{fileInfo.Rows[0][1].ToString().Replace(' ', '-')}.pdf");

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
            catch (IndexOutOfRangeException)
            {
                return string.Empty;
            }
        }

        public static bool AddAppointment(string type, DateTime startTime, int availableTime, string instructor, string appointmentTable = AppointmentTable)
        {
            return MySql.AddAppointment(instructor, startTime.ToString("G",
                CultureInfo.CreateSpecificCulture("zh-CN")), availableTime, type, appointmentTable);
        }

        public static List<AppointmentStructure> AppointmentsList(string appointmentTable = AppointmentTable, string userTable = UserTable)
        {
            List<AppointmentStructure> appointments = new List<AppointmentStructure>();
            DataTable queryInfo = MySql.GetAllAppointments(appointmentTable, userTable);

            foreach (DataRow appointment in queryInfo.Rows)
            {
                string instructorName = $"{(string) appointment[6]} {(string) appointment[7]}";
                appointments.Add(new AppointmentStructure((int) appointment[0], (int) appointment[1], (DateTime) appointment[2], (int) appointment[3], (string) appointment[4], Convert.ToBoolean(appointment[5]), instructorName));
            }

            return appointments;
        }

        public static List<User> UserSearchList(string searchInput, string userTable = UserTable)
        {
            DataTable queryInfo = MySql.UserSearch(searchInput, userTable);
            List<User> usersFound = new List<User>();

            for (int i = 0; i < queryInfo.Rows.Count; i++)
            {
                usersFound.Add(new User(queryInfo, i));   
            }

            return usersFound;
        }

        public static int GetActiveUserCount(string userTable = UserTable)
        {
            return MySql.GetAllRows(userTable).Rows.Count;
        }

        public static int GetAppointmentsByInstructorIdCount(int instructorId, string appointmentTable = AppointmentTable)
        {
            DataTable results = MySql.GetAllAppointmentsByInstructorId(instructorId, appointmentTable);
            int count = 0;

            foreach (DataRow resultsRow in results.Rows)
            {
                count += Convert.ToInt32(resultsRow[3]);
            }

            return count;
        }

        public static string GetLatestTodaysNote(string todaysNoteTable = TodaysNoteTable)
        {
            DataTable queryInfo = MySql.GetLatestTodaysNote(todaysNoteTable);

            string todaysNote = (string) queryInfo.Rows[0][3];

            return todaysNote;
        }

        public static LessonTemplate GetLessonTemplateFromID(int lessonId, string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable DatabaseResults = MySql.GetLessonTemplateByID(lessonId, lessonTemplateTable);

            LessonTemplate lessonTemplate = new LessonTemplate(
                Convert.ToInt32(DatabaseResults.Rows[0][0]), 
                DatabaseResults.Rows[0][1].ToString(), 
                DatabaseResults.Rows[0][2].ToString(),
                DatabaseResults.Rows[0][3].ToString(), 
                Convert.ToInt32(DatabaseResults.Rows[0][4]), 
                DatabaseResults.Rows[0][5].ToString());

            return lessonTemplate;
        }

        public static LessonTemplate GetNextLessonTemplateFromID(int lessonTemplateId, string lessonType, string lessonTemplateTable = LessonTemplateTable)
        {
            DataTable DatabaseResults = MySql.GetNextLessonTemplateByID(lessonTemplateId, lessonType, lessonTemplateTable);

            LessonTemplate lessonTemplate = new LessonTemplate(
                Convert.ToInt32(DatabaseResults.Rows[0][0]),
                DatabaseResults.Rows[0][1].ToString(),
                DatabaseResults.Rows[0][2].ToString(),
                DatabaseResults.Rows[0][3].ToString(),
                Convert.ToInt32(DatabaseResults.Rows[0][4]),
                DatabaseResults.Rows[0][5].ToString());

            return lessonTemplate;
        }

        public static List<User> GetUsersOnAppointmentID(int appointmentid, string lessonTable = LessonTable, string userTable = UserTable)
        {
            DataTable queryInfo = MySql.GetUsersFromAppointmentID(appointmentid, lessonTable, userTable);
            List<User> usersOnAppointment = new List<User>();

            for (int i = 0; i < queryInfo.Rows.Count; i++)
            {
                usersOnAppointment.Add(new User(queryInfo, i));
            }

            return usersOnAppointment;
        }

        public static List<Lesson> GetUsersAndLessonsOnAppointmentID(int appointmentid, string lessonTable = LessonTable, string userTable = UserTable)
        {
            DataTable queryInfo = MySql.GetUsersAndLessonsFromAppointmentID(appointmentid, lessonTable, userTable);
            List<Lesson> firstLessonForUserOnAppointment = new List<Lesson>(); 

            foreach (DataRow result in queryInfo.Rows)
            {
                Lesson lessonToAdd = new Lesson();
                lessonToAdd.UserID = Convert.ToInt32(result[0]);
                lessonToAdd.TemplateID = Convert.ToInt32(result[1]);
                lessonToAdd.Progress = Convert.ToInt32(result[2]);
                firstLessonForUserOnAppointment.Add(lessonToAdd);
            }

            return firstLessonForUserOnAppointment;
        }

        public static bool DeleteAppointment(int appointmentId, string appointmentTable = AppointmentTable)
        {
            return MySql.DeleteAppointment(appointmentId, appointmentTable);
        }

        public static List<Lesson> GetAllLessonsFromAppointmentID(int id, string lessonTable = LessonTable)
        {
            DataTable result = MySql.GetAllLessonsFromAppointmentID(id, lessonTable);

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
            if (appointments.Count == 0) return new List<Lesson>();
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

        public static List<AppointmentStructure> GetAppointmentsByInstructorId(int id, string appointmentTable = AppointmentTable)
        {
            DataTable result = MySql.GetAllAppointmentsByInstructorId(id, appointmentTable);

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

        public static List<Lesson> CancelLesson(int templateID, int progressID, int userID, string lessonTable = LessonTable, string lessonTemplateTable = LessonTemplateTable)
        {
            List<Lesson> lessonsAppointment = new List<Lesson>();

            int lessonID = MySql.GetLessonIDFromUserIDProgressIDTemplateID(templateID, progressID, userID, lessonTable);

            DataTable result = MySql.GetAllLessonsAfterLessonID(lessonID, userID, lessonTable, lessonTemplateTable);

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


﻿using System;
using System.Data;
 using System.Runtime.CompilerServices;
 using DriveLogCode.Objects;
 using Microsoft.Build.Tasks;
 using MySql.Data.MySqlClient;

[assembly: InternalsVisibleTo("DriveLogTests")]

namespace DriveLogCode.DataAccess
{
    internal static class MySql
    {
        private const string ConnectionString = "server=ds315e17.duckdns.org;port=50000;uid=DriveLog;pwd=#SWe2017;database=DriveLog";
        private static readonly  MySqlConnection Connection = new MySqlConnection(ConnectionString);

        private const string UserTable = "users";
        private const string DocumnentTable = "documents";
        private const string LessonTemplateTable = "lessonTemplates";
        private const string AppointmentTable = "appointments";
        private const string LessonTable = "lessons";
        private const string TodaysNoteTable = "todaysNoteTable";

        /// <summary>
        /// Gets all instructors
        /// </summary>
        /// <param name="table">The user table which the query is send to</param>
        /// <returns>Returns all instructors found in a DataTable</returns>
        internal static DataTable GetAllInstrutors(string table = UserTable)
        {
            var cmd = new MySqlCommand($"SELECT firstname, lastname, phone, signature FROM {table} WHERE sysmin = 'True'");

            if (ExistTable(table)) return SendQuery(cmd);
            return CreateTemplateTable(table) ? SendQuery(cmd) : null;

        }

        /// <summary>
        /// Gets lessons and appointments belonging to a specific user
        /// </summary>
        /// <param name="userid">The user's id</param>
        /// <param name="LessonTable">The lesson table</param>
        /// <param name="AppointmentTable">The appointment table</param>
        /// <param name="UserTable">The user table</param>
        /// <param name="LessonTemplateTable">The lesson template table</param>
        /// <returns>Returns all lessons and appointments found in a DataTable</returns>
        internal static DataTable GetLessonsAndAttachedAppointmentByUserId(int userid, string LessonTable = LessonTable, string AppointmentTable = AppointmentTable, string UserTable = UserTable, string LessonTemplateTable = LessonTemplateTable)
        {
            var cmd = new MySqlCommand("SELECT " +
                $"{UserTable}.firstname AS InstructorFirstname, " +
                $"{UserTable}.lastname AS InstructorLastname, " +
                $"{LessonTable}.AppointmentID, " +
                $"{LessonTable}.LessonID AS TemplateID, " +
                $"{LessonTable}.LessonPart AS Progress, " +
                $"{LessonTable}.StartDate, " +
                $"{LessonTable}.EndDate, " +
                $"{LessonTable}.Completed, " +
                $"{LessonTemplateTable}.title, " +
                $"{LessonTemplateTable}.description, " +
                $"{LessonTemplateTable}.type, " +
                $"{LessonTemplateTable}.time, " +
                $"{LessonTemplateTable}.reading, " +
                $"{UserTable}.signature " +
                $"FROM {AppointmentTable}, {LessonTable}, {UserTable}, {LessonTemplateTable} " + 
                "WHERE " +
                $"{LessonTable}.AppointmentID = {AppointmentTable}.id AND " + 
                $"{LessonTable}.UserID = '{userid}' AND " +
                $"{UserTable}.user_id = {AppointmentTable}.instructorID AND " +
                $"{LessonTemplateTable}.id = {LessonTable}.LessonID " +
                $"ORDER BY {LessonTable}.id");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets students on an appointment from it's id
        /// </summary>
        /// <param name="appointmentid">The appointment id</param>
        /// <param name="lessonTable">The lesson table</param>
        /// <param name="userTable">The user table</param>
        /// <returns>Returns the student found in a DataTable</returns>
        internal static DataTable GetUsersFromAppointmentID(int appointmentid, string lessonTable = LessonTable, string userTable = UserTable)
        {
            var cmd = new MySqlCommand($"SELECT {userTable}.* " +
                                       $"FROM {lessonTable}, {userTable} " +
                                       $"WHERE " +
                                       $"{lessonTable}.AppointmentID = {appointmentid} " +
                                       $"AND " +
                                       $"{userTable}.user_id = {lessonTable}.UserID " +
                                       $"GROUP BY UserID");
            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets students and lessons on an appointment
        /// </summary>
        /// <param name="appointmentid">The appointment id</param>
        /// <param name="lessonTable">The lesson table</param>
        /// <param name="userTable">The user tble</param>
        /// <returns></returns>
        internal static DataTable GetUsersAndLessonsFromAppointmentID(int appointmentid, string lessonTable = LessonTable, string userTable = UserTable)
        {
            var cmd = new MySqlCommand($"SELECT {userTable}.user_id, min({lessonTable}.LessonID), min({lessonTable}.LessonPart) " +
                                       $"FROM {lessonTable}, {userTable} " +
                                       $"WHERE " +
                                       $"{lessonTable}.AppointmentID = {appointmentid} " +
                                       $"AND " +
                                       $"{userTable}.user_id = {lessonTable}.UserID " +
                                       $"GROUP BY UserID");
            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets lessons a speceffic instructor has to mark as completed.
        /// </summary>
        /// <param name="instructorId">The instructors id</param>
        /// <param name="LessonTable">The lesson table</param>
        /// <param name="AppointmentTable">The appointment table</param>
        /// <param name="LessonTemplateTable">The lesson template table</param>
        /// <returns>Returns all lessons found in a DataTable</returns>
        internal static DataTable GetLessonsToComplete(int instructorId, string LessonTable = LessonTable,
            string AppointmentTable = AppointmentTable, string LessonTemplateTable = LessonTemplateTable )
        {
            var cmd = new MySqlCommand("SELECT " +
                $"{LessonTable}.AppointmentID, " +
                $"{LessonTable}.LessonID AS TemplateID, " +
                $"{LessonTable}.LessonPart AS Progress, " +
                $"{LessonTable}.StartDate, " +
                $"{LessonTable}.EndDate, " +
                $"{LessonTable}.Completed, " +
                $"{LessonTemplateTable}.title, " +
                $"{LessonTemplateTable}.description, " +
                $"{LessonTemplateTable}.type, " +
                $"{LessonTemplateTable}.time, " +
                $"{LessonTemplateTable}.reading, " +
                $"{LessonTable}.UserID " +
                $"FROM {AppointmentTable}, {LessonTable}, {LessonTemplateTable} " +
                "WHERE " +
                $"{LessonTable}.AppointmentID = {AppointmentTable}.id AND " +
                $"{AppointmentTable}.instructorID = '{instructorId}' AND " +
                $"{LessonTemplateTable}.id = {LessonTable}.LessonID AND " +
                $"{LessonTable}.Completed = 'False' " +
                $"ORDER BY {LessonTable}.EndDate");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets a lesson by it's id
        /// </summary>
        /// <param name="id">The lesson id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the lesson found in a DataTable</returns>
        internal static DataTable GetLessonByID(int id, string table = LessonTable)
        {
            return GetFromDB("id", id.ToString(), table);
        }

        /// <summary>
        /// Gets an instructor by id
        /// </summary>
        /// <param name="id">The instructor id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the instructor found in a DataTable</returns>
        internal static DataTable GetInstructorByID(int id, string table = UserTable)
        {
            return GetFromDB("user_id", id.ToString(), table);
        }

        /// <summary>
        /// Gets a lesson template from the database by it's id
        /// </summary>
        /// <param name="id">The template's id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the template found in a DataTable</returns>
        internal static DataTable GetLessonTemplateByID(int lessonId, string table = LessonTemplateTable)
        {
            return GetFromDB("id", lessonId.ToString(), table);
        }

        /// <summary>
        /// Gets a lesson from the database by it's user's is
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the lesson found in a DataTable</returns>
        internal static DataTable GetLessonsByUser(int userID, string table = LessonTable)
        {
            return GetFromDB("userID", userID.ToString(), table);
        }

        /// <summary>
        /// Gets all lessons attatced to an appointment by a specific user
        /// </summary>
        /// <param name="userID">The user's id</param>
        /// <param name="appointmentID">The appointment id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns all lessons found in a DataTable</returns>
        internal static DataTable GetLessonsByUserAndAppointment(int userID, int appointmentID,
            string table = AppointmentTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM `{table}` WHERE `userID` = '{userID}' AND `appointmentID` = '{appointmentID}'");

            return ExistTable(table) ? SendQuery(cmd) : null;
        }

        /// <summary>
        /// Gets all appointments in the database and the fullname of it's instructor 
        /// </summary>
        /// <param name="appointmentTable">The appointment table</param>
        /// <param name="userTable">The user table</param>
        /// <returns>Returns all appointments found and their instructor's fullname in a DataTable</returns>
        internal static DataTable GetAllAppointments(string appointmentTable = AppointmentTable, string userTable = UserTable)
        {
            var cmd = new MySqlCommand("SELECT " +
                                       $"{appointmentTable}.id, " +
                                       $"{appointmentTable}.instructorID, " +
                                       $"{appointmentTable}.startTime, " +
                                       $"{appointmentTable}.availableTime, " +
                                       $"{appointmentTable}.lessonType, " +
                                       $"{appointmentTable}.fullyBooked, " +
                                       $"{userTable}.firstname, " +
                                       $"{userTable}.lastname " +
                                       $"FROM {AppointmentTable}, {userTable} " +
                                       "WHERE " +
                                       $"{userTable}.user_id = {AppointmentTable}.instructorID " +
                                       $"ORDER BY {appointmentTable}.startTime, {appointmentTable}.availableTime ");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets a specific user's lesson template's part
        /// </summary>
        /// <param name="templateId">The template id</param>
        /// <param name="progressId">The progress id</param>
        /// <param name="userId">The user' id</param>
        /// <param name="lessonTable">The lesson table</param>
        /// <returns>Returns the number of rows found in the DataTable</returns>
        internal static int GetLessonIDFromUserIDProgressIDTemplateID(int templateId, int progressId, int userId, string lessonTable = LessonTable)
        {
            var cmd = new MySqlCommand($"SELECT * " +
                                       $"FROM {lessonTable} " +
                                       $"WHERE " +
                                       $"{lessonTable}.UserID = {userId} " +
                                       $"AND " +
                                       $"{lessonTable}.LessonID = {templateId} " +
                                       $"AND " +
                                       $"{lessonTable}.LessonPart = {progressId}");

            DataTable results = SendQuery(cmd);

            return Convert.ToInt32(results.Rows[0][0]);    // Should always return 1 since the id's are unique
        }

        /// <summary>
        /// Gets all booked lessons after a specific booked lessons. 
        /// </summary>
        /// <param name="lessonId">The lesson id</param>
        /// <param name="userId">The user's id</param>
        /// <param name="lessonTable">The lesson table</param>
        /// <param name="lessonTemplateTable">The lesson template table</param>
        /// <returns>Returns all the lessons found in a DataTable</returns>
        internal static DataTable GetAllLessonsAfterLessonID(int lessonId, int userId, string lessonTable = LessonTable, string lessonTemplateTable = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"SELECT " +
                                       $"{lessonTable}.id, " +
                                       $"{lessonTable}.UserID, " +
                                       $"{lessonTable}.AppointmentID, " +
                                       $"{lessonTable}.LessonID, " +
                                       $"{lessonTable}.LessonPart, " +
                                       $"{lessonTable}.StartDate, " +
                                       $"{lessonTable}.EndDate, " +
                                       $"{lessonTable}.Completed, " +
                                       $"{lessonTemplateTable}.id AS idTemplate, " +
                                       $"{lessonTemplateTable}.title, " +
                                       $"{lessonTemplateTable}.description, " +
                                       $"{lessonTemplateTable}.type, " +
                                       $"{lessonTemplateTable}.time, " +
                                       $"{lessonTemplateTable}.reading, " +
                                       $"{lessonTemplateTable}.active " +
                                       $"FROM {lessonTable}, " +
                                       $"{lessonTemplateTable} " +
                                       $"WHERE {lessonTable}.UserID = {userId} " +
                                       $"AND {lessonTable}.id >= {lessonId} " +
                                       $"AND {lessonTable}.LessonID = {lessonTemplateTable}.id"); 

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets all appointments on one instructor by id
        /// </summary>
        /// <param name="instructorId">The instructor's id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns all appointments found in a DataTable</returns>
        internal static DataTable GetAllAppointmentsByInstructorId(int instructorId, string table = AppointmentTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE instructorID = {instructorId}");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets the next lesson by the current lessons template id
        /// </summary>
        /// <param name="lessonTemplateId">The template id</param>
        /// <param name="lessonType">The lesson type</param>
        /// <param name="lessonTemplateTable">The table the query is send to</param>
        /// <returns>Returns the lesson found in a DataTable</returns>
        internal static DataTable GetNextLessonTemplateByID(int lessonTemplateId, string lessonType, string lessonTemplateTable = LessonTemplateTable)
        {
            var cmd = new MySqlCommand("SELECT " +
                                       $"{lessonTemplateTable}.id, " +
                                       $"{lessonTemplateTable}.title, " +
                                       $"{lessonTemplateTable}.description, " +
                                       $"{lessonTemplateTable}.type, " +
                                       $"{lessonTemplateTable}.time, " +
                                       $"{lessonTemplateTable}.reading, " +
                                       $"{lessonTemplateTable}.active " +
                                       $"FROM {lessonTemplateTable} " +
                                       "WHERE " +
                                       $"{lessonTemplateTable}.id > {lessonTemplateId} AND " +
                                       $"{lessonTemplateTable}.type = '{lessonType}' " +
                                       $"ORDER BY {lessonTemplateTable}.id ");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets all lessons on a appointment
        /// </summary>
        /// <param name="id">The appointment id</param>
        /// <param name="lessonTable">The table the query is send to</param>
        /// <returns>Returns all lessons found in a DataTable</returns>
        internal static DataTable GetAllLessonsFromAppointmentID(int id, string lessonTable = LessonTable)
        {
            var cmd = new MySqlCommand($"SELECT * " +
                                       $"FROM {lessonTable} " +
                                       $"WHERE " +
                                       $"{lessonTable}.AppointmentID = {id}");
            return SendQuery(cmd);
        }

        /// <summary>
        /// Adds a lessons the the lesson table in the databse
        /// </summary>
        /// <param name="userId">The user id </param>
        /// <param name="appointmentID">The appointment id </param>
        /// <param name="templateID">The lesson template's id</param>
        /// <param name="part">The lesson part</param>
        /// <param name="startDate">The start time of the appointment</param>
        /// <param name="endDate">The end time of the appointment</param>
        /// <param name="completed">The completion satus of the appointment</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the lesson was added or not</returns>
        internal static bool AddLesson(int userId, int appointmentID, int templateID, int part, string startDate, string endDate, bool completed, string table = LessonTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO `{table}` (`userID`, `appointmentID`, `lessonID`, `lessonPart`, `StartDate`, `EndDate`, `Completed` )" +
                                       $"VALUES ('{userId}', '{appointmentID}', '{templateID}', '{part}', '{startDate}', '{endDate}', '{completed}')");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return CreateLessonTable(table) && SendNonQuery(cmd);
        }

        /// <summary>
        /// Gets an appointment by the indtructor's id
        /// </summary>
        /// <param name="instructorID">The indstructor's id</param>
        /// <param name="table">The table  the query is send to</param>
        /// <returns>Returns the appointment found in a DataTable</returns>
        internal static DataTable GetAppointmentsByInstuctor(int instructorID, string table = AppointmentTable)
        {
            return GetFromDB("instructorID", instructorID.ToString(), table);
        }

        /// <summary>
        /// Get an appointment by it's id
        /// </summary>
        /// <param name="id">The id of the appointment</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the appointment found in a DataTable</returns>
        internal static DataTable GetAppointmentByID(int id, string table = AppointmentTable)
        {
            return GetFromDB("id", id.ToString(), table);
        }

        /// <summary>
        /// Gets a value from a speciffic column in a given table
        /// </summary>
        /// <param name="column">The colum to get from</param>
        /// <param name="value">The value to look after</param>
        /// <param name="table">The table to look in and the table the query is send to</param>
        /// <returns>Returns the data found in a DataTable</returns>
        internal static DataTable GetFromDB(string column, string value, string table)
        {
            var cmd = new MySqlCommand($"SELECT * FROM `{table}` WHERE `{column}` = '{value}'");

            return ExistTable(table) ? SendQuery(cmd) : null;
        }

        /// <summary>
        /// Adds an appointment to the appointment table
        /// </summary>
        /// <param name="instructor">The instructor's id</param>
        /// <param name="startTime">The starttime of the appointment</param>
        /// <param name="availableTime">The number of lessons on the appointment</param>
        /// <param name="type">The type of the lessons</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns></returns>
        internal static bool AddAppointment(string instructor, string startTime, int availableTime, string type, string table = AppointmentTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO `{table}` (`instructorID`, `startTime`, `availableTime`, `lessonType`) " +
                                       $"VALUES ('{instructor}', '{startTime}', '{availableTime}', '{type}')");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return CreateAppointmentTable(table) && SendNonQuery(cmd);
        }

        /// <summary>
        /// Creates a table for lessons in the database
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table was created or not</returns>
        internal static bool CreateLessonTable(string tableName = LessonTable)
        {
            var cmd = new MySqlCommand($"CREATE TABLE `{tableName}` (" +
                                       $"`id`  int NOT NULL AUTO_INCREMENT ," +
                                       $"`UserID`  int NOT NULL ," +
                                       $"`AppointmentID`  int NOT NULL ," +
                                       $"`LessonID`  int NOT NULL ," +
                                       $"`LessonPart`  int NOT NULL ," +
                                       $"`StartDate`  datetime NULL DEFAULT NULL ," +
                                       $"`EndDate`  datetime NULL DEFAULT NULL ," +
                                       $"`Completed`  enum(\'True\',\'False\') NOT NULL DEFAULT \'False\' ," +
                                       $"PRIMARY KEY (`id`)" +
                                       $")" +
                                       $"ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Creates a table for appointments in the databse
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table was created or not</returns>
        private static bool CreateAppointmentTable(string tableName = AppointmentTable)
        {
            var cmd = new MySqlCommand($"CREATE TABLE `{tableName}` (" +
                                       $"`id`  int NOT NULL AUTO_INCREMENT ," +
                                       $"`instructorID`  int NOT NULL ," +
                                       $"`startTime`  datetime NOT NULL ," +
                                       $"`availableTime`  int NOT NULL ," +
                                       $"`lessonType`  enum(\'Theoretical\',\'Practical\',\'Manoeuvre\',\'Slippery\',\'Other\') NOT NULL ," +
                                       $"`fullyBooked`  enum(\'True\',\'False\') NOT NULL DEFAULT \'False\' ," +
                                       $"PRIMARY KEY (`id`)" +
                                       $")" +
                                       $"ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Deletes a lesson template from the database
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the template was deleted or not</returns>
        internal static bool DeleteTemplate(int id, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET active = 'False' WHERE id = {id}");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return false;
        }

        /// <summary>
        /// Gets all active lesson templates
        /// </summary>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the templates found in a DataTable</returns>
        internal static DataTable GetAllActiveLessonTemplates(string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"SELECT `title` FROM {table} WHERE active = 'True'");

            if (ExistTable(table)) return SendQuery(cmd);
            return CreateTemplateTable(table) ? SendQuery(cmd) : null;
        }

        /// <summary>
        /// Gets all rows in a table
        /// </summary>
        /// <param name="table">The name of the table</param>
        /// <returns>Returns all rows in a DataTable</returns>
        internal static DataTable GetAllRows(string table)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table}");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Get a lesson from the databse
        /// </summary>
        /// <param name="title">The lessons title</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the lesson data which were found in a DataTable</returns>
        internal static DataTable GetLessonData(string title, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE title = '{title}' LIMIT 1");

            if (ExistTable(table)) return SendQuery(cmd);
            return CreateTemplateTable(table) ? SendQuery(cmd) : null;
        }

        /// <summary>
        /// Updates an existing lesson template.
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="title">The template's title</param>
        /// <param name="description">The template's describtion</param>
        /// <param name="type">The type of the teplate</param>
        /// <param name="time">The amount of lessons the template involves</param>
        /// <param name="reading">The reading material</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the template was updated or not</returns>
        private static bool UpdateLessonTemplate(string id, string title, string description, string type, string time, string reading, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET title = '{title}', description = '{description}', type = '{type}', time = '{time}', reading = '{reading}' WHERE id = {id}");
            

            if (ExistTable(table)) return SendNonQuery(cmd);
            if (CreateTemplateTable(table)) return SendNonQuery(cmd);

            return false;
        }

        /// <summary>
        /// Sets the completion status of a lesson.
        /// </summary>
        /// <param name="studentId">The student's id</param>
        /// <param name="appointmentId">The appointment id</param>
        /// <param name="progress">The students progress</param>
        /// <param name="status">The status of the </param>
        /// <param name="table"></param>
        /// <returns>Returns a bool indicating whether the status was set or not</returns>
        internal static bool SetLessonToComplete(int studentId, int appointmentId, int progress, bool status, string table = LessonTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET Completed = '{status}' WHERE UserID = {studentId} AND AppointmentID = {appointmentId} AND LessonPart = {progress} LIMIT 1");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Deletes a lesson
        /// </summary>
        /// <param name="studentId">The students id </param>
        /// <param name="appointmentid">The appointment id</param>
        /// <param name="progress">The progress of the student</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the lesson was deleted or not</returns>
        internal static bool DeleteLesson(int studentId, int appointmentid, int progress, string table = LessonTable)
        {
            var cmd = new MySqlCommand($"DELETE FROM {table} WHERE UserID = {studentId} AND AppointmentID = {appointmentid} AND LessonPart = {progress} LIMIT 1");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Deletes lessons from the database
        /// </summary>
        /// <param name="idsToDelete">The id of the lessons to be deleted seperated by ","</param>
        /// <param name="lessonTable">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the lessons were deleted or not</returns>
        internal static bool DeleteLessons(string idsToDelete, string lessonTable = LessonTable)
        {
            var cmd = new MySqlCommand($"DELETE from {lessonTable} " +
                                       $"WHERE id IN ({idsToDelete})");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Uploades a lesson template
        /// </summary>
        /// <param name="id">The id of the template</param>
        /// <param name="title">The title of the template</param>
        /// <param name="description">The description of the template</param>
        /// <param name="type">The type of the template</param>
        /// <param name="time">The amout of lessons</param>
        /// <param name="reading">The reading material</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the template was uploaded or not</returns>
        internal static bool UploadLessonTemplate(string id, string title, string description, string type, string time, string reading, string table = LessonTemplateTable)
        {
           var cmd = new MySqlCommand($"INSERT INTO {table} (title, description, type, time, reading) VALUES ('{title}', '{description}', '{type}', '{time}', '{reading}')");

            if (ExistTable(table))
            {
                if (id != null && Exist("id", id, LessonTemplateTable)) return UpdateLessonTemplate(id, title, description, type, time, reading, table);
                return SendNonQuery(cmd);
            }
            if (CreateTemplateTable(table)) return SendNonQuery(cmd);

            return false;
        }

        /// <summary>
        /// Creates a table in the database to hold lesson templates
        /// </summary>
        /// <param name="table">The table name</param>
        /// <returns>Returns a bool indicating whether the table was created or not</returns>
        private static bool CreateTemplateTable(string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"CREATE TABLE `{table}` (" +
                                       $"`id`  int(11) NOT NULL AUTO_INCREMENT ," +
                                       $"`title`  varchar(255) NOT NULL ," +
                                       $"`description`  varchar(2000) NOT NULL ," +
                                       $"`type`  enum('Practical','Theoretical') NOT NULL ," +
                                       $"`time`  varchar(255) NOT NULL ," +
                                       $"`reading`  varchar(255) NULL ," +
                                       $"`active`  enum('True','False') NOT NULL DEFAULT 'True'" +
                                       $"PRIMARY KEY (`id`)) ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Gets a row from the document table
        /// </summary>
        /// <param name="type">The document type</param>
        /// <param name="id">The user id</param>
        /// <param name="docTable">The table the query is send to</param>
        /// <returns>Returns the row found in a DataTable</returns>
        internal static DataTable GetDocument(string type, int id, string docTable = DocumnentTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {docTable} WHERE user = {id} AND type = '{type}' LIMIT 1");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Updates a document
        /// </summary>
        /// <param name="type">The document type</param>
        /// <param name="userId">The id of the user the document is uploaded to</param>
        /// <param name="newPath">The path of the new document</param>
        /// <param name="docTable"></param>
        /// <returns>Returns a bool indicating whether the document is succesfully updated or not</returns>
        internal static bool UpdateDocument(string type, int userId, string newPath, string docTable = DocumnentTable)
        {
            var cmd = new MySqlCommand($"UPDATE {docTable} SET path = '{newPath}' WHERE type = '{type}' AND `user` = {userId}");

            if (ExistTable(docTable)) return SendNonQuery(cmd);

            var tableCreated = CreateDocumentTabel(docTable);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        /// <summary>
        /// Uploades a documents 
        /// </summary>
        /// <param name="title">The document title</param>
        /// <param name="type">The document type</param>
        /// <param name="date">The date of the upload</param>
        /// <param name="userId">The id of the user the document is upload to</param>
        /// <param name="path">The document path</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the document is succesfully uploaded or not</returns>
        internal static bool UploadDocument(string title, string type, DateTime date, int userId, string path, string table = DocumnentTable)
        {
            if (ExistDocument(userId, type, table)) return UpdateDocument(type, userId, path, table);

            var cmd = new MySqlCommand($"INSERT INTO documents (title, type, `user`, path) VALUES ('{title}', '{type}', {userId}, '{path}')");

            if (ExistTable(table)) return SendNonQuery(cmd);

            var tableCreated = CreateDocumentTabel(table);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        /// <summary>
        /// Creates a table to hold documents
        /// </summary>
        /// <param name="tablename">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table was created or not</returns>
        internal static bool CreateDocumentTabel(string tablename = DocumnentTable)
        {
            var query = $"CREATE TABLE `{tablename}` (" +
                        "`id`  int(11) NOT NULL AUTO_INCREMENT ," +
                        "`title`  varchar(255) NOT NULL ," +
                        "`type`  enum('FirstAid','DoctorsNote','Other') NULL ," +
                        "`date`  datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ," +
                        "`user`  int(11) NOT NULL ," +
                        "`path`  varchar(255) NOT NULL ," +
                        "PRIMARY KEY (`id`))" +
                        "ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;";

            var cmd = new MySqlCommand(query);

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Gets a user by username
        /// </summary>
        /// <param name="username">The username to find</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the user found in a DataTable</returns>
        internal static DataTable GetUserByUsername(string username, string table = UserTable)
        {
            if (!ExistUsername(username, table)) return null;

            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE username = '{username}' LIMIT 1");
            return SendQuery(cmd);
        }

        /// <summary>
        /// Gets a user by a user id
        /// </summary>
        /// <param name="id">The user id</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the user found in a DataTable</returns>
        internal static DataTable GetUserByID(int id, string table = UserTable)
        {
            if (!ExistUserId(id, table)) return null;

            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE user_id = '{id}' LIMIT 1");
            return SendQuery(cmd);
        }

        /// <summary>
        /// Checks if a documents exists
        /// </summary>
        /// <param name="id">The user's id</param>
        /// <param name="type">The document type</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the documents exists or not</returns>
        internal static bool ExistDocument(int id, string type, string table = DocumnentTable)
        {
            var cmd = new MySqlCommand($"SELECT 1 FROM {table} WHERE type = '{type}' AND user = {id} LIMIT 1");

            if (ExistTable(table))
            {
                var results = SendQuery(cmd);

                return results.Rows.Count == 1;
            }

            var tableCreated = CreateDocumentTabel(table);

            if (tableCreated)
            {
                var results = SendQuery(cmd);

                return results.Rows.Count == 1;
            }

            return false;
        }

        /// <summary>
        /// Checks if a userid exists
        /// </summary>
        /// <param name="id">The id to chech for</param>
        /// <param name="table">The table the query is send for</param>
        /// <returns></returns>
        internal static bool ExistUserId(int id, string table = UserTable)
        {
            return Exist("user_id", id.ToString(), table);
        }

        /// <summary>
        /// Checks if an email exists
        /// </summary>
        /// <param name="email">The email to check for</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool in indicating whether the email exists or not</returns>
        internal static bool ExistEmail(string email, string table = UserTable)
        {
            return Exist("email", email, table);
        }

        /// <summary>
        /// Checks if a username exists
        /// </summary>
        /// <param name="username">The username to check for</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the username exists or not</returns>
        internal static bool ExistUsername(string username, string table = UserTable)
        {
            return Exist("username", username, table);
        }

        /// <summary>
        /// Checks if a given cpr exists
        /// </summary>
        /// <param name="cpr">The cpr to check for</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns></returns>
        internal static bool ExistCPR(string cpr, string table = UserTable)
        {
            return Exist("cpr", cpr, table);
        }

        /// <summary>
        /// Checks if a value exists in a speciffic column in the usertable.
        /// </summary>
        /// <param name="column">The column to check in </param>
        /// <param name="value">The value to check for</param>
        /// <param name="table">´The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the value exists or not</returns>
        private static bool Exist(string column, string value, string table = UserTable)
        {
            var cmd = new MySqlCommand($"SELECT 1 FROM {table} WHERE {column} = '{value}' LIMIT 1");

            var results = SendQuery(cmd);

            try
            {
                return results.Rows.Count == 1;
            }
            catch (NullReferenceException)
            {
                return false;
            }

        }

        /// <summary>
        /// Adds a user to the databse
        /// </summary>
        /// <param name="firstname">The user's firstname</param>
        /// <param name="lastname">The user's lastname</param>
        /// <param name="phone">The user's phone</param>
        /// <param name="mail">The user's mail</param>
        /// <param name="cpr">The user's cpr</param>
        /// <param name="address">The user's adress</param>
        /// <param name="zip">The user's zip</param>
        /// <param name="city">The user's city</param>
        /// <param name="username">The user's username</param>
        /// <param name="password">The user's password</param>
        /// <param name="picture">The user's picturepath</param>
        /// <param name="signature">The user's signaturepath</param>
        /// <param name="sysmin">The user's sysmin value</param>
        /// <param name="classname">The user's class name</param>
        /// <param name="usertable">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the user was succesfully added or not</returns>
        internal static bool AddUser(string firstname, string lastname, string phone, string mail, string cpr, string address, 
            string zip, string city, string username, string password, string picture = null, string signature = "", string sysmin = "false", string classname = "", string usertable = UserTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO {usertable} (" +
                                       $"firstname, lastname, phone, email, cpr, address, zip, city, username, `password`, picture, signature, sysmin, class, theotestdone, practestdone, feepaid, active)" +
                                       $"VALUES (" +
                                       $"'{firstname}', '{lastname}', '{phone}', '{mail}', '{cpr}', '{address}', '{zip}', '{city}', '{username}', " +
                                       $"'{password}', '{picture}', '{signature}', '{sysmin}', '{classname}', 'False', 'False', 'False', 'True')");


            if (ExistTable(usertable)) return SendNonQuery(cmd);

            var tableCreated = CreateUserTable(usertable);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        /// <summary>
        /// Updates informtaion on a specific user
        /// </summary>
        /// <param name="cpr">The cpr to be updated</param>
        /// <param name="firstname">The firstname to be updated</param>
        /// <param name="lastname">The lastname to be updated</param>
        /// <param name="phone">The phone to be updated</param>
        /// <param name="mail">The mail to be updated</param>
        /// <param name="address">The address to be updated</param>
        /// <param name="zip">The zip to be updated</param>
        /// <param name="city">The city to be updated</param>
        /// <param name="username">The username to be updated</param>
        /// <param name="password">The password to be updated</param>
        /// <param name="picture">The picturepath to be updated</param>
        /// <param name="signature">The signaturepath to be updated</param>
        /// <param name="sysmin">The sysmin value to be updated</param>
        /// <param name="usertable">The table the query is send to</param>
        /// <returns>Reeturns a bool indicating whether the user was succesfully updated or not</returns>
        internal static bool UpdateUser(string cpr, string firstname, string lastname, string phone, string mail, string address,
            string zip, string city, string username, string password, string picture = null, string signature = "", string sysmin = "false", string usertable = UserTable)
        {
            var cmd = new MySqlCommand($"UPDATE {usertable} SET " +
                                       $"`firstname` = '{firstname}', `lastname` = '{lastname}', `phone` = '{phone}'," +
                                       $"`email` = '{mail}', `address` = '{address}', `zip` = '{zip}', `city` = '{city}'," +
                                       $"`username` = '{username}', `password` = '{password}', `picture` = '{picture}', `signature` = '{signature}',`sysmin` = '{sysmin}'" +
                                       $"WHERE `cpr` = '{cpr}'");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Sets a bool value in a speciffic column in the user table.
        /// </summary>
        /// <param name="userid">The id of the user to be updated</param>
        /// <param name="column">The column to be updated</param>
        /// <param name="value">The bool value to be set</param>
        /// <param name="table">The name of the table the query is send to</param>
        /// <returns>Returns a bools indicating whether table was succrsfully updated or not</returns>
        internal static bool UpdateUserEnum(int userid, string column, bool value, string table = UserTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET " +
                                       $"`{column}` = '{value}' " +
                                       $"WHERE user_id = {userid}");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Checks if the table allready exists in the database.
        /// </summary>
        /// <param name="tablename">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table exists or not</returns>
        private static bool ExistTable(string tablename)
        {
            var cmd = new MySqlCommand($"SELECT 1 FROM {tablename} LIMIT 1;");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Creates a user tablee in the databse
        /// </summary>
        /// <param name="tablename">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table was succesfully created or not</returns>
        private static bool CreateUserTable(string tablename)
        {
            var query = $"CREATE TABLE `{tablename}` (" +
                        "`user_id`  int(11) NOT NULL AUTO_INCREMENT ," +
                        "`firstname`  varchar(255) NOT NULL ," +
                        "`lastname`  varchar(255) NOT NULL ," +
                        "`phone`  varchar(255) NOT NULL ," +
                        "`email`  varchar(255) NOT NULL ," +
                        "`cpr`  varchar(255) NOT NULL ," +
                        "`address`  varchar(255) NOT NULL ," +
                        "`zip`  varchar(255) NOT NULL ," +
                        "`city`  varchar(255) NOT NULL ," +
                        "`username`  varchar(255) NOT NULL ," +
                        "`password`  varchar(255) NOT NULL ," +
                        "`picture`  varchar(255) NULL ," +
                        "`signature`  varchar(255) NOT NULL, " +
                        "`sysmin`  enum('True','False') NOT NULL ," +
                        "`class`  varchar(255) NOT NULL ," +
                        "`theotestdone`  enum('True','False') NOT NULL ," +
                        "`practestdone`  enum('True','False') NOT NULL ," +
                        "`feepaid`  enum('True','False') NOT NULL ," +
                        "`active`  enum('True','False') NOT NULL " +
                        "PRIMARY KEY (`user_id`))" +
                        "ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;";

            var query2 = "ALTER TABLE `users` " +
                         "ADD FULLTEXT INDEX `FulltextSearch` (`firstname`, `lastname`, `phone`, `email`, `cpr`, `address`, `zip`, `city`, `username`)" ;

            var cmd = new MySqlCommand(query);
            var cmd2 = new MySqlCommand(query2);

            return (SendNonQuery(cmd) && SendNonQuery(cmd2));
        }

        /// <summary>
        /// Searches in every colum of the user table for a match of the search input.
        /// </summary>
        /// <param name="searchInput">The search input string</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the search results found in a DataTable</returns>
        internal static DataTable UserSearch(string searchInput, string table = UserTable)
        {
            string query;
            if (searchInput == "" || searchInput == "%")
                query = $"SELECT * FROM {table}";
            else
            {
                query =
                    $"SELECT * FROM {table} WHERE MATCH(`username`, `firstname`, `lastname`, `phone`, `email`, `cpr`, `address`, `zip`, `city`) AGAINST ('*{searchInput}*' IN BOOLEAN MODE)";
            }
            var cmd = new MySqlCommand(query);

            return SendQuery(cmd);
        }

        /// <summary>
        /// Adds a todays note message to the databse.
        /// </summary>
        /// <param name="user">The user that adds the message</param>
        /// <param name="todayNoteText">The message string</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool indicating whether the table was succesfully updated or not.
        ///  If the table does not exist it is created</returns>
        internal static bool AddTodaysNote(User user, string todayNoteText, string table = TodaysNoteTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO {table} (" +
                                       $"userID, description)" +
                                       $"VALUES (" +
                                       $"'{user.Id}', '{todayNoteText}')");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return CreateTodaysNoteTable(table) && SendNonQuery(cmd);
        }

        /// <summary>
        /// This metod creates a new table in the databse to hold todays note messages.
        /// </summary>
        /// <param name="tableName">The name of the table</param>
        /// <returns>Returns a bool indicating whether the table was succesfully created or not</returns>
        private static bool CreateTodaysNoteTable(string tableName)
        {
            var cmd = new MySqlCommand($"CREATE TABLE `{tableName}` (" +
                        "`id`  int(11) NOT NULL AUTO_INCREMENT ," +
                        "`userID`  int NOT NULL ," +
                        "`date`  datetime NOT NULL DEFAULT CURRENT_TIMESTAMP ," +
                        "`description`  varchar(2000) NOT NULL ," +
                        "PRIMARY KEY (`id`))" +
                        "ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;");

            return SendNonQuery(cmd);
        }

        /// <summary>
        /// Gets the latest todays note message from the database 
        /// </summary>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the message found in a DataTable</returns>
        internal static DataTable GetLatestTodaysNote(string table = TodaysNoteTable)
        {
            string query = $"SELECT * FROM {table} ORDER BY `id` DESC LIMIT 1;";
            var cmd = new MySqlCommand(query);

            return SendQuery(cmd);
        }

        /// <summary>
        /// Returns all lessons found corresponding to the appointmentids given.
        /// </summary>
        /// <param name="appointmentIdString">The string holding the appointmentIDs which are seperated by a ",".</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the appointments found in a DataTable</returns>
        public static DataTable GetAllLessonsFromMultipleAppointmentIds(string appointmentIdString,
            string table = LessonTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE {table}.AppointmentID IN ({appointmentIdString});");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Send a non query to the database and returns. Used to update data in the database.
        /// </summary>
        /// <param name="cmd">The MySQL Command to execute in the database</param>
        /// <returns>Returns a bool wether the operation was succesfull or not</returns>
        private static bool SendNonQuery(MySqlCommand cmd)
        {
            try
            {
                cmd.Connection = Connection;
                Connection.Open();
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException ex)
            {
                //TODO: Do something with error
                Console.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        /// <summary>
        /// Sends a query to the database.
        /// </summary>
        /// <param name="cmd">The MySQL query to execute in the database</param>
        /// <returns>Returns a DataTable for further use in the DatabaseParser</returns>
        private static DataTable SendQuery(MySqlCommand cmd)
        {
            DataTable results = new DataTable();

            try
            {
                cmd.Connection = Connection;
                Connection.Open();

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    results.Load(reader);
                }
            }
            catch (MySqlException ex)
            {
                //TODO: Do something with error
                Console.WriteLine(ex.Message + ex.Number);
                return null;
            }
            finally
            {
                Connection.Close();
            }

            return results;

        }

        /// <summary>
        /// Returns all users found corresponding to the userids given.
        /// </summary>
        /// <param name="userIdsString">The string holding the userIDs which are seperated by a ",".</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns the results found in a DataTable by the SendQuery metod</returns>
        public static DataTable GetAllUsersFromMultipleUserIds(string userIdsString, string table = UserTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE {table}.user_id IN ({userIdsString});");

            return SendQuery(cmd);
        }

        /// <summary>
        /// Delets an appointment in the appointment table in the databse
        /// </summary>
        /// <param name="appointmentId">The id of the appointment to be deleted</param>
        /// <param name="table">The table the query is send to</param>
        /// <returns>Returns a bool which indicated whether the query were executed or not</returns>
        public static bool DeleteAppointment(int appointmentId, string table)
        {
            var cmd = new MySqlCommand($"DELETE FROM {table} WHERE id = {appointmentId}");

            return SendNonQuery(cmd);
        }
    }
}


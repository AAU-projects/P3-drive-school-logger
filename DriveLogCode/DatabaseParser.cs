using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace DriveLogCode
{
    public static class DatabaseParser
    {
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
                LessonTemplate newTemplate = new LessonTemplate(Convert.ToInt32(row[2]), (string)row[6], (string)row[7], (string)row[8], Convert.ToInt32(row[9]), (string)row[10]);
                lessonsList.Add(new Lesson((string)row[0], (string)row[1], Convert.ToInt32(row[2]), Convert.ToInt32(row[3]), (DateTime)row[4], Convert.ToBoolean(row[5]), newTemplate));
            }

            return lessonsList;
        }

        public static Dictionary<string, string> GetTemplate(string templateName)
        {
            DataTable lessonInfo = MySql.GetLessonData(templateName);

            return GetDict(lessonInfo);
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
                string tempFilePath = Path.Combine(Path.GetTempPath(), $"{fileInfo.Rows[0][1].ToString().Replace(' ','.')}.pdf");

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

        public static bool AddAppointment(string type, DataTable startTime, int availableTime, string instructor)
        {
            return MySql.AddAppointment(instructor, startTime, availableTime, type);
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
    }
}

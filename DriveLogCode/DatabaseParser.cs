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

        public static Dictionary<string, string> GetTemplate(string templateName)
        {
            DataTable lessonInfo = MySql.GetLessonData(templateName);

            return GetDict(lessonInfo);
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

        public static List<AppointmentStructure> AppointmentsList()
        {
            List<AppointmentStructure> appointments = new List<AppointmentStructure>();
            DataTable queryInfo = MySql.GetAllAppointments();

            foreach (DataRow appointment in queryInfo.Rows)
            {
                appointments.Add(new AppointmentStructure((int) appointment[0], (int) appointment[1], (DateTime) appointment[2], (int) appointment[3], (string) appointment[4], Convert.ToBoolean(appointment[5])));
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
            LessonTemplate lessonTemplate = new LessonTemplate();
            DataTable DatabaseResults = MySql.GetLessonTemplateByID(lessonId);

            lessonTemplate.ID = Convert.ToInt32(DatabaseResults.Columns[0]);
            lessonTemplate.Title = DatabaseResults.Columns[1].ToString();
            lessonTemplate.Description = DatabaseResults.Columns[2].ToString();
            lessonTemplate.Type = DatabaseResults.Columns[3].ToString();
            lessonTemplate.Time = Convert.ToInt32(DatabaseResults.Columns[4]);
            lessonTemplate.Reading = DatabaseResults.Columns[5].ToString();

            return lessonTemplate;
        }
    }
}

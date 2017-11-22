using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Tasks.Deployment.Bootstrapper;
using MySql.Data.MySqlClient;

namespace DriveLogCode
{
    public static class MySql
    {
        private const string ConnectionString = "server=ds315e17.duckdns.org;port=50000;uid=DriveLog;pwd=#SWe2017;database=DriveLog";
        private static readonly  MySqlConnection Connection = new MySqlConnection(ConnectionString);

        private const string UserTable = "users";
        private const string DocumnentTable = "documents";
        private const string LessonTemplateTable = "lessonTemplates";
        private const string AppointmentTable = "appointments";
        private const string LessonTable = "lessons";

        public static DataTable GetLessonsAndAttachedAppointmentByUserId(int userid, string LessonTable = LessonTable, string AppointmentTable = AppointmentTable, string UserTable = UserTable, string LessonTemplateTable = LessonTemplateTable)
        {
            var cmd = new MySqlCommand("SELECT " +
                $"{UserTable}.firstname AS InstructorFirstname, " +
                $"{UserTable}.lastname AS InstructorLastname, " +
                $"{LessonTable}.LessonID AS TemplateID, " +
                $"{LessonTable}.LessonPart AS Progress, " +
                $"{LessonTable}.EndDate, " +
                $"{LessonTable}.Completed, " +
                $"{LessonTemplateTable}.title, " +
                $"{LessonTemplateTable}.description, " +
                $"{LessonTemplateTable}.type, " +
                $"{LessonTemplateTable}.time, " +
                $"{LessonTemplateTable}.reading " +
                $"FROM {AppointmentTable}, {LessonTable}, {UserTable}, {LessonTemplateTable} " + 
                "WHERE " +
                $"{LessonTable}.AppointmentID = {AppointmentTable}.id AND " + 
                $"{LessonTable}.UserID = '{userid}' AND " +
                $"{UserTable}.user_id = {AppointmentTable}.instructorID AND " +
                $"{LessonTemplateTable}.id = {LessonTable}.LessonID " +
                $"ORDER BY {LessonTable}.id");

            return SendQuery(cmd);
        }

        public static DataTable GetLessonByID(int id, string table = LessonTable)
        {
            return GetFromDB("id", id.ToString(), table);
        }

        public static DataTable GetInstructorByID(int id, string table = UserTable)
        {
            return GetFromDB("user_id", id.ToString(), table);
        }

        public static DataTable GetLessonTemplateByID(int lessonId, string table = LessonTemplateTable)
        {
            return GetFromDB("id", lessonId.ToString(), table);
        }

        public static DataTable GetLessonsByUser(int userID, string table = LessonTable)
        {
            return GetFromDB("userID", userID.ToString(), table);
        }

        public static DataTable GetLessonsByUserAndAppointment(int userID, int appointmentID,
            string table = AppointmentTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM `{table}` WHERE `userID` = '{userID}' AND `appointmentID` = '{appointmentID}'");

            return ExistTable(table) ? SendQuery(cmd) : null;
        }

        public static DataTable GetAllAppointments(string appointmentTable = AppointmentTable, string userTable = UserTable)
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
                                       $"{userTable}.user_id = {AppointmentTable}.instructorID ");

            return SendQuery(cmd);
        }

        public static bool AddLesson(int userId, int appointmentID, int templateID, int part, string table = LessonTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO `{table}` (`userID`, `appointmentID`, `lessonID`, `lessonPart`)" +
                                       $"VALUES ('{userId}', '{appointmentID}', '{templateID}', '{part}')");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return CreateAppointmentTable(table) && SendNonQuery(cmd);
        }

        public static DataTable GetAppointmentsByInstuctor(int instructorID, string table = AppointmentTable)
        {
            return GetFromDB("instructorID", instructorID.ToString(), table);
        }

        public static DataTable GetAppointmentByID(int id, string table = AppointmentTable)
        {
            return GetFromDB("id", id.ToString(), table);
        }

        private static DataTable GetFromDB(string column, string value, string table)
        {
            var cmd = new MySqlCommand($"SELECT * FROM `{table}` WHERE `{column}` = '{value}'");

            return ExistTable(table) ? SendQuery(cmd) : null;
        }

        public static bool AddAppointment(string instructor, DataTable startTime, int availableTime, string type, string table = AppointmentTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO `{table}` (`instructor`, `startTime`, `availableTime`, `lessonType`) " +
                                       $"VALUES ('{instructor}', '{startTime}', '{availableTime}', '{type}')");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return CreateAppointmentTable(table) && SendNonQuery(cmd);
        }

        private static bool CreateLessonTable(string tableName = LessonTable)
        {
            var cmd = new MySqlCommand($"CREATE TABLE `{tableName}` (" +
                                       $"`id`  int NOT NULL AUTO_INCREMENT ," +
                                       $"`userID`  int NOT NULL ," +
                                       $"`appointmentID`  int NOT NULL ," +
                                       $"`lessonID`  int NOT NULL ," +
                                       $"`lessonPart`  int NOT NULL ," +
                                       $"`endDate`  datetime NULL DEFAULT NULL ," +
                                       $"`completed`  enum(\'True\',\'False\') NOT NULL DEFAULT \'False\' ," +
                                       $"PRIMARY KEY (`id`)" +
                                       $")" +
                                       $"ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;");

            return SendNonQuery(cmd);
        }

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

        public static bool DeleteTemplate(int id, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET active = 'False' WHERE id = {id}");

            if (ExistTable(table)) return SendNonQuery(cmd);
            return false;
        }

        public static DataTable GetCreatedLessonNames(string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"SELECT `title` FROM {table} WHERE active = 'True'");

            if (ExistTable(table)) return SendQuery(cmd);
            return CreateTemplateTable(table) ? SendQuery(cmd) : null;
        }

        public static DataTable GetAllRows(string table)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table}");

            return SendQuery(cmd);
        }

        public static DataTable GetLessonData(string title, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE title = '{title}' LIMIT 1");

            if (ExistTable(table)) return SendQuery(cmd);
            return CreateTemplateTable(table) ? SendQuery(cmd) : null;
        }

        private static bool UpdateLessonTemplate(string id, string title, string description, string type, string time, string reading, string table = LessonTemplateTable)
        {
            var cmd = new MySqlCommand($"UPDATE {table} SET title = '{title}', description = '{description}', type = '{type}', time = '{time}', reading = '{reading}' WHERE id = {id}");
            

            if (ExistTable(table)) return SendNonQuery(cmd);
            if (CreateTemplateTable(table)) return SendNonQuery(cmd);

            return false;
        }

        public static bool UploadLessonTemplate(string id, string title, string description, string type, string time, string reading, string table = LessonTemplateTable)
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

        public static DataTable GetDocument(string type, int id, string docTable = DocumnentTable)
        {
            var cmd = new MySqlCommand($"SELECT * FROM {docTable} WHERE user = {id} AND type = '{type}' LIMIT 1");

            return SendQuery(cmd);
        }

        public static bool Updatedocument(string type, int userId, string newPath, string docTable = DocumnentTable)
        {
            var cmd = new MySqlCommand($"UPDATE {docTable} SET path = '{newPath}' WHERE type = '{type}' AND `user` = {userId}");

            if (ExistTable(docTable)) return SendNonQuery(cmd);

            var tableCreated = CreateDocumentTabel(docTable);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        public static bool UploadDocument(string title, string type, DateTime date, int userId, string path, string table = DocumnentTable)
        {
            if (ExistDocument(userId, type, table)) return Updatedocument(type, userId, path, table);

            var cmd = new MySqlCommand($"INSERT INTO documents (title, type, `user`, path) VALUES ('{title}', '{type}', {userId}, '{path}')");

            if (ExistTable(table)) return SendNonQuery(cmd);

            var tableCreated = CreateDocumentTabel(table);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        public static bool CreateDocumentTabel(string tablename = DocumnentTable)
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

        public static DataTable GetUserByName(string username, string table = UserTable)
        {
            if (!ExistUsername(username, table)) return null;

            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE username = '{username}' LIMIT 1");
            return SendQuery(cmd);
        }

        public static DataTable GetUserByID(int id, string table = UserTable)
        {
            if (!ExistUserId(id, table)) return null;

            var cmd = new MySqlCommand($"SELECT * FROM {table} WHERE user_id = '{id}' LIMIT 1");
            return SendQuery(cmd);
        }

        public static bool ExistDocument(int id, string type, string table = DocumnentTable)
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

        public static bool ExistUserId(int id, string table = UserTable)
        {
            return Exist("user_id", id.ToString(), table);
        }

        public static bool ExistEmail(string email, string table = UserTable)
        {
            return Exist("email", email, table);
        }

        public static bool ExistUsername(string username, string table = UserTable)
        {
            return Exist("username", username, table);
        }

        public static bool ExistCPR(string cpr, string table = UserTable)
        {
            return Exist("cpr", cpr, table);
        }

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

        public static bool AddUser(string firstname, string lastname, string phone, string mail, string cpr, string address, 
            string zip, string city, string username, string password, string picture = null, string sysmin = "false", string usertable = UserTable)
        {
            var cmd = new MySqlCommand($"INSERT INTO {usertable} (" +
                                       $"firstname, lastname, phone, email, cpr, address, zip, city, username, `password`, picture, sysmin)" +
                                       $"VALUES (" +
                                       $"'{firstname}', '{lastname}', '{phone}', '{mail}', '{cpr}', '{address}', '{zip}', '{city}', '{username}', " +
                                       $"'{password}', '{picture}', '{sysmin}')");


            if (ExistTable(usertable)) return SendNonQuery(cmd);

            var tableCreated = CreateUserTable(usertable);

            if (tableCreated) return SendNonQuery(cmd);

            return false;
        }

        public static bool UpdateUser(string cpr, string firstname, string lastname, string phone, string mail, string address,
            string zip, string city, string username, string password, string picture = null, string sysmin = "false", string usertable = UserTable)
        {
            var cmd = new MySqlCommand($"UPDATE {usertable} SET " +
                                       $"`firstname` = '{firstname}', `lastname` = '{lastname}', `phone` = '{phone}'," +
                                       $"`email` = '{mail}', `address` = '{address}', `zip` = '{zip}', `city` = '{city}'," +
                                       $"`username` = '{username}', `password` = '{password}', `picture` = '{picture}', `sysmin` = '{sysmin}'" +
                                       $"WHERE `cpr` = '{cpr}'");

            return SendNonQuery(cmd);
        }

        private static bool ExistTable(string tablename)
        {
            var cmd = new MySqlCommand($"SELECT 1 FROM {tablename} LIMIT 1;");

            return SendNonQuery(cmd);
        }

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
                        "`sysmin`  enum('True','False') NOT NULL ," +
                        "PRIMARY KEY (`user_id`))" +
                        "ENGINE=InnoDB DEFAULT CHARACTER SET=utf8 COLLATE=utf8_danish_ci;";

            var cmd = new MySqlCommand(query);

            return SendNonQuery(cmd);
        }

        public static DataTable UserSearch(string searchInput, string table = UserTable)
        {
            string query = $"SELECT * FROM {table} WHERE username LIKE '%{searchInput}%' OR  firstname LIKE '%{searchInput}%' OR" +
                           $" lastname LIKE '%{searchInput}%' OR phone LIKE '%{searchInput}%' OR email LIKE '%{searchInput}%' OR" +
                           $" cpr LIKE '%{searchInput}%' OR address LIKE '%{searchInput}%' OR zip LIKE '%{searchInput}%' OR city LIKE '%{searchInput}%'";
            var cmd = new MySqlCommand(query);

            return SendQuery(cmd);
        }

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
    }
}

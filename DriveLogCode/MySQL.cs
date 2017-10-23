using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DriveLogCode
{
    public static class MySql
    {
        private static string _connectionString = "server=ds315e17.duckdns.org;port=50000;uid=DriveLog;pwd=#SWe2017;database=DriveLog";
        private static readonly  MySqlConnection Connection = new MySqlConnection(_connectionString);

        private static readonly string UserTable = "users";

        public static bool AddUser(string firstname, string lastname, string phone, string mail, string cpr, string address, 
            string zip, string city, string username, string password, string picture = null, string sysmin = "false")
        {
            var cmd = new MySqlCommand($"INSERT INTO {UserTable} (" +
                                       $"firstname, lastname, phone, email, cpr, address, zip, city, username, `password`, picture, sysmin)" +
                                       $"VALUES (" +
                                       $"'{firstname}', '{lastname}', '{phone}', '{mail}', '{cpr}', '{address}', '{zip}', '{city}', '{username}', " +
                                       $"'{password}', '{picture}', '{sysmin}')");
            
            return SendNonQuery(cmd);
        }

        private static bool CreateTable(string tablename)
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
                Console.WriteLine(ex.Message);
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

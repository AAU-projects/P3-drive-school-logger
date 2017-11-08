using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class Session
    {
        public static User LoggedInUser;
        public static string TypeFirstAid = "FirstAid";
        public static string TypeDoctorsNote = "DoctorsNote";

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User(userTable);
        }
    }
}

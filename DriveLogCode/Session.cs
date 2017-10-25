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

        public static void LoadUserFromDataTable(DataTable userTable)
        {
            LoggedInUser = new User((string)userTable.Rows[0][1], (string)userTable.Rows[0][2], (string)userTable.Rows[0][3], (string)userTable.Rows[0][4], 
                (string)userTable.Rows[0][5], (string)userTable.Rows[0][6], (string)userTable.Rows[0][7], (string)userTable.Rows[0][8],
                (string)userTable.Rows[0][9], (string)userTable.Rows[0][11], Convert.ToBoolean((string)userTable.Rows[0][12]));
        }
    }
}

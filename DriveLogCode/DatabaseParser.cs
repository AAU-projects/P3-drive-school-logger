using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class DatabaseParser
    {
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

        public static Document GetDoctorsNote(User user)
        {
            return GetDocumentFromDatabase(user, Session.TypeDoctorsNote);
        }
        public static Document GetFirstAid(User user)
        {
            return GetDocumentFromDatabase(user, Session.TypeFirstAid);
        }

        private static Document GetDocumentFromDatabase(User user, string type)
        {
            try
            {
                return new Document(MySql.GetDocument(type, user.Id));

            }
            catch (EmptyDataTableException)
            {
                return null;
            }
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
    }
}

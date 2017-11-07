using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class DatabaseParser
    {
        public static bool ExistDoctorsNote(User user)
        {
            return ExistDocument(user, "DoctorsNote");
        }

        public static bool ExistFirstAid(User user)
        {
            return ExistDocument(user, "FirstAid");
        }

        private static bool ExistDocument(User user, string type)
        {
            return MySql.ExistDocument(user.Id, type);
        }

        public static Document GetDoctorsNote(User user)
        {
            return GetDocumentFromDatabase(user, "FirstAid");
        }
        public static Document GetFirstAid(User user)
        {
            return GetDocumentFromDatabase(user, "FirstAid");
        }

        private static Document GetDocumentFromDatabase(User user, string type)
        {
            try
            {
                return new Document(MySql.GetDocument(type, user.Id));

            }
            catch (EmptyDataTableException e)
            {
                return null;
            }
        }
    }
}

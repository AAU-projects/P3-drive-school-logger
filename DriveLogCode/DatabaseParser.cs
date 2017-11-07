using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class DatabaseParser
    {
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
            return new Document(MySql.GetDocument(type, user.Id));
        }
    }
}

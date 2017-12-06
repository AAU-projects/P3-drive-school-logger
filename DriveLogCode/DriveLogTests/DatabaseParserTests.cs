using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveLogCode.DataAccess;
using DriveLogCode.Objects;
using NUnit.Framework;

namespace DriveLogTests
{
    class DatabaseParserTests
    {
        private string appointmentTestTable = "appointments_test";
        private string documentTestTable = "documents_test";
        private string lessonTestTable = "lessons_test";
        private string lessonTemplateTestTable = "lessonTemplates_test";
        private string todaysNoteTestTable = "todaysNoteTable_test";
        private string userTestTable = "user_test";

        private readonly User testUser = new User
            (0, "Name", "Lastname", "12345678", "email@you.com", "1234561234", "adress",
            "9000", "Aalborg", "username", "password", "picturePath", "signaturePath", 
            true, "classname", true, true, true, true);

        [TestCase("hello", ExpectedResult = true)]
        public bool AddTodaysNote_CheckAdding(string todayNoteText)
        {
            return MySql.AddTodaysNote(testUser, todayNoteText, todaysNoteTestTable);
        }

    }
}

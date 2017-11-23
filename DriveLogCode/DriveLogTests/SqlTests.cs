using System;
using System.Data;
using NUnit.Framework;
using DriveLogCode;
using DriveLogCode.DataAccess;

namespace DriveLogTests
{
    public class SqlTests
    {
        private string testtable = "usertest";

        [TestCase("bob","bob","88888888","bob@bob.bob","much secret","bobvej 14","9025","Bobsby","Bob1","BOb")]
        public void CreateUser_Succesfull(string firstname, string lastname, string phone, string mail, string cpr, string address,
            string zip, string city, string username, string password, string picture = null)
        {
            Assert.IsTrue(MySql.AddUser(firstname, lastname, phone, mail, cpr, address, zip, city, username, password, picture, usertable: "usertest")); 
        }

        [TestCase("much secret", ExpectedResult = true)]
        [TestCase("Davs", ExpectedResult = false)]
        public bool CprExist(string cpr)
        {
            return MySql.ExistCPR(cpr, testtable);
        }

        [TestCase("bob", ExpectedResult = true)]
        [TestCase("Brian", ExpectedResult = false)]
        public bool UsernameExist(string username)
        {
            return MySql.ExistUsername(username, testtable);
        }

        [TestCase("bob@bob.bob", ExpectedResult = true)]
        [TestCase("Brian@brian.brian", ExpectedResult = false)]
        public bool EmailExist(string email)
        {
            return MySql.ExistEmail(email, testtable);
        }

        [TestCase("bob")]
        public void GetUser_ValidUser(string username)
        {
            DataTable resultTable = MySql.GetUserByName(username, testtable);
            Assert.IsTrue((string) resultTable.Rows[0][5] == "bob");
        }

        [TestCase("Mustafa")]
        public void GetUser_NonVaildUser(string username)
        {
            DataTable resultTable = MySql.GetUserByName(username, testtable);
            Assert.IsNull(resultTable);
        }
    }
}
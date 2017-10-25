using System;
using NUnit.Framework;
using DriveLogCode;

namespace DriveLogTests
{
    public class RegisterVerificationTests
    {
        [TestCase("2010170035", ExpectedResult = false)]
        [TestCase("2010170039", ExpectedResult = true)]
        [TestCase("201017-0039", ExpectedResult = true)]
        public bool CPRVerification_CheckInput(string cpr)
        {
            return RegisterVerification.CPRVerification(cpr);
        }

        [TestCase("HansHansen", ExpectedResult = true)]
        [TestCase("Hans-Hansen", ExpectedResult = true)]
        [TestCase("HansHansen-", ExpectedResult = false)]
        [TestCase("-HansHansen", ExpectedResult = false)]
        [TestCase("Hans-_Hansen", ExpectedResult = false)]
        public bool UsernameVerification_CheckInput(string username)
        {
            return RegisterVerification.UsernameVerifacation(username);
        }

        [TestCase("testmail@domain.com", ExpectedResult = true)]
        [TestCase("testmail@domain.co.uk", ExpectedResult = true)]
        [TestCase("test.mail@domain.co.uk", ExpectedResult = true)]
        [TestCase("testmail@domain", ExpectedResult = false)]
        [TestCase("testmail@domain..com", ExpectedResult = false)]
        [TestCase("testmail@domain.", ExpectedResult = false)]
        [TestCase("test@mail@domain.com", ExpectedResult = false)]
        [TestCase(".testmail@domain.com", ExpectedResult = false)]
        [TestCase("testmail@domain.com.", ExpectedResult = false)]
        public bool EmailVerification_CheckInput(string email)
        {
            return RegisterVerification.EmailVerification(email);
        }

        [TestCase("Vesterbro 7", ExpectedResult = true)]
        [TestCase("Vesterbro 7 7th", ExpectedResult = true)]
        [TestCase("Vesterbro", ExpectedResult = false)]
        [TestCase("Vester7bro 7", ExpectedResult = false)]
        [TestCase("Vester_bro 7", ExpectedResult = false)]
        [TestCase("Vesterbro 7 7 th", ExpectedResult = false)]
        [TestCase("Vesterbro7 ", ExpectedResult = false)]
        public bool AdressVerification_CheckInput(string adress)
        {
            return RegisterVerification.AdressVerification(adress);
        }

        [TestCase("mypassword", ExpectedResult = true)]
        [TestCase("my-password", ExpectedResult = true)]
        [TestCase("my_password", ExpectedResult = true)]
        [TestCase("my", ExpectedResult = false)]
        [TestCase("my123password", ExpectedResult = true)]
        [TestCase("1234", ExpectedResult = false)]
        [TestCase("my.password", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("       ", ExpectedResult = false)]
        public bool PasswordVerification_CheckInput(string password)
        {
            return RegisterVerification.PasswordVertification(password);
        }

        [TestCase("88888888", ExpectedResult = true)]
        [TestCase("12345678", ExpectedResult = true)]
        [TestCase("7777777", ExpectedResult = false)]
        [TestCase("7", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("       ", ExpectedResult = false)]
        public bool PhoneVerification_CheckInput(string phoneNo)
        {
            return RegisterVerification.PhoneVerifacation(phoneNo);
        }

        [TestCase("7777", ExpectedResult = true)]
        [TestCase("9000", ExpectedResult = true)]
        [TestCase("900", ExpectedResult = false)]
        [TestCase("7", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("       ", ExpectedResult = false)]
        public bool ZipVerification_CheckInput(string zip)
        {
            return RegisterVerification.ZipVerifacation(zip);
        }

        [TestCase("Aalborg", ExpectedResult = true)]
        [TestCase("Aalborg SV", ExpectedResult = true)]
        [TestCase("Aalborg S V", ExpectedResult = false)]
        [TestCase("Aa7borg", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        [TestCase("Aa-lborg", ExpectedResult = false)]
        public bool CityVerification_CheckInput(string city)
        {
            return RegisterVerification.CityVerification(city);
        }

        [TestCase("Ole", ExpectedResult = true)]
        [TestCase("Ole1", ExpectedResult = false)]
        [TestCase("...", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase(" ", ExpectedResult = false)]
        public bool InputOnlyLettersVerification_CheckInput(string input)
        {
            return RegisterVerification.InputOnlyLettersVerification(input);
        }
    }
}

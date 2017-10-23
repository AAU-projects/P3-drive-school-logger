using System;
using NUnit.Framework;
using DriveLogCode;

namespace DriveLogTests
{
    public class Tests
    {
        [TestCase("2010170035", ExpectedResult = false)]
        [TestCase("2010170039", ExpectedResult = true)]
        [TestCase("201017-0039", ExpectedResult = true)]
        public bool CPRValidation_CheckInput(string cpr)
        {
            return RegisterVerification.CPRVerification(cpr);
        }

        [TestCase("HansHansen", ExpectedResult = true)]
        [TestCase("Hans-Hansen", ExpectedResult = true)]
        [TestCase("HansHansen-", ExpectedResult = false)]
        [TestCase("-HansHansen", ExpectedResult = false)]
        [TestCase("Hans-_Hansen", ExpectedResult = false)]
        public bool UsernameValidation_CheckInput(string username)
        {
            return RegisterVerification.UsernameVerifacation(username);
        }
    }
}

using System;
using NUnit.Framework;
using DriveLogCode;

namespace DriveLogTests
{
    public class Tests
    {
        [Test]
        public void CPRValidation_InvalidInput_False()
        {
            bool result = RegisterVerification.CPRVerification("2010170035");

            Assert.IsFalse(result);
        }

        [Test]
        public void CPRValidation_ValidInput_True()
        {
            bool result = RegisterVerification.CPRVerification("2010170039");

            Assert.IsTrue(result);
        }

        [Test]
        public void CPRValidation_ValidInputWithDash_True()
        {
            bool result = RegisterVerification.CPRVerification("201017-0039");

            Assert.IsTrue(result);
        }
    }
}

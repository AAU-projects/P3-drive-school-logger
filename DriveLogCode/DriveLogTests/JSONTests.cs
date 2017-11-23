using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveLogCode;
using DriveLogCode.DataAccess;
using NUnit.Framework;

namespace DriveLogTests
{
    public class JSONTests
    {
        [TestCase(8700, ExpectedResult = "Horsens")]
        [TestCase(6933, ExpectedResult = "Kibæk")]
        [TestCase(9200, ExpectedResult = "Aalborg SV")]
        [TestCase(4444, ExpectedResult = null)]
        public string GetCity_recieveZipCode_returnsCityName(int zip)
        {
            return JSONReader.GetCity(zip);
        }
    }
}

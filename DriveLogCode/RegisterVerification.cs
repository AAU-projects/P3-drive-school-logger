using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class RegisterVerification
    {
        public static bool UsernameVerifacation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && !c.Equals('_') && !c.Equals('-') && !c.Equals('.'))
                    return false;
            }

            return true;
        }
    }
}

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

        public static bool EmailVerification(string input)
        {
            try
            {
                var emailAdress = new System.Net.Mail.MailAddress(input);
                return emailAdress.Address == input;
            }
            catch
            {
                return false;
            }
        }

        public static bool CPRVerification(string input)
        {
            input.Replace("-", String.Empty);

            if (input.Length != 10)
                return false;

            int[] intArray = input.Select(c => (c - '0')).ToArray();

            int sum = (intArray[0] * 4) + (intArray[1] * 3) + (intArray[2] * 2) + (intArray[3] * 7) + (intArray[4] * 6) + (intArray[5] * 5) + 
                (intArray[6] * 4) + (intArray[7] * 3) + (intArray[8] * 2) + intArray[9];

            if (sum % 11 == 0)
                return true;
            else
                return false;
        }
    }
}


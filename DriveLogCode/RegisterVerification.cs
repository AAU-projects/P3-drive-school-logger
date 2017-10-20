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

        public static bool InputOnlyLettersVerification(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        public static bool AdressVerification(string adress)
        {
            if (string.IsNullOrEmpty(adress) || !adress.Contains(' '))
                return false;

            string[] adressStrings = adress.Split(' ');
            string street = adressStrings[0];
            string streetNo = adressStrings[1];

            if (adressStrings.Length == 1)
                return false;

            if (!InputOnlyLettersVerification(street))
                    return false;

            foreach (char number in streetNo)
            {
                if (!char.IsDigit(number))
                    return false;
            }

            if (adressStrings.Length == 3)
            {
                string floor = adressStrings[2];
                foreach (char c in floor)
                {
                    if (!char.IsLetterOrDigit(c))
                        return false;
                }
            }
            return true;
        }
    }
}

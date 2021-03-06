﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DriveLogCode
{
    public static class RegisterVerification
    {
        /// <summary>
        /// checks for valid username, 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool UsernameVerifacation(string input)
        {
            if (DataAccess.MySql.ExistUsername(input)) return false;

            if (string.IsNullOrEmpty(input))
                return false;

            char[] specialChars = { '_', '-', '.' };

            if (specialChars.Contains(input[0]) || specialChars.Contains(input[input.Length - 1]))
                return false;

            for(int i = 0; i < input.Length; i++)
            {
                if (!char.IsLetterOrDigit(input[i]) && !specialChars.Contains(input[i]))
                    return false;
                if (i != 0 && specialChars.Contains(input[i]) && specialChars.Contains(input[i-1]))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// checks if the input is only letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
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

        /// <summary>
        /// checks if the input is only letters
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool InputOnlyDigitVerification(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// checks if valid street name
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool StreetNameVerification(string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            foreach (var c in input)
            {
                if (!char.IsLetter(c))
                {
                    if (c == '.' || c == '-')
                        return true;

                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// checks if address is valid
        /// </summary>
        /// <param name="adress"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool AdressVerification(string adress)
        {
            string[] adressStrings = adress.Split(' ');
            string street1 = adressStrings[0];

            int inputOnlyDigit = 0;
            foreach (string s in adressStrings)
            {
                if (InputOnlyDigitVerification(s))
                    inputOnlyDigit++;
            }

            if (string.IsNullOrEmpty(adress) || !adress.Contains(' ') || adressStrings.Length < 2 || 
                !StreetNameVerification(street1) || inputOnlyDigit < 1)
                return false;

            return true;
        }

        /// <summary>
        /// checks if emails is valid
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool EmailVerification(string input)
        {
            if (DataAccess.MySql.ExistEmail(input)) return false;

            string[] splittedEmail = input.Split('@');
            string localPart;
            string domainPart;
            char[] allowedDomainChars = { '.', '-' };

            if (splittedEmail.Length != 2)
                return false;

            else
            {
                localPart = splittedEmail[0];
                domainPart = splittedEmail[1];
            }
            if (!localPart.All(c => char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '-')
                || localPart.StartsWith("_")
                || localPart.StartsWith(".")
                || localPart.StartsWith("-"))
            {
                return false;
            }
            else if (!domainPart.All(c => char.IsLetterOrDigit(c) || c == '.' || c == '-')
                || domainPart.StartsWith(".")
                || domainPart.StartsWith("-")
                || domainPart.EndsWith("-")
                || domainPart.EndsWith(".")
                || !domainPart.Any(c => c == '.'))
            {
                return false;
            }
            for (int i = 0; i < domainPart.Length; i++)
            {
                if (i != 0 && allowedDomainChars.Contains(domainPart[i]) && allowedDomainChars.Contains(domainPart[i - 1]))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// checks if valid cpr number
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool CPRVerification(string input)
        {
            input = input.Replace("-", "");

            //if (MySql.ExistCPR(input)) return false;

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

        /// <summary>
        /// checks for valid password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool PasswordVertification(string password)
        {
            int letterCounter = 0;

            if (string.IsNullOrWhiteSpace(password) || password.Length < 3) return false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                    letterCounter++;

                if (!char.IsLetterOrDigit(c) && !c.Equals('_') && !c.Equals('-'))
                    return false;
            }

            if (letterCounter < 1)
                return false;

            return true;
        }

        /// <summary>
        /// calculates the strenght of the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>returns an int, the higher the stronger password</returns>
        public static int PasswordStrength(string password)
        {
            int hasUppercase = 0;
            int hasLowercase = 0;
            int hasDigit = 0;
            int hasSpecialChar = 0;

            if (password == "Password")
                return 0;

            foreach(char c in password)
            {
                if (char.IsDigit(c))
                    hasDigit = 2;
                else if (char.IsLower(c))
                    hasLowercase = 2;
                else if (char.IsUpper(c))
                    hasUppercase = 2;
                else if (c.Equals('_') || c.Equals('-'))
                    hasSpecialChar = 2;
            }

            return hasUppercase + hasLowercase + hasDigit + hasSpecialChar + password.Length;
        }

        /// <summary>
        /// checks for valid phonenumber
        /// </summary>
        /// <param name="phoneNo"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool PhoneVerifacation(string phoneNo)
        {

            if (string.IsNullOrEmpty(phoneNo) || phoneNo.Length != 8)
                return false;

            foreach (char c in phoneNo)
            {
                if (!phoneNo.All(char.IsDigit))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// checks for valid zipcode
        /// </summary>
        /// <param name="zip"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool ZipVerifacation(string zip)
        {
            if (string.IsNullOrEmpty(zip) || zip.Length != 4)
                return false;

            foreach (char c in zip)
            {
                if (!zip.All(char.IsDigit))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// checks for valid city
        /// </summary>
        /// <param name="city"></param>
        /// <returns>returns true if valid, false if invalid</returns>
        public static bool CityVerification(string city)
        {
            if (string.IsNullOrEmpty(city) || (string.IsNullOrWhiteSpace(city))) return false;

            int whiteSpaceCounter = 0;

            foreach (char c in city)
            {
                if (c == ' ')
                    whiteSpaceCounter++;

                if (whiteSpaceCounter > 1)
                    return false;

                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                    return false;
            }
            return true;
        }
    }
}


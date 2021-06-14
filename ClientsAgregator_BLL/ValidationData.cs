using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace ClientsAgregator_BLL
{
    public class ValidationData
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return false;
            }

            if (Regex.IsMatch(email,
                    @"^[^@\s\.]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
            {
                return false;
            }

            if (Regex.IsMatch(phone,
                @"^\+[0-9]{11,16}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidStringLenght(string str, int validCharQuantity)
        {
            if (validCharQuantity >= 0)
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                    return true;
                }

                int minLength = 0;

                if (str.Length <= validCharQuantity && str.Length >= minLength)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsStringNotNull(string str)
        {
            if (!(string.IsNullOrEmpty(str)))
            {
                return true;
            }

            return false;
        }

        public static bool IsNumber(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return true;
            }

            if (Regex.IsMatch(str,
               @"^[0-9]{0,53}\,?[0-9]{0,2}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

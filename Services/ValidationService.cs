using System.Text.RegularExpressions;

namespace ValidationFramework.Services
{
    public class ValidationService
    {
        public static bool checkRegex(string value, string pattern)
        {
            return Regex.IsMatch(value, pattern);
        }

        public static bool isPhoneNumber(string phoneNumber)
        {
            return checkRegex(phoneNumber, "^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\\s\\./0-9]*$");
        }

        public static bool isDateOfBirth(DateTime dob)
        {
            if (dob == null) return false;
            return dob.CompareTo(DateTime.Now) <= 0;
        }
    }
}

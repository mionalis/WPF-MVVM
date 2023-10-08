using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ViewModel.Services
{
    public static class ValueValidator
    {
        public static string ValidateFullName(string fullName, int maxLength)
        {
            if (fullName.Length < maxLength)
            {
                return null;
            }

            return $"Full Name must not exceed {maxLength} characters.";
        }

        public static string ValidatePhoneNumber(string phoneNumber, int maxLength)
        {
            var pattern = @"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$";

            if (Regex.IsMatch(phoneNumber, pattern) && phoneNumber.Length < maxLength)
            {
                return null;
            }

            return $"Phone Number must not exceed {maxLength} characters and " +
                   "can only contain digits and symbols: +-(). Example: +7 (900) 111-22-33";
        }

        public static string ValidateEmail(string email, int maxLength)
        {
            var pattern = @"^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$";

            if (Regex.IsMatch(email, pattern) && email.Length < maxLength)
            {
                return null;
            }

            return $"Email must not exceed {maxLength} characters and must contain the @ symbol." +
                   " Example: none@domain.com";
        }
    }
}

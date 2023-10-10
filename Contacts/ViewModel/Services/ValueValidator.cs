using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ViewModel.Services
{
    /// <summary>
    /// Выполняет валидацию вводимых данных.
    /// </summary>
    public static class ValueValidator
    {
        /// <summary>
        /// Выполняет валидацию ФИО контакта. Длина строки не должна превышать указанного значения.
        /// </summary>
        /// <param name="fullName">ФИО контакта.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <returns>Строка с сообщением об ошибке.</returns>
        public static string ValidateFullName(string fullName, int maxLength)
        {
            if (fullName.Length < maxLength)
            {
                return null;
            }

            var errorMessage = $"Full Name must not exceed {maxLength} characters.";

            return errorMessage;
        }

        /// <summary>
        /// Выполняет валидацию имени телефонного номера. Допускается использовать только
        /// цифры и символы +-(). Длина строки не должна превышать указанного значения.
        /// </summary>
        /// <param name="phoneNumber">Телефонный номер контакта.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <returns>>Строка с сообщением об ошибке.</returns>
        public static string ValidatePhoneNumber(string phoneNumber, int maxLength)
        {
            var phoneNumberPattern = @"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$";

            if (Regex.IsMatch(phoneNumber, phoneNumberPattern) && phoneNumber.Length < maxLength)
            {
                return null;
            }

            var errorMessage = $"Phone Number must not exceed {maxLength} characters " +
                               $"and can only contain digits and symbols: +-(). " +
                               $"Example: +7 (900) 111-22-33";

            return errorMessage;
        }

        /// <summary>
        /// Выполняет валидацию электронного адреса номера. Он должен содержать символ @ и домен
        /// после него. Длина строки не должна превышать указанного значения.
        /// </summary>
        /// <param name="email">Электронный адрес.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <returns>Строка с сообщением об ошибке.</returns>
        public static string ValidateEmail(string email, int maxLength)
        {
            var emailPattern = @"^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$";

            if (Regex.IsMatch(email, emailPattern) && email.Length < maxLength)
            {
                return null;
            }

            var errorMessage = $"Email must not exceed {maxLength} characters " +
                               $"and must contain the @ symbol. Example: none@domain.com";

            return errorMessage;
        }
    }
}

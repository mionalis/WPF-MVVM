using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace View.Model.Services
{
    internal static class ValueValidator
    {
        /// <summary>
        /// Проверяет, удовлетворяет ли количество цифр в значении требуемому числу.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="requiredNumberOfDigits">Требуемое количество цифр.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Корректное значение.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если количество цифр в значении
        /// не удовлетворяет требуемому.</exception>
        public static int AssertValueOnNumberOfDigits(
            int value,
            int requiredNumberOfDigits,
            string propertyName)
        {
            if (value == 0)
            {
                return value;
            }

            var numberOfDigitsInValue = Math.Floor(Math.Log10(value) + 1);

            if (numberOfDigitsInValue == requiredNumberOfDigits)
            {
                return value;
            }

            throw new ArgumentException(
                $"Invalid value in {propertyName}.The number of digits in value doesn't match " +
                $"the required ({requiredNumberOfDigits}).");
        }

        /// <summary>
        /// Выполняет проверку целочисленных аргументов на неположительное значение.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Корректное значение.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если значение неположительное.</exception>
        public static int AssertOnPositiveValue(int value, string propertyName)
        {
            if (value >= 0)
            {
                return value;
            }

            throw new ArgumentException( 
                $"Invalid value in {propertyName}. Only positive values are allowed.");
        }

        /// <summary>
        /// Проверяет, состоит ли строка из символов английского алфавита.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <exception cref="ArgumentException">Выбрасывается, если строка не полностью 
        /// состоит из символов английского алфавита.</exception>
        public static string AssertStringContainsOnlyLetters(string value, string propertyName)
        {
            var lettersOnlyRegexPattern = @"^[a-zA-Z]+$";

            if (Regex.IsMatch(value, lettersOnlyRegexPattern))
            {
                return value;
            }

            throw new ArgumentException($"Invalid value in {propertyName}");
        }
    }
}

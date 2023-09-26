using System;

namespace ContactsApp.Model.Services
{
    /// <summary>
    /// Реализует валидацию значений.
    /// </summary>
    internal static class ValueValidator
    {
        /// <summary>
        /// Проверяет, не превышает ли длина строки заданной величины.
        /// </summary>
        /// <param name="value">Строка.</param>
        /// <param name="maxLength">Максимальная длина строки.</param>
        /// <param name="propertyName">Название свойства.</param>
        /// <returns>Корректное значение.</returns>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки
        /// превышает заданное значение.</exception>
        public static string AssertStringOnLength(
            string value,
            int maxLength,
            string propertyName)
        {
            if (value == null)
            {
                return value;
            }

            if (value.Length > maxLength)
            {
                throw new ArgumentException($"Invalid value in {propertyName}." +
                                            $"Maximum string length exceeded: {maxLength}.");
            }

            return value;
        }
    }
}

using System;

namespace Model.Services
{
    /// <summary>
    /// Генерирует случайный телефонный контакт.
    /// </summary>
    public static class ContactFactory
    {
        /// <summary>
        /// Массив имен.
        /// </summary>
        private static readonly string[] _names = { "Anton", "Ivan", "Alexander", "Fedor" };

        /// <summary>
        /// Массив фамилий.
        /// </summary>
        private static readonly string[] _surnames = { "Gromov", "Kuzmov", "Ivanov", "Petrov" };

        /// <summary>
        /// Массив почтовых доменов.
        /// </summary>
        private static readonly string[] _emailDomains = 
            { "gmail.com", "mail.ru", "yahoo.com", "yandex.ru"};

        /// <summary>
        /// Экземпляр класса Random.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Генерирует фамилию и имя контакта. Выходной формат: "Ivanov Ivan".
        /// </summary>
        /// <returns>Строка с фамилией и именем контакта.</returns>
        private static string GenerateFullName()
        {
            var name = _names[_random.Next(_names.Length)];
            var surname = _surnames[_random.Next(_surnames.Length)];

            return $"{surname} {name}";
        }

        /// <summary>
        /// Генерирует телефонный номер контакта. Выходной формат: "89001002233".
        /// </summary>
        /// <returns>Телефонный номер контакта.</returns>
        private static string GeneratePhoneNumber()
        {
            var phoneCode = _random.Next(900, 999);
            var numbers = _random.Next(1000000, 9999999);

            return $"8{phoneCode}{numbers}";
        }

        /// <summary>
        /// Генерирует почтовый адрес контакта. 
        /// </summary>
        /// <returns>Почтовый адрес контакта.</returns>
        private static string GenerateEmail()
        {
            var surname = _surnames[_random.Next(_surnames.Length)];
            var numbers = _random.Next(1000, 99999);
            var emailDomain = _emailDomains[_random.Next(_emailDomains.Length)];

            return $"{surname}{numbers}@{emailDomain}";
        }

        /// <summary>
        /// Генерирует телефонный контакт.
        /// </summary>
        /// <returns>Телефонный контакт.</returns>
        public static Contact GenerateContact()
        {
            var contact = new Contact
            {
                FullName = GenerateFullName(),
                PhoneNumber = GeneratePhoneNumber(),
                Email = GenerateEmail()
            };

            return contact;
        }
    }
}

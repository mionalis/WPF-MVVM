using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsApp.Model;

namespace ContactsApp.Model.Services
{
    /// <summary>
    /// Генерирует случайный телефонный контакт.
    /// </summary>
    internal class ContactFactory
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
        /// Генерирует телефонный контакт.
        /// </summary>
        /// <returns>Телефонный контакт.</returns>
        public static Contact GenerateContact()
        {
            var contact = new Contact();
            contact.FullName = GenerateFullName();

            return contact;
        }
    }
}

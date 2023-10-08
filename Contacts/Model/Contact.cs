using System;

namespace Model
{
    /// <summary>
    /// Хранит информацию контакта телефонной книги.
    /// </summary>
    public class Contact : ICloneable
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        /// <param name="fullName">Фамилия и имя контакта.</param>
        /// <param name="email">Электронная почта контакта.</param>
        /// <param name="phoneNumber">Телефонный номер контакта.</param>
        public Contact(string fullName, string email, string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="Contact"/>.
        /// </summary>
        public Contact()
        {
        }

        /// <summary>
        /// Возвращает и задает фамилию и имя контакта. Формат ввода: "Ivanov Ivan".
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Возвращает и задает телефонный номер контакта. Формат ввода: "+7 (900) 111-22-33".
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Возвращает и задает электронную почту контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Создает копию объекта класса.
        /// </summary>
        /// <returns>Копия объекта.</returns>
        public object Clone()
        {
            return new Contact(FullName, Email, PhoneNumber);
        }
    }
}

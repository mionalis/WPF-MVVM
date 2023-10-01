using System;
using View.Model.Services;

namespace View.Model
{
    /// <summary>
    /// Хранит информацию контакта телефонной книги.
    /// </summary>
    internal class Contact : ICloneable
    {
        /// <summary>
        /// Фамилия и имя контакта. Формат ввода: "Ivanov Ivan".
        /// </summary>
        private string _fullName;

        /// <summary>
        /// Телефонный номер контакта. Формат ввода: "89001002233".
        /// </summary>
        private string _phoneNumber;

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
        /// Возвращает и задает электронную почту контакта.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Возвращает и задает фамилию и имя контакта. Формат ввода: "Ivanov Ivan".
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если строка не  состоит из 
        /// символов английского алфавита.</exception>
        public string FullName 
        {
            get => _fullName;

            set 
            {
                var maxFullNameLength = 100;
                _fullName = ValueValidator.AssertStringOnLength(
                    value,
                    maxFullNameLength, 
                    nameof(FullName)); 
            }
        }

        /// <summary>
        /// Возвращает и задает телефонный номер контакта. Формат ввода: "89001002233".
        /// </summary>
        /// <exception cref="ArgumentException">Выбрасывается, если длина строки превышает 
        /// заданное значение.</exception>
        public string PhoneNumber 
        {
            get => _phoneNumber;

            set
            {
                var maxPhoneNumberLength = 11;
                _phoneNumber = ValueValidator.AssertStringOnLength(
                    value, 
                    maxPhoneNumberLength, 
                    nameof(FullName));
            }
        }

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

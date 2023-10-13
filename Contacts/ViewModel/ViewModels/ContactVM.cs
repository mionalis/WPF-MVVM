using Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Model.Services;
using ViewModel.Services;

namespace ViewModel.ViewModels
{
    /// <summary>
    /// Реализует ViewModel для класса Contact.
    /// </summary>
    public class ContactVM : ObservableObject, ICloneable, IDataErrorInfo
    {
        /// <summary>
        /// Валидность введенных данных.
        /// </summary>
        private bool _isValid;

        /// <summary>
        /// Создаёт экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        /// <summary>
        /// Создаёт экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        public ContactVM()
        {
        }

        /// <summary>
        /// Возвращает и задает валидность введенных данных.
        /// </summary>
        public bool IsValid
        {
            get => _isValid;
            set
            {
                _isValid = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Возвращает сообщение об ошибке, показывающее причину отказа в данном объекте.
        /// </summary>
        public string Error => null;

        /// <summary>
        /// Возвращает и задает контакт: экземпляр класса Contact. 
        /// </summary>
        public Contact Contact { get; set; } = new Contact();

        /// <summary>
        /// Возвращает сообщение об ошибке для свойства с заданным именем.
        /// </summary>
        /// <param name="columnName">Название свойства.</param>
        /// <returns>Сообщение об ошибке.</returns>
        public string this[string columnName]
        {
            get
            {
                string error = null;
                IsValid = true;

                switch (columnName)
                {
                    case "FullName":
                    {
                        var maxFullNameLength = 100;

                        error = ValueValidator.ValidateFullName(
                            Contact.FullName,
                            maxFullNameLength);

                        break;
                    }
                    case "PhoneNumber":
                    {
                        var maxPhoneNumberLength = 50;

                        error = ValueValidator.ValidatePhoneNumber(
                            Contact.PhoneNumber,
                            maxPhoneNumberLength);

                        break;
                    }
                    case "Email":
                    {
                        var maxEmailLength = 100;

                        error = ValueValidator.ValidateEmail(Contact.Email, maxEmailLength);

                        break;
                    }
                }

                if (error != null)
                {
                    IsValid = false;
                }

                return error;
            }
        }

        /// <summary>
        /// Возвращает и задает фамилию и имя контакта. Формат ввода: "Ivanov Ivan".
        /// </summary>
        public string FullName
        {
            get => Contact.FullName;
            set
            {
                Contact.FullName = value;
            }
        }

        /// <summary>
        /// Возвращает и задает телефонный номер контакта. Формат ввода: "+7 (900) 111-22-33".
        /// </summary>
        public string PhoneNumber
        {
            get => Contact.PhoneNumber;
            set
            {
                Contact.PhoneNumber = value;
            }
        }

        /// <summary>
        /// Возвращает и задает электронную почту контакта.
        /// </summary>
        public string Email
        {
            get => Contact.Email;
            set
            {
                Contact.Email = value;
            }
        }

        /// <summary>
        /// Создает копию объекта класса.
        /// </summary>
        /// <returns>Копия объекта.</returns>
        public object Clone()
        {
            var contactClone = (Contact)Contact.Clone();
            return new ContactVM(contactClone);
        }
    }
}

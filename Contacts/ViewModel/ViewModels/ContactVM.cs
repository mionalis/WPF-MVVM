using Model;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace ViewModel.ViewModels
{
    public class ContactVM : INotifyPropertyChanged, ICloneable, IDataErrorInfo
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
        }

        public ContactVM()
        {
        }

        /// <summary>
        /// Возвращает и задает контакт: экземпляр класса Contact. 
        /// </summary>
        public Contact Contact { get; set; } = new Contact();

        /// <summary>
        /// Возвращает и задает фамилию и имя контакта. Формат ввода: "Ivanov Ivan".
        /// </summary>
        public string FullName
        {
            get => Contact.FullName;
            set
            {
                Contact.FullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        /// <summary>
        /// Возвращает и задает телефонный номер контакта. Формат ввода: "89001002233".
        /// </summary>
        public string PhoneNumber
        {
            get => Contact.PhoneNumber;
            set
            {
                Contact.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
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
                OnPropertyChanged(nameof(Email));
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = null;

                switch (columnName)
                {
                    case "FullName":
                    {
                        var maxFullNameLength = 100;

                        if (FullName.Length > maxFullNameLength)
                        {
                            error = "Error";
                        }

                        break;
                    }
                    case "PhoneNumber":
                    {
                        var pattern = @"^([+]?[\s0-9]+)?(\d{3}|[(]?[0-9]+[)])?([-]?[\s]?[0-9])+$";

                        if (!Regex.IsMatch(Contact.PhoneNumber, pattern))
                        {
                            error = "Error";
                        }

                        break;
                    }
                    case "Email":
                    {
                        var pattern = @"^[^\s@]+@([^\s@.,]+\.)+[^\s@.,]{2,}$";

                        if (!Regex.IsMatch(Contact.Email, pattern))
                        {
                            error = "Error";
                        }

                        break;
                    }
                }

                return error;
            }
        }

        public string Error => null;

        /// <summary>
        /// Срабатывает, когда объект класса изменяет значение свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged при изменении свойства.
        /// </summary>
        /// <param name="prop"></param>
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
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

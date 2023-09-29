using View.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewModel
{
    internal class ContactVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="ContactVM"/>.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public ContactVM(Contact contact)
        {
            Contact = contact;
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
    }
}

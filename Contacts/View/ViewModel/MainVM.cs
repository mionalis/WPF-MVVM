using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using View.Model.Services;
using View.ViewModel;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Реализует ViewModel для главного окна.
    /// </summary>
    internal class MainVM 
    {
        /// <summary>
        /// Команда создания контакта.
        /// </summary>
        private RelayCommand _addContactCommand;

        /// <summary>
        /// Команда принятия изменений.
        /// </summary>
        private RelayCommand _applyContactCommand;

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public ContactVM CurrentContact { get; set; } 

        /// <summary>
        /// Возвращает и задает список контактов.
        /// </summary>
        public ObservableCollection<ContactVM> Contacts { get; set; } 
            = new ObservableCollection<ContactVM>();

        /// <summary>
        /// Возвращает команду, описывающую создание контакта.
        /// </summary>
        public RelayCommand AddContactCommand
        {
            get
            {
                return _addContactCommand ??
                       (_addContactCommand = new RelayCommand(obj =>
                       {
                           var contact = new ContactVM(ContactFactory.GenerateContact());
                           CurrentContact = contact;
                       }));
            }
        }

        /// <summary>
        /// Возвращает команду, описывающую принятие изменений и добавление контакта в список.
        /// </summary>
        public RelayCommand ApplyContactCommand
        {
            get
            {
                return _applyContactCommand ??
                       (_applyContactCommand = new RelayCommand(obj =>
                       {
                           Contacts.Add(CurrentContact);
                       }));
            }
        }
    }
}

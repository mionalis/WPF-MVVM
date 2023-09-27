using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ContactsApp.Model.Services;
using ContactsApp.ViewModel;
using ContactsApp.Model;
using ContactsApp.Model.Services;

namespace ContactsApp.ViewModel
{
    /// <summary>
    /// Реализует ViewModel для главного окна.
    /// </summary>
    internal class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// 
        /// </summary>
        private RelayCommand _addContactCommand;

        private RelayCommand _applyContactCommand;

        /// <summary>
        /// Возвращает и задает контакт: экземпляр класса Contact. 
        /// </summary>
        public ContactVM CurrentContact { get; set; } 

        public ObservableCollection<ContactVM> Contacts { get; set; } 
            = new ObservableCollection<ContactVM>();

        /// <summary>
        /// 
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

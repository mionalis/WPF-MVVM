using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Реализует ViewModel для главного окна.
    /// </summary>
    internal class MainVM : ObservableObject
    {
        /// <summary>
        /// Создаёт экземпляр класса <see cref="MainVM"/>.
        /// </summary>
        public MainVM()
        {
            Contacts = ContactSerializer.Load() ?? new ObservableCollection<ContactVM>();

            AddContactCommand = new RelayCommand(AddContact);
            ApplyContactCommand = new RelayCommand(ApplyContact);
            EditContactCommand = new RelayCommand(EditContact);
            RemoveContactCommand = new RelayCommand(RemoveContact);
        }

        /// <summary>
        /// Текущий контакт.
        /// </summary>
        private ContactVM _currentContact;

        /// <summary>
        /// Видимость объекта.
        /// </summary>
        private bool _isVisible;

        /// <summary>
        /// Доступность редактирования текстового поля.
        /// </summary>
        private bool _isReadOnly;

        /// <summary>
        /// Доступность объекта.
        /// </summary>
        private bool _isEnabled;

        /// <summary>
        /// Возвращает и задает индекс текущего контакта в списке <see cref="Contacts"/>.
        /// </summary>
        private int CurrentContactIndex { get; set; }

        /// <summary>
        /// Возвращает и задает копию объекта класса <see cref="ContactVM"/>.
        /// </summary>
        private ContactVM ContactClone { get; set; }

        /// <summary>
        /// Возвращает команду создания контакта.
        /// </summary>
        public ICommand AddContactCommand { get; }

        /// <summary>
        /// Возвращает команду редактирования контакта.
        /// </summary>
        public ICommand EditContactCommand { get; }

        /// <summary>
        /// Возвращает команду удаления контакта из списка.
        /// </summary>
        public ICommand RemoveContactCommand { get; }

        /// <summary>
        /// Возвращает команду добавления контакта в список.
        /// </summary>
        public ICommand ApplyContactCommand { get; }

        /// <summary>
        /// Возвращает и задает доступ к редактированию контакта.
        /// </summary>
        public bool IsEdit { get; private set; }

        /// <summary>
        /// Возвращает и задает список контактов.
        /// </summary>
        public ObservableCollection<ContactVM> Contacts { get; set; }

        /// <summary>
        /// Возвращает и задает доступность объекта.
        /// </summary>
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Возвращает и задает видимость объекта.
        /// </summary>
        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Возвращает и задает доступ к редактированию объекта.
        /// </summary>
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public ContactVM CurrentContact
        {
            get => _currentContact;
            set
            {
                _currentContact = value;

                if (
                    _currentContact != null && 
                    Contacts != null &&
                    Contacts.IndexOf(_currentContact) != -1)
                {
                    IsEnabled = true;
                    CurrentContactIndex = Contacts.IndexOf(_currentContact);
                }

                IsVisible = false;
                IsReadOnly = true;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Описывает команду создания контакта.
        /// </summary>
        public void AddContact()
        {
            var contact = new ContactVM(ContactFactory.GenerateContact());
            CurrentContact = contact;
            EnableEditMode();
        }

        /// <summary>
        /// Описывает команду редактирования контакта.
        /// </summary>
        public void EditContact()
        {
            IsEdit = true;
            ContactClone = CurrentContact;
            CurrentContact = (ContactVM)ContactClone.Clone();
            EnableEditMode();
        }

        /// <summary>
        /// Описывает команду удаления контакта.
        /// </summary>
        public void RemoveContact()
        {
            Contacts.RemoveAt(CurrentContactIndex);

            if (Contacts.Count == 0)
            {
                CurrentContact = null;
            }
            else if (CurrentContactIndex == Contacts.Count)
            {
                CurrentContact = Contacts[CurrentContactIndex - 1];
            }
            else
            {
                CurrentContact = Contacts[CurrentContactIndex];
            }

            IsEnabled = false;
            ContactSerializer.Save(Contacts);
        }

        /// <summary>
        /// Описывает команду принятия изменений и добавления контакта в список.
        /// </summary>
        public void ApplyContact()
        {
            if (IsEdit)
            {
                Contacts[CurrentContactIndex] = CurrentContact;
                ContactClone = null;
                CurrentContact = null;
            }
            else
            {
                Contacts.Add(CurrentContact);
                CurrentContactIndex = Contacts.IndexOf(CurrentContact);
                CurrentContact = null;
            }

            EnableReadMode();

            ContactSerializer.Save(Contacts);
        }

        /// <summary>
        /// Переводит приложение в режим редактирования (выключает кнопки Edit и Remove,
        /// выводит текстовые поля из режима чтения, показывает кнопку Apply).
        /// </summary>
        private void EnableEditMode()
        {
            IsVisible = true;
            IsReadOnly = false;
            IsEnabled = false;
        }

        /// <summary>
        /// Переводит приложение в режим чтения (скрывает кнопку Apply, переводит текстовые поля
        /// в режим чтения, выключает кнопки Edit и Remove). 
        /// </summary>
        private void EnableReadMode()
        {
            IsVisible = false;
            IsReadOnly = true;
            IsEdit = false;
            IsEnabled = false;
        }
    }
}


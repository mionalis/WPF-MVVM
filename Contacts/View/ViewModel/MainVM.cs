using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Windows.Input;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Реализует ViewModel для главного окна.
    /// </summary>
    internal class MainVM : ObservableObject
    {
        public MainVM()
        {
            AddContactCommand = new RelayCommand(AddContact);
            ApplyContactCommand = new RelayCommand(ApplyContact);
            EditContactCommand = new RelayCommand(EditContact);
            RemoveContactCommand = new RelayCommand(RemoveContact);
        }

        private ContactVM _currentContact;

        private bool _isVisible;

        private bool _isReadOnly;

        private bool _isEnabled;

        private int CurrentContactIndex { get; set; }

        private ContactVM ContactClone { get; set; }

        public ICommand AddContactCommand { get; }

        public ICommand EditContactCommand { get; }

        public ICommand ApplyContactCommand { get; }

        public ICommand RemoveContactCommand { get; }

        public bool IsEdit { get; set; }

        /// <summary>
        /// Возвращает и задает список контактов.
        /// </summary>
        public ObservableCollection<ContactVM> Contacts { get; set; }
            = new ObservableCollection<ContactVM>();

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool IsVisible
        {
            get => _isVisible;
            set
            {
                _isVisible = value;
                OnPropertyChanged();
            }
        }

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

                if (_currentContact != null && Contacts.IndexOf(_currentContact) != -1)
                {
                    IsEnabled = true;
                    CurrentContactIndex = Contacts.IndexOf(_currentContact);
                }

                IsVisible = false;
                IsReadOnly = true;
                OnPropertyChanged();
            }
        }

        public void AddContact()
        {
            var contact = new ContactVM(ContactFactory.GenerateContact());
            CurrentContact = contact;
            IsVisible = true;
            IsReadOnly = false;
            IsEnabled = false;
        }

        public void EditContact()
        {
            IsEdit = true;
            ContactClone = CurrentContact;
            CurrentContact = (ContactVM)ContactClone.Clone();
            IsVisible = true;
            IsReadOnly = false;
        }

        public void RemoveContact()
        {
            if (CurrentContact == null)
            {
                return;
            }

            Contacts.RemoveAt(CurrentContactIndex);
            IsEnabled = false;
        }

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

            IsVisible = false;
            IsReadOnly = true;
            IsEdit = false;
            IsEnabled = false;
        }
    }
}


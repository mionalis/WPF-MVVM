using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using View.Model.Services;
using View.ViewModel;
using View.Model;
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

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
        }

        private ContactVM _currentContact;

        private bool _isVisible;

        private bool _isReadOnly;

        public bool isVisible
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

        public ICommand AddContactCommand { get; }

        public ICommand ApplyContactCommand { get; }

        /// <summary>
        /// Возвращает и задает текущий контакт.
        /// </summary>
        public ContactVM CurrentContact
        {
            get => _currentContact;
            set
            {
                _currentContact = value;
                OnPropertyChanged();
            }
        } 

        /// <summary>
        /// Возвращает и задает список контактов.
        /// </summary>
        public ObservableCollection<ContactVM> Contacts { get; set; }
            = new ObservableCollection<ContactVM>();

        public void AddContact()
        {
            CurrentContact = null;
            var contact = new ContactVM(ContactFactory.GenerateContact());
            CurrentContact = contact;
            isVisible = true;
            IsReadOnly = false;
        }

        public void ApplyContact()
        {
            Contacts.Add(CurrentContact);
            CurrentContact = null;
            isVisible = false;
            IsReadOnly = true;
        }
    }
}


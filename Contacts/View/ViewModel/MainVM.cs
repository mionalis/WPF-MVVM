using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using View.Model.Services;
using View.ViewModel;
using View.Model;
﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Reflection;

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

        private int CurrentContactIndex { get; set; }

        private ContactVM ContactClone { get; set; }

        private bool IsEdit { get; set; }

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

        public ICommand AddContactCommand { get; }

        public ICommand EditContactCommand { get; }

        public ICommand ApplyContactCommand { get; }

        public ICommand RemoveContactCommand { get; }

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
            IsVisible = true;
            IsReadOnly = false;
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
        }

        public void ApplyContact()
        {
            if (IsEdit)
            {
                Contacts[CurrentContactIndex] = CurrentContact;
                ContactClone = null;
                IsEdit = false;
            }
            else
            {
                Contacts.Add(CurrentContact);
                CurrentContactIndex = Contacts.IndexOf(CurrentContact);
                CurrentContact = null;
                IsEdit = false;
                IsVisible = false;
                IsReadOnly = true;
            }
        }
    }
}


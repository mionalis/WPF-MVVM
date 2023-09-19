﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using View.Model;
using View.Model.Services;

namespace View.ViewModel
{
    /// <summary>
    /// Реализует ViewModel для главного окна.
    /// </summary>
    internal class MainVM : INotifyPropertyChanged
    {
        /// <summary>
        /// Команда сохранения контакта в файл.
        /// </summary>
        private RelayCommand _saveCommand;

        /// <summary>
        /// Команда загрузки сохраненного контакта из файла.
        /// </summary>
        private RelayCommand _loadCommand;

        /// <summary>
        /// Возвращает и задает контакт: экземпляр класса Contact. 
        /// </summary>
        public Contact Contact { get; set; } = new Contact();

        /// <summary>
        /// Возвращает команду сохранения контакта в файл.
        /// </summary>
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new RelayCommand(obj =>
                       {
                           ContactSerializer.Save(Contact);
                       }));
            }
        }

        /// <summary>
        /// Возвращает команду загрузки сохраненного контакта из файла.
        /// </summary>
        public RelayCommand LoadCommand
        {
            get
            {
                return _loadCommand ??
                       (_loadCommand = new RelayCommand(obj =>
                       {
                           var contact = ContactSerializer.Load();
                           FullName = contact.FullName;
                           Email = contact.Email;
                           PhoneNumber = contact.PhoneNumber;
                       }));
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

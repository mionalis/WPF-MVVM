using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.IO;
using ViewModel.ViewModels;

namespace ViewModel.Services
{
    /// <summary>
    /// Выполняет сохранение и загрузку одного объекта контакта из файла.
    /// </summary>
    public static class ContactSerializer
    {
        /// <summary>
        /// Возвращает путь файла, в котором будут храниться сериализованные данные.
        /// </summary>
        private static string Path =>
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\contacts.json";

        /// <summary>
        /// Сохраняет список контактов в файл по заданному пути.
        /// </summary>
        /// <param name="contacts">Список контактов.</param>
        public static void Save(ObservableCollection<ContactVM> contacts)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
            }

            var serializedItems = JsonConvert.SerializeObject(contacts);
            File.WriteAllText(Path, serializedItems);
        }

        /// <summary>
        /// Выполняет загрузку списка контактов из файла по заданному пути. 
        /// </summary>
        /// <returns> Список контактов.</returns>
        public static ObservableCollection<ContactVM> Load()
        {
            var contacts = new ObservableCollection<ContactVM>();

            if (!File.Exists(Path))
            {
                return contacts;
            }

            using (var streamReader = new StreamReader(Path))
            {
                var readContacts = streamReader.ReadToEnd();
                contacts = 
                    JsonConvert.DeserializeObject<ObservableCollection<ContactVM>>(readContacts);
            }

            return contacts;
        }
    }
}

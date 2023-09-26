using Newtonsoft.Json;
using System;
using System.IO;

namespace ContactsApp.Model.Services
{
    /// <summary>
    /// Выполняет сохранение и загрузку одного объекта контакта из файла.
    /// </summary>
    internal static class ContactSerializer
    {
        /// <summary>
        /// Возвращает путь файла, в котором будут храниться сериализованные данные.
        /// </summary>
        private static string Path =>
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\contacts.json";

        /// <summary>
        /// Сохраняет объект контакта в файл по заданному пути.
        /// </summary>
        /// <param name="contact">Контакт.</param>
        public static void Save(Contact contact)
        {
            var json = JsonConvert.SerializeObject(contact, Formatting.Indented);
            File.WriteAllText(Path, json);
        }

        /// <summary>
        /// Выполняет загрузку объекта контакта из файла по заданному пути. 
        /// </summary>
        /// <returns> Объект контакта.</returns>
        public static Contact Load()
        {
            var contact = new Contact();

            if (File.Exists(Path))
            {
                var jsonFileContents = File.ReadAllText(Path);
                contact = JsonConvert.DeserializeObject<Contact>(jsonFileContents);
            }

            return contact;
        }
    }
}

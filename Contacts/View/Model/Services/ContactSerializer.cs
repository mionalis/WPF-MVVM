using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace View.Model.Services
{
    internal static class ContactSerializer
    {
        private static string Path =>
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\contacts.json";

        public static void Save(Contact contact)
        {
            var json = JsonConvert.SerializeObject(contact, Formatting.Indented);
            File.WriteAllText(Path, json);
        }

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

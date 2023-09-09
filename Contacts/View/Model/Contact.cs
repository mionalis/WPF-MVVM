using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Model
{
    internal class Contact
    {
        private string _fullName;

        private string _email;

        private int _phoneNumber;

        public Contact(string fullName, string email, int phoneNumber)
        {
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public Contact()
        {

        }

        public string FullName 
        {
            get { return _fullName; }

            set 
            {
                _fullName = value; 
            }
        }

        public string Email 
        {
            get { return _email; } 

            set
            { 
                _email = value; 
            }
        }

        public int PhoneNumber 
        { 
            get { return _phoneNumber; }

            set
            {
                _phoneNumber = value;
            }
        }
    }
}

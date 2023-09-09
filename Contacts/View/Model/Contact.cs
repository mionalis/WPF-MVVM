using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using View.Model.Services;

namespace View.Model
{
    internal class Contact
    {
        private string _fullName;

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

        public string Email { get; set; }

        public string FullName 
        {
            get { return _fullName; }

            set 
            {
                _fullName =
                    ValueValidator.AssertStringContainsOnlyLetters(value, nameof(FullName)); 
            }
        }

        public int PhoneNumber 
        { 
            get { return _phoneNumber; }

            set
            {
                _phoneNumber = 
                    ValueValidator.AssertValueOnNumberOfDigits(value, 11, nameof(PhoneNumber));
                _phoneNumber = ValueValidator.AssertOnPositiveValue(value, nameof(PhoneNumber));
            }
        }
    }
}

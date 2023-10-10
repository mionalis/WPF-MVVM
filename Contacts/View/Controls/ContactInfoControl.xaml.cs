using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace View.Controls
{
    /// <summary>
    /// Логика взаимодействия для ContactInfoControl.xaml
    /// </summary>
    public partial class ContactInfoControl : UserControl
    {
        public ContactInfoControl()
        {
            InitializeComponent();
        }

        public string PhoneNumberPattern => @"[\+\-\(\)\d]";

        private void PhoneNumberTextBox_PreviewInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, PhoneNumberPattern))
            {
                e.Handled = true;
            }
        }

        private void PhoneNumberTextBox_OnPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var enteredText = (string)e.DataObject.GetData(typeof(string));

                if (!Regex.IsMatch(enteredText, PhoneNumberPattern))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}

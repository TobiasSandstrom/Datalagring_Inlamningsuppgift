using Datalagring_Casehandler.Entities;
using Datalagring_Casehandler.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Datalagring_Casehandler.Views
{
    public partial class CustomersView : UserControl, INotifyPropertyChanged
    {

        Customer_Service _customerService = new();
        public event PropertyChangedEventHandler? PropertyChanged;
       
        private void Property_Changed(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


        public CustomersView()
        {
            InitializeComponent();
            cbCustomers.SelectedValuePath = "Key";
            cbCustomers.DisplayMemberPath = "Value";
            if (FillCustomers() == false)
            {
                lbCustomerError.Visibility = Visibility.Visible;
                lbCustomerError.Content = "Det finns inga ärenden i databasen";
            }
            else
            {
                lbCustomerError.Visibility = Visibility.Collapsed;
                lbCustomerError.Content = "";
            }

            this.DataContext = this;
        }

        //Funktion som fyller upp comboboxen med kunderna
        private bool FillCustomers()
        {
            cbCustomers.Items.Clear();

            foreach (var item in _customerService.ListAllCustomers())
                cbCustomers.Items.Add(new KeyValuePair<int, string>(item.Id, $"Kundnummer: {item.Id} || Namn: {item.FirstName} {item.LastName} || Personnummer: {item.SocialSecurityNumber}"));

            if (cbCustomers.Items.Count > 0)
            {
                return true;

            }
            return false;

        }

        //Funktion som sätter variablernas värde till det av valet ifrån listan
        public void SetCustomer(Customer _customer)
        {
            FullName = $"{_customer.FirstName} {_customer.LastName}";
            SocialSecurityNumber = _customer.SocialSecurityNumber;
            Email = _customer.Contact.Email;
            PhoneNumber = _customer.Contact.PhoneNumber;
            Adress = _customer.Adress.StreetAdress;
            ZipcodeCity = $"{_customer.Adress.ZipCode}, {_customer.Adress.City}";
            Country = _customer.Adress.Country;

        }
        // Knappen
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Customer _customer = new();
            if (cbCustomers.SelectedValue != null)
            {
                _customer = _customerService.ListOne((int)cbCustomers.SelectedValue);


                if (_customer != null)
                {

                    lbCustomerError.Visibility = Visibility.Collapsed;
                    lbCustomerError.Content = "";
                    SetCustomer(_customer);


                }
                else
                {
                    lbCustomerError.Visibility = Visibility.Visible;
                    lbCustomerError.Content = "";
                }

            }
            else
            {

                lbCustomerError.Content = "Du måste välja från menyerna ovan";
                lbCustomerError.Visibility = Visibility.Visible;
            }
        }

        // Variabler
        #region

        private string _FullName;
        public string FullName
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                Property_Changed("FullName");
            }
        }

        private string _SocialSecurityNumber;
        public string SocialSecurityNumber
        {
            get { return _SocialSecurityNumber; }
            set
            {
                _SocialSecurityNumber = value;
                Property_Changed("SocialSecurityNumber");
            }
        }
        private string _Email;
        public string Email
        {
            get { return _Email; }
            set
            {
                _Email = value;
                Property_Changed("Email");
            }
        }

        private string _PhoneNumber;
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                _PhoneNumber = value;
                Property_Changed("PhoneNumber");
            }
        }

        private string _Adress;
        public string Adress
        {
            get { return _Adress; }
            set
            {
                _Adress = value;
                Property_Changed("Adress");
            }
        }

        private string _ZipcodeCity;
        public string ZipcodeCity
        {
            get { return _ZipcodeCity; }
            set
            {
                _ZipcodeCity = value;
                Property_Changed("ZipcodeCity");
            }
        }

        private string _Country;
        public string Country
        {
            get { return _Country; }
            set
            {
                _Country = value;
                Property_Changed("Country");
            }
        }

        #endregion
    }
}

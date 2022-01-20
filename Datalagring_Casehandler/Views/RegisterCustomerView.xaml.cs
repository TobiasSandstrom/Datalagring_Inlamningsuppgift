using Datalagring_Casehandler.Entities;
using Datalagring_Casehandler.Models;
using Datalagring_Casehandler.Services;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for RegisterCustomerView.xaml
    /// </summary>
    public partial class RegisterCustomerView : UserControl
    {
        Customer_Service _cs = new();
        public RegisterCustomerView()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text != "" && tbLastName.Text != "" && tbSocialSecurityNumber.Text != "" && tbPhoneNumber.Text != "" && tbEmail.Text != "" && tbStreetAddress.Text != "" && tbZipCode.Text != "" && tbCity.Text != "" && tbCountry.Text != "")
            {
                if (tbSocialSecurityNumber.Text.Count() == 12)
                {
                    var customer = new CustomerModel()
                    {
                        FirstName = tbFirstName.Text,
                        LastName = tbLastName.Text,
                        SocalSecurityNumber = tbSocialSecurityNumber.Text,
                        PhoneNumber = tbPhoneNumber.Text,
                        Email = tbEmail.Text,
                        StreetAddress = tbStreetAddress.Text,
                        ZipCode = tbZipCode.Text,
                        City = tbCity.Text,
                        Country = tbCountry.Text
                    };
                    if (_cs.Create(customer) == true)
                    {
                        Clear();
                        lbError.Content = "";
                        lbSuccess.Content = "Kund Registrerad";
                    }
                    else
                    {
                        lbError.Content = "En kund med det personnummret finns redan registrerad";
                        lbSuccess.Content = "";
                    }
                }
                else
                {
                    lbError.Content = "Personnummret är ifyllt fel";
                    lbSuccess.Content = "";
                }
                
            }
            else
            {
                lbError.Content = "Du måste fylla i alla fälten";
                lbSuccess.Content = "";
            }
        }

        private void Clear()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbSocialSecurityNumber.Text = "";
            tbPhoneNumber.Text = "";
            tbEmail.Text = "";
            tbStreetAddress.Text = "";
            tbZipCode.Text = "";
            tbCity.Text = "";
            tbCountry.Text = "";
        }
    }
}

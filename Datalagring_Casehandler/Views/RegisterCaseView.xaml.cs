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
    public partial class RegisterCaseView : UserControl
    {
        CaseManager_Service _managerService = new();
        Case_Service _caseService = new();
        Customer_Service _customerService = new();

        public RegisterCaseView()
        {
            InitializeComponent();
            
            
            tbHandler.SelectedValuePath = "Key";
            tbHandler.DisplayMemberPath = "Value";
            if (FillManager() == false)
            {
                lbManagerError.Visibility = Visibility.Visible;
            }
            else
            {
                lbManagerError.Visibility = Visibility.Collapsed;
            }

            tbStatus.SelectedValuePath = "Key";
            tbStatus.DisplayMemberPath = "Value";
            if (FillStatus() == false)
            {
                lbStatusError.Visibility = Visibility.Visible;
            }
            else
            {
                lbStatusError.Visibility = Visibility.Collapsed;
            }

            tbCustomer.SelectedValuePath = "Key";
            tbCustomer.DisplayMemberPath = "Value";
            if (FillCustomer() == false)
            {
                lbCustomerError.Visibility = Visibility.Visible;
            }
            else
            {
                lbCustomerError.Visibility = Visibility.Collapsed;
            }
        }

        //Knappen
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbHeader.Text != "" && tbDescription.ToString() != "" && tbHandler.SelectedValue != null && tbStatus.SelectedValue != null && tbCustomer.SelectedValue != null)
            {
                string _description = ConvertRichTextBox(tbDescription);
                CaseModel model = new()
                {
                    Header = tbHeader.Text,
                    Description = _description,
                    HandlerID = (int)tbHandler.SelectedValue,
                    StatusID = (int)tbStatus.SelectedValue,
                    CustomerID = (int)tbCustomer.SelectedValue
                };
                _caseService.Create(model);
                lbSuccess.Content = "Ärende registrerat";
                lbError.Content = "";
                Clear();
            }
            else
            {
                lbSuccess.Content = "";
                lbError.Content = "Du måste ange värden på alla rader";
            }
        }

        //Konverterar texten i en RichTextBox till en string
        string ConvertRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                rtb.Document.ContentStart,
                rtb.Document.ContentEnd
            );
            return textRange.Text;
        }

        //Fyller upp hanterarna i comboboxen
        private bool FillManager()
        {
            tbHandler.Items.Clear();
           
                foreach (var item in _managerService.ListAllManagers())
                    tbHandler.Items.Add(new KeyValuePair<int, string>(item.Id, $"{item.FirstName} {item.LastName}"));

            if (tbHandler.Items.Count > 0)
            {
                return true;

            }
            return false;           
            
        }

        //Fyller upp statusarna i comboboxen
        private bool FillStatus()
        {
            tbStatus.Items.Clear();

            foreach (var item in _caseService.ListAllStatuses())
                tbStatus.Items.Add(new KeyValuePair<int, string>(item.Id, item.Status));

            if (tbStatus.Items.Count > 0)
            {
                return true;

            }
            return false;

        }

        //Fyller upp kunderna i comboboxen
        private bool FillCustomer()
        {
            tbCustomer.Items.Clear();

            foreach (var item in _customerService.ListAllCustomers())
                tbCustomer.Items.Add(new KeyValuePair<int, string>(item.Id, $"Kundnummer: {item.Id} || Namn: {item.FirstName} {item.LastName} || Personnummer: {item.SocialSecurityNumber}"));

            if (tbCustomer.Items.Count > 0)
            {
                return true;

            }
            return false;

        }
        

        private void Clear()
        {
            tbHeader.Text = "";
            tbDescription.Document.Blocks.Clear();
            tbHandler.Text = "";
            tbStatus.Text = "";
            tbCustomer.Text = "";
        }
    }
}

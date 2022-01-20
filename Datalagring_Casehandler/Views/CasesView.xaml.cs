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


    public partial class CasesView : UserControl, INotifyPropertyChanged
    {

        public string Header { get; set; } = "bsgfjsfafja";
        public string Description { get; set; }
        public string CustomerNameSocial { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }
        public string CaseHandler { get; set; }
        public string CaseStatus { get; set; }
        public string CaseCreated { get; set; }
        public string CaseChanged { get; set; }

        Case_Service _caseService = new();

        public event PropertyChangedEventHandler? PropertyChanged;

        public CasesView()
        {
            
            InitializeComponent();
            cbCases.SelectedValuePath = "Key";
            cbCases.DisplayMemberPath = "Value";
            if (FillCases() == false)
            {
                lbCaseError.Visibility = Visibility.Visible;
                lbCaseError.Content = "Det finns inga ärenden i databasen";
            }
            else
            {
                lbCaseError.Visibility = Visibility.Collapsed;
                lbCaseError.Content = "";
            }

            this.DataContext = this;
            
        }

        private bool FillCases()
        {
            cbCases.Items.Clear();

            foreach (var item in _caseService.ListAllCases())
                cbCases.Items.Add(new KeyValuePair<int, string>(item.Id, $"Ärendenummer: {item.Id} || Rubrik: {item.CaseHeader} || Status: {item.Status.Status} || Kund: {item.Customer.FirstName} {item.Customer.LastName} {item.Customer.SocialSecurityNumber}"));

            if (cbCases.Items.Count > 0)
            {
                return true;

            }
            return false;

        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Case _case = new();
            if (cbCases.SelectedValue != null)
            {
                _case = _caseService.ListOne((int)cbCases.SelectedValue);


                if (_case != null)
                {

                    lbCaseError.Visibility = Visibility.Collapsed;
                    lbCaseError.Content = "";
                    SetCase(_case);
                    this.DataContext = this;
                    
                }
                else
                {
                    lbCaseError.Visibility = Visibility.Visible;
                    lbCaseError.Content = "Ärendet har redan den statusen";
                }

            }
            else
            {
                
                lbCaseError.Content = "Du måste välja från menyerna ovan";
                lbCaseError.Visibility = Visibility.Visible;
            }
        }
        public void SetCase(Case _case)
        {
            Header = _case.CaseHeader;
            
            Description = _case.CaseDescription;
            CustomerNameSocial = $"{_case.Customer.FirstName} {_case.Customer.LastName}  ||  {_case.Customer.SocialSecurityNumber}";
            CustomerAddress = $"{_case.Customer.Adress.StreetAdress} {_case.Customer.Adress.ZipCode} {_case.Customer.Adress.City}, {_case.Customer.Adress.Country}";
            CustomerContact = $"{_case.Customer.Contact.Email}  ||  {_case.Customer.Contact.PhoneNumber}";
            CaseHandler = $"{_case.Manager.FirstName} {_case.Manager.LastName}";
            CaseStatus = $"Ärende status : {_case.Status.Status}";
            CaseCreated = $"Skapad: {_case.CaseCreated}";
            CaseChanged = $"Senast ändrad: {_case.CaseLastChanged}";

        }
    }
}

    


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
        

        Case_Service _caseService = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        private void Property_Changed(string prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

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

        //Funktion som fyller upp comboboxen med kunderna
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

        //Funktion som sätter variablernas värde till det av valet ifrån listan
        public void SetCase(Case _case)
        {
            Header = _case.CaseHeader;
            Description = _case.CaseDescription.ToString();
            CustomerNameSocial = $"{_case.Customer.FirstName} {_case.Customer.LastName},  {_case.Customer.SocialSecurityNumber}";
            CustomerAddress = $"{_case.Customer.Adress.StreetAdress}";
            CustomerZipCodeCity = $"{_case.Customer.Adress.ZipCode}, {_case.Customer.Adress.City} " ;
            CustomerCountry = $"{_case.Customer.Adress.Country}";
            CustomerContact = $"{_case.Customer.Contact.Email},  {_case.Customer.Contact.PhoneNumber}";
            CaseHandler = $"{_case.Manager.FirstName} {_case.Manager.LastName}";
            CaseStatus = $"Ärende status : {_case.Status.Status}";
            DateCreated = $"Skapad: {_case.CaseCreated.ToShortDateString()}";

            DateTime _date = new DateTime();
            if (_case.CaseLastChanged != null)
            {
                _date = _case.CaseLastChanged.Value;
                DateChanged = $"Senast ändrad: {_date.ToShortDateString()}";
            }
        }


        //Knappen
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
                    
                    
                }
                else
                {
                    lbCaseError.Visibility = Visibility.Visible;
                    lbCaseError.Content = "";
                }

            }
            else
            {
                
                lbCaseError.Content = "Du måste välja från menyerna ovan";
                lbCaseError.Visibility = Visibility.Visible;
            }
        }
        

        //Variabler
        #region
        private string _Header;
        public string Header
        {
            get { return _Header; }
            set
            {
                _Header = value;
                Property_Changed("Header");
            }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                Property_Changed("Description");
            }
        }

        private string _CustomerNameSocial;
        public string CustomerNameSocial
        {
            get { return _CustomerNameSocial; }
            set
            {
                _CustomerNameSocial = value;
                Property_Changed("CustomerNameSocial");
            }
        }

        private string _CustomerContact;
        public string CustomerContact
        {
            get { return _CustomerContact; }
            set
            {
                _CustomerContact = value;
                Property_Changed("CustomerContact");
            }
        }

        private string _CustomerAddress;
        public string CustomerAddress
        {
            get { return _CustomerAddress; }
            set
            {
                _CustomerAddress = value;
                Property_Changed("CustomerAddress");
            }
        }

        private string _CaseHandler;
        public string CaseHandler
        {
            get { return _CaseHandler; }
            set
            {
                _CaseHandler = value;
                Property_Changed("CaseHandler");
            }
        }


        private string _CaseStatus;
        public string CaseStatus
        {
            get { return _CaseStatus; }
            set
            {
                _CaseStatus = value;
                Property_Changed("CaseStatus");
            }
        }


        private string _DateCreated;
        public string DateCreated
        {
            get { return _DateCreated; }
            set
            {
                _DateCreated = value;
                Property_Changed("DateCreated");
            }
        }

        private string _DateChanged;
        public string DateChanged
        {
            get { return _DateChanged; }
            set
            {
                _DateChanged = value;
                Property_Changed("DateChanged");
            }
        }

        private string _CustomerCountry;
        public string CustomerCountry
        {
            get { return _CustomerCountry; }
            set
            {
                _CustomerCountry = value;
                Property_Changed("CustomerCountry");
            }
        }

        private string _CustomerZipCodeCity;
        public string CustomerZipCodeCity
        {
            get { return _CustomerZipCodeCity; }
            set
            {
                _CustomerZipCodeCity = value;
                Property_Changed("CustomerZipCodeCity");
            }
        }
        #endregion
    }
}

    


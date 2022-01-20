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
 
    public partial class EditCaseView : UserControl
    {
        Case_Service _caseService = new();

        public EditCaseView()
        {
            InitializeComponent();

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

            tbCase.SelectedValuePath = "Key";
            tbCase.DisplayMemberPath = "Value";
            if (FillCases() == false)
            {
                lbCaseError.Visibility = Visibility.Visible;
            }
            else
            {
                lbCaseError.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbCase.SelectedValue != null && tbStatus.SelectedValue != null)
            {
                if (_caseService.ChangeStatus((int)tbCase.SelectedValue, (int)tbStatus.SelectedValue) == true)
                {
                    lbChangeSuccess.Content = "Ärendets status har ändrats";
                    lbChangeError.Content = "";
                    FillCases();
                    Clear();
                }
                else
                {
                    lbChangeSuccess.Content = "";
                    lbChangeError.Content = "Ärendet har redan den statusen";
                }
                
            }
            else
            {
                lbChangeSuccess.Content = "";
                lbChangeError.Content = "Du måste välja från menyerna ovan";
            }
        }


        private bool FillCases()
        {
            tbCase.Items.Clear();

            foreach (var item in _caseService.ListAllCases())
                tbCase.Items.Add(new KeyValuePair<int, string>(item.Id, $"Ärendenummer: {item.Id} || Rubrik: {item.CaseHeader} || Status: {item.Status.Status} || Kund: {item.Customer.FirstName} {item.Customer.LastName} {item.Customer.SocialSecurityNumber}"));

            if (tbCase.Items.Count > 0)
            {
                return true;

            }
            return false;

        }

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

        private void Clear()
        {
            tbCase.Text = "";
            tbStatus.Text = "";
        }
    }
}

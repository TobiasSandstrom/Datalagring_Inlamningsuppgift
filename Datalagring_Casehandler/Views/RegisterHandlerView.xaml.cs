using Datalagring_Casehandler.Entities;
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
    /// Interaction logic for RegisterHandlerView.xaml
    /// </summary>
    public partial class RegisterHandlerView : UserControl
    {
        private CaseManager_Service _caseManager = new CaseManager_Service();
        private Case_Service _caseService = new Case_Service();

        public RegisterHandlerView()
        {
            InitializeComponent();
        }

        private void BtnManagerSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbFirstName.Text != "" && tbLastName.Text != "")
            {
                var manager = new Casemanager()
                {
                    FirstName = tbFirstName.Text,
                    LastName = tbLastName.Text
                };
                if (_caseManager.Create(manager) == true)
                {
                    Clear();
                    lbManagerSuccess.Content = "Handläggaren registrerad";
                    lbManagerError.Content = "";
                }
                else
                {
                    lbManagerSuccess.Content = "";
                    lbManagerError.Content = "Handläggaren finns redan registrerad";
                } 
            }
            else
            {
                lbManagerError.Content = "Du måste fylla i alla fälten";
                lbManagerSuccess.Content = "";
            }
        }
        
        
        private void BtnStatusSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbStatus.Text != "")
            {
                var status = new CaseStatus()
                {
                    Status = tbStatus.Text
                };
                
                if (_caseService.CreateStatus(status) == true)
                {
                    Clear();
                    lbStatusSuccess.Content = "Status registrerad";
                    lbStatusError.Content = "";
                }
                else
                {
                    lbStatusSuccess.Content = "";
                    lbStatusError.Content = "Statusen finns redan registrerad";
                }
            }
            else
            {
                lbStatusSuccess.Content = "";
                lbStatusError.Content = "Du måste fylla i fältet";
            }
        }
        public void Clear()
        {
            tbFirstName.Text = "";
            tbLastName.Text = "";
            tbStatus.Text = "";
        }
    }
}

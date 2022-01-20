using Datalagring_Casehandler.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_Casehandler.Models.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        private object _currentView;

        public MainViewModel()
        {
            CasesViewModel = new CasesViewModel();
            CustomersViewModel = new CustomersViewModel();
            EditCaseViewModel = new EditCaseViewModel();
            HomepageViewModel = new HomepageViewModel();
            RegisterCustomerViewModel = new RegisterCustomerViewModel();
            RegisterCaseViewModel = new RegisterCaseViewModel();
            RegisterHandlerViewModel = new RegisterHandlerViewModel();
            CurrentView = HomepageViewModel;

            CasesViewCommand = new RelayCommand(x => CurrentView = CasesViewModel);
            CustomersViewCommand = new RelayCommand(x => CurrentView = CustomersViewModel);
            EditCaseViewCommand = new RelayCommand(x => CurrentView = EditCaseViewModel);
            HomepageViewCommand = new RelayCommand(x => CurrentView = HomepageViewModel);
            RegisterCaseViewCommand = new RelayCommand(x => CurrentView = RegisterCaseViewModel);
            RegisterCustomerViewCommand = new RelayCommand(x => CurrentView = RegisterCustomerViewModel);
            RegisterHandlerViewCommand = new RelayCommand(x => CurrentView = RegisterHandlerViewModel);

             
        }

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand CasesViewCommand { get; set; }
        public CasesViewModel CasesViewModel { get; set; }


        public RelayCommand CustomersViewCommand { get; set; }
        public CustomersViewModel CustomersViewModel { get; set; }
         

        public RelayCommand EditCaseViewCommand { get; set; }
        public EditCaseViewModel EditCaseViewModel { get; set; }


        public RelayCommand HomepageViewCommand { get; set; }
        public HomepageViewModel HomepageViewModel { get; set; }


        public RelayCommand RegisterCaseViewCommand { get; set; }
        public RegisterCaseViewModel RegisterCaseViewModel { get; set; }
        

        public RelayCommand RegisterCustomerViewCommand { get; set; }
        public RegisterCustomerViewModel RegisterCustomerViewModel { get; set; }

        public RelayCommand RegisterHandlerViewCommand { get; set; }
        public RegisterHandlerViewModel RegisterHandlerViewModel { get; set; }



    }
}

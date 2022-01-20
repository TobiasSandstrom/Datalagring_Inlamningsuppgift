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
   
    public partial class HomepageView : UserControl
    {

        Case_Service _caseService = new();

        public IEnumerable<Case> cases;
        int[] _statusStatistics = new int[3];

        public string NotStarted { get; set; } = null!;
        public string Ongoing { get; set; } = null!;
        public string Finished { get; set; } = null!;

        public HomepageView()
        {
            InitializeComponent();
            _statusStatistics = _caseService.GetStatusStatistics();
            NotStarted = $"Ej Påbörjade: {_statusStatistics[0]}";
            Ongoing = $"Pågående: {_statusStatistics[1]}";
            Finished = $"Avslutade: {_statusStatistics[2]}";

            cases = _caseService.GetLatestCases();
            if (cases.Count() > 1)
            {
                ListLatestCases();
            }

            this.DataContext = this;
        }
       
       

        //Listar de 10 senaste ärendena i listview
        public void ListLatestCases()
        {
            lbHeader.Content = $"1 {cases.First().CaseCreated.ToShortDateString()}{cases.Last().CaseCreated.ToShortDateString()}";
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_Casehandler.Models
{
    internal class CaseModel
    {

        public string Header { get; set; }
        public string Description { get; set; }
        public int StatusID { get; set; }
        public int HandlerID { get; set; }
        public int CustomerID { get; set; }
        public DateOnly? DateCreated { get; set; }
        public DateOnly? DateUpdated { get; set; }

    }
}

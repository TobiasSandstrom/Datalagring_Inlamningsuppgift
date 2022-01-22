using Datalagring_Casehandler.Data;
using Datalagring_Casehandler.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_Casehandler.Services
{
    internal class CaseManager_Service
    {
        private SqlContext _context = new SqlContext();

        // Skapar en ny handläggare
        public bool Create(Casemanager manager)
        {
            var _manager = _context.Casemanagers.Where(x => x.FirstName == manager.FirstName && x.LastName == manager.LastName).FirstOrDefault();

            if (_manager == null)
            {
                _context.Casemanagers.Add(manager);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //Hämtar alla handläggare från databasen
        public IEnumerable<Casemanager> ListAllManagers()
        {
            return _context.Casemanagers;
        }
    }
}

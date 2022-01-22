using Datalagring_Casehandler.Data;
using Datalagring_Casehandler.Entities;
using Datalagring_Casehandler.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_Casehandler.Services
{
    internal class Case_Service
    {
        
        private SqlContext _context = new SqlContext();

        //----------------------------------------------- < Ärenden > -----------------------------------------------------------


        //Skapar ett ärende
        public void Create(CaseModel _case)
        {

            var newCase = _context.Cases
                .Where(x => x.CaseDescription == _case.Description && x.CaseHeader == _case.Header && x.Customer.Id == _case.CustomerID)
                .FirstOrDefault();

            if (newCase == null)
            {
                var caseState = _context.CaseStatuses
                    .Where(x => x.Id == _case.StatusID)
                    .FirstOrDefault();

                var caseManager = _context.Casemanagers
                .Where(x => x.Id == _case.HandlerID)
                .FirstOrDefault();



                var dateCreated = DateTime.Now;
                _context.Cases.Add(new Case
                {
                    CaseHeader = _case.Header,
                    CaseDescription = _case.Description,
                    CaseCreated = dateCreated,
                    ManagerId = caseManager.Id,
                    StatusId = caseState.Id,
                    CustomerId = _case.CustomerID,

                });
                _context.SaveChanges();
            }
        }

        //Hämtar ett ärende
        public Case ListOne(int id)
        {
            Case _case = new();
            return _case = _context.Cases
                .Include(x => x.Manager)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Adress)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Contact)
                .Include(x => x.Status)
                .Where(x => x.Id == id)
                .FirstOrDefault() ?? null!;
        }

        //Hämtar alla ärenden
        public IEnumerable<Case> ListAllCases()
        {
            return _context.Cases.Include(x => x.Manager)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Adress)
                .Include(x => x.Customer)
                .ThenInclude(x => x.Contact)
                .Include(x => x.Status);
        }

        //Hämtar de 10 senaste ärendena och sorterar dem nyast först
        public IEnumerable<Case> GetAllCasesSorted()
        {
            var recentCases = _context.Cases.OrderByDescending(t => t.CaseCreated).Take(10);
            return recentCases;
        }

        //----------------------------------------------- < Status > -----------------------------------------------------------


        // Hämtar alla statusar
        public IEnumerable<CaseStatus> ListAllStatuses()
        {
            return _context.CaseStatuses;
        }

        public bool CreateStatus(CaseStatus status)
        {
            var newStatus = _context.CaseStatuses.Where(x => x.Status == status.Status).FirstOrDefault();

            if (newStatus == null)
            {
                _context.CaseStatuses.Add(status);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //Ändrar ett ärendes status
        public bool ChangeStatus(int caseId, int statusId)
        {
            DateTime _date = DateTime.Now;
            var newCase = _context.Cases.Where(x => x.Id == caseId).FirstOrDefault();

            if (newCase != null && newCase.Status.Id != statusId)
            {
                newCase.StatusId = statusId;
                newCase.CaseLastChanged = _date;
                _context.Cases.Update(newCase);
                _context.SaveChanges();
                return true;
            }

            return false;
        }


        public int[] GetStatusStatistics()
        {
            var statuses = _context.Cases;
            int[] _statuses = new int[3];
            int notStarted = 0;
            int ongoing = 0;
            int finished = 0;
            foreach (var status in statuses)
            {

                if (status.StatusId == 1)
                {
                    notStarted++;
                }
                if (status.StatusId == 2)
                {
                    ongoing++;
                }
                if (status.StatusId == 3)
                {
                    finished++;
                }

            }
            _statuses[0] = notStarted; _statuses[1] = ongoing; _statuses[2] = finished;
            return _statuses;
        }
    }
}

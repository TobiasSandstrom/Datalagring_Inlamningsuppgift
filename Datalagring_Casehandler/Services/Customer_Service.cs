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
    internal class Customer_Service
    {

        private SqlContext _context = new SqlContext();


        //---------------------------------------------------------- Skapa en kund ------------------------------------------------------------
        public bool Create(CustomerModel customer)
        {

            var _customer = _context.Customers
                .Where(x => x.SocialSecurityNumber == customer.SocalSecurityNumber)
                .FirstOrDefault();

            if (_customer == null)
            {

                var customerContactInfo = _context.CustomerContactInfos
                    .Where(x => x.Email == customer.Email && x.PhoneNumber == customer.PhoneNumber)
                    .FirstOrDefault();


                if (customerContactInfo == null)
                {
                    customerContactInfo = new CustomerContactInfo() { Email = customer.Email, PhoneNumber = customer.PhoneNumber };
                    _context.CustomerContactInfos.Add(customerContactInfo);
                    _context.SaveChanges();
                }


                var customerAddress = _context.CustomerAddresses
                    .Where(x => x.StreetAdress == customer.StreetAddress && x.ZipCode == customer.ZipCode)
                    .FirstOrDefault();

                if (customerAddress == null)
                {
                    customerAddress = new CustomerAddress() { StreetAdress = customer.StreetAddress, ZipCode = customer.ZipCode, City = customer.City, Country = customer.Country };
                    _context.CustomerAddresses.Add(customerAddress);
                    _context.SaveChanges();
                }

                _context.Customers.Add(new Customer
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    SocialSecurityNumber = customer.SocalSecurityNumber,
                    AdressId = customerAddress.Id,
                    ContactId = customerContactInfo.Id
                });
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        //---------------------------------------------------------- Lista en Kund ------------------------------------------------------------

        public Customer ListOne(int id)
        {
            Customer _customer = new();
            _customer = _context.Customers
                .Include(x => x.Adress)
                .Include(x => x.Contact)
                .Where(x => x.Id == id)
                .FirstOrDefault() ?? null!;
            return _customer;
        }


        //---------------------------------------------------------- Lista alla Kunder ------------------------------------------------------------

        public IEnumerable<Customer> ListAllCustomers()
        {
            return _context.Customers.Include(x => x.Contact).Include(x => x.Adress);
        }

        //---------------------------------------------------------- Radera en Kund ------------------------------------------------------------

        public string Delete(int id)
        {
            Customer customer = new();
            CustomerModel _customer = new();

            try
            {
                customer = _context.Customers.Find(customer.Id = id);
                _context.Customers.Remove(customer);

                _context.CustomerContactInfos.Remove(customer.Contact);

                _context.SaveChanges();

                return $"{customer.FirstName} {customer.LastName} has been removed";
            }
            catch
            {
                return $"Cant find that customer to remove";

            }
        }
    }
}

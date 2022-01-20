using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_Casehandler.Models
{
    internal class CustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocalSecurityNumber { get; set; }

        //Kontaktinformation
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        //Adressinformation
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }


    }
}

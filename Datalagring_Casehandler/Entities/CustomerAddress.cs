using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string StreetAdress { get; set; } = null!;
        [StringLength(5)]
        [Unicode(false)]
        public string ZipCode { get; set; } = null!;
        [StringLength(50)]
        public string City { get; set; } = null!;
        [StringLength(50)]
        public string Country { get; set; } = null!;

        [InverseProperty(nameof(Customer.Adress))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

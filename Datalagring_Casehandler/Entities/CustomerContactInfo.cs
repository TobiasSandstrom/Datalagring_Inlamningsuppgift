using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    public partial class CustomerContactInfo
    {
        public CustomerContactInfo()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Email { get; set; } = null!;
        [StringLength(20)]
        public string PhoneNumber { get; set; } = null!;

        [InverseProperty(nameof(Customer.Contact))]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

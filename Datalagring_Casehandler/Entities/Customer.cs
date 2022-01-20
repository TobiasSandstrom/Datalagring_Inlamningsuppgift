using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    [Index(nameof(SocialSecurityNumber), Name = "UQ__Customer__2EFDFD39B93CC212", IsUnique = true)]
    public partial class Customer
    {
        public Customer()
        {
            Cases = new HashSet<Case>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;
        [StringLength(12)]
        [Unicode(false)]
        public string SocialSecurityNumber { get; set; } = null!;
        public int AdressId { get; set; }
        public int ContactId { get; set; }

        [ForeignKey(nameof(AdressId))]
        [InverseProperty(nameof(CustomerAddress.Customers))]
        public virtual CustomerAddress Adress { get; set; } = null!;
        [ForeignKey(nameof(ContactId))]
        [InverseProperty(nameof(CustomerContactInfo.Customers))]
        public virtual CustomerContactInfo Contact { get; set; } = null!;
        [InverseProperty(nameof(Case.Customer))]
        public virtual ICollection<Case> Cases { get; set; }
    }
}

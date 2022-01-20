using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    public partial class Casemanager
    {
        public Casemanager()
        {
            Cases = new HashSet<Case>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [InverseProperty(nameof(Case.Manager))]
        public virtual ICollection<Case> Cases { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    [Index(nameof(Status), Name = "UQ__CaseStat__3A15923F39FD71DD", IsUnique = true)]
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Cases = new HashSet<Case>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Status { get; set; } = null!;

        [InverseProperty(nameof(Case.Status))]
        public virtual ICollection<Case> Cases { get; set; }
    }
}

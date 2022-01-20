using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Datalagring_Casehandler.Entities
{
    public partial class Case
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string CaseHeader { get; set; } = null!;
        public string? CaseDescription { get; set; }
        [Column(TypeName = "date")]
        public DateTime CaseCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CaseLastChanged { get; set; }
        public int StatusId { get; set; }
        public int? ManagerId { get; set; }
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Cases")]
        public virtual Customer Customer { get; set; } = null!;
        [ForeignKey(nameof(ManagerId))]
        [InverseProperty(nameof(Casemanager.Cases))]
        public virtual Casemanager? Manager { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(CaseStatus.Cases))]
        public virtual CaseStatus Status { get; set; } = null!;
    }
}

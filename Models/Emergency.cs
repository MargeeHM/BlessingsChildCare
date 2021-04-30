using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Emergency
    {
        [Key]
        [Column("emergency_id")]
        public int EmergencyId { get; set; }
        [Required]
        [Column("emergencyContactFirstName")]
        [StringLength(50)]
        public string EmergencyContactFirstName { get; set; }
        [Required]
        [Column("emergencyContactLastName")]
        [StringLength(50)]
        public string EmergencyContactLastName { get; set; }
        [Required]
        [Column("emergencyContactPhone")]
        [StringLength(10)]
        public string EmergencyContactPhone { get; set; }
        [StringLength(25)]
        public string Relationship { get; set; }
        [Column("child_id")]
        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("Emergency")]
        public virtual Child Child { get; set; }
    }
}

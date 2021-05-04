using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Enrollment
    {
        [Key]
        [Column("enrollment_id")]
        public int EnrollmentId { get; set; }
        [Required]
        [Column("course")]
        [StringLength(50)]
        public string Course { get; set; }
        [Required]
        [Column("roomNo")]
        [StringLength(10)]
        public string RoomNo { get; set; }
        [Column("enrollmentDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        [Column("child_id")]
        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("Enrollment")]
        public virtual Child Child { get; set; }
    }
}

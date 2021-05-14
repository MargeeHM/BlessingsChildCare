using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Staff
    {
        [Key]
        [Column("staff_id")]
        public int StaffId { get; set; }
        [Required]
        [Column("staffFirstName")]
        [StringLength(50)]
        public string StaffFirstName { get; set; }
        [Required]
        [Column("staffLastName")]
        [StringLength(50)]
        public string StaffLastName { get; set; }
        [Required]
        [Column("room")]
        [StringLength(50)]
        public string Room { get; set; }
        [Required]
        [Column("street")]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [Column("city")]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [Column("zipcode")]
        [StringLength(10)]
        public string Zipcode { get; set; }
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("phone")]
        [StringLength(10)]
        public string Phone { get; set; }
        [InverseProperty("Staff")]
        public virtual ICollection<StaffLog> StaffLog { get; set; }
    }
}

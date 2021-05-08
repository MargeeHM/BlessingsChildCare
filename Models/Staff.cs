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
        [Display(Name = "FirstName")]
        [StringLength(50)]
        public string StaffFirstName { get; set; }
        [Required]
        [Column("staffLastName")]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public string StaffLastName { get; set; }
        [Required]
        [Column("room")]
        [Display(Name = "Room")]
        [StringLength(50)]
        public string Room { get; set; }
        [Required]
        [Column("street")]
        [Display(Name = "Street")]
        [StringLength(50)]
        public string Street { get; set; }
        [Required]
        [Column("city")]
        [Display(Name = "City")]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [Display(Name = "State")]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [Column("zipcode")]
        [StringLength(10)]
        [Display(Name = "Zipcode")]
        public string Zipcode { get; set; }
        [Required]
        [Column("email")]
        [Display(Name = "Email")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column("phone")]
        [Display(Name = "Phone")]
        [StringLength(10)]
        public string Phone { get; set; }
    }
}

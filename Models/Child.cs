using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Child
    {
        public Child()
        {
            Emergency = new HashSet<Emergency>();
            Enrollment = new HashSet<Enrollment>();
            Medical = new HashSet<Medical>();
            Payment = new HashSet<Payment>();
        }

        [Key]
        [Column("child_id")]
        public int ChildId { get; set; }
        [Required]
        [Column("childFirstName")]
        [StringLength(50)]
        [Display(Name = "FirstName")]
        public string ChildFirstName { get; set; }
        [Required]
        [Column("childLastName")]
        [Display(Name = "LastName")]
        [StringLength(50)]
        public string ChildLastName { get; set; }
        [Column("childBirthdate", TypeName = "date")]
        [DataType(DataType.Date)]
        [Display(Name = "Birthdate")]
        public DateTime ChildBirthdate { get; set; }
        [Column("age")]
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Required]
        [Column("fatherFirstName")]
        [Display(Name = "Father FirstName")]
        [StringLength(50)]
        public string FatherFirstName { get; set; }
        [Required]
        [Column("fatherLastName")]
        [Display(Name = "Father LastName")]
        [StringLength(50)]
        public string FatherLastName { get; set; }
        [Required]
        [Column("motherFirstName")]
        [Display(Name = "Mother FirstName")]
        [StringLength(50)]
        public string MotherFirstName { get; set; }
        [Required]
        [Column("motherLastName")]
        [Display(Name = "Mother LastName")]
        [StringLength(50)]
        public string MotherLastName { get; set; }
        [Required]
        [Column("contactPhone")]
        [StringLength(10)]
        [Display(Name = "Phone")]
        public string ContactPhone { get; set; }
        [Required]
        [Column("street")]
        [StringLength(50)]
        [Display(Name = "Street")]
        public string Street { get; set; }
        [Required]
        [Column("city")]
        [StringLength(50)]
        [Display(Name = "City")]
        public string City { get; set; }
        [Required]
        [Column("state")]
        [StringLength(2)]
        [Display(Name = "State")]
        public string State { get; set; }
        [Column("zipcode")]
        [Display(Name = "Zipcode")]
        public int Zipcode { get; set; }

        [InverseProperty("Child")]
        public virtual ICollection<Emergency> Emergency { get; set; }
        [InverseProperty("Child")]
        public virtual ICollection<Enrollment> Enrollment { get; set; }
        [InverseProperty("Child")]
        public virtual ICollection<Medical> Medical { get; set; }
        [InverseProperty("Child")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}

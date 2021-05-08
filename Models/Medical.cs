﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Medical
    {
        [Key]
        [Column("medical_id")]
        public int MedicalId { get; set; }
        [Required]
        [Column("personToContactFirstName")]
        [Display(Name = "Person To Contact FirstName")]
        [StringLength(50)]
        public string PersonToContactFirstName { get; set; }
        [Required]
        [Column("personToContactLastName")]
        [Display(Name = "Person To Contact LastName")]
        [StringLength(50)]
        public string PersonToContactLastName { get; set; }
        [Required]
        [Column("personToContactPhone")]
        [Display(Name = "Person To Contact Phone")]
        [StringLength(10)]
        public string PersonToContactPhone { get; set; }
        [Required]
        [Column("childsDoctorFirstName")]
        [Display(Name = "Child's Doctor Firstname")]
        [StringLength(50)]
        public string ChildsDoctorFirstName { get; set; }
        [Required]
        [Column("childsDoctorLastName")]
        [Display(Name = "Child's Doctor Lastname LastName")]
        [StringLength(50)]
        public string ChildsDoctorLastName { get; set; }
        [Required]
        [Column("childsDoctorPhone")]
        [Display(Name = "Child's Doctor Phone")]
        [StringLength(10)]
        public string ChildsDoctorPhone { get; set; }
        [Required]
        [Column("regularlyUsedHospitalName")]
        [Display(Name = "Regularly Used Hospital Name")]
        [StringLength(50)]
        public string RegularlyUsedHospitalName { get; set; }
        [Column("diaetryRestriction")]
        [Display(Name = "Diaetry Restriction")]
        [StringLength(100)]
        public string DiaetryRestriction { get; set; }
        [Column("medicalIssue")]
        [Display(Name = "Medical Issue")]
        [StringLength(100)]
        public string MedicalIssue { get; set; }
        [Column("child_id")]
        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("Medical")]
        public virtual Child Child { get; set; }
    }
}

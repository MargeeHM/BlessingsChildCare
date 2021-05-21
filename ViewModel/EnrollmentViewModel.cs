using Blessings.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.ViewModel
{
    public class EnrollmentViewModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EnrollmentListId { get; set; }
        public int EnrollmentId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Child name")]
        public string ChildFirstName { get; set; }
        
        [Required]
        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime ChildBirthdate { get; set; }

        [Required]
        [Display(Name = "Course")]
        [StringLength(50)]
        public string Course { get; set; }

        [Required]
        [Display(Name = "Room")]
        [StringLength(10)]
        public string RoomNo { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Enrollment End Date")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentEndDate { get; set; }
        
       
        public int? ChildId { get; set; }
    }
}

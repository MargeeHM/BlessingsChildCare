using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blessings.ViewModel
{
    public class PaymentVM
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaymentListId { get; set; }
        public int PaymentId { get; set; }

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

        [Required]
        [Display(Name = "Payment Type")]
        [StringLength(50)]
        public string PaymentType { get; set; }
        [Required]
        [Display(Name = "Status")]
        [StringLength(25)]
        public string Status { get; set; }
        [Display(Name = "Payment Amount")]
        public float Amount { get; set; }
        [Display(Name = "Payment Date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }

        public int? EnrollmentId { get; set; }
    }
}

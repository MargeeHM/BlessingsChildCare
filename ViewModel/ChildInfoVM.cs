using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blessings.ViewModel
{
    public class ChildInfoVM
    {
        [Key]

        public int ChildId { get; set; }

        [Display(Name = "Child FirstName")]
        public string ChildFirstName { get; set; }
        [Display(Name = "Child LastName")]
        public string ChildLastName { get; set; }

        [Display(Name = "Birthdate")]
        [DataType(DataType.Date)]
        public DateTime ChildBirthdate { get; set; }
        [Display(Name = "Age")]
        public int Age { get; set; }
        [Display(Name = "Father FirstName")]
        public string FatherFirstName { get; set; }
        [Display(Name = "Father FirstName")]
        public string FatherLastName { get; set; }
        [Display(Name = "Mother FirstName")]
        public string MotherFirstName { get; set; }
        [Display(Name = "Mother FirstName")]
        public string MotherLastName { get; set; }
        [Display(Name = "Phone")]
        public string ContactPhone { get; set; }
        [Display(Name = "Street")]
        public string Street { get; set; }
       
        public string City { get; set; }
    
        public string State { get; set; }
 
        public int Zipcode { get; set; }

        public int EnrollmentId { get; set; }
       
        public string Course { get; set; }
        [Display(Name = "Room")]
        public string RoomNo { get; set; }
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Enrollment End Date")]
        [DataType(DataType.Date)]
        public DateTime? EnrollmentEndDate { get; set; }

        public int AuthorizedPickupId { get; set; }
        [Display(Name = "Person name")]
        public string PersonName { get; set; }

        public string? Relation { get; set; }
        [Display(Name = "Phone")]
        public string? phone { get; set; }

        public int MedicalId { get; set; }
        [Display(Name = "Person to contact Firstname")]
        public string PersonToContactFirstName { get; set; }
        [Display(Name = "Person to contact Lastname")]
        public string PersonToContactLastName { get; set; }
        [Display(Name = "Person to contact Phone")]
        public string PersonToContactPhone { get; set; }
        [Display(Name = "Child's Doctor Firstname")]
        public string ChildsDoctorFirstName { get; set; }
        [Display(Name = "Child's Doctor Lastname")]
        public string ChildsDoctorLastName { get; set; }
        [Display(Name = "Child's Doctor Phone")]
        public string ChildsDoctorPhone { get; set; }
        [Display(Name = "Regularly Used Hospital name")]
        public string RegularlyUsedHospitalName { get; set; }
        [Display(Name = "Diaetry Restriction")]
        public string DiaetryRestriction { get; set; }
        [Display(Name = "Medical Issue")]
        public string MedicalIssue { get; set; }

        public int EmergencyId { get; set; }
        [Display(Name = "Emergency Contact FirstName")]
        public string EmergencyContactFirstName { get; set; }
        [Display(Name = "Emergency Contact LastName")]
        public string EmergencyContactLastName { get; set; }
        [Display(Name = "Emergency Contact Phone")]
        public string EmergencyContactPhone { get; set; }
        [StringLength(25)]
        public string Relationship { get; set; }
    }
}

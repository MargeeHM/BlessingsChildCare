using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.ViewModel
{
    public class ChildActivitiesVM
    {
        [Key]
        
        public int ChildActivityId { get; set; }
    
        public DateTime Activitytime { get; set; }
     
        public string ActivityName { get; set; }
    
        [Display(Name ="Image Name")]
        public string ImageName { get; set; }
        [Display(Name = "Child name")]
        public string ChildFirstName { get; set; }

        public string Room { get; set; }
        public int? ChildId { get; set; }

        public int? EnrollmentId { get; set; }
    }
}

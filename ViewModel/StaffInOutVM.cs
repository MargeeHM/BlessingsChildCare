using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Blessings.ViewModel
{
    public class StaffInOutVM
    {

        [Key]
        public int StafflogId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StaffCheckIn { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StaffCheckOut { get; set; }

        [Display(Name = "Staff name")]
        public string StaffFirstName { get; set; }

        public int StaffId { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.ViewModel
{
    public class Sign_InOutChildrenVM
    {
        [Key]
        
        
        public int ChildlogId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime? CheckIn { get; set; }
        [DataType(DataType.Time)]
        public DateTime? CheckOut { get; set; }

        [Display(Name = "Child name")]
        public string ChildFirstName { get; set; }
        public int ChildId { get; set; }
    }
}

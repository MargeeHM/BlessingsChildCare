using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blessings.Models
{
    public class StaffLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StafflogId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StaffCheckIn { get; set; }
        [DataType(DataType.Time)]
        public DateTime? StaffCheckOut { get; set; }
       
      
        public int StaffId { get; set; }
        [ForeignKey(nameof(StaffId))]
        [InverseProperty("StaffLog")]
        public virtual Staff Staff { get; set; }
    }
}

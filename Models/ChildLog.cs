using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blessings.Models
{
    public class ChildLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChildlogId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan CheckIn { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan CheckOut { get; set; }

        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("ChildLog")]
        public virtual Child Child { get; set; }
    }
}

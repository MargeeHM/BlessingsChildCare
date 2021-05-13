using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blessings.Models
{
    public class CourseFees
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseFeeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Course { get; set; }

        [Required]
        public double Fee { get; set; }

        [InverseProperty("CourseFees")]
        public virtual ICollection<Enrollment> Enrollment { get; set; }
    }
}

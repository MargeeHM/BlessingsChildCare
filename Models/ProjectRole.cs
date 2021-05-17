using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blessings.Models
{
    public class ProjectRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectRoleId { get; set; }
        [Required]
     
        [StringLength(50)]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}

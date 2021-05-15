using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace Blessings.Models
{
    public class ChildActivity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ChildActivityId { get; set; }
        [Required]
        public DateTime Activitytime { get; set; }
        [Required]
        [StringLength(100)]
        public string ActivityName { get; set; }
        [StringLength(100)]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }
        [NotMapped]
        [DisplayName("Upload photo")]
        public IFormFile? ActivityImage { get; set; }

        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("ChildActivity")]
        public virtual Child Child { get; set; }
    }
}
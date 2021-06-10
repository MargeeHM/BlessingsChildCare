using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Blessings.Models
{
    public class AuthorizedPickup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorizedPickupId { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Person Name")]
        public string PersonName { get; set; }
        [StringLength(25)]
        [DisplayName("Relation")]
        public string? Relation { get; set; }

        [StringLength(10)]
        [DisplayName("Phone")]
        public string? phone { get; set; }
       
        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("AuthorizedPickup")]
        public virtual Child Child { get; set; }
    }
}

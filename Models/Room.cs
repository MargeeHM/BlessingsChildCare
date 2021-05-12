using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blessings.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int RoomId { get; set; }
        
        [Required]
        [StringLength(10)]
        public string RoomNo { get; set; }
        
        [Required]
        [StringLength(25)]
        public string? Course { get; set; }
       
    }
}

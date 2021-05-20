using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Blessings.Models;

namespace Blessings.ViewModel
{
    public class DashBoradViewModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dashboardvmId { get; set; }
        public int Childrens { get; set; }

        public int Staffs { get; set;}

        public float TotalAmount { get; set; }

        public float DueAmount { get; set; }

        public List<Child> ChildrenList { get; set; }
    }
}

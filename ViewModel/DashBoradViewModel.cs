using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blessings.Models;

namespace Blessings.ViewModel
{
    public class DashBoradViewModel
    {
        public int Childrens { get; set; }

        public int Staffs { get; set;}

        public float TotalAmount { get; set; }

        public float DueAmount { get; set; }

        public List<Child> ChildrenList { get; set; }
    }
}

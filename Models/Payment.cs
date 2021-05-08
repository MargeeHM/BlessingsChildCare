using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public string PayerName { get; set; }
        public string PaymentType { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ChildId { get; set; }
    }
}

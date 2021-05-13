using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Payment
    {
        [Key]
        [Column("payment_id")]
        public int PaymentId { get; set; }
        [Required]
        [Column("payerName")]
        [StringLength(50)]
        public string PayerName { get; set; }
        [Required]
        [Column("paymentType")]
        [StringLength(50)]
        public string PaymentType { get; set; }
        [Column("amount")]
        public double Amount { get; set; }
        [Column("paymentDate", TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime PaymentDate { get; set; }
        [Column("child_id")]
        public int ChildId { get; set; }

        [ForeignKey(nameof(ChildId))]
        [InverseProperty("Payment")]
        public virtual Child Child { get; set; }
        
        [Column("EnrollmentId")]
        public int? EnrollmentId { get; set; }

        [ForeignKey(nameof(EnrollmentId))]
        [InverseProperty("Payment")]
        public virtual Enrollment Enrollment { get; set; }
    }
}

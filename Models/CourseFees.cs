using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class CourseFees
    {
        public int CoursefeesId { get; set; }
        public string CourseName { get; set; }
        public double Fees { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Blessings.Models
{
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public string Course { get; set; }
        public string RoomNo { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int ChildId { get; set; }
    }
}

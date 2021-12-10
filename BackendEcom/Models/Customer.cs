using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class Customer
    {
        public Guid? UserId { get; set; }
        public decimal CustomerContact { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual UserTable User { get; set; }
    }
}

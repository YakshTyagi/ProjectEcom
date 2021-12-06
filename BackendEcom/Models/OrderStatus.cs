using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class OrderStatus
    {
        public Guid? OrderProductId { get; set; }
        public DateTime? FromStatus { get; set; }
        public DateTime? ToStatus { get; set; }
        public string TransitionNotesComments { get; set; }

        public virtual OrderProduct OrderProduct { get; set; }
    }
}

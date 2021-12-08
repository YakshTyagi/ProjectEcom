using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class Cart
    {
        public Guid? CustomerId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsWishlistItem { get; set; }
        public Guid? ProductVariationId { get; set; }

        public virtual UserTable Customer { get; set; }
        public virtual ProductVariation ProductVariation { get; set; }
    }
}

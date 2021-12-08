using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class OrderProduct
    {
        public Guid OrderProductId { get; set; }
        public Guid? OrderId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public Guid? ProductVariationId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual OrderTable Order { get; set; }
        public virtual ProductVariation ProductVariation { get; set; }
    }
}

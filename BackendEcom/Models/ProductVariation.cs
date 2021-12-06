using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class ProductVariation
    {
        public ProductVariation()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public Guid ProductVariationId { get; set; }
        public Guid? ProductId { get; set; }
        public int? QunatityAvailable { get; set; }
        public decimal? Price { get; set; }
        public string VariationMetadata { get; set; }
        public string PrimaryImageName { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Product Product { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}

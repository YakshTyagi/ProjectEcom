using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class Product
    {
        public Product()
        {
            Category = new HashSet<Category>();
            ProductVariation = new HashSet<ProductVariation>();
        }

        public Guid ProductId { get; set; }
        public Guid? Sellerid { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }
        public bool? IsCancelable { get; set; }
        public bool? IsReturnable { get; set; }
        public string Brand { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual UserTable Seller { get; set; }
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<ProductVariation> ProductVariation { get; set; }
    }
}

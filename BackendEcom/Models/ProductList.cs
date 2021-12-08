using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Models
{
    public class ProductList
    {
        public Guid ProductVariationId { get; set; }
        public Guid ProductId { get; set; }
        public string PName { get; set; }
        public string PDescription { get; set; }
        public bool? IsCancelable { get; set; }
        public bool? IsReturnable { get; set; }
        public string Brand { get; set; }
        public string Review { get; set; }
        public double? Rating { get; set; }
        public decimal? Price { get; set; }

        public int? QunatityAvailable { get; set; }
        public string VariationMetadata { get; set; }
        public string PrimaryImageName { get; set; }
        public bool? IsActive { get; set; }
    }
}

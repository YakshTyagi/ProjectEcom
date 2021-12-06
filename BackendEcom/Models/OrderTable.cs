using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class OrderTable
    {
        public OrderTable()
        {
            OrderProduct = new HashSet<OrderProduct>();
        }

        public Guid OrderId { get; set; }
        public Guid? CustomerId { get; set; }
        public decimal? AmountPaid { get; set; }
        public Guid? AddressId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual Addresses Address { get; set; }
        public virtual UserTable Customer { get; set; }
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
    }
}

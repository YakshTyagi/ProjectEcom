using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace BackendEcom.Models
{
    public partial class UserTable
    {
        public UserTable()
        {
            Addresses = new HashSet<Addresses>();
            Customer = new HashSet<Customer>();
            OrderTable = new HashSet<OrderTable>();
            Product = new HashSet<Product>();
            Seller = new HashSet<Seller>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Upassword { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastUpdated { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Addresses> Addresses { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<OrderTable> OrderTable { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<Seller> Seller { get; set; }
    }
}

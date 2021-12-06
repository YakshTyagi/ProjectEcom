using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.IRepository
{
    public interface SellerInterface
    {
        public IEnumerable<Seller> GetSeller();
        public string Insert(Seller model);
        public Seller GetBySellerGuid(Guid id);
    }
}

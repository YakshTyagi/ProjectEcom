using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.IRepository
{
    public interface ProductInterface
    {
        public IEnumerable<ProductList> GetProducts();
        public string Insert(Product model);
    }
}

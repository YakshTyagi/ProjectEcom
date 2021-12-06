using BackendEcom.IRepository;
using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Repository
{
    public class SellerTable : SellerInterface
    {
        string str = string.Empty;

        private readonly Demo_ProjectContext context;


        public SellerTable(Demo_ProjectContext _context)
        {
            context = _context;
        }

        public string Insert(Seller model)
        {
            try
            {

                context.Seller.Add(model);

                context.SaveChanges();

                str = "User Added successfully.";
            }

            catch (Exception ex)
            {
                str = "Deletion Failed due to=" + ex.Message + ".";
            }
            return str;


        }
        public IEnumerable<Seller> GetSeller()
        {
            var response = context.Seller.ToList();
            return response;
        }
        public Seller GetBySellerGuid(Guid id)
        {
            return context.Seller.FirstOrDefault(x => x.Sellerid == id);
        }
    }
}

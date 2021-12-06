using BackendEcom.IRepository;
using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Repository
{
    public class CustomerTable : CustomerInterface
    {

        string str = string.Empty;
        private readonly Demo_ProjectContext context;
        public CustomerTable(Demo_ProjectContext _context)
        {
            context = _context;
        }
        public IEnumerable<BackendEcom.Models.Customer> GetCustomer()
        {
            var response = context.Customer.ToList();
            return response;
        }

        public string Insert(BackendEcom.Models.Customer model)
        {
            try
            {

                context.Customer.Add(model);
                context.SaveChanges();
                str = "User Added successfully.";
            }
            catch (Exception ex)
            {
                str = "Deletion Failed due to=" + ex.Message + ".";
            }
            return str;
        }

        BackendEcom.Models.Customer CustomerInterface.GetByCustomerGuid(Guid id)
        {
            return context.Customer.FirstOrDefault(x => x.UserId == id);
        }
    }
}

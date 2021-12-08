using BackendEcom.IRepository;
using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.Repository
{
    public class UserClass : UserInterface
    {
        string str = string.Empty;
        private readonly Demo_ProjectContext context;
        public UserClass(Demo_ProjectContext _context)
        {
            context = _context;
        }

        public IEnumerable<UserTable> GetUser()
        {
            var response = context.UserTable.ToList();
            return response;
        }

        public string Insert(UserTable model)
        {
            try
            {

                context.UserTable.Add(model);

                context.SaveChanges();

                str = "User saved successfully.";
            }
            catch (Exception ex)
            {
                str = "Deletion Failed due to=" + ex.Message + ".";
            }
            return str;
        }

        public UserTable GetByUserGuid(Guid id)
        {
            var response = context.UserTable.FirstOrDefault(x => x.Id == id);
            return response;
        }

        public UserTable GetIdByEmail(string Email)
        {
            var response = context.UserTable.FirstOrDefault(x => x.Email == Email);
            return response;
        }
    }
}
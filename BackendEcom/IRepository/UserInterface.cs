using BackendEcom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendEcom.IRepository
{
    public interface UserInterface
    {
        public IEnumerable<UserTable> GetUser();

        public string Insert(UserTable model);
        public UserTable GetByUserGuid(Guid id);

       // public UserTable GetIdByEmail(string Email);
    }
}

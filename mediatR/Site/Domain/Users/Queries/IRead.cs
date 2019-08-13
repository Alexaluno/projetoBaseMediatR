using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain.Users.Queries
{
    public interface IRead
    { 
        Task<User> GetById(Guid id);

        Task<User> GetByEmail(string email);

        Task<IEnumerable<User>> List();
    }
}

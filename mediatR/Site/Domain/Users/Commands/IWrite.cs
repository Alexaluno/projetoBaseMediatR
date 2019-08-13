using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain.Users.Commands
{
    public interface IWrite
    {
        Task Insert(User user);
        Task Update(User user);
    }
}

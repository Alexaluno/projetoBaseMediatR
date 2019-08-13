using Site.Domain.Users;
using Site.Domain.Users.Commands;
using Site.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Infra
{
    public class Data
    {
        public static List<User> USER = new List<User>();
    }
    public class Write : IWrite
    {
        public Task Insert(User user)
        {
            Data.USER.Add(user);
            return Task.CompletedTask;
        }

        public Task Update(User user)
        {
                var currentUser = Data.USER.FirstOrDefault(c => c.Id.Equals(user.Id));
                Data.USER.Remove(currentUser);
                Data.USER.Add(user);
                return Task.CompletedTask;
        }
    }

    public class Read : IRead
    {
        public async Task<User> GetByEmail(string email)
        {
            return  Data.USER.FirstOrDefault(c => c.Email.Equals(email));
            
        }

        public async Task<User> GetById(Guid id)
        {
           return Data.USER.FirstOrDefault(c => c.Id.Equals(id));
        }

        public async Task<IEnumerable<User>> List()
        {
            return Data.USER.ToList();
        }
    }
}

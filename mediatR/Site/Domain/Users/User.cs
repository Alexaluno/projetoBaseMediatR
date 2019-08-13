using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain.Users
{
    public class User
    {
        public User()
        {
            this.Id = Guid.NewGuid();        
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        public User(string name, string email):this()
        {
            
            this.Name = name;
            this.Email = email;
           
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

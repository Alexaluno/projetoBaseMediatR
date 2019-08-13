using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain.Users.Commands.Insert
{
    public class Request : IRequest<Response>
    {
        public string Name { get; set; }
        public string Email { get; set; }

        internal User ConvertToUser()
        {
            return new User(this.Name, this.Email);
        }
    }
}

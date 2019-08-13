using MediatR;
using Site.Domain.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Domain.Users.Commands.Insert
{
    public class Handler : IRequestHandler<Request, Response>
    {
        private readonly IMediator _mediator;
        private readonly IWrite _write;
        private readonly IRead _read;

        public Handler(IMediator mediator, IWrite write, IRead read)
        {
            _mediator = mediator;
            _write = write;
            _read = read;
        }

        public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
        {
            var existingUser = await this._read.GetByEmail(request.Email);
            if (existingUser != null)
                return new Response("username", "There is already a user with this email");

            var user = request.ConvertToUser();
            await this._write.Insert(user);
            return Response.Ok;


        }
    }
}

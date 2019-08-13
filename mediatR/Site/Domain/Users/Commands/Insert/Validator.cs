using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.Domain.Users.Commands.Insert
{
    public class Validator : AbstractValidator<Request>
    {
        public Validator()
        {
            this.RuleFor(x => x.Name).NotEmpty()
                                     .WithMessage("O Campo nome está vazio")
                                     .MaximumLength(50);
            this.RuleFor(x => x.Email).NotEmpty()
                                      .WithMessage("O Campo email não está vazio")
                                      .EmailAddress()
                                      .MaximumLength(100);
        }
    }
}

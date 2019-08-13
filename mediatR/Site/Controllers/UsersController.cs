using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Site.Domain.Users.Queries;

namespace Site.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IRead _read;

        public UsersController(IMediator mediator, IRead read)
        {
            this._mediator = mediator;
            this._read = read;
        }

        public async Task<IActionResult> Index()
        {
            var users = await this._read.List();
            return View(users);
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(Domain.Users.Commands.Insert.Request request)
        {
            var respose = await this._mediator.Send(request);
            if (respose.HasValidations)
            {
                foreach (var validation in respose.Validations)
                    ModelState.AddModelError(validation.PropertyName, validation.ErrorMessage);
                return View();
            }
            return Redirect("Index");
        }
    }
}
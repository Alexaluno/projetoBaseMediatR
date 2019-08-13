using System.Linq;
using System.Collections.Generic;
using System.Threading;
using FluentValidation.Results;
using System.Threading.Tasks;
using Site.Domain;
using MediatR;
using FluentValidation;

namespace Site.Pipelines
{
    public class ValidationFailurePipelineBehavior<TRequest,TResponse>
                                                 :IPipelineBehavior<TRequest,TResponse>
                                           where TRequest: IRequest<TResponse> where TResponse:Response
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationFailurePipelineBehavior(IEnumerable<IValidator<TRequest>> validators) => this._validators = validators;
        public Task<TResponse> Handle(TRequest request, 
                                            CancellationToken cancellationToken, 
                                            RequestHandlerDelegate<TResponse> next)
        {
            var failures = this._validators.Select(v => v.Validate(request));
            var errors = failures.SelectMany(result => result.Errors).Where(f => f != null);
            return failures.Any() ? Erros(errors) : next();
        }

        private static Task<TResponse> Erros(IEnumerable<ValidationFailure> validations)
        {
            var response = new Response(validations);
            return Task.FromResult(response as TResponse);
        }
    }
}

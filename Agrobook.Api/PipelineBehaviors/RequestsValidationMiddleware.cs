namespace Agrobook.Api.PipelineBehaviors
{
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Core.Responses;
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestsValidationMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        //private Response<ValidationResult> _response;
        private readonly IEnumerable<IValidator> _validators;
        public RequestsValidationMiddleware(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                      
            //var result =  .Fail(failures);

            //if (_validators.Any())
            //    return result.ValidationResult;

            return await next();
        }        
    }   
}

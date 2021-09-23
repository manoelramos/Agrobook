namespace Agrobook.Api.PipelineBehaviors
{
    using Agrobook.Domain.Core.Responses;
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class RequestsValidationMiddleware<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse> where TResponse : ValidationResult
    {
        private readonly IEnumerable<IValidator> _validators;
        public RequestsValidationMiddleware(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var contextValidation = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(contextValidation, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();                     

            if (failures.Any())
                return Response<TResponse>.Fail(failures).ValidationResult as TResponse;

            return await next();
        }        
    }   
}

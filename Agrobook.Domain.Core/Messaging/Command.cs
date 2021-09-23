namespace Agrobook.Domain.Core.Messaging
{
    using FluentValidation.Results;
    using MediatR;

    public abstract class Command<TResponse> : IRequest<TResponse>
    {
        //[SwaggerExclude]
        //public long Id { get; set; }

        //public DateTime Timestamp { get; protected set; } = DateTime.Now;
                
        //public ValidationResult ValidationResult { get; protected set; } = new ValidationResult();

        //public virtual bool IsValid() => ValidationResult.IsValid;
    }

    public abstract class Command : Command<ValidationResult>
    {
    }
}

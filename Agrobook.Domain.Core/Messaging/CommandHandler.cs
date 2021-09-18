namespace Agrobook.Domain.Core.Messaging
{
    using Agrobook.Domain.Core.Data;
    using FluentValidation;
    using FluentValidation.Results;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        protected ValidationResult ValidationResult { get; } = new ValidationResult();

        protected CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected bool IsValid<TParameter>(TParameter target) where TParameter : AbstractValidator<TParameter>
        {
            var validationResult = target.Validate(target);
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }


        protected bool IsValid<TValidator, TEntity>(TValidator validator, TEntity target) where TValidator : AbstractValidator<TEntity>
        {
            var validationResult = validator.Validate(target);
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected bool IsSuccess(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                ValidationResult.Errors.Add(error);

            return ValidationResult.IsValid;
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected Task BeginTransactionAsync(CancellationToken cancellationToken = default) =>
            _uow.BeginTransactionAsync(cancellationToken);

        protected Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
            _uow.CommitTransactionAsync(cancellationToken);

        protected Task<int> SaveAsync(CancellationToken cancellationToken = default) =>
            _uow.SaveAsync(cancellationToken);

        protected async Task<ValidationResult> CommitAsync(string message, CancellationToken cancellationToken = default)
        {
            if (_uow.HasChanges() && (await _uow.SaveAsync(cancellationToken) <= 0))
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> CommitAsync(CancellationToken cancellationToken = default)
        {
            return await CommitAsync(DomainResources.CommitErrorMessage, cancellationToken);
        }

        protected async Task<ValidationResult> RollbackAsync(CancellationToken cancellationToken = default)
        {
            await _uow.RollbackTransactionAsync(cancellationToken);
            return ValidationResult;
        }

        protected bool HasChanges()
        {
            return _uow.HasChanges();
        }

        protected static Responses.Response<TData> Success<TData>(TData data, ValidationResult validationResult = default)
        {
            return Responses.Response<TData>.Success(data, validationResult);
        }

        protected static Responses.Response<TData> Fail<TData>(ValidationResult validationResult = default)
        {
            return Responses.Response<TData>.Fail(validationResult);
        }
    }
}

namespace Agrobook.Domain.Core.Responses
{
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;

    public class Response<TData>
    {
        public TData Data { get; protected set; }

        public ValidationResult ValidationResult { get; protected set; }

        public bool IsValid => ValidationResult.IsValid;

        public static Response<TData> Success(TData data, ValidationResult validationResult = default)
        {
            return new Response<TData>
            {
                Data = data,
                ValidationResult = validationResult
            };
        }

        public static Response<TData> Fail(ValidationResult validationResult = default)
        {
            return new Response<TData> { ValidationResult = validationResult };
        }

        public static Response<TData> Fail(IEnumerable<ValidationFailure>  validationResult = default)
        {
            var validation = new ValidationResult(validationResult);
            return new Response<TData> { ValidationResult = validation };
        }

        public static implicit operator Response<TData>(Response<ValidationResult> v)
        {
            throw new NotImplementedException();
        }
    }
}

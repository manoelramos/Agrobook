namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Paises : Entity<Paises>
    {
        public string Nome { get; set; }
        
        public ICollection<Estados> Estados { get; set; }
        public ICollection<Enderecos> Enderecos { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(200)
                .NotEmpty();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

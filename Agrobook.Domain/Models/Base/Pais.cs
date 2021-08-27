namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Pais : Entity<Pais>
    {
        public string Nome { get; set; }
        
        public ICollection<Estado> Estados { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }

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

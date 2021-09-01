namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Cidades : Entity<Cidades>
    {
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estados Estado { get; set; }
        public ICollection<Enderecos> Enderecos { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(100)
                .NotEmpty();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

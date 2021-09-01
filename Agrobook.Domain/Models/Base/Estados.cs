namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Estados : Entity<Estados>
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidades> Cidades { get; set; }
        public Paises Pais { get; set; }
        public int PaisId {  get; set; }
        public ICollection<Enderecos> Enderecos { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(c => c.Sigla)
                .Length(2)
                .NotEmpty();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

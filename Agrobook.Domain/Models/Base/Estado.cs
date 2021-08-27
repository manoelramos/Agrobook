namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Estado : Entity<Estado>
    {
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }
        public Pais Pais { get; set; }
        public int PaisId {  get; set; }
        public ICollection<Endereco> Enderecos { get; set; }

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

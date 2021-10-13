namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using FluentValidation;
    using System.Collections.Generic;

    public class Estados : Entity<Estados>
    {
        public int CodigoUf {  get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }
        public int Regiao {  get; set; }        
        public ICollection<Cidades> Cidades { get; set; }

        public override bool IsValid()
        {
            RuleFor(c => c.Nome)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(c => c.Uf)
                .Length(2)
                .NotEmpty();

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}

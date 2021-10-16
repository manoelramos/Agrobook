namespace Agrobook.Application.Parcela.Validators
{
    using Agrobook.Application.Parcela.Commands;
    using FluentValidation;

    public class ParcelaCreateValidator : AbstractValidator<ParcelaCreateCommand>
    {
        public ParcelaCreateValidator()
        {
            RuleFor(a => a.IdMoedaParcela).NotEmpty().GreaterThan(0).WithMessage("Informe um código válido para moeda.");
            RuleFor(a => a.ValorParcela).NotEmpty().GreaterThan(0).WithMessage("Informe um valor válido para parcela.");
        }
    }
}

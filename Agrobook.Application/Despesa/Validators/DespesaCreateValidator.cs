namespace Agrobook.Application.Despesa.Validators
{
    using Agrobook.Application.Despesa.Commands;
    using FluentValidation;

    public class DespesaCreateValidator : AbstractValidator<DespesaCreateCommand>
    {
        public DespesaCreateValidator()
        {
            RuleFor(a => a.CategoriaId).NotEmpty().NotNull().WithMessage("Informe uma categoria para a despesa.");
            //RuleFor(a => a.Parcelas).Must(x => x.Count < 1).WithMessage("Informe pelo menos uma parcela para despesa.");
            RuleForEach(a => a.Parcelas).Must(x => x.ValorParcela <= 0).WithMessage("Informe um valor coerente para a parcela.");
            RuleForEach(a => a.Parcelas).Must(x => x.IdMoedaParcela <= 0).WithMessage("Informe uma moeda para o valor da parcela.");
        }
    }
}

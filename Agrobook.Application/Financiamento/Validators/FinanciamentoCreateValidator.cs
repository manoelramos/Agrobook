namespace Agrobook.Application.Financiamento.Validators
{
    using Agrobook.Application.Financiamento.Commands;
    using Agrobook.Application.Parcela.Validators;
    using FluentValidation;

    public class FinanciamentoCreateValidator : AbstractValidator<FinanciamentoCreateCommand>
    {
        public FinanciamentoCreateValidator()
        {
            RuleFor(a => a.IdMoedaParcela).NotEmpty().WithMessage("Informe um valor válido para moeda.");
            RuleFor(a => a.CredorId).NotEmpty().WithMessage("Informe um valor válido para o credor.");
            RuleForEach(a => a.Parcelas).SetValidator(new ParcelaCreateValidator());           
        }
    }
}

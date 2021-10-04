namespace Agrobook.Application.PessoaFisica.Validators
{
    using Agrobook.Application.PessoaFisica.Commands;
    using FluentValidation;
    using Flunt.Extensions.Br.Validations;
    using Flunt.Validations;

    public class PessoaFisicaCreateValidator : AbstractValidator<PessoaFisicaCreateCommand>
    {
        public PessoaFisicaCreateValidator()
        {
            RuleFor(a => a.PessoaFisica.CPF).Must(IsCpfVaild).WithMessage("CPF incorreto ou não informado.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email incorreto ou não informado.");
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Incorreto ou não informado.");
            RuleFor(a => a.PessoaFisica.CTPS).Must(x => x.ToString().Length == 7).WithMessage("Incorreto ou não informado.");
            RuleFor(a => a.PessoaFisica.PisPasep).Must(x => x.ToString().Length == 11).WithMessage("Incorreto ou não informado.");
            RuleFor(a => a.PessoaFisica.SerieCtps).Must(x => x.ToString().Length == 4).WithMessage("Incorreto ou não informado.");
        }

        private bool IsCpfVaild(long cpf)
        {
            var teste = new Contract<int>().IsCpf(cpf.ToString(), "CPF", "CPF inválido");
            return teste.IsValid;
        }
    }
}

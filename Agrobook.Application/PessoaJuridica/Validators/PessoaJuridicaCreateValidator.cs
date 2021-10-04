namespace Agrobook.Application.PessoaJuridica.Validators
{
    using Agrobook.Application.PessoaJuridica.Commands;
    using FluentValidation;
    using Flunt.Extensions.Br.Validations;
    using Flunt.Validations;

    public class PessoaJuridicaCreateValidator : AbstractValidator<PessoaJuridicaCreateCommand>
    {
        public PessoaJuridicaCreateValidator()
        {
            RuleFor(a => a.PessoaJuridica.Cnpj).Must(IsCnpfVaild).WithMessage("CPF incorreto ou não informado.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email incorreto ou não informado.");
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Incorreto ou não informado.");

        }

        private bool IsCnpfVaild(long cnpj)
        {
            return new Contract<int>().IsCnpj(cnpj.ToString(), "CPF", "CPF inválido").IsValid;
        }
    }
}

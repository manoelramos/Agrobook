namespace Agrobook.Application.PessoaFisica.Validators
{
    using Agrobook.Application.PessoaJuridica.Commands;
    using FluentValidation;
    using Flunt.Extensions.Br.Validations;
    using Flunt.Validations;

    public class PessoaJuridicaUpdateValidator : AbstractValidator<PessoaJuridicaUpdateCommand>
    {
        public PessoaJuridicaUpdateValidator()
        {
            RuleFor(a => a.PessoaJuridica.Cnpj).Must(IsCnpjVaild).WithMessage("CPF incorreto ou não informado.");
            RuleFor(a => a.Email).EmailAddress().WithMessage("Email incorreto ou não informado.");
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Incorreto ou não informado.");
            
        }

        private bool IsCnpjVaild(long cnpj)
        {
            return new Contract<int>().IsCpf(cnpj.ToString(), "CPF", "CPF inválido").IsValid;
        }
    }
}

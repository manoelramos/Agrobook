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
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Informe o nome da pessoa ou instituição.");
            RuleFor(a => a.Emai).EmailAddress().WithMessage("Informe incorreto ou não informado.");
            RuleFor(a => a.CPF).Must(IsCpfVaild);
        }

        private bool IsCpfVaild(int cpf) {
            var teste = new Contract<int>().IsCpf(cpf.ToString(),"CPF", "CPF inválido");
            return teste.IsValid;            
        }
    }
}

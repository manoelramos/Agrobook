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
            RuleFor(a => a.CPF).Must(IsCpfVaild).WithMessage("CPF incorreto ou não informado.");
            RuleFor(a => a.Emai).EmailAddress().WithMessage("Email incorreto ou não informado.");
            RuleFor(a => a.Nome).NotEmpty().NotNull().WithMessage("Informe o nome da pessoa ou instituição.");
            RuleFor(a => a.Ctps).Must(x => x.ToString().Length == 7).WithMessage("CTPS incorreto ou não informado.");
            RuleFor(a => a.Pispasep).Must(x => x.ToString().Length == 11).WithMessage("pis/pasep incorreto ou não informado.");
            RuleFor(a => a.SerieCTPS).Must(x => x.ToString().Length == 4).WithMessage("Saerie CTPS incorreto ou não informado.");

            //Nome associado, email, endereço, CPF, RG, Data nascimento, Grau Instrução, função, estado civil, ctps(7 DIGIOS INT), Serie CTPS(4 DIGITOS INT), pispasep(11 DIGITOS INT)
        }

        private bool IsCpfVaild(int cpf)
        {
            var teste = new Contract<int>().IsCpf(cpf.ToString(), "CPF", "CPF inválido");
            return teste.IsValid;
        }
    }
}

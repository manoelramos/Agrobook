namespace Agrobook.Application.Organizacao.Commands
{
    using Agrobook.Domain.Models;
    using FluentValidation;

    public class OrganizacaoValidator : AbstractValidator<OrganizacaoCreateCommand>
    {
        public OrganizacaoValidator()
        {
            RuleFor(a => a.NomeCompleto).NotEmpty().WithMessage("O Nome é obrigatório.");
            RuleFor(a => a.NomeCompleto).Length(3, 200).NotEmpty().WithMessage("O Nome não pode excerder 200 caracteres.");
            RuleFor(a => a.NomeFantasia).Length(3, 200).NotEmpty().WithMessage("O Nome fantasia não pode excerder 200 caracteres.");
            RuleFor(a => a.Endereco.CEP).NotEqual(0).WithMessage("O CEP não informado.");

            //RuleFor(a => a.IsValidImage()).GreaterThan(false).WithMessage("A imagem enviada não corresponde ao formato esperado.");
        }
    }
}

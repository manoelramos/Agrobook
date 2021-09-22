namespace Agrobook.Application.Organizacao.Commands
{
    using FluentValidation;

    public class OrganizacaoCreateValidator : AbstractValidator<OrganizacaoCreateCommand>
    {
        public OrganizacaoCreateValidator()
        {
            RuleFor(a => a.RazaoSocial).NotEmpty().WithMessage("O Nome é obrigatório.");
            RuleFor(a => a.RazaoSocial).Length(3, 200).NotEmpty().WithMessage("O Nome não pode excerder 200 caracteres.");
            RuleFor(a => a.NomeFantasia).Length(3, 200).NotEmpty().WithMessage("O Nome fantasia não pode excerder 200 caracteres.");
            RuleFor(a => a.Endereco.CEP).NotEqual(0).WithMessage("O CEP não informado.");

            //RuleFor(a => a.IsValidImage()).GreaterThan(false).WithMessage("A imagem enviada não corresponde ao formato esperado.");
        }
    }
}

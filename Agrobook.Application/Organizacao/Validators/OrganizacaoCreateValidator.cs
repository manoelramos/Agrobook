namespace Agrobook.Application.Organizacao.Commands.Validators
{
    using FluentValidation;

    public class OrganizacaoCreateValidator : AbstractValidator<OrganizacaoCreateCommand>
    {
        public OrganizacaoCreateValidator()
        {
            RuleFor(a => a.RazaoSocial).NotEmpty().NotNull().WithMessage("Informe uma razão social válida.");
            RuleFor(a => a.NomeFantasia).NotEmpty().NotNull().WithMessage("Informe um nome fantasia válido.");
            RuleFor(a => a.Endereco.Logradouro).NotEmpty().NotNull().WithMessage("Informe um logradouro válida.");
            RuleFor(a => a.Endereco.Cidade).NotEmpty().NotNull().WithMessage("Informe uma cidade válida.");
            RuleFor(a => a.Endereco.Uf).NotEmpty().NotNull().WithMessage("Informe um estado válida.");
            RuleFor(a => a.Endereco.Latitude).NotNull().WithMessage("Informe a latitude válida.");
            RuleFor(a => a.Endereco.Longitude).NotNull().WithMessage("Informe a longitude válida.");
            RuleFor(a => a.Endereco.CEP).GreaterThanOrEqualTo(11111111).WithMessage("Informe um CEP válido.");

            //RuleFor(a => a.IsValidImage()).GreaterThan(false).WithMessage("A imagem enviada não corresponde ao formato esperado.");
        }
    }
}

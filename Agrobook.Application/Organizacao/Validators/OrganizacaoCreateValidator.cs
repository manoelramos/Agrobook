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
            RuleFor(a => a.Endereco.CidadeId).GreaterThan(0).WithMessage("Informe uma cidade válida.");
            RuleFor(a => a.Endereco.EstadoId).GreaterThan(0).WithMessage("Informe um estado válido.");
            RuleFor(a => a.Endereco.PaisId).GreaterThan(0).WithMessage("Informe um país válido.");
            RuleFor(a => a.Endereco.Latitude).NotNull().WithMessage("Informe a latitude válida.");
            RuleFor(a => a.Endereco.Longitude).NotNull().WithMessage("Informe a longitude válida.");
            RuleFor(a => a.Endereco.CEP).GreaterThanOrEqualTo(11111111).WithMessage("Informe um CEP válido.");

            //RuleFor(a => a.IsValidImage()).GreaterThan(false).WithMessage("A imagem enviada não corresponde ao formato esperado.");
        }
    }
}

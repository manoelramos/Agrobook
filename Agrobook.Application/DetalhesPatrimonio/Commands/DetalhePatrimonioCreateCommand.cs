namespace Agrobook.Application.DetalhesPatrimonio.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class DetalhePatrimonioCreateCommand : Command
    {
        public int PatrimonioId {  get; set; }
        public string Observacao {  get; set; }
    }
}

namespace Agrobook.Application.UnidadesMedidas.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class UnidadeMedidaDeleteCommand : Command
    {
        public UnidadeMedidaDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }

    }
}

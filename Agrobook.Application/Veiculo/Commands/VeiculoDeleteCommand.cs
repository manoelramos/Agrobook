namespace Agrobook.Application.Veiculo.Commands
{
    using Agrobook.Domain.Core.Messaging;

    public class VeiculoDeleteCommand : Command
    {
        public VeiculoDeleteCommand(int patrimonioId)
        {
            PatrimonioId = patrimonioId;
        }

        public int PatrimonioId { get; set; }
    }
}

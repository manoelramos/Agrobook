namespace Agrobook.Application.Veiculo.Queries
{
    using Agrobook.Application.Veiculo.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class VeiculoByIdQuery : Query<VeiculoResponse>
    {
        public VeiculoByIdQuery(int patrimonioId)
        {
            PatrimonioId = patrimonioId;
        }

        public int PatrimonioId { get; set; }
    }
}

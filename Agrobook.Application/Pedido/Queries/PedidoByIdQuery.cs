namespace Agrobook.Application.Pedido.Queries
{
    using Agrobook.Application.Pedido.Responses;
    using Agrobook.Domain.Core.Messaging;

    public  class PedidoByIdQuery : Query<PedidoResponse>
    {
        public PedidoByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

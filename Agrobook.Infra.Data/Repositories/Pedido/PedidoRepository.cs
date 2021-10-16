namespace Agrobook.Infra.Data.Repositories.Pedido
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Pedido;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class PedidoRepository : Repository<Pedidos>, IPedidoRepository
    {
        public PedidoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

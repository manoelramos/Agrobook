namespace Agrobook.Application.Pedido.Commands
{
    public class PedidoDeleteCommand
    {
        public PedidoDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}

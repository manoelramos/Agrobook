namespace Agrobook.Application.Pedido.Commands
{
    using Agrobook.Application.Parcela.Commands;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class PedidoCreateCommand : Command
    {
        public int NumeroPedidoFornecedor { get; set; }
        public decimal Quantidade { get; set; }
        public bool PossuiRoyalty { get; set; }
        public int UnidadeMedidaId { get; set; }        
        public int FazendaId { get; set; }
        public int FornecedorId { get; set; }
        public int InsumoId { get; set; }
        public List<ParcelaCreateCommand> Parcelas { get; set; }
    }
}

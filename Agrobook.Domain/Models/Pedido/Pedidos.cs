namespace Agrobook.Domain.Models.Pedido
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System.Collections.Generic;

    public class Pedidos : Entity<Pedidos>
    {        
        public int NumeroPedidoFornecedor { get; set; }
        public decimal Quantidade { get; set; }

        public int UnidadeMedidaId { get; set; }
        public UnidadesMedidas UnidadeMedida { get; set; }

        public int FazendaId { get; set; }
        public Fazendas Fazenda { get; set; }

        public int FornecedorId { get; set; }
        public Juridicas Fornecedor { get; set; }

        public int InsumoId { get; set; }
        public Insumos Insumo { get; set; }
                
        public ICollection<Parcelas> Parcelas { get; set; }
    }
}

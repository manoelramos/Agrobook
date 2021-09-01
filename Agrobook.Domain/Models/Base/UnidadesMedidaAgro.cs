namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;

    public class UnidadesMedidaAgro : Entity<UnidadesMedidaAgro>
    {
        public string Descricao { get; set; }
        public decimal Quantidade { get; set; }

        public int UnidadesMedidaId { get; set; }
        public UnidadesMedida UnidadesMedida { get; set; }
    }
}

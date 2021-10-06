namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class UnidadesMedidas : Entity<UnidadesMedidas>
    {
        public string Descricao { get; set; }
        public string Simbolo { get; set; }
        public int? UnidadeBaseId { get; set; }
        public decimal? ValorUnidade { get; set; }
        public virtual UnidadesMedidas UnidadeMedidaCustom { get; set; }
        public virtual HashSet<UnidadesMedidas> UnidadesMedidasCustom { get; set; }
    }
}

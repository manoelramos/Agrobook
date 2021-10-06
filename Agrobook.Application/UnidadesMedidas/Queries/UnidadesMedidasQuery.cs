namespace Agrobook.Application.UnidadesMedidas.Queries
{
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class UnidadesMedidasQuery : Query<List<UnidadeMedidaResponse>>
    {
        public enum TipoFilter
        {
            Base,
            Custom,
            All
        }

        public UnidadesMedidasQuery(TipoFilter filter)
        {
            Filter = filter;
        }

        public TipoFilter Filter { get; set; }
    }    
}

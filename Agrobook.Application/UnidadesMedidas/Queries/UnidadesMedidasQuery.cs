namespace Agrobook.Application.UnidadesMedidas.Queries
{
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class UnidadesMedidasQuery : Query<List<UnidadeMedidaResponse>>
    {
        public UnidadesMedidasQuery(bool active)
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

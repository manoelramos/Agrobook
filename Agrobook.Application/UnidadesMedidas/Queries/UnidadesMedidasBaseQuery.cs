namespace Agrobook.Application.UnidadesMedidas.Queries
{
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class UnidadesMedidasBaseQuery : Query<List<UnidadeMedidaResponse>>
    {
        public UnidadesMedidasBaseQuery(bool active)
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

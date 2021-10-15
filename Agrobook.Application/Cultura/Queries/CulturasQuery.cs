namespace Agrobook.Application.Cultura.Queries
{
    using Agrobook.Application.Cultura.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class CulturasQuery : Query<List<CulturaResponse>>
    {
        public CulturasQuery(bool ativo = true)
        {
            Ativo = ativo;
        }

        public bool Ativo { get; set; }

    }
}

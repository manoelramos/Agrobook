namespace Agrobook.Application.Cultura.Queries
{
    using Agrobook.Application.Cultura.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class CulturasQuery : Query<CulturaResponse>
    {
        public CulturasQuery(bool ativo = true)
        {
            Ativo = ativo;
        }

        public bool Ativo { get; set; }

    }
}

using Agrobook.Domain.Core.Messaging;

namespace Agrobook.Application.Localidade.Queries
{
    public class PaisesQuery : Query<Response>
    {
        public PaisesQuery(bool ativo)
        {
            Ativo = ativo;
        }

        public bool Ativo {  get; set; }
    }
}

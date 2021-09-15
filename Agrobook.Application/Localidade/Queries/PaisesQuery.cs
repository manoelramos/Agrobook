using Agrobook.Application.Localidade.Responses;
using Agrobook.Domain.Core.Messaging;
using System.Collections.Generic;

namespace Agrobook.Application.Localidade.Queries
{
    public class PaisesQuery : Query<List<PaisResponse>>
    {
        public PaisesQuery(bool ativo)
        {
            Ativo = ativo;
        }

        public bool Ativo {  get; set; }
    }
}

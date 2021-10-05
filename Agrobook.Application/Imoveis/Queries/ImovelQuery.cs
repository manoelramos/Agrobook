namespace Agrobook.Application.Imoveis.Queries
{
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class ImovelQuery : Query<List<ImovelResponse>>
    {
        public ImovelQuery(bool ativo)
        {
            Ativo = ativo;
        }

        public bool Ativo {  get; set; }
    }
}

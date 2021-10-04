namespace Agrobook.Application.Fazenda.Queries
{
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class FazendaQuery : Query<List<FazendaResponse>>
    {
        public FazendaQuery(bool ativo)
        {
            Ativo = ativo;
        }
        public bool Ativo {  get; set; }
    }
}

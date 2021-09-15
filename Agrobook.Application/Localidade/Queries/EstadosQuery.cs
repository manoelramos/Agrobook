namespace Agrobook.Application.Localidade.Queries
{
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class EstadosQuery : Query<List<EstadoResponse>>
    {
        public EstadosQuery(int paisId)
        {
            PaisId = paisId;
        }

        public int PaisId { get; set; }
    }
}

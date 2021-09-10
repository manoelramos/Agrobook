namespace Agrobook.Application.Localidade.Queries
{
    using Agrobook.Domain.Core.Messaging;

    public class EstadosQuery : Query<Response>
    {
        public EstadosQuery(int paisId)
        {
            PaisId = paisId;
        }

        public int PaisId { get; set; }
    }
}

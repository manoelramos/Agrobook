namespace Agrobook.Application.Fazenda.Queries
{
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class FazendaByIdQuery : Query<FazendaResponse>
    {
        public FazendaByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}

namespace Agrobook.Application.Imoveis.Queries
{
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class ImovelByIdQuery :  Query<ImovelResponse>
    {
        public ImovelByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}

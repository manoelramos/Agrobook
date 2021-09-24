namespace Agrobook.Application.Organizacao.Queries
{
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Domain.Core.Messaging;

    public class OrganizacaoByIdQuery : Query<OrganizacaoResponse>
    {
        public OrganizacaoByIdQuery(int id)
        {
            Id = id;
        }

        public int Id {  get; set; }
    }
}

namespace Agrobook.Application.Organizacao.Queries
{
    using Agrobook.Domain.Core.Messaging;

    public class OrganizacaoQuery : Query<Response>
    {
        public OrganizacaoQuery(bool active)
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

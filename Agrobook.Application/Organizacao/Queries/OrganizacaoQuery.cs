namespace Agrobook.Application.Organizacao.Queries
{
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class OrganizacaoQuery : Query<List<OrganizacaoResponse>>
    {
        public OrganizacaoQuery(bool active)
        {
            Active = active;
        }

        public bool Active { get; set; }
    }
}

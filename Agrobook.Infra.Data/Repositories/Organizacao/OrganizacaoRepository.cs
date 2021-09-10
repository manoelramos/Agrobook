namespace Agrobook.Infra.Data.Repositories.Organizacao
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class OrganizacaoRepository : Repository<Organizacoes>, IOrganizacaoRepository
    {

        public OrganizacaoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}


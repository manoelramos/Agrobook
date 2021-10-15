namespace Agrobook.Infra.Data.Repositories.Cultura
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Producao;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class CulturaRepository : Repository<Culturas>, ICulturaRepository
    {
        public CulturaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

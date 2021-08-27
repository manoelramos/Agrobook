namespace Agrobook.Infra.Data.Repositories.Fazenda
{
    using Agrobook.Infra.Data.Repositories.Base;
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Domain.Interfaces.Data;

    public class FazendaRepository : Repository<Fazenda>, IFazendaRepository
    {
        public FazendaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

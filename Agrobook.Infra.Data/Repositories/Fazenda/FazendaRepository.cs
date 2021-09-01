namespace Agrobook.Infra.Data.Repositories.Fazenda
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class FazendaRepository : Repository<Fazendas>, IFazendaRepository
    {
        public FazendaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

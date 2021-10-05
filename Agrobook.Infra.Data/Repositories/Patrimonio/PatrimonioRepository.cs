namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class PatrimonioRepository : Repository<Patrimonios>, IPatrimonioRepository
    {
        public PatrimonioRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

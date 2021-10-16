namespace Agrobook.Infra.Data.Repositories.Financiamentos
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Repositories.Base;
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.Context;

    public class FinanciamentoRepository : Repository<Financiamentos>, IFinanciamentoRepository
    {
        public FinanciamentoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

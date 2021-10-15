namespace Agrobook.Infra.Data.Repositories.Despesas
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Repositories.Base;
    using Agrobook.Domain.Models.Caixa;
    using Agrobook.Infra.Data.Context;

    public class DespesaRepository : Repository<Despesas>, IDespesaRepository
    {
        public DespesaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

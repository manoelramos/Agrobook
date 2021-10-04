namespace Agrobook.Infra.Data.Repositories.UnidadesMedidas
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;
    using Domain.Models.Base;

    public class UnidadeMedidaBaseRepository : Repository<UnidadesMedidas>, IUnidadeMedidaBaseRepository
    {
        public UnidadeMedidaBaseRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

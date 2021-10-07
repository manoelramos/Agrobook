namespace Agrobook.Infra.Data.Repositories.Patrimonio
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class DetalhePatrimonioRepository : Repository<DetalhesPatrimonio>, IDetalhePatrimonioRepository
    {
        public DetalhePatrimonioRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

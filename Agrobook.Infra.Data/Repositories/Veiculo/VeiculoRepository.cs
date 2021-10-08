namespace Agrobook.Infra.Data.Repositories.Veiculo
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class VeiculoRepository : Repository<Veiculos>, IVeiculoRepository
    {
        public VeiculoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class PaisRepository : Repository<Paises>, IPaisesRepository
    {
        public PaisRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

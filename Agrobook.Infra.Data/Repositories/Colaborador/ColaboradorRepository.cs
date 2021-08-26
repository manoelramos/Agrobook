namespace Agrobook.Infra.Data.Repositories.Colaborador
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        public ColaboradorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

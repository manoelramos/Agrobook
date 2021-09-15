namespace Agrobook.Infra.Data.Repositories.Enderecos
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class EnderecosRepository : Repository<Enderecos>, IEnderecosRepository
    {
        public EnderecosRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

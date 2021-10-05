namespace Agrobook.Infra.Data.Repositories.Imoveis
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Repositories.Base;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Infra.Data.Context;

    public class ImovelRepository : Repository<Imoveis>, IImovelRepository
    {
        public ImovelRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

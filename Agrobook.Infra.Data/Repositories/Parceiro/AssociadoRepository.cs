namespace Agrobook.Infra.Data.Repositories.Colaborador
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class AssociadoRepository : Repository<Associados>, IColaboradorRepository
    {
        public AssociadoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

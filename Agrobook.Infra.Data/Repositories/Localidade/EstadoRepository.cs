namespace Agrobook.Infra.Data.Repositories.Localidade
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class EstadoRepository : Repository<Estados>, IEstadosRepository
    {
        public EstadoRepository(ApplicationContext context) : base(context)
        {
        }

        //public override IQueryable<Estados> Include()
        //{
        //    return Include(x => x.Cidades);
        //}
    }
}

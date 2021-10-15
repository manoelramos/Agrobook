namespace Agrobook.Infra.Data.Repositories.CategoriaDespesa
{
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Caixa;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Base;

    public class CategoriaDespesaRepository : Repository<CategoriasDespesas>, ICategoriaDespesaRepository
    {
        public CategoriaDespesaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}

namespace Agrobook.Application.Despesa.Queries
{
    using Agrobook.Application.Despesa.Response;
    using Agrobook.Domain.Core.Messaging;

    public class DespesasByCategoryQuery : Query<DespesaResponse>
    {
        public int categoriaId;

        public DespesasByCategoryQuery(int categoriaId)
        {
            this.categoriaId = categoriaId;
        }
    }
}

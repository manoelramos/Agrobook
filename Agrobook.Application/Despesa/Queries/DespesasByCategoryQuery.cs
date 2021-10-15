namespace Agrobook.Application.Despesa.Queries
{
    using Agrobook.Application.Despesa.Response;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class DespesasByCategoryQuery : Query<List<DespesaResponse>>
    {
        public int categoriaId;

        public DespesasByCategoryQuery(int categoriaId)
        {
            this.categoriaId = categoriaId;
        }
    }
}

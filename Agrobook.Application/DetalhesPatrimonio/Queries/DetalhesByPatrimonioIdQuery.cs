namespace Agrobook.Application.DetalhesPatrimonio.Queries
{
    using Agrobook.Application.DetalhesPatrimonio.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class DetalhesByPatrimonioIdQuery: Query<List<DetalhesPatrimonioResponse>>
    {
        public DetalhesByPatrimonioIdQuery(int id)
        {
            PatrimonioId = id;
        }
        public int PatrimonioId {  get; set; }
    }
}

namespace Agrobook.Application.CategoriaDespesa.Queries
{
    using Agrobook.Application.CategoriaDespesa.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class CategoriaDespesaQuery : Query<List<CategoriaDespesaResponse>>
    {
        public CategoriaDespesaQuery(bool ativo = true)
        {
            Ativo = ativo;
        }

        public bool Ativo { get; set; }

    }
}

namespace Agrobook.Application.Veiculos.Queries
{
    using Agrobook.Application.Veiculos.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class VeiculosQuery : Query<List<VeiculoResponse>>
    {
        public VeiculosQuery(bool ativo)
        {
            Ativo = ativo;
        }

        public bool Ativo {  get; set; }
    }
}

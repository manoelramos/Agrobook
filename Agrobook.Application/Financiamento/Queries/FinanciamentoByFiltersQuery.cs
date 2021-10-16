namespace Agrobook.Application.Financiamento.Queries
{
    using Agrobook.Application.Financiamento.Responses;
    using Agrobook.Domain.Core.Messaging;
    using System;
    using System.Collections.Generic;

    public class FinanciamentoByFiltersQuery : Query<List<FinanciamentoResponse>>
    {
        public FinanciamentoByFiltersQuery() { }
        public FinanciamentoByFiltersQuery(int credorId, DateTime dataInicial, DateTime dataFinal)
        {
            CredorId = credorId;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
        }

        public int CredorId { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}

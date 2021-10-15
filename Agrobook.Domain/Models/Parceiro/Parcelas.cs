namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Caixa;
    using System;
    using System.Collections.Generic;

    public class Parcelas : Entity<Parcelas>
    {
        public decimal ValorParcela { get; set; }
        public decimal? ValorPago { get; set; }
        public string Observacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
        
        public int DespesaId { get; set; }
        public Despesas Despesa { get; set; }

        public ICollection<ComprovantesPagamentos> ComprovantesPagamentos { get; set; }

        public int IdMoedaParcela { get; set; }
        public Moeda Moeda { get; set; }
    }
}

namespace Agrobook.Application.Fazenda.Responses
{
    using System;

    public class ParcelaResponse
    {
        public decimal ValorParcela { get; set; }
        public decimal? ValorPago { get; set; }
        public string Observacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime? DataPagamento { get; set; }
    }
}

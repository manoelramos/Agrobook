namespace Agrobook.Application.Parcela.Commands
{
    using System;

    public class ParcelaCreateCommand
    {
        public DateTime DataVencimento { get; set; }
        public decimal ValorParcela { get; set; }
        public int IdMoedaParcela { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? ValorPago { get; set; }
    }
}

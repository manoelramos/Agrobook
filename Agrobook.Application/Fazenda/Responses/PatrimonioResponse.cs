namespace Agrobook.Application.Fazenda.Responses
{
    using System;

    public class PatrimonioResponse
    {
        public long? NumeroNotaFical { get; set; }
        public DateTime? DataCompra { get; set; }
        public DateTime? DataVenda { get; set; }
        public int? ExpectativaUso { get; set; }
        public decimal? ValorCompra { get; set; }
        public decimal? ValorVenda { get; set; }
    }
}

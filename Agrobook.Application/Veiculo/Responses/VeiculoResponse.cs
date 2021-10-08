namespace Agrobook.Application.Veiculo.Responses
{
    using System;

    public class VeiculoResponse
    {
        public int PatrimonioId { get; set; }
        public string CodigoImovel { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public long? Renavam { get; set; }
        public long? Chassi { get; set; }
        public string Cor { get; set; }
        public int? AnoFabricao { get; set; }
        public int? AnoModelo { get; set; }
        public DateTime DataAquisicao { get; set; }
        public string Combustivel { get; set; }
        public string EstadoConservacao { get; set; }
        public long? KilometragemCompra { get; set; }
        public long? KilometragemVenda { get; set; }
        public decimal? TaxaDepreciacaoAnual { get; set; }
    }
}

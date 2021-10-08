namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public class Veiculos : Entity<Veiculos>
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public long? Renavam { get; set; }
        public long? Chassi { get; set; }
        public string Cor { get; set; }        
        public string Combustivel { get; set; }
        public string EstadoConservacao { get; set; }
        public int? AnoFabricao { get; set; }
        public int? AnoModelo { get; set; }
        public DateTime DataAquisicao { get; set; }
        public long? KilometragemCompra { get; set; }
        public long? KilometragemVenda { get; set; }
        public decimal? TaxaDepreciacaoAnual { get; set; }
        public int PatrimonioId { get; set; }
        public Patrimonios Patrimonio { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Manutencoes> Manutencoes { get; set; }
        public ICollection<AnexosVeiculo> Anexos { get; set; }
    }
}

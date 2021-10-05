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
        public string Renavam { get; set; }
        public string Chassi { get; set; }
        public string Cor { get; set; }
        public string Tipo { get; set; }
        public string Combustivel { get; set; }
        public string EstadoConservacao { get; set; }
        public DateTime? AnoFabricao { get; set; }
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

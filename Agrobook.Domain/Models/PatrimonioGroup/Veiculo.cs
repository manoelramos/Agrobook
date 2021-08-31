namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using System;
    using System.Collections.Generic;

    public class Veiculo : Entity<Veiculo>
    {
        public string Modelo { get; set; }
        public string Placa { get; set; }
        public string Combustivel { get; set; }
        public DateTime AnoFabricao { get; set; }
        public long Kilometragem { get; set; }
        public Patrimonio Patrimonio { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}

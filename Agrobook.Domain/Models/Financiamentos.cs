namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System;
    using System.Collections.Generic;

    public class Financiamentos : Entity<Financiamentos>
    {
        public  decimal ValorFinanciado { get; set; }
        public string Descricao { get; set; }
        public DateTime AdquiridoEm { get; set; }
        
        public int? CredorId { get; set; }
        public Associados Credor { get; set; }

        public int? PatrimonioId { get; set; }
        public Patrimonios Patrimonio { get; set; }

        public int IdMoedaParcela { get; set; }
        public Moedas Moeda { get; set; }

        public ICollection<Parcelas> Parcelas { get; set; }
    }
}

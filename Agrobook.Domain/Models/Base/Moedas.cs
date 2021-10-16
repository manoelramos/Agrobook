namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Parceiro;
    using System.Collections.Generic;

    public class Moedas : Entity<Moedas>
    {
        public string Nome { get; set; }

        public ICollection<Parcelas> Parcelas {  get; set; }
        public ICollection<Financiamentos> Financiamentos { get; set; }
        
    }
}

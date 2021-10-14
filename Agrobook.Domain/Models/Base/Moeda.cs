namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using Agrobook.Domain.Models.Parceiro;
    using System.Collections.Generic;

    public class Moeda : Entity<Moeda>
    {
        public string Descricao { get; set; }

        public ICollection<Parcelas> Parcelas {  get; set; }
    }
}

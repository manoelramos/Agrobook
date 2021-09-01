namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using System.Collections.Generic;

    public class Moeda : Entity<Moeda>
    {
        public ICollection<Despesas> Despesas {  get; set; }
    }
}

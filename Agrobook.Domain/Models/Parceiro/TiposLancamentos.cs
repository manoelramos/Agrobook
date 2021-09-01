namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class TiposLancamentos : Entity<TiposLancamentos>
    {
        public string Descricao {  get; set; }
        public ICollection<LancamentosContabeis> LancamentosContabeis { get; set; }
    }
}
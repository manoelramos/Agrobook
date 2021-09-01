namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Parceiro;
    using System.Collections.Generic;

    public class Culturas : Entity<Culturas>
    {
        public string Descricao {  get; set; }
        public ICollection<LancamentosContabeis> LancamentosContabeis {  get; set; }
    }
}

namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class UnidadesMedida : Entity<UnidadesMedida>
    {
        public string Descricao { get; set; }
        public ICollection<UnidadesMedidaAgro> UnidadesMedidaAgro {  get; set; }
    }
}

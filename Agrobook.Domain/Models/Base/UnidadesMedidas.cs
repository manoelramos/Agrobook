namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class UnidadesMedidas : Entity<UnidadesMedidas>
    {
        public string Descricao { get; set; }
        public string Simbolo { get; set; }
        public ICollection<UnidadesMedidasAgro> UnidadesMedidaAgro {  get; set; }
    }
}

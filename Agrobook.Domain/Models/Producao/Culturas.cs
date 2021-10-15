namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class Culturas : Entity<Culturas>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<Safras> Safras { get; set; }
    }
}

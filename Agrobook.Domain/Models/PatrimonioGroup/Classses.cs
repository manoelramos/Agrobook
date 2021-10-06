namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public  class Classses : Entity<Classses>
    {
        public string Descricao { get; set; }

        public ICollection<Imoveis> Imoveis {  get; set; }
    }
}

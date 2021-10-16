namespace Agrobook.Domain.Models.Pedido
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class Insumos : Entity<Insumos>
    {
        public string Nome { get; set; }
        public string Descricao {  get; set;}
        public string Fabricante { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; }
    }
}

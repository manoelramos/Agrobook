using Agrobook.Domain.Core.Models;
using System.Collections.Generic;

namespace Agrobook.Domain.Models.Caixa
{
    public class CategoriasDespesas : Entity<CategoriasDespesas>
    {
        public string Descricao { get; set; }
        public ICollection<Despesas> Despesas {  get; set; }
    }
}
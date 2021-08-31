namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System.Collections.Generic;

    public class Talhao : Entity<Talhao>
    {
        public decimal Hectare { get; set; }
        public int FazendaId {  get; set; } 
        public Fazenda Fazenda { get; set; }
        public ICollection<TalhaoSafra> TalhaoSafras {  get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}

namespace Agrobook.Domain.Models.Producao
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using System.Collections.Generic;

    public class Talhoes : Entity<Talhoes>
    {
        public decimal Area { get; set; }
        public string Observacao {  get; set; }
        public int FazendaId {  get; set; } 
        public Fazendas Fazenda { get; set; }
        public ICollection<TalhoesSafras> TalhaoSafras {  get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}

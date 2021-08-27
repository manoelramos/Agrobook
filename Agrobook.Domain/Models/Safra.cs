namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;

    public class Safra : Entity<Safra>
    {
        public string Descricao { get; set; }
        public decimal Hectare { get; set; }
        public string Cultura { get; set; }
        public string NomeResponsável { get; set; }
        public string TelefoneResponsável { get; set; }

        public virtual Fazenda Fazenda { get; set; }
        public int FazendaId {  get; set; }

    }
}

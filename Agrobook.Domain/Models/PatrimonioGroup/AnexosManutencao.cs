namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;

    public class AnexosManutencao :  Entity<AnexosManutencao>
    {
        public byte[] Anexo { get; set; }
        public string Descricao { get; set; }
        public int ManutencaoId { get; set; }
        public Manutencoes Manutencao { get; set; }
    }
}

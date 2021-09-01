namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;

    public class AnexosVeiculo : Entity<AnexosVeiculo>
    {
        public byte[] Anexo { get; set; }
        public string Descricao { get; set; }
        public int VeiculoId { get; set; }
        public Veiculos Veiculo { get; set; }
    }
}

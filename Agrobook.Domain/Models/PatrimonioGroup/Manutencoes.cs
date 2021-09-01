namespace Agrobook.Domain.Models.PatrimonioGroup
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class Manutencoes : Entity<Manutencoes>
    {
        public string Descricao {  get; set; }
        public decimal Custo {  get; set; }
        public int VeiculoId {  get; set; }
        public Veiculos Veiculo {  get; set; }
        public ICollection<AnexosManutencao> Anexos {  get; set; }
    }
}

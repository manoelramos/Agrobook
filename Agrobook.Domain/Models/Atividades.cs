namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Producao;
    using System;

    public class Atividades : Entity<Atividades>
    {
        public string Descricao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int AssociadoId { get; set; }
        public Associados Associado { get; set; }
        public int VeiculoId { get; set; }
        public Veiculos Veiculo { get; set; }
        public int TalhaoId { get; set; }
        public Talhoes Talhao { get; set; }
        public int SafraId { get; set; }
        public Safras Safra { get; set; }
    }
}

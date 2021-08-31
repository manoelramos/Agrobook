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
        public Associado Associado { get; set; }
        public int VeiculoId { get; set; }
        public Veiculo Veiculo { get; set; }
        public int TalhaoId { get; set; }
        public Talhao Talhao { get; set; }
        public int SafraId { get; set; }
        public Safra Safra { get; set; }
    }
}

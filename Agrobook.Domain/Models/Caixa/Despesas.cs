namespace Agrobook.Domain.Models.Caixa
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Producao;
    using System.Collections.Generic;

    public class Despesas : Entity<Despesas>
    {
        public decimal? Valor { get; set; }
        public string Observacao { get; set; }

        public int? CredorId { get; set; }
        public Associados Credor { get; set; }

        public int CategoriaDespesaId {  get; set; }
        public CategoriasDespesas CategoriaDespesa {  get; set; }
        
        public int? SafraId {  get; set; }
        public Safras Safra { get; set; }

        public int? PatrimonioId {  get; set; }
        public Patrimonios Patrimonio { get; set; }

        public ICollection<Parcelas> Parcelas { get; set; }

        public int? CulturaId { get; set; }
        public Culturas Cultura { get; set; }
    }
}

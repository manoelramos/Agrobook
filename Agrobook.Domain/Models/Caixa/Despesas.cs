namespace Agrobook.Domain.Models.Caixa
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Producao;
    using System.Collections.Generic;

    public class Despesas : Entity<Despesas>
    {
        public string TipoPessoa {  get; set; }
        
        public int CategoriaDespesaId {  get; set; }
        public CategoriasDespesas CategoriaDespesa {  get; set; }

        public decimal Valor {  get; set; }
        public string Observacao {  get; set; }
        
        public int MoedaId {  get; set; }
        public Moeda Moeda {  get; set; }

        public int SafraId {  get; set; }
        public Safras Safra { get; set; }

        public int PatrimonioId {  get; set; }
        public Patrimonios Patrimonio { get; set; }

        public ICollection<Pagamentos> Pagamentos { get; set; }
    }
}

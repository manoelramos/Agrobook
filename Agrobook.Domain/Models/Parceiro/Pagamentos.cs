namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Caixa;
    using System.Collections.Generic;

    public class Pagamentos : Entity<Pagamentos>
    {
        public decimal SalarioBase {  get; set; }
        public decimal FGTS { get; set; }
        public string Observacao {  get; set; }
        public ICollection<LancamentosContabeis> LancamentosContabeis {  get; set; }
        public int AssociadoId {  get; set; }
        public Associados Associados {  get; set; }
        public ICollection<ComprovantesPagamentos> ComprovantesPagamentos { get; set; }
        
        public int DespesaId {  get; set; }
        public Despesas Despesa { get; set; }
    }
}

namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.Producao;

    public class LancamentosContabeis : Entity<LancamentosContabeis>
    {
        public int TipoLancamentoId {  get; set; }
        public TiposLancamentos TipoLancamento { get; set; }

        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        public int PagamentoId { get; set; }
        public Parcelas Pagamento { get; set; }

        public int CulturaId { get; set; }
        public Culturas Cultura { get; set; }


    }
}

namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class Remuneracoes : Entity<Remuneracoes>
    {
        public decimal FGTS { get; set; }
        public string Observacao {  get;}

        public int PagamentoId { get; set; }
        public Parcelas Pagamento { get; set; }
    }
}

namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class ComprovantesPagamentos : Entity<ComprovantesPagamentos>
    {
        public byte[] Anexo { get; set; }
        public string Descricao { get; set; }
        public int PagamentosId { get; set; }
        public Pagamentos Pagamentos { get; set; }
    }
}

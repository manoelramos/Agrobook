namespace Agrobook.Domain.Models.Base
{
    using Agrobook.Domain.Core.Models;

    public class UnidadesMedidasAgro : Entity<UnidadesMedidasAgro>
    {
        public string Descricao { get; set; }
        public string Simbolo { get; set; }
        public decimal Quantidade { get; set; }
        public int UnidadesMedidasId { get; set; }
        public UnidadesMedidas UnidadesMedidas { get; set; }
    }
}

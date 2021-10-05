namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class DadosBancarios : Entity<DadosBancarios>
    {
        public string Banco { get; set; }
        public int? Agencia { get; set; }
        public string Conta { get; set; }
        public string TipoPix {  get; set; }
        public string PIX { get; set; }
        public int AssociadoId {  get; set; }
        public Associados Associado { get; set; }
    }
}

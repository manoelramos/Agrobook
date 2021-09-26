namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class DadosBancarios : Entity<DadosBancarios>
    {
        public string Instituicao { get; set; }
        public int Banco { get; set; }
        public int Agencia { get; set; }
        public int Conta { get; set; }
        public string TipoPix {  get; set; }
        public int PIX { get; set; }
        public int AssociadoId {  get; set; }
        public Associados Associado { get; set; }
    }
}

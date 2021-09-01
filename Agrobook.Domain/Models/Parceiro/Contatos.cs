namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class Contatos : Entity<Contatos>
    {
        public string TipoContato {  get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public int AssociadoId {  get; set; }
        public Associados Associado {  get; set; }
    }
}

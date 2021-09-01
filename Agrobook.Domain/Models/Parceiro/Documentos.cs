namespace Agrobook.Domain.Models.Parceiro
{
    using Agrobook.Domain.Core.Models;

    public class Documentos : Entity<Documentos>
    {
        public byte[] Anexo { get; set; }
        public string Descricao { get; set; }
        public int AssociadosId {  get; set; }
        public Associados Associado {  get; set; }
    }
}

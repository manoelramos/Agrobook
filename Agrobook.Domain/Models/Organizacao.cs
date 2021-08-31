namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Parceiro;
    using System.Collections.Generic;

    public class Organizacao : Entity<Organizacao>
    {
        public string NomeCompleto {  get; set; }
        public string NomeFantasia {  get; set; }
        public byte[] LogoMarca {  get; set; }
        public int EnderecoId {  get; set; }
        public Endereco Endereco {  get; set; }
        public ICollection<Patrimonio> Patrimonios {  get; set; }
        public ICollection<Contratacao> Contratacoes {  get; set;}
    }
}

namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using System.Collections.Generic;

    public class Organizacao : Entity<Organizacao>
    {
        public string NomeCompleto {  get; set; }
        public string NomeFantasia {  get; set; }
        public byte[] LogoMarca {  get; set; }
        public int EnderecoId {  get; set; }
        public Endereco Endereco {  get; set; }
        public ICollection<Patrimonio> Patrimonios {  get; set; }
    }
}

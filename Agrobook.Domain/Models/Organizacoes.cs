namespace Agrobook.Domain.Models
{
    using Agrobook.Domain.Core.Models;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Parceiro;
    using System.Collections.Generic;

    public class Organizacoes : Entity<Organizacoes>
    {
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public byte[] LogoMarca { get; set; }
        public int? EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }
        public ICollection<Patrimonios> Patrimonios { get; set; }
        public ICollection<Contratacoes> Contratacoes { get; set; }
    }
}

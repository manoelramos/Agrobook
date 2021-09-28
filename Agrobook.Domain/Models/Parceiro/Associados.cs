using Agrobook.Domain.Core.Models;
using System.Collections.Generic;

namespace Agrobook.Domain.Models.Parceiro
{
    public class Associados : Entity<Associados>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
                
        public ICollection<Contratacoes> Contratacoes { get; set; }

        public int? EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }

        public PessoasFisicas PessoaFisica { get; set; }
        public PessoasJuridicas PessoaJuridica { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Contatos> Contatos { get; set; }
        public ICollection<DadosBancarios> DadosBancarios { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
        public ICollection<Pagamentos> Pagamentos { get; set; }
    }
}

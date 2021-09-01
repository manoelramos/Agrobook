using Agrobook.Domain.Core.Models;
using System.Collections.Generic;

namespace Agrobook.Domain.Models.Parceiro
{
    public class Associados : Entity<Associados>
    {
        public string Nome { get; set; }
        public string Email { get; set; }        

        public int PessoaFisicaId { get; set; }
        public PessoasFisicas PessoaFisica { get; set; }

        public int PessoaJuridicaId { get; set; }
        public PessoasJuridicas PessoaJuridica {  get; set; }

        public int ContratacaoId { get; set; }
        public Contratacoes Contratacao { get; set; }

        public int EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }

        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Contatos> Contatos { get; set; }
        public ICollection<ContasBancarias> ContasBancarias { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
        public ICollection<Pagamentos> Pagamentos {  get; set; }
    }
}

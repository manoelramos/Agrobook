using Agrobook.Domain.Core.Enum;
using Agrobook.Domain.Core.Models;
using Agrobook.Domain.Models.Caixa;
using System.Collections.Generic;

namespace Agrobook.Domain.Models.Parceiro
{
    public class Associados : Entity<Associados>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public Categorias.TipoRelacao TipoRelacao { get; set; }        

        public int? EnderecoId { get; set; }
        public Enderecos Endereco { get; set; }

        public Fisicas PessoaFisica { get; set; }
        public Juridicas PessoaJuridica { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
        public ICollection<Contatos> Contatos { get; set; }
        public ICollection<DadosBancarios> DadosBancarios { get; set; }
        public ICollection<Documentos> Documentos { get; set; }
        public ICollection<Despesas> Despesas { get; set; }
        public ICollection<Contratacoes> Contratacoes { get; set; }
    }
}

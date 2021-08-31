using Agrobook.Domain.Core.Models;
using System.Collections.Generic;

namespace Agrobook.Domain.Models.Parceiro
{
    public class Associado : Entity<Associado>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public char TipoPessoa { get; set; }
        public int CPF { get; set; }
        public int CNPJ { get; set; }
        public int ContratacaoId { get; set; }
        public Contratacao Contratacao { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Atividades> Atividades { get; set; }
    }
}

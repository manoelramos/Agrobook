namespace Agrobook.Application.PessoaJuridica.Commands
{
    using Agrobook.Application.Common;
    using Agrobook.Domain.Core.Messaging;
    using System.Collections.Generic;

    public class PessoaJuridicaUpdateCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public PessoaJuridicaCommand PessoaJuridica { get; set; }
        public EnderecoCommand Endereco { get; set; }
        public List<ContatosCommand> Contatos { get; set; }
        public List<DadosBancariosCommand> DadosBancarios { get; set; }
        public List<DocumentosCommand> Anexos { get; set; }
    }
}

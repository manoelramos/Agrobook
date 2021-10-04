namespace Agrobook.Application.PessoaJuridica.Responses
{
    using Agrobook.Application.Common;
    using Agrobook.Application.PessoaJuridica.Commands;
    using System.Collections.Generic;

    public class PessoaJuridicaResponse
    {
        public int Id {  get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public PessoaJuridicaCommand PessoaJuridica { get; set; }
        public EnderecoCommand Endereco { get; set; }
        public List<ContatosCommand> Contato { get; set; }
        public List<DadosBancariosCommand> DadosBancarios { get; set; }
        public List<DocumentosCommand> Anexos { get; set; }
        public bool Ativo {  get; set; }
    }
}

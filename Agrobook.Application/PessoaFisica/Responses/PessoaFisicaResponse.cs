namespace Agrobook.Application.PessoaFisica.Responses
{
    using Agrobook.Application.Common;
    using Agrobook.Application.PessoaFisica.Commands;
    using System.Collections.Generic;

    public class PessoaFisicaResponse
    {
        public int Id {  get; set; } 
        public string Nome { get; set; }
        public string Email { get; set; }
        public PessoaFisicaCommand PessoaFisica { get; set; }
        public EnderecoCommand Endereco { get; set; }
        public List<ContatosCommand> Contato { get; set; }
        public List<DadosBancariosCommand> DadosBancarios { get; set; }
        public List<DocumentosCommand> Anexos { get; set; }
        public bool Ativo {  get; set; }
    }
}

namespace Agrobook.Application.PessoaFisica.Commands
{
    using Agrobook.Application.Common;
    using System;

    public class PessoaFisicaCreateCommand
    {
        public string Nome { get; set; }
        public string Emai { get; set; }
        public int CPF { get; set; }
        public int? RG { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string GrauInstrucao { get; set; }
        public string Funcao { get; set; }
        public int? Ctps { get; set; }
        public int? SerieCTPS { get; set; }
        public int? Pispasep { get; set; }
        public EnderecoCreateCommand Endereco { get; set; }
        public ContatosCreateCommand Contato { get; set; }
        public DadosBancariosCreateCommand DadosBancarios { get; set; }
        public DocumentosCreateCommand Anexos { get; set; }

        //Nome associado, email, endereço, CPF, RG, Data nascimento, Grau Instrução, função, estado civil, ctps(7 DIGIOS INT), Serie CTPS(4 DIGITOS INT), pispasep(11 DIGITOS INT)
    }
}

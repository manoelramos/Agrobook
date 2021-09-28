namespace Agrobook.Application.PessoaFisica.Commands
{
    using System;

    public class PessoaFisicaCommand
    {
        public long CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public string GrauInstrucao { get; set; }
        public string Funcao { get; set; }
        public string EstadoCivil { get; set; }
        public string CTPS { get; set; }
        public string SerieCtps { get; set; }
        public string PisPasep { get; set; }
    }
}
